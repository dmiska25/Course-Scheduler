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
    public partial class SemesterEdit : SemesterAdd
    {
        private List<Semester> semesterList;
        private Semester editSemester;

        public SemesterEdit(ref List<Semester> semesterList, Semester editSemester)
            : base(ref semesterList)
        {
            InitializeComponent();

            //set values
            this.semesterList = semesterList;
            this.editSemester = editSemester;

            //pre stuff
            //change title
            this.Text = "Edit Semester";
            //change add button
            this.addSemesterButton.Text = "Edit Semester";

            //set all text boxes to editSemester values
            yearTB.Text = editSemester.Year.ToString();
            termTB.Text = editSemester.Term.ToString();
            minCreditsTB.Text = editSemester.MinCredits.ToString();
            maxCreditsTB.Text = editSemester.MaxCredits.ToString();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        protected override void addSemesterButton_Click(object sender, EventArgs e)
        {
            //variables
            int year;
            TermEnums term;
            int minCredits;
            int maxCredits;
            Semester editedSemester;


            try
            {
                //attempt to parse text boxes
                year = parseYear(yearTB.Text);
                term = parseTerm(termTB.Text);
                verifyCredits(minCreditsTB.Text, maxCreditsTB.Text, out minCredits, out maxCredits);


                //attempt to create Semester object
                editedSemester = new Semester(year, term);
                editedSemester.MaxCredits = maxCredits;
                editedSemester.MinCredits = minCredits;

                //check that the semester does not already exist, if reference change 
                if (!editedSemester.Equals(editSemester))
                {
                    if (semesterList.Contains(editedSemester))
                    {
                        throw new Exception("The Semester already exists!");
                    }
                }

                //replace edited semester object
                semesterList.Remove(editSemester);
                semesterList.Add(editedSemester);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
