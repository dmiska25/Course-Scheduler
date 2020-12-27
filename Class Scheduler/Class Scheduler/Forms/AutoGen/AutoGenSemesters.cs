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

namespace Class_Scheduler.Forms.AutoGen
{
    public partial class AutoGenSemesters : Form
    {
        // field
        private List<Semester> _genedSemestersList;

        // property
        public List<Semester> GeneratedSemesterList { get => _genedSemestersList; }



        public AutoGenSemesters()
        {
            InitializeComponent();
        }

        private void autoGenSemButton_Click(object sender, EventArgs e)
        {
            try
            {


                // store semesters in a new list
                List<Semester> genedSemesters = new List<Semester>();

                // Calculate semester atributes

                //- try to grab number of semesters to generate
                int numSemToGen = 0;
                if (!int.TryParse(numSemToGenTB.Text, out numSemToGen)
                    || numSemToGen < 0)
                    throw new Exception("Invalid Number of Semesters!");

                Console.WriteLine(System.DateTime.Now.Year);

                //- try to get starting year
                int startingYear = 0;
                if (!int.TryParse(startingYearTB.Text, out startingYear)
                    || startingYear < System.DateTime.Now.Year)
                    throw new Exception(" Invalid Starting Year! Must be at least current year.");

                //- try to get minimum credits
                int miniCred = 0;
                if (!int.TryParse(minimumCreditsTB.Text, out miniCred)
                    || miniCred < 0)
                    throw new Exception("Invalid minimum credits! must be valid positive integer.");

                //- try to get maximum credits
                int maxCred = 0;
                if (!int.TryParse(maximumCreditsTB.Text, out maxCred)
                    || maxCred < miniCred)
                    throw new Exception("Invalid maximum credits! Must be valid positive integer" +
                        "greater than minimum credits.");
                
                //- Set min/max Summer credits if option selected
                int sumMinCred = 0;
                int sumMaxCred = 0;
                if (includeSumTermCB.Checked) 
                {
                    //- try to get minimum summer credits
                    
                    if (!int.TryParse(sumMinCreditsTB.Text, out sumMinCred)
                        || sumMinCred < 0)
                        throw new Exception("Invalid minimum summer credits! must be valid positive integer.");

                    //- try to get maximum summer credits
                    
                    if (!int.TryParse(sumMaxCreditsTB.Text, out sumMaxCred)
                        || sumMaxCred < sumMinCred)
                        throw new Exception("Invalid maximum summer credits! Must be valid positive integer" +
                            "greater than minimum summer credits.");
                }

                //- try to get starting term
                TermEnums startingTerm;
                if (fallRB.Checked) startingTerm = TermEnums.FALL;
                else if (springRB.Checked) startingTerm = TermEnums.SPRING;
                else if (summerRB.Checked) startingTerm = TermEnums.SUMMER;
                else throw new Exception("Starting term must be selected!");

                //- set other options
                bool summerTerms = includeSumTermCB.Checked;
                bool overloading = overloadingCB.Checked;


                // generate semesters
                int currentYear = startingYear;
                TermEnums currentTerm = startingTerm;

                for (int i = 0; i < numSemToGen; i++)
                {
                    // create next semester
                    Semester sem = new Semester(currentYear, currentTerm);
                    if(!currentTerm.Equals(TermEnums.SUMMER))
                    {
                        sem.MinCredits = miniCred;
                        sem.MaxCredits = maxCred;
                    }
                    else
                    {
                        sem.MinCredits = sumMinCred;
                        sem.MaxCredits = sumMaxCred;
                    }
                    
                    sem.IsOverloadable = overloading;

                    // add to list
                    genedSemesters.Add(sem);

                    //calculate next year and term
                    if (currentTerm.Equals(TermEnums.SPRING))
                    {
                        if (summerTerms) currentTerm = TermEnums.SUMMER;
                        else currentTerm = TermEnums.FALL;
                    }
                    else if (currentTerm.Equals(TermEnums.SUMMER))
                        currentTerm = TermEnums.FALL;
                    else if (currentTerm.Equals(TermEnums.FALL))
                    {
                        currentTerm = TermEnums.SPRING;
                        currentYear++;
                    }
                    else
                        throw new Exception("Error when calculating new year/term!");
                }

                _genedSemestersList = genedSemesters;

            }
            catch ( Exception ex )
            {
                // display error message
                MessageBox.Show(ex.Message);
                return;
            }

            // close the form
            this.Close();

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            // close form
            this.Close();
        }

        private void includeSumTermCB_CheckedChanged(object sender, EventArgs e)
        {
            if(includeSumTermCB.Checked)
            {
                sumMinCreditsLabel.Visible = true;
                sumMaxCreditsLabel.Visible = true;
                sumMinCreditsTB.Visible = true;
                sumMaxCreditsTB.Visible = true;
            }
            else
            {
                sumMinCreditsLabel.Visible = false;
                sumMaxCreditsLabel.Visible = false;
                sumMinCreditsTB.Visible = false;
                sumMaxCreditsTB.Visible = false;
            }
        }
    }
}
