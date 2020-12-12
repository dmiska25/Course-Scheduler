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
    public partial class ElementViewer : Form
    {
        //componenets to view
        private List<String> elements;



        public ElementViewer(ref List<String> elements, String title)
        {
            InitializeComponent();
            this.elements = elements;

            this.Text = title;
        }

        private void ElementViewer_Load(object sender, EventArgs e)
        {
            String viewerString = "";

            //load the elements into the viewer
            foreach(String element in elements)
            {
                viewerString += element+'\n';
            }

            //send the string to the label
            ElementViewerLabel.Text = viewerString;

            //set opening position
            this.StartPosition = FormStartPosition.Manual;
            this.Location = Application.OpenForms[0].Location;

            //adjust size to label
            int width = ElementViewerLabel.Location.X * 5 + ElementViewerLabel.Width;
            int height = ElementViewerLabel.Location.Y * 4 + ElementViewerLabel.Height + closeButton.Height * 2;
            this.ClientSize = new Size(width, height);

            //set the close button position
            int x = this.Width / 2 - closeButton.Width/2;
            int y = this.Height - closeButton.Height * 3;
            closeButton.Location = new Point(x,y);
        }


        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
