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

namespace Class_Scheduler.Forms.AutoGen
{
    public partial class AutoGenElectives : Form
    {
        // field
        private List<Course> _courses;
        private List<Course> _genedElectives;
        private int _genElectCount;
        private int _majElectCount;

        // Property
        public List<Course> GeneratedElectives { get => _genedElectives; }

        public AutoGenElectives(List<Course> courses, int genElectCount, int majElectCount)
        {
            this._courses = courses;
            _genElectCount = genElectCount;
            _majElectCount = majElectCount;
            InitializeComponent();
        }

        // attempt to generate electives
        private void autoGenElectButton_Click(object sender, EventArgs e)
        {
            // attempt to retrieve variables from form
            try
            {
                //variables
                String electCourseNamePre = "";
                String electCoursePrefix = "";
                int electCourseID = 100;
                bool generalCourse = false;
                int electCredits = 0;
                List<TermEnums> electValidTerms = new List<TermEnums>();
                int toGenCount = 0;
                List<Course> genedElectives = new List<Course>();
                int reqCreditsCount = 0;
                


                // gen or maj elective
                if (genElectRB.Checked)
                {
                    generalCourse = true;
                    electCourseNamePre = "General Ed ";
                    electCoursePrefix = "GENR";
                    electCourseID += _genElectCount;
                }
                else if(majorElectRB.Checked)
                {
                    generalCourse = false;
                    electCourseNamePre = "Major Elect ";
                    electCoursePrefix = "MAJR";
                    electCourseID += _majElectCount;
                }
                else
                    throw new Exception("Invalid Elective Type Selected!");

                // number of credits
                if (!int.TryParse(creditsTB.Text, out electCredits)
                    || electCredits < 1
                    || electCredits > 30)
                    throw new Exception("Invalid number of credits! Must be valid int from 1 to 30.");

                // Valid Terms
                if (FallCB.Checked)
                    electValidTerms.Add(TermEnums.FALL);
                if (springCB.Checked)
                    electValidTerms.Add(TermEnums.SPRING);
                if (summerCB.Checked)
                    electValidTerms.Add(TermEnums.SUMMER);
                if (electValidTerms.Count == 0)
                    throw new Exception("Must have at least one valid term!");

                // number of electives to gen
                if (!int.TryParse(electToGenTB.Text, out toGenCount)
                    || toGenCount < 1)
                    throw new Exception("Invalid Electives to Gen! Must be valid int greater than 1.");

                // begin generating Courses
                for (int i = 0; i < toGenCount; i++)
                {
                    // set variables
                    electCourseID++;
                    String electCourseName = electCourseNamePre + electCourseID;
                    Course elective;

                    // create course object
                    CourseBuilder builder = new Course.CourseBuilder(electCourseName, "N/A",
                         electCoursePrefix, electCourseID, electCredits, _courses);

                    // set course details
                    CourseDetails details = new CourseDetails();
                    if (generalCourse)
                    {
                        details.GeneralElective = true;
                        details.DegreeElective = false;
                    }
                    else
                    {
                        details.GeneralElective = false;
                        details.DegreeElective = true;

                        if(gradeLevelReqCB.Checked)
                        {
                            if (FreshmanRB.Checked) details.RequiredStanding = Standing.FRESHMAN;
                            else if (sophmoreRB.Checked) details.RequiredStanding = Standing.SOPHOMORE;
                            else if (juniorRB.Checked) details.RequiredStanding = Standing.JUNIOR;
                            else if (seniorRB.Checked) details.RequiredStanding = Standing.SENIOR;
                            else throw new Exception("Invalid grade level req!");
                        }
                        if(creditCountReqCB.Checked)
                        {
                            if (!int.TryParse(creditsCountReqTB.Text, out reqCreditsCount)
                                || reqCreditsCount < 0)
                                throw new Exception("Invalid required credit count! Must be valid positive int.");
                            details.CreditsRequired = reqCreditsCount;
                        }
                    }
                    details.UndergraduateLevel = true;
                    details.GraduateLevel = false;
                    builder.CourseDetails = details;

                    // set valid terms
                    builder.ValidTerms = electValidTerms;
                    
                    // build
                    elective = builder.build();

                    // add to list
                    genedElectives.Add(elective);

                }

                // set field
                _genedElectives = genedElectives;

            }
            catch(Exception ex)
            {
                // Display error message
                MessageBox.Show(ex.Message);
            }

            // close window
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            // close the form
            this.Close();
        }


        // form behavior
        private void majorElectRB_CheckedChanged(object sender, EventArgs e)
        {
            if (majorElectRB.Checked)
            {
                gradeLevelReqLabel.Visible = true;
                gradeLevelReqCB.Visible = true;
                if(gradeLevelReqCB.Checked)
                {
                    FreshmanRB.Visible = true;
                    sophmoreRB.Visible = true;
                    juniorRB.Visible = true;
                    seniorRB.Visible = true;
                    gradeLevelGB.Visible = true;
                }
                creditsReqLabel.Visible = true;
                creditCountReqCB.Visible = true;
                if(creditCountReqCB.Checked)
                {
                    creditCountReqLabel.Visible = true;
                    creditsCountReqTB.Visible = true;
                }
            }
            else
            {
                gradeLevelReqLabel.Visible = false;
                gradeLevelReqCB.Visible = false;
                FreshmanRB.Visible = false;
                sophmoreRB.Visible = false;
                juniorRB.Visible = false;
                seniorRB.Visible = false;
                gradeLevelGB.Visible = false;
                creditsReqLabel.Visible = false;
                creditCountReqCB.Visible = false;
                creditCountReqLabel.Visible = false;
                creditsCountReqTB.Visible = false;
            }
        }

        private void gradeLevelReqCB_CheckedChanged(object sender, EventArgs e)
        {
            if(gradeLevelReqCB.Checked)
            {
                FreshmanRB.Visible = true;
                sophmoreRB.Visible = true;
                juniorRB.Visible = true;
                seniorRB.Visible = true;
                gradeLevelGB.Visible = true;
            }
            else
            {
                FreshmanRB.Visible = false;
                sophmoreRB.Visible = false;
                juniorRB.Visible = false;
                seniorRB.Visible = false;
                gradeLevelGB.Visible = false;
            }
        }

        private void creditCountReqCB_CheckedChanged(object sender, EventArgs e)
        {
            if(creditCountReqCB.Checked)
            {
                creditCountReqLabel.Visible = true;
                creditsCountReqTB.Visible = true;
            }
            else
            {
                creditCountReqLabel.Visible = false;
                creditsCountReqTB.Visible = false;
            }
        }
    }
}
