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

namespace Class_Scheduler.Forms.SemesterForms
{
    public partial class SemesterAdd : Form
    {
        private List<Semester> semesterList;
        private Semester semester;
        public Semester Semester { get { return semester; } }



        public SemesterAdd(ref List<Semester> semesterList)
        {
            InitializeComponent();
            this.semesterList = new List<Semester>(semesterList);

            //set opening position
            this.StartPosition = FormStartPosition.Manual;
            this.Location = Application.OpenForms[0].Location;
        }

        private void SemesterAdd_Load(object sender, EventArgs e)
        {

        }

        protected virtual void addSemesterButton_Click(object sender, EventArgs e)
        {
            //variables
            int year;
            TermEnums term;
            int minCredits;
            int maxCredits;


            try
            {
                //attempt to parse text boxes
                year = parseYear(yearTB.Text);
                term = parseTerm(termTB.Text);
                verifyCredits(minCreditsTB.Text, maxCreditsTB.Text, out minCredits, out maxCredits);


                //attempt to create Semester object
                semester = new Semester(year, term);
                semester.MaxCredits = maxCredits;
                semester.MinCredits = minCredits;

                //check that the semester does not already exist
                if (semesterList.Contains(semester))
                {
                    semester = null;
                    throw new Exception("The Semester already exists!");
                }

                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //non event methods
        protected void verifyCredits(String minTB, String maxTB, out int min, out int max)
        { 
            if(!int.TryParse(minTB, out min)) { throw new Exception("Invalid minimum credits value!"); }
            if(!int.TryParse(maxTB, out max)) { throw new Exception("Invalid maximum credits value!"); }

            //ensure positive
            if (min <= 0 || max <= 0) { throw new Exception("Credits must be more than 0!"); }

            //ensure reasonable quantity
            if (min > 50 || max > 50) { throw new Exception("Credits cannot be more than 50!"); }

            //ensure min is less than or equal to max
            if (min > max) { throw new Exception("Minimum credits cannot be more than Maximum credits!"); }
        }

        protected int parseYear(String yearString)
        {
            //variables
            int currentYear = DateTime.Today.Year;
            int parsedYear;

            //attempt to parse int
            if (!int.TryParse(yearString, out parsedYear)) 
            { throw new Exception("Invalid Year!"); }

            //verify that the year is current
            if (parsedYear < currentYear)
            { throw new Exception("Semester Year cannot be in the past!"); }

            return parsedYear;
        }

        protected TermEnums parseTerm(String termString)
        {
            //make everything uppercase
            termString = termString.ToUpper();

            //remove space from begining and end of the string
            termString = termString.Trim();

            //determine term
            switch(termString)
            {
                case "FALL":
                    return TermEnums.FALL;
                case "SUMMER":
                    return TermEnums.SUMMER;
                case "SPRING":
                    return TermEnums.SPRING;
                default:
                    throw new Exception
                        (termString + " is not a valid term! Valid terms are Fall, Summer, or Spring.");
            }
        }


    }
}
