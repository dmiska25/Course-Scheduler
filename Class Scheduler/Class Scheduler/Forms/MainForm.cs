using Class_Scheduler.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Class_Scheduler.Comparers;
using Class_Scheduler.Forms.MiscellaneousForms;
using Class_Scheduler.Forms.CourseForms;
using Class_Scheduler.Forms.SemesterForms;
using Class_Scheduler.StaticClasses;
using Class_Scheduler.Forms.AutoGen;
using Class_Scheduler.Tooltips;

namespace Class_Scheduler.Forms
{
    /// <summary>
    /// This is the Main Form for Class Scheduler. It contains the logic for the tool
    /// strip, course list, semester list, and menu strip interactions. 
    /// </summary>
    public partial class MainForm : Form
    {
        // Variables
        private List<Course> courseList;  // List of courses to be scheduled
        private List<Course> previousCompletedCourses;  // List of previously completed courses
        private List<Semester> semesterList;  // List of semesters that can have courses assigned to
        private HashSet<String> coursePrefixes;  // List of Prefixes for all courses in courseList
        private List<String> prioritisedCoursePrefixes;  // List of course Prefixes in prioritized order
        private Dictionary<Semester, List<Course>> preScheduleDict;  // Dictionary containing Semester -> presheduled courses
        // Tool Tips
        private ToolTip toolTips;

        public MainForm()
        {
            InitializeComponent();
            courseList = new List<Course>();
            previousCompletedCourses = new List<Course>();
            semesterList = new List<Semester>();
            coursePrefixes = new HashSet<string>();
            prioritisedCoursePrefixes = new List<string>();
            preScheduleDict = new Dictionary<Semester, List<Course>>();
            

        }

        // Main load
        private void Main_Load(object sender, EventArgs e)
        {
            //diable menu strip
            EditElementMenuStrip.Enabled = false;

            //tool tip laod
            toolTips = new ToolTip();
            
            semesterToolStripMenuItem.ToolTipText = MainTooltips.addSemesterTT;
            classToolStripMenuItem.ToolTipText = MainTooltips.addCourseTT;
            classListToTxtFileToolStripMenuItem.ToolTipText = MainTooltips.saveCourseListTT;
            semesterListToTxtFileToolStripMenuItem.ToolTipText = MainTooltips.saveSemesterListTT;
            classListFromTxtFileToolStripMenuItem.ToolTipText = MainTooltips.loadCourseListTT;
            semesterListFromTxtFileToolStripMenuItem.ToolTipText = MainTooltips.loadSemesterListTT;
            semestersToolStripMenuItem.ToolTipText = MainTooltips.generatSemestersTT;
            electivesToolStripMenuItem.ToolTipText = MainTooltips.generateElectiveTT;

            toolTips.SetToolTip(delayGradCoursesLabel, MainTooltips.delayGradTT);
            toolTips.SetToolTip(prioritizePrefixesLabel, MainTooltips.prioritizePrefixes);
            toolTips.SetToolTip(prioritizeLowerLevelCourcesLabel, MainTooltips.prioritizeLowerLevelTT);
            toolTips.SetToolTip(PrioritizeLabpairLabel, MainTooltips.prioritizeLabPairTT);
            toolTips.SetToolTip(overloadableLabel, MainTooltips.overloadableTT);
            toolTips.SetToolTip(genSchedules, MainTooltips.generateTT);


        }


        /// <summary>
        /// Main method to begin Scheduling courses. This method will wrap course objects in
        /// Course Container objects used in the scheduling algorithm, then pass the course
        /// objects and semesters list to the scheduling algorithm. Once scheduled, debug info
        /// will be printed and, if selected, the optimization algorithm will be ran. Once
        /// finished, a viewer form will be initiated, constructed, and opened for viewing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void genSchedulesButton(object sender, EventArgs e)
        {
            // generate course containers for courses
            List<CourseContainer> processed = ScheduleGenerator.genCourseContainers(courseList).ToList();

            Console.WriteLine("\nBegining Scheduleing test...");



            //generate schedule and add course containers to semesters.
            //Add options to customCoursePriority comparer
            bool result = ScheduleGenerator.scheduleSemesters(processed, semesterList, preScheduleDict,
                new CustumCoursePriority(
                    delayGradCoursesCB.Checked,
                    lowerLevelCB.Checked,
                    labPairGroupingCB.Checked,
                    prioritisedCoursePrefixes
                    ), previousCompletedCourses
                );
            


            //debug
            int totalScheduled = 0;
            Console.WriteLine("Semester List:");
            foreach (Semester sem in semesterList)
            {
                String output = (sem.SemesterReference + ':' + sem.TotalCredits+':');
                foreach (CourseContainer course in sem.Courses) { output += course.Course.courseReference + ','; }
                Console.WriteLine(output);

                totalScheduled += sem.TotalCredits;
            }
            Console.WriteLine("Course count: " + courseList.Count);
            Console.WriteLine("Total Credits Scheduled: " + totalScheduled);

            if (!result) { return; }


            //testing schedule optimizer
            if (overloadableCB.Checked)
            {
                ScheduleOptimizer.checkOverflow(semesterList, preScheduleDict, previousCompletedCourses);
            }


            //create new form
            ScheduleResultView schedule = new ScheduleResultView();

            // add previously completed courses to first result, if any
            if(previousCompletedCourses.Count != 0)
            {
                schedule.scheduleViewer.Nodes.Add("Previously Completed Courses");
                foreach (Course course in previousCompletedCourses)
                {
                    schedule.scheduleViewer.Nodes[0].Nodes.Add(course.courseReference);
                }
            }


            foreach(Semester semester in semesterList)
            {
                //check if semester is empty
                if (semester.Courses.Count == 0) continue;

                //add the semester header
                schedule.scheduleViewer.Nodes.Add(semester.SemesterReference);

                //add each course to Subheaders
                foreach(CourseContainer course in semester.Courses)
                {
                    schedule.scheduleViewer.Nodes[schedule.scheduleViewer.Nodes.Count - 1]
                        .Nodes.Add(course.Course.courseReference);
                }

            }



            //display view
            this.SuspendLayout();
            schedule.ShowDialog();

            //clear results when finished viewing
            foreach(Semester semester in semesterList) { semester.removeAllCourses(); }
            processed = null;
        }



        // Menu Strip ---------------------------------------------------------------------

        // # Adding items from menu

        // ## Add course from menu

        /// <summary>
        /// The classToolStripMenuItem method is used to instantiate the CourseAdd
        /// Form and handle some other functionality.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void classToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //suspend current window, load new course add window
            this.SuspendLayout();
            CourseAdd newClass = new CourseAdd(ref courseList);
            newClass.ShowDialog();

            //check if action was canceled ie.is getCourse null?
            if(newClass.NewCourse == null) { return; }

            //Add course from course add form to object
            Course newCourse = newClass.NewCourse;

            //add new course object to course list
            courseList.Add(newCourse);

            //update viewer
            updateCourseViewer();

            //update prefixes
            updatePrefixes();
        }

        // ## add semester from menu

        /// <summary>
        /// The semesterToolStripMenuItem method is used to instantiate the SemesterAdd
        /// Form and handle some other functionality.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void semesterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //suspend current window, load new semester add window
            this.SuspendLayout();
            SemesterAdd newSemester = new SemesterAdd(ref semesterList);
            newSemester.ShowDialog();

            //check if action was canceled ie. is getSemester null?
            if (newSemester.Semester == null) { return; }

            //add the new semester to a reference
            Semester semester = newSemester.Semester;

            //add new semester object to semester list
            semesterList.Add(semester);

            //create dictionary entry for prescheduleing
            preScheduleDict.Add(semester, new List<Course>());

            //update viewer
            updateSemesterViewer();
        }

        // # Loading data from txt file

        // ## loading Classes from txt file

        /// <summary>
        /// The classListFromTxtFileToolStripMenuItem method is used to handle loading
        /// of courses from a file into the courseList.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void classListFromTxtFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //define stream and formatter object
                if (!(openFileWindow.ShowDialog() == System.Windows.Forms.DialogResult.OK)) return;     //return if user canceled
                Stream stream = File.Open(openFileWindow.FileName, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();

                //load courses into form list
                courseList = (List<Course>)bf.Deserialize(stream);
                stream.Close();

                //update viewer
                updateCourseViewer();

                //update prefixes
                updatePrefixes();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error loading file!\n" + ex.Message);
            }
        }

        // ## loading semester data from txt file

        /// <summary>
        /// The semesterListFromTxtFileToolStripMenuItem method is used to handle loading
        /// of semesters from a file into the semesterList.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void semesterListFromTxtFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //define stream and formatter object
                if (!(openFileWindow.ShowDialog() == System.Windows.Forms.DialogResult.OK)) return;     //return if user canceled
                Stream stream = File.Open(openFileWindow.FileName, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();

                //load courses into form list
                semesterList = (List<Semester>)bf.Deserialize(stream);
                stream.Close();

                //create dictionary entrys for prescheduleing 
                foreach(Semester semester in semesterList)
                {
                    preScheduleDict.Add(semester, new List<Course>());
                }

                //update viewer
                updateSemesterViewer();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error loading file!\n"+ex.Message);
            }
        }


        // # saving data to text file

        // ## saving course objects to txt file

        /// <summary>
        /// The classListToTxtFileToolStripMenuItem method is used to handle saving
        /// of courses from the courseList to a file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void classListToTxtFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //define stream and formatter object
            if (!(saveFileWindow.ShowDialog() == System.Windows.Forms.DialogResult.OK)) return;     //return if user canceled
            Stream stream = File.Open(saveFileWindow.FileName, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();

            //write data to file
            bf.Serialize(stream, courseList);
            stream.Close();
        }


        // ## saving semester objects to txt file

        /// <summary>
        /// The semesterListToTxtFileToolStripMenuItem method is used to handle saving
        /// of semesters from the semesterList to a file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void semesterListToTxtFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //define stream and formatter object
            if (!(saveFileWindow.ShowDialog() == System.Windows.Forms.DialogResult.OK)) return;     //return if user canceled
            Stream stream = File.Open(saveFileWindow.FileName, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();

            //write data to file
            bf.Serialize(stream, semesterList);
            stream.Close();
        }

        // # Auto Generating

        // ## Auto Generating Semesters

        /// <summary>
        /// The semestersToolStripMenuItem method is used to handle autogening semesters
        /// from the autogen menu. It will generate a collection of semesters and add them
        /// to the semesterList.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void semestersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // open a new form
            AutoGenSemesters genSemWindow = new AutoGenSemesters();
            genSemWindow.ShowDialog();

            // add all generated semesters to Semester List and reload
            if (genSemWindow.GeneratedSemesterList is null) return;
            foreach (Semester sem in genSemWindow.GeneratedSemesterList)
            {
                if (semesterList.Contains(sem))
                {
                    MessageBox.Show("Duplicate semester detected while attempting to add generated" +
                        "Semesters to List! Ensure no duplicated semesters!");
                    return;
                }
            }
            foreach (Semester sem in genSemWindow.GeneratedSemesterList)
            {
                semesterList.Add(sem);
            }
            updateSemesterViewer();
        }


        // ## Auto Generating Electives

        /// <summary>
        /// The electivesToolStripMenuItem method is used to handle autogening course
        /// elective placeholders. It can generate a list of eaither general or major
        /// electives and add them to the courseList.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void electivesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // open a new form
            AutoGenElectives genElectWindow = new AutoGenElectives(courseList);
            genElectWindow.ShowDialog();

            // override bool
            bool containsDuplicates = false;

            // check if generated electives already exist
            if (genElectWindow.GeneratedElectives is null) return;
            foreach (Course elective in genElectWindow.GeneratedElectives)
            {
                if (courseList.Contains(elective))
                    containsDuplicates = true;
            }

            // if gened electives already exist, prompt to override
            if (containsDuplicates)
            {
                // open prompt form
                PromptWindow prompt = new PromptWindow("Generated Electives of this type already exist.\n" +
                    "Override existing?");
                prompt.ShowDialog();
                if (!prompt.Result)
                    return;
            }

            // add all generated electives to Course list and reload
            foreach (Course elective in genElectWindow.GeneratedElectives)
            {
                courseList.Add(elective);
            }
            updateCourseViewer();
        }


        // Mouse Actions ------------------------------------------------------------

        // # Double Click Course View element

        /// <summary>
        /// The CourseView_DoubleClick method opens a course viewer form for
        /// the selected course.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CourseView_DoubleClick(object sender, EventArgs e)
        {
            int index = CourseView.SelectedItems[0].Index;
            Course course = courseList[index];
            courseViewer(course);
        }

        // # Double Click Semester View element

        /// <summary>
        /// The SemesterView_DoubleClick method opens a semester viewer form for
        /// the selected semester.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SemesterViewer_DoubleClick(object sender, EventArgs e)
        {
            int index = SemesterViewer.SelectedItems[0].Index;
            Semester semester = semesterList[index];
            semesterViewer(semester);
        }


        // # Right Click Menu Strip Options (Course Viewer)

        // ## view

        /// <summary>
        /// The viewToolStripMenuItem will send a request to the respective
        /// selected course/semester double click viewer method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //course
            if (CourseView.SelectedItems.Count == 1)
            {
                CourseView_DoubleClick(sender, e);
            }
            //semester
            else if (SemesterViewer.SelectedItems.Count == 1)
            {
                SemesterViewer_DoubleClick(sender, e);
            }
            else
            {
                throw new Exception("Not Allowed!");
            }
        }

        // ## edit

        /// <summary>
        /// The editToolStripMenuItem method will open a edit form for the 
        /// selected course/semester element. It will update the respective
        /// list and viewer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            //course
            if (CourseView.SelectedItems.Count == 1)
            {
                //edit the selected course
                CourseEdit edit = new CourseEdit(ref courseList, courseList[CourseView.SelectedItems[0].Index]);
                this.SuspendLayout();
                edit.ShowDialog();

                //update viewer
                updateCourseViewer();

                //update prefixes
                updatePrefixes();
            }
            //semester
            else if (SemesterViewer.SelectedItems.Count == 1)
            {
                //edit the selected semester
                SemesterEdit edit =
                    new SemesterEdit(ref semesterList, semesterList[SemesterViewer.SelectedItems[0].Index]);
                this.SuspendLayout();
                edit.ShowDialog();

                //update viewer
                updateSemesterViewer();
            }
            else
            {
                throw new Exception("Not Allowed!");
            }
        }

        // ## remove

        /// <summary>
        /// the deleteToolStripMenuItem will attempt to delete the selected course
        /// from the viewer and courseList. It will find a list of all courses that
        /// may depend on the selected course and warn the user that they will be
        /// removed as well.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //course
            if (CourseView.SelectedItems.Count == 1)
            {
                //variable
                Course deleteCourse = courseList[CourseView.SelectedItems[0].Index];

                //find all dependees that depend on deleteCourse
                List<Course> toDelete = new List<Course>();
                toDelete.Add(deleteCourse);


                int counter = 0;
                while (counter < toDelete.Count)
                {
                    foreach (Course course in courseList)
                    {
                        if (course.dependencies.Contains(toDelete[counter])
                            || course.copendencies.Contains(toDelete[counter]))
                        {
                            toDelete.Add(course);
                        }
                    }
                    counter++;
                }

                //remove seed course
                toDelete.Remove(deleteCourse);


                if (!(toDelete.Count == 0))
                {
                    //prompt the user to ensure continue
                    String message =
                        "Warning: This will also remove the following courses that\n"
                        + "depend on "+ deleteCourse.courseReference + ", Continue?\n"
                        + "Course List: ";

                    foreach (Course course in toDelete) { message += course.courseReference + ", "; }
                    message = message.TrimEnd(',');

                    PromptWindow confirm = new PromptWindow(message);
                    this.SuspendLayout();
                    confirm.ShowDialog();

                    // if ok, delete, else cancel
                    if (confirm.Result)
                    {
                        foreach (Course course in toDelete)
                        {
                            courseList.Remove(course);
                            removePrescheduledCourse(course);
                        }
                    }
                    else { return; }
                }

                //remove the course from the list
                courseList.Remove(deleteCourse);
                removePrescheduledCourse(deleteCourse);

                //update course view
                updateCourseViewer();

                //update prefixes
                updatePrefixes();
            }
            //semester
            else if (SemesterViewer.SelectedItems.Count == 1)
            {
                //remove the semester
                semesterList.RemoveAt(SemesterViewer.SelectedItems[0].Index);

                //update semester view
                updateSemesterViewer();
            }
            else
            {
                throw new Exception("Not Allowed!");
            }
        }

        // ## Prescheduleing

        /// <summary>
        /// The scheduleCoursesToolStripMenuItem method will find a list of valid courses
        /// that can be prescheduled for the selected semester in semesterViewer. It will
        /// then open the Preschedule viewer to allow the user to preschedule courses and
        /// update the courseViewer when done.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void scheduleCoursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ensure only one selection
            if (SemesterViewer.SelectedItems.Count == 1)
            {

                //generate remaining courses
                List<Course> remainingCourses = new List<Course>(courseList);
                foreach (List<Course> courses in preScheduleDict.Values)
                {
                    foreach (Course course in courses)
                    {
                        remainingCourses.Remove(course);
                    }
                }

                //get semester at selected index
                Semester semester = semesterList[SemesterViewer.SelectedItems[0].Index];

                //retrieve prescheduledCourses List coresponding to the semester
                List<Course> prescheduledCourses = new List<Course>();
                preScheduleDict.TryGetValue(semester, out prescheduledCourses);

                //create viewer
                PrescheduleViewer prescheduleSemesterViewer =
                    new PrescheduleViewer(courseList, prescheduledCourses,
                    semesterList, preScheduleDict, semester, previousCompletedCourses);

                //modify viewer
                prescheduleSemesterViewer.upButton.Visible = false;
                prescheduleSemesterViewer.downButton.Visible = false;
                prescheduleSemesterViewer.Name = "Semester Manual Scheduling";


                //open viewer
                prescheduleSemesterViewer.ShowDialog();

                //update list
                updateCourseViewer();
            }
            else
            {
                throw new Exception("Not Allowed!");
            }
        }

        // ## uncompleted/completed change

        /// <summary>
        /// The markAsCompletedToolStripMenuItem method will mark a selected uncompleted
        /// course as completed or a selected completed course as uncompleted then updated
        /// the course viewer window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void markAsCompletedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // get selected course
            Course course = courseList[CourseView.SelectedItems[0].Index];

            // if selected course is not in completed courses list. Add to completed courses list.
            if (!previousCompletedCourses.Contains(course))
            {
                previousCompletedCourses.Add(course);
            }
                
            // if selected course is in completed courses list. Remove from completed courses list.
            else
            {
                previousCompletedCourses.Remove(course);
            }
                

            //reload viewer
            updateCourseViewer();
        }




        // Options Pane ---------------------------------------------------------------------

        // # Prefix Prioritization button click

        /// <summary>
        /// The prefixPrioritiesFormButton Method launches the prefix Prioritization
        /// Viewer Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void prefixPrioritiesFormButton_Click(object sender, EventArgs e)
        {
            PriorityViewer<String> viewer =
                new PriorityViewer<String>(coursePrefixes, prioritisedCoursePrefixes);
            this.SuspendLayout();
            viewer.ShowDialog();
        }


        // Form behavior ---------------------------------------------------------------------

        // # Define when options button is enabled

        /// <summary>
        /// The prioritizePrefixesCB_CheckedChanged method handles when the Prioritize options
        /// button is enabled in the options pane according to prioritized prefixes CB.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void prioritizePrefixesCB_CheckedChanged(object sender, EventArgs e)
        {
            if (prioritizePrefixesCB.Checked)
            {
                //enable form button
                prefixPrioritiesFormButton.Enabled = true;
            }
            else
            {
                //disable form button
                prefixPrioritiesFormButton.Enabled = false;

                //clear list
                prioritisedCoursePrefixes.Clear();
            }
        }


        // # Define when menu strip can be used for courseView

        /// <summary>
        /// The CourseView_ItemSelectionChanged handles selection changes behavior in the
        /// Course List View.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CourseView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (CourseView.SelectedItems.Count == 1)
            {
                //enable menu
                EditElementMenuStrip.Enabled = true;
                //disable pre-scheduling option
                scheduleCoursesToolStripMenuItem.Enabled = false;
                scheduleCoursesToolStripMenuItem.Visible = false;
                //enable prior completion mark option and change the name
                if (previousCompletedCourses.Contains(courseList[CourseView.SelectedItems[0].Index]))
                    markAsCompletedToolStripMenuItem.Text = "Mark as Uncompleted";
                else
                    markAsCompletedToolStripMenuItem.Text = "Mark as Completed";
                markAsCompletedToolStripMenuItem.Enabled = true;
                markAsCompletedToolStripMenuItem.Visible = true;
            }
            else
            {
                //disable menu
                EditElementMenuStrip.Enabled = false;
                //disable pre-scheduling option
                scheduleCoursesToolStripMenuItem.Enabled = false;
                scheduleCoursesToolStripMenuItem.Visible = false;
                //disable prior completion mark option
                markAsCompletedToolStripMenuItem.Enabled = false;
                markAsCompletedToolStripMenuItem.Visible = false;
            }
        }

        // # Define when menu strip can be used for semesterView

        /// <summary>
        /// The SemesterView_ItemSelectionChanged handles selection changes behavior in the
        /// Course List View.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SemesterViewer_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (SemesterViewer.SelectedItems.Count == 1)
            {
                //enable menu
                EditElementMenuStrip.Enabled = true;
                //enable pre-scheduling option
                scheduleCoursesToolStripMenuItem.Enabled = true;
                scheduleCoursesToolStripMenuItem.Visible = true;
                //disable prior completion mark option
                markAsCompletedToolStripMenuItem.Enabled = false;
                markAsCompletedToolStripMenuItem.Visible = false;
            }
            else
            {
                //disable menu
                EditElementMenuStrip.Enabled = false;
                //disable pre-scheduling option
                scheduleCoursesToolStripMenuItem.Enabled = false;
                scheduleCoursesToolStripMenuItem.Visible = false;
                //disable prior completion mark option
                markAsCompletedToolStripMenuItem.Enabled = false;
                markAsCompletedToolStripMenuItem.Visible = false;
            }
        }





        // Helper Methods -------------------------------------------------------------------

        /// <summary>
        /// The updateCourseViewer method will update the course viewer on the form.
        /// It will clear the viewer, sort the courseList items, and add each back to
        /// the viewer. It also contains logic to place previously completed courses
        /// at the bottom of the viewer and grey/italic them.
        /// </summary>
        private void updateCourseViewer()
        {
            //sort the course list
            courseList.Sort(new ClassViewCompare(previousCompletedCourses));

            //clear the viewer
            CourseView.Items.Clear();

            //add elements to viewer
            foreach (Course course in courseList) 
            {
                // create List View Item and name it
                ListViewItem courseReference = new ListViewItem();
                courseReference.Text = course.courseReference;
                // if the course is already scheduled, change the color to grey and italicize
                if (previousCompletedCourses.Contains(course))
                {
                    courseReference.ForeColor = Color.Gray;
                    courseReference.Font =
                        new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Italic);
                }


                // Add to list
                CourseView.Items.Add(courseReference);
                
            }
        }

        /// <summary>
        /// The updateSemesterViewer method will update the semester viewer on the form.
        /// It will clear the viewer, sort the semesterList items, and add each back to
        /// the viewer.
        /// </summary>
        private void updateSemesterViewer()
        {
            //sort the semester list
            semesterList.Sort(new SemesterCompare());

            //clear the viewer
            SemesterViewer.Items.Clear();

            //add elements to viewer
            foreach (Semester semester in semesterList) { SemesterViewer.Items.Add(semester.SemesterReference); }
        }


        /// <summary>
        /// The updatePrefixes method handles updateing both the current list of course
        /// prefixes and the list of prioritized prefixes. First the coursePrefixes list
        /// is cleared and then repopulated. Then The priorityPrefixes list is compared
        /// against the new prefixes list to determine if/which prefixes are now extinct.
        /// The found extinct prefixes are then removed from the prioritisedCoursePrefixes
        /// list.
        /// </summary>
        private void updatePrefixes()
        {
            //update coursePrefix list
            coursePrefixes.Clear();
            foreach (Course course in courseList)
            {
                coursePrefixes.Add(course.coursePrefix);
            }

            //remove any removed prefixes from priority list
            List<String> removeList = new List<string>();
            foreach (String prefix in prioritisedCoursePrefixes)
            {
                if (!coursePrefixes.Contains(prefix))
                    removeList.Add(prefix);
            }
            prioritisedCoursePrefixes.RemoveAll(t => removeList.Contains(t));
        }

        /// <summary>
        /// The removePrescheduledCourse method will loop through the prescheduleDictionary,
        /// find the selected course and remove it from the list.
        /// </summary>
        /// <param name="courseToDelete"></param>
        private void removePrescheduledCourse(Course courseToDelete)
        {
            foreach (List<Course> courses in preScheduleDict.Values)
            {
                foreach (Course course in courses)
                {
                    if (course.Equals(courseToDelete))
                    {
                        courses.Remove(courseToDelete);
                        return;
                    }
                }
            }
        }



        // Viewers --------------------------------------------------------------------------


        /// <summary>
        /// The courseViewer method will instantiate, generate, and open a ElementViewer
        /// Form to display the contents of a specified course object.
        /// </summary>
        /// <param name="course"></param>
        private void courseViewer(Course course)
        {
            // elements list
            List<String> elements = new List<string>();

            //get dependencies
            String dependencies = "";
            foreach (Course dependency in course.dependencies) { dependencies += dependency.courseReference + ", "; }
            dependencies = dependencies.Trim(' ', ',');

            //get copendencies
            String copendencies = "";
            foreach (Course copendency in course.copendencies) { copendencies += copendency.courseReference + ", "; }
            copendencies = copendencies.Trim(' ', ',');

            //get valid terms
            String terms = "";
            foreach (TermEnums term in course.validTerms) { terms += term.ToString() + ", "; }
            terms = terms.Trim(' ', ',');



            //add all the courses elements to a list of strings
            elements.Add("Course Name: " + course.courseName);
            elements.Add("Course Description: " + course.courseDescription);
            elements.Add("Course Prefix: " + course.coursePrefix);
            elements.Add("Course ID: " + course.courseID);
            elements.Add("Credit hours: " + course.credits);
            elements.Add("Dependencies: " + dependencies);
            elements.Add("Copendencies: " + copendencies);
            elements.Add("Valid Terms: " + terms);

            // print additional course details
            elements.Add("Additional details: ");

            if (course.courseDetails.UndergraduateLevel)
                elements.Add("-Course Level: " + "Undergraduate");
            else
                elements.Add("-Course Level: " + "Graduate");

            if (course.courseDetails.CreditsRequired.HasValue)
                elements.Add("-Required taken Credits: " + course.courseDetails.CreditsRequired);
            if (course.courseDetails.YearBase.HasValue) {
                elements.Add("-Year Rotation Base: " + course.courseDetails.YearBase);
                elements.Add("-Year Rotation Multiplier: " + course.courseDetails.YearMultiple);
            }
            if (!course.courseDetails.RequiredStanding.Equals(Objects.Standing.FRESHMAN))
                elements.Add("-Required standing level: " + course.courseDetails.RequiredStanding.ToString());
            if (course.courseDetails.GeneralElective)
                elements.Add("-Fullfills general elective requirements");
            if (course.courseDetails.DegreeElective)
                elements.Add("-Fullfills degree elective requirements");
            if (course.courseDetails.DualCredit)
                elements.Add("-Fullfills dual credit");

            //open a new element viewer
            this.SuspendLayout();
            ElementViewer courseDetails =
                new ElementViewer(ref elements, course.courseReference);
            courseDetails.ShowDialog();
        }

        /// <summary>
        /// The semesterViewer method will instantiate, generate, and open a ElementViewer
        /// Form to display the contents of a specified semester object.
        /// </summary>
        /// <param name="semester"></param>
        private void semesterViewer(Semester semester)
        {
            // elements list
            List<String> elements = new List<String>();

            //add all the semester elements to a list of strings
            elements.Add("Year: " + semester.Year);
            elements.Add("Term: " + semester.Term.ToString());
            elements.Add("Minimum Credits: " + semester.MinCredits);
            elements.Add("Maximum Credits: " + semester.MaxCredits);
            elements.Add("Overloadable: " + semester.IsOverloadable.ToString());

            //open a new elment viewer
            this.SuspendLayout();
            ElementViewer semesterDetails =
                new ElementViewer(ref elements, semester.SemesterReference);
            semesterDetails.ShowDialog();
        }

    }
}