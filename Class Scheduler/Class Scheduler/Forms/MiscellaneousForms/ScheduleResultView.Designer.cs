namespace Class_Scheduler.Forms.MiscellaneousForms
{
    partial class ScheduleResultView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.scheduleViewer = new System.Windows.Forms.TreeView();
            this.potentialScheduleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // scheduleViewer
            // 
            this.scheduleViewer.Location = new System.Drawing.Point(12, 24);
            this.scheduleViewer.MinimumSize = new System.Drawing.Size(350, 405);
            this.scheduleViewer.Name = "scheduleViewer";
            this.scheduleViewer.Size = new System.Drawing.Size(350, 405);
            this.scheduleViewer.TabIndex = 0;
            // 
            // potentialScheduleLabel
            // 
            this.potentialScheduleLabel.AutoSize = true;
            this.potentialScheduleLabel.Location = new System.Drawing.Point(135, 8);
            this.potentialScheduleLabel.Name = "potentialScheduleLabel";
            this.potentialScheduleLabel.Size = new System.Drawing.Size(96, 13);
            this.potentialScheduleLabel.TabIndex = 1;
            this.potentialScheduleLabel.Text = "Potential Schedule";
            // 
            // ScheduleResultView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 441);
            this.Controls.Add(this.potentialScheduleLabel);
            this.Controls.Add(this.scheduleViewer);
            this.MinimumSize = new System.Drawing.Size(392, 480);
            this.Name = "ScheduleResultView";
            this.Text = "ScheduleResultView";
            this.ResizeEnd += new System.EventHandler(this.ScheduleResultView_ResizeEnd);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label potentialScheduleLabel;
        public System.Windows.Forms.TreeView scheduleViewer;
    }
}