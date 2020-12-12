using Class_Scheduler.Forms.CourseForms;
using Class_Scheduler.Forms.MiscellaneousForms;
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
using static Class_Scheduler.Objects.Course;

namespace Class_Scheduler.Forms.CourseForms
{
    public partial class CourseEdit : CourseAdd
    {
        private Course editCourse;
        new private List<Course> courses;
        private CourseAddDetails detailsEditForm;

        public CourseEdit(ref List<Course> courses, Course editCourse) : base(ref courses)
        {
            InitializeComponent();

            //set values
            this.courses = courses;
            this.editCourse = editCourse;

            //pre stuff
            //change title
            this.Text = "Edit Course";
            //change "add" button to "edit"
            this.addCourseButton.Text = "Edit Course";

            //create course terms string
            String terms = "";
            foreach(TermEnums term in editCourse.validTerms) { terms += term.ToString() + ", "; }
            terms = terms.Trim(',', ' ');

            //create course dependencies string
            String dependencies = "";
            foreach(Course dependency in editCourse.dependencies) { dependencies += dependency.courseReference + ", "; }
            dependencies = dependencies.Trim(',', ' ');

            //create course copendencies string
            String copendencies = "";
            foreach(Course copencnecy in editCourse.copendencies) { copendencies += copencnecy.courseReference + ", "; }
            copendencies = copendencies.Trim(' ', ',');
            
            //set all text boxes to editCourse values
            courseNameTB.Text = editCourse.courseName;
            coursePrefixTB.Text = editCourse.coursePrefix;
            courseIDTB.Text = editCourse.courseID.ToString();
            courseCreditsTB.Text = editCourse.credits.ToString();
            courseDescriptionTB.Text = editCourse.courseDescription;
            validSemestersTB.Text = terms;
            courseDependenciesTB.Text = dependencies;
            courseCopendenciesTB.Text = copendencies;

            //set all course details text boxes to editCourse values
            detailsEditForm = new CourseAddDetails();
            detailsEditForm.courseDetails = editCourse.courseDetails;
        }

        protected override void advancedDetailsButton_Click(object sender, EventArgs e)
        {
            detailsEditForm.ShowDialog();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        protected override void addCourseButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Attempt to create course object
                StringCourseBuilder builder = new Course.StringCourseBuilder(courseNameTB.Text, courseDescriptionTB.Text,
                    coursePrefixTB.Text, courseIDTB.Text, courseCreditsTB.Text, courses);
                builder.ValidTerms = validSemestersTB.Text;
                builder.Dependencies = courseDependenciesTB.Text;
                builder.Copendencies = courseCopendenciesTB.Text;
                builder.CourseDetails = detailsEditForm.courseDetails;
                Course editedCourse = builder.build();

                //check to ensure course ref is the same
                if (!editedCourse.Equals(editCourse))
                {
                    //if not, ensure it does not already exist in the course list
                    if (courses.Contains(editedCourse)) { throw new Exception("Course already exists!"); }
                }

                //find all dependees that will need there dependent ref updated
                List<Course> dependenciesToModify = new List<Course>();
                List<Course> copendenciesToModify = new List<Course>();

                foreach(Course course in courses)
                {
                    if (course.dependencies.Contains(editCourse)) 
                    {
                        dependenciesToModify.Add(course);
                    }
                    if (course.copendencies.Contains(editCourse))
                    {
                        copendenciesToModify.Add(editCourse);
                    }
                }

                //add edited course to list
                courses.Add(editedCourse);

                if (!(dependenciesToModify.Count == 0 && copendenciesToModify.Count == 0))
                {
                    //prompt the user to ensure continue
                    String message =
                        "Warning: This will overide the course dependent for the following courses from\n"
                        + editCourse.courseReference + " to " + editedCourse.courseReference + ", Continue?\n"
                        + "Course List: ";

                    foreach (Course course in dependenciesToModify) { message += course.courseReference + ", "; }
                    foreach (Course course in copendenciesToModify) { message += course.courseReference + ", "; }
                    message = message.TrimEnd(',');

                    PromptWindow confirm = new PromptWindow(message);
                    this.SuspendLayout();
                    confirm.ShowDialog();

                    // if ok, overrite, else cancel
                    if (confirm.Result)
                    {
                        foreach (Course course in dependenciesToModify)
                        {
                            CourseBuilder newCourse = new Course.CourseBuilder(course, courses);
                            newCourse.removeDependency(editCourse);
                            newCourse.addDependency(editedCourse);

                            courses.Remove(course);
                            courses.Add(newCourse.build());
                        }
                        foreach (Course course in copendenciesToModify)
                        {
                            CourseBuilder newCourse = new Course.CourseBuilder(course, courses);
                            newCourse.removeCopendency(editCourse);
                            newCourse.addCopendency(editedCourse);

                            courses.Remove(course);
                            courses.Add(newCourse.build());
                        }
                    }
                    else 
                    {
                        courses.Remove(editedCourse);
                        return; 
                    }
                }

                //remove the course from the list
                courses.Remove(editCourse);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
