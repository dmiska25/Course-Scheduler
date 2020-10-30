using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Class_Scheduler
{
    public partial class PromptWindow : Form
    {
        // field
        private bool _result;

        //property
        public bool Result { get { return _result; } }

        public PromptWindow(String message)
        {
            InitializeComponent();
            this.promptLabel.Text = message;
        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            _result = true;
            this.Close();
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            _result = false;
            this.Close();
        }
    }
}
