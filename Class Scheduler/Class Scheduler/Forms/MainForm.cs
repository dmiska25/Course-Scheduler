using Class_Scheduler.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.ObjectModel;
using Class_Scheduler.Comparers;

namespace Class_Scheduler
{
    public partial class MainForm : Form
    {
        //variables
        private List<Course> courseList = new List<Course>();
        private List<Semester> semesterList = new List<Semester>();

        public MainForm()
        {
            InitializeComponent();
        }

        //main load
        private void Main_Load(object sender, EventArgs e)
        {
            //diable menu strip
            EditElementMenuStrip.Enabled = false;
        }


        //generate schedules
        private void genSchedulesButton(object sender, EventArgs e)
        {
            // generate course containers for courses
            List<CourseContainer> processed = ScheduleGenerator.genCourseContainers(courseList).ToList();

            Console.WriteLine("\nBegining Scheduleing test...");

            //generate schedule and add course containers to semesters
            bool result = ScheduleGenerator.scheduleSemesters(processed, semesterList);
            


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

            //create new form
            ScheduleResultView schedule = new ScheduleResultView();

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



        //menu strip

        //-adding items from menu

        //--Add course from menu
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
        }

        //--add semester from menu
        private void semesterToolStripMenuItem1_Click(object sender, EventArgs e)
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

            //update viewer
            updateSemesterViewer();
        }

        //-Loading data from txt file

        //--loading Classes from txt file
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
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error loading file!\n" + ex.Message);
            }
        }

        //--loading semester data from txt file
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

                //update viewer
                updateSemesterViewer();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error loading file!\n"+ex.Message);
            }
        }


        //- saving data to text file

        //--saving course objects to txt file
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


        //--saving semester objects to txt file
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



        // Mouse Actions

        //- Double Click Course View element
        private void CourseView_DoubleClick(object sender, EventArgs e)
        {
            List<String> elements = new List<string>();
            int index = CourseView.SelectedItems[0].Index;
            Course course = courseList[index];

            //get dependencies
            String dependencies = "";
            foreach (Course dependency in course.dependencies) { dependencies += dependency.courseReference + ", "; }
            dependencies = dependencies.Trim(' ',',');

            //get copendencies
            String copendencies = "";
            foreach (Course copendency in course.copendencies) { copendencies += copendency.courseReference + ", "; }
            copendencies = copendencies.Trim(' ', ',');

            //get valid terms
            String terms = "";
            foreach(TermEnums term in course.validTerms) { terms += term.ToString() + ", "; }
            terms = terms.Trim(' ', ',');



            //add all the courses elements to a list of strings
            elements.Add("Course Name: " + course.courseName);
            elements.Add("Course Prefix: " + course.coursePrefix);
            elements.Add("Course ID: " + course.courseID);
            elements.Add("Credit hours: " + course.credits);
            elements.Add("Dependencies: " + dependencies);
            elements.Add("Copendencies: " + copendencies);
            elements.Add("Valid Terms: " + terms);
            elements.Add("Graduate Level: " + course.isGraduate.ToString());

            //open a new element viewer
            this.SuspendLayout();
            ElementViewer courseDetails = 
                new ElementViewer(ref elements, course.courseReference);
            courseDetails.ShowDialog();
        }

        //- Double Click Semester View element
        private void SemesterViewer_DoubleClick(object sender, EventArgs e)
        {
            List<String> elements = new List<String>();
            int index = SemesterViewer.SelectedItems[0].Index;
            Semester semester = semesterList[index];


            //add all the semester elements to a list of strings
            elements.Add("Year: " + semester.Year);
            elements.Add("Term: " + semester.Term.ToString());
            elements.Add("Minimum Credits: " + semester.MinCredits);
            elements.Add("Maximum Credits: " + semester.MaxCredits);

            //open a new elment viewer
            this.SuspendLayout();
            ElementViewer semesterDetails =
                new ElementViewer(ref elements, semester.SemesterReference);
            semesterDetails.ShowDialog();
        }


        //-Right Click Menu Strip Options (Course Viewer)

        //--Define when menu strip can be used for courseView
        private void CourseView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if(CourseView.SelectedItems.Count == 1)
            {
                //enable menu
                EditElementMenuStrip.Enabled = true;
            }
            else
            {
                //disable menu
                EditElementMenuStrip.Enabled = false;
            }
        }
        //--Define when menu strip can be used for semesterView
        private void SemesterViewer_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (SemesterViewer.SelectedItems.Count == 1)
            {
                //enable menu
                EditElementMenuStrip.Enabled = true;
            }
            else
            {
                //disable menu
                EditElementMenuStrip.Enabled = false;
            }
        }




        //--view
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

        //--edit
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

        //--remove
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
                        }
                    }
                    else { return; }
                }

                //remove the course from the list
                courseList.Remove(deleteCourse);

                //update course view
                updateCourseViewer();
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


        // Helper Methods
        private void updateCourseViewer()
        {
            //sort the course list
            courseList.Sort(new ClassViewCompare());

            //clear the viewer
            CourseView.Items.Clear();

            //add elements to viewer
            foreach (Course course in courseList) { CourseView.Items.Add(course.courseReference); }
        }

        private void updateSemesterViewer()
        {
            //sort the semester list
            semesterList.Sort(new SemesterViewCompare());

            //clear the viewerr
            SemesterViewer.Items.Clear();

            //add elements to viewer
            foreach (Semester semester in semesterList) { SemesterViewer.Items.Add(semester.SemesterReference); }
        }


    }
}