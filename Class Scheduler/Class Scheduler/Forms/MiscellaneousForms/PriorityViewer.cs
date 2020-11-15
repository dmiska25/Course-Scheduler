using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Class_Scheduler.Objects;

namespace Class_Scheduler.Forms.MiscellaneousForms
{
    public partial class PriorityViewer<T> : Form
    {
        //variables
        private List<T> itemList;
        private List<T> priorityList;



        public PriorityViewer(IEnumerable<T> items)
        {
            InitializeComponent();
            itemList = new List<T>(items);
            foreach( var item in itemList )
            {
                itemList1.Items.Add(item.ToString());
            }
        }

        private void PriorityViewer_Load(object sender, EventArgs e)
        {

        }

        private void moveRightButton_Click(object sender, EventArgs e)
        {

        }

        private void moveLeftButton_Click(object sender, EventArgs e)
        {

        }

        private void upButton_Click(object sender, EventArgs e)
        {

        }

        private void downButton_Click(object sender, EventArgs e)
        {

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
