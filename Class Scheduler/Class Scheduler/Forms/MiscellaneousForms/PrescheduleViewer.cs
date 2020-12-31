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

namespace Class_Scheduler.Forms.MiscellaneousForms
{
    public partial class PrescheduleViewer : PriorityViewer<Course>
    {
        private List<Semester> semesterList;
        private Dictionary<Semester, List<Course>> allPrescheduledCourses;
        private Semester semester;
        private List<Course> completedCourses;

        public PrescheduleViewer(IEnumerable<Course> courses, List<Course> prescheduledCourses,
            List<Semester> semesterList, Dictionary<Semester, List<Course>> allPrescheduledCourses,
            Semester semester, List<Course> completedCourses) : 
            base(new List<Course>(courses), prescheduledCourses)
        {
            List<Course> test = new List<Course>();
            InitializeComponent();

            //set variables
            this.semesterList = semesterList;
            this.allPrescheduledCourses = allPrescheduledCourses;
            this.semester = semester;
            this.completedCourses = completedCourses;

            //modify form
            this.upButton.Visible = false;
            this.downButton.Visible = false;
            this.Name = "Schedule Semester";


            //remove already scheduled courses
            foreach(List<Course> coursesInSem in allPrescheduledCourses.Values)
            {
                foreach(Course cou in coursesInSem)
                {
                    _nonPrioritizedItems.Remove(cou);
                }
            }

            //add current semester back in
            foreach(Course cou in prescheduledCourses)
            {
                _nonPrioritizedItems.Add(cou);
            }

            //update lists
            base.updateLists(_nonPrioritizedItems, _priorityList);
            
        }



        protected override void moveRightButton_Click(object sender, EventArgs e)
        {
            //get selected course
            Course course = getSelectedItem();

            //get semester index
            int semIndex = semesterList.IndexOf(semester);

            //get all prescheduled courses before the selected semester
            List<Course> priorCourses = new List<Course>();
            for (int i = 0; i < semIndex; i++)
            {
                List<Course> semCourses = new List<Course>();
                allPrescheduledCourses.TryGetValue(semesterList[i], out semCourses);
                foreach(Course semCourse in semCourses)
                {
                    priorCourses.Add(semCourse);
                }
            }

            //check prereqs of course by ensureing all prereqs are in the previously generated list
            bool reqsMet = true;
            List<Course> coursesNotAlreadyScheduled = new List<Course>();

            foreach(Course prereq in course.dependencies)
            {
                if (!priorCourses.Contains(prereq) && !completedCourses.Contains(prereq))
                {
                    reqsMet = false;
                    coursesNotAlreadyScheduled.Add(prereq);
                }
            }


            //also check coreqs
            List<Course> semesterCourses = new List<Course>();
            allPrescheduledCourses.TryGetValue(semester, out semesterCourses);

            priorCourses = priorCourses.Union(semesterCourses).ToList<Course>();
            foreach(Course coreq in course.copendencies)
            {
                if(!priorCourses.Contains(coreq) && !completedCourses.Contains(coreq))
                {
                    reqsMet = false;
                    coursesNotAlreadyScheduled.Add(coreq);
                }
            }

            //if reqs are not met, show a popup message
            if (!reqsMet)
            {
                String message = "The following courses have not been scheduled: \n";
                foreach(Course prereq in coursesNotAlreadyScheduled)
                {
                    message += prereq.ToString()+", ";
                }
                message = message.TrimEnd(',',' ');
                MessageBox.Show(message);
                return;
            }


            //check to ensure enough space in the semester
            //-count the credits already prescheduled
            int creditCount = 0;
            foreach(Course cou in semesterCourses)
            {
                creditCount += cou.credits;
            }
            //-if credits are greater than semester supports
            if((creditCount+course.credits) > semester.MaxCredits)
            {
                MessageBox.Show("Failed to schedule, max credits exceeded for the semester!");
                return;
            }


            // check to ensure correct term
            if(!(course.validTerms.Contains(semester.Term)))
            {
                MessageBox.Show("Failed to schedule, term is not supported by this course!");
                return;
            }


            // check to ensure course multiple
            if(course.courseDetails.YearBase.HasValue)
            {
                if ((semester.Year -
                    course.courseDetails.YearBase.Value) % 
                    course.courseDetails.YearMultiple.Value != 0)
                {
                    MessageBox.Show("Failed to schedule, course cannot be scheduled this year!");
                    return;
                }
            }


            // check to ensure course is not already completed
            if (completedCourses.Contains(course))
            {
                MessageBox.Show("Failed to schedule, course has already been completed!");
                return;
            }


            // display notification to user to ensure user is aware of credit requirement
            if(course.courseDetails.CreditsRequired.HasValue)
            {
                MessageBox.Show("The course has a credit requirement, please ensure" +
                    "Course is scheduled far enough in the curiculum to meet this requirement!");
            }


            // if all reqs met, schedule the course

            //move course
            base.moveRightButton_Click(sender, e);
        }

        protected override void moveLeftButton_Click(object sender, EventArgs e)
        {
            //get selected course
            Course course = getSelectedItem();

            //get semester index
            int semIndex = semesterList.IndexOf(semester);

            //get all postscheduled courses after the selected semester
            List<Course> postCourses = new List<Course>();
            for (int i = semIndex; i < semesterList.Count; i++)
            {
                List<Course> semCourses = new List<Course>();
                allPrescheduledCourses.TryGetValue(semesterList[i], out semCourses);
                foreach (Course semCourse in semCourses)
                {
                    postCourses.Add(semCourse);
                }
            }

            // iterate through courses in post semesters and check if they depend on the course
            List<Course> dependentCourses = new List<Course>();
            bool depends = false;
            foreach(Course postCourse in postCourses)
            {
                if (postCourse.dependencies.Contains(course) ||
                    postCourse.copendencies.Contains(course))
                {
                    dependentCourses.Add(postCourse);
                    depends = true;
                }
            }

            if(depends)
            {
                string message = "The following Courses will also be unscheduled: \n";
                foreach(Course depenCourse in dependentCourses)
                {
                    message += depenCourse.ToString()+", ";
                }
                message = message.TrimEnd(',', ' ');

                PromptWindow prompt = new PromptWindow(message);
                prompt.ShowDialog();

                if(prompt.Result)
                {
                    // remove all dependent courses first
                    for (int i = semIndex; i < semesterList.Count; i++)
                    {
                        List<Course> semCourses = new List<Course>();
                        allPrescheduledCourses.TryGetValue(semesterList[i], out semCourses);
                        foreach (Course depenCourse in dependentCourses)
                        {
                            if(semCourses.Contains(depenCourse))
                                semCourses.Remove(depenCourse);
                        }
                    }
                }
                else
                {
                    // cancel
                    return;
                }
            }

            //move course
            base.moveLeftButton_Click(sender, e);

            //update window
            base.updateLists(_nonPrioritizedItems, _priorityList);

        }




    }
}
