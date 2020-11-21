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
    public partial class CourseAddDetails : Form
    {
        //field
        private CourseDetails _courseDetails;
        //property
        public CourseDetails courseDetails { get { return _courseDetails; } set { _courseDetails = value; } }

        public CourseAddDetails()
        {
            InitializeComponent();
        }

        private void CourseAddDetails_Load(object sender, EventArgs e)
        {
            //if form object already contains valid _courseDetails, load values
            if (object.ReferenceEquals(null, _courseDetails))
            {
                //create default Course Details
                _courseDetails = new CourseDetails();
                _courseDetails.UndergraduateLevel = true;
            }
            else
            {
                //load values
                if (!object.ReferenceEquals(null, _courseDetails.CreditsRequired))
                {
                    this.minimumCreditsCB.Checked = true;
                    this.minimumCreditsRequiredTB.Text = _courseDetails.CreditsRequired.ToString();
                }
                if (!object.ReferenceEquals(null, _courseDetails.YearBase))
                {
                    this.yearRotationCB.Checked = true;
                    this.yearBaseTB.Text = _courseDetails.YearBase.ToString();
                    this.yearMultipleTB.Text = _courseDetails.YearMultiple.ToString();
                }
                if (!_courseDetails.RequiredStanding.Equals(Objects.Standing.FRESHMAN))
                {
                    this.standingRequirementCB.Checked = true;
                    switch (_courseDetails.RequiredStanding)
                    {
                        case Objects.Standing.FRESHMAN:
                            this.standingFreshmenRB.Checked = true;
                            break;
                        case Objects.Standing.SOPHOMORE:
                            this.standingSophmoreRB.Checked = true;
                            break;
                        case Objects.Standing.JUNIOR:
                            this.standingJuniorRB.Checked = true;
                            break;
                        case Objects.Standing.SENIOR:
                            this.standingSeniorRB.Checked = true;
                            break;
                    }
                }

                if (_courseDetails.GraduateLevel)
                    this.courseTypeGRB.Checked = true;

                if (_courseDetails.GeneralElective)
                    this.generalElectiveCB.Checked = true;
                if (_courseDetails.DegreeElective)
                    this.degreeElectiveCB.Checked = true;
                if (_courseDetails.DualCredit)
                    this.dualCreditCB.Checked = true;
            }
            
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            int temp;
            // Initiate new CourseDetails
            _courseDetails = new CourseDetails();

            // Test each aspect to skip or add it to details struct
            if (minimumCreditsCB.Checked) {
                if (!int.TryParse(minimumCreditsRequiredTB.Text, out temp))
                    throw new Exception("Invalid integer value in Minimum Credits Text Box!");
                _courseDetails.CreditsRequired = temp;

            }

            if (yearRotationCB.Checked)
            {
                if (!int.TryParse(yearBaseTB.Text, out temp))
                    throw new Exception("Invalid integer value in Year Base Text Box!");
                _courseDetails.YearBase = temp;

                if (!int.TryParse(yearMultipleTB.Text, out temp))
                    throw new Exception("Invalid integer value in Year Multiple Text Box!");
                _courseDetails.YearMultiple = temp;
            }

            if (standingRequirementCB.Checked)
            {
                if (standingFreshmenRB.Checked)
                    _courseDetails.RequiredStanding = Objects.Standing.FRESHMAN;
                else if (standingSophmoreRB.Checked)
                    _courseDetails.RequiredStanding = Objects.Standing.SOPHOMORE;
                else if (standingJuniorRB.Checked)
                    _courseDetails.RequiredStanding = Objects.Standing.JUNIOR;
                else
                    _courseDetails.RequiredStanding = Objects.Standing.SENIOR;
            }

            // course type
            if (courseTypeUGRB.Checked)
                _courseDetails.UndergraduateLevel = true;
            else
                _courseDetails.GraduateLevel = true;

            //other details
            if (generalElectiveCB.Checked)
                _courseDetails.GeneralElective = true;
            else
                _courseDetails.GeneralElective = false;
            if (degreeElectiveCB.Checked)
                _courseDetails.DegreeElective = true;
            else
                _courseDetails.DegreeElective = false;
            if (dualCreditCB.Checked)
                _courseDetails.DualCredit = true;
            else
                _courseDetails.DualCredit = false;

            //close the form
            this.Close();
        }



        //enable or disable various aspects
        private void minimumCreditsCB_CheckedChanged(object sender, EventArgs e)
        {
            if (minimumCreditsCB.Checked)
            {
                minimumCreditsLabel.Enabled = true;
                minimumCreditsRequiredTB.Enabled = true;
            }
            else
            {
                minimumCreditsLabel.Enabled = false;
                minimumCreditsRequiredTB.Enabled = false;
            }
        }

        private void yearRotationCB_CheckedChanged(object sender, EventArgs e)
        {
            if (yearRotationCB.Checked)
            {
                yearBaseLabel.Enabled = true;
                yearBaseTB.Enabled = true;
                yearMultipleLabel.Enabled = true;
                yearMultipleTB.Enabled = true;
            }
            else
            {
                yearBaseLabel.Enabled = false;
                yearBaseTB.Enabled = false;
                yearMultipleLabel.Enabled = false;
                yearMultipleTB.Enabled = false;
            }
        }

        private void standingRequirementCB_CheckedChanged(object sender, EventArgs e)
        {
            if (standingRequirementCB.Checked)
            {
                standingFreshmenRB.Enabled = true;
                standingSophmoreRB.Enabled = true;
                standingJuniorRB.Enabled = true;
                standingSeniorRB.Enabled = true;
            }
            else
            {
                standingFreshmenRB.Enabled = false;
                standingSophmoreRB.Enabled = false;
                standingJuniorRB.Enabled = false;
                standingSeniorRB.Enabled = false;
            }
        }

    }
}
