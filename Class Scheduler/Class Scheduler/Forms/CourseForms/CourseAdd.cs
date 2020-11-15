using Class_Scheduler.Forms.CourseForms;
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
using System.Windows.Forms.VisualStyles;
using static Class_Scheduler.Objects.Course;

namespace Class_Scheduler.Forms.CourseForms
{
    public partial class CourseAdd : Form
    {
        //Variables
        protected Course course;
        protected List<Course> courses;
        protected CourseAddDetails detailsForm;
        public Course NewCourse { get { return course; } }
        

        public CourseAdd(ref List<Course> courses)
        {
            InitializeComponent();
            this.courses = new List<Course>(courses);

            //set opening position
            this.StartPosition = FormStartPosition.Manual;
            this.Location = Application.OpenForms[0].Location;
        }

        private void CourseAdd_Load(object sender, EventArgs e)
        {
            //initiate CourseDetailsForm
            detailsForm = new CourseAddDetails();
        }

        protected virtual void addCourseButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Attempt to create course object
                StringCourseBuilder builder = new Course.StringCourseBuilder(courseNameTB.Text, courseDescriptionTB.Text, 
                    coursePrefixTB.Text, courseIDTB.Text, courseCreditsTB.Text, courses);
                builder.CourseDetails = detailsForm.courseDetails;
                builder.ValidTerms = validSemestersTB.Text;
                builder.Dependencies = courseDependenciesTB.Text;
                builder.Copendencies = courseCopendenciesTB.Text;
                course = builder.build();

                //check to make sure course ref does not exist
                if (courses.Contains(course))
                {
                    course = null;
                    throw new Exception("Course already exists!");
                }
                
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //advanced details button
        protected virtual void advancedDetailsButton_Click(object sender, EventArgs e)
        {
            detailsForm.ShowDialog();
        }






        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
 