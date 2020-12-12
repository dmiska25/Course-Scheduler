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
    public partial class ScheduleResultView : Form
    {
        public ScheduleResultView()
        {
            InitializeComponent();
        }

        private void ScheduleResultView_ResizeEnd(object sender, EventArgs e)
        {
            //on resize, also resize tree view and reposition label

            //first move label
            potentialScheduleLabel.SetBounds(this.Width / 2 - potentialScheduleLabel.Size.Width / 2,
                potentialScheduleLabel.Size.Height / 2,
                potentialScheduleLabel.Size.Width, potentialScheduleLabel.Size.Height);

            //then resize tree view
            scheduleViewer.SetBounds(10, potentialScheduleLabel.Size.Height * 2,
                this.Width - 40, this.Height - 50 - potentialScheduleLabel.Size.Height * 2);

        }
    }
}
