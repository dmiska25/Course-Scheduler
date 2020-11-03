namespace Class_Scheduler.Forms.Course
{
    partial class CourseAddDetails
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
            this.requirementsLabel = new System.Windows.Forms.Label();
            this.minimumCreditsCB = new System.Windows.Forms.CheckBox();
            this.yearRotationCB = new System.Windows.Forms.CheckBox();
            this.standingRequirementCB = new System.Windows.Forms.CheckBox();
            this.courseTypeUGRB = new System.Windows.Forms.RadioButton();
            this.courseTypeGRB = new System.Windows.Forms.RadioButton();
            this.generalElectiveCB = new System.Windows.Forms.CheckBox();
            this.degreeElectiveCB = new System.Windows.Forms.CheckBox();
            this.dualCreditCB = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.yearBaseLabel = new System.Windows.Forms.Label();
            this.yearBaseTB = new System.Windows.Forms.TextBox();
            this.yearMultipleLabel = new System.Windows.Forms.Label();
            this.yearMultipleTB = new System.Windows.Forms.TextBox();
            this.minimumCreditsLabel = new System.Windows.Forms.Label();
            this.minimumCreditsRequiredTB = new System.Windows.Forms.TextBox();
            this.standingFreshmenRB = new System.Windows.Forms.RadioButton();
            this.standingSophmoreRB = new System.Windows.Forms.RadioButton();
            this.standingJuniorRB = new System.Windows.Forms.RadioButton();
            this.standingSeniorRB = new System.Windows.Forms.RadioButton();
            this.segment1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.courseTypeGB = new System.Windows.Forms.GroupBox();
            this.courseTypeGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // requirementsLabel
            // 
            this.requirementsLabel.AutoSize = true;
            this.requirementsLabel.Location = new System.Drawing.Point(12, 9);
            this.requirementsLabel.Name = "requirementsLabel";
            this.requirementsLabel.Size = new System.Drawing.Size(75, 13);
            this.requirementsLabel.TabIndex = 0;
            this.requirementsLabel.Text = "Requirements:";
            // 
            // minimumCreditsCB
            // 
            this.minimumCreditsCB.AutoSize = true;
            this.minimumCreditsCB.Location = new System.Drawing.Point(13, 26);
            this.minimumCreditsCB.Name = "minimumCreditsCB";
            this.minimumCreditsCB.Size = new System.Drawing.Size(164, 17);
            this.minimumCreditsCB.TabIndex = 0;
            this.minimumCreditsCB.Text = "minimum credits requirement?";
            this.minimumCreditsCB.UseVisualStyleBackColor = true;
            this.minimumCreditsCB.CheckedChanged += new System.EventHandler(this.minimumCreditsCB_CheckedChanged);
            // 
            // yearRotationCB
            // 
            this.yearRotationCB.AutoSize = true;
            this.yearRotationCB.Location = new System.Drawing.Point(13, 66);
            this.yearRotationCB.Name = "yearRotationCB";
            this.yearRotationCB.Size = new System.Drawing.Size(90, 17);
            this.yearRotationCB.TabIndex = 2;
            this.yearRotationCB.Text = "year rotation?";
            this.yearRotationCB.UseVisualStyleBackColor = true;
            this.yearRotationCB.CheckedChanged += new System.EventHandler(this.yearRotationCB_CheckedChanged);
            // 
            // standingRequirementCB
            // 
            this.standingRequirementCB.AutoSize = true;
            this.standingRequirementCB.Location = new System.Drawing.Point(12, 107);
            this.standingRequirementCB.Name = "standingRequirementCB";
            this.standingRequirementCB.Size = new System.Drawing.Size(130, 17);
            this.standingRequirementCB.TabIndex = 5;
            this.standingRequirementCB.Text = "standing requirement?";
            this.standingRequirementCB.UseVisualStyleBackColor = true;
            this.standingRequirementCB.CheckedChanged += new System.EventHandler(this.standingRequirementCB_CheckedChanged);
            // 
            // courseTypeUGRB
            // 
            this.courseTypeUGRB.AutoSize = true;
            this.courseTypeUGRB.Checked = true;
            this.courseTypeUGRB.Location = new System.Drawing.Point(29, 0);
            this.courseTypeUGRB.Name = "courseTypeUGRB";
            this.courseTypeUGRB.Size = new System.Drawing.Size(135, 17);
            this.courseTypeUGRB.TabIndex = 10;
            this.courseTypeUGRB.TabStop = true;
            this.courseTypeUGRB.Text = "undergraduate course?";
            this.courseTypeUGRB.UseVisualStyleBackColor = true;
            // 
            // courseTypeGRB
            // 
            this.courseTypeGRB.AutoSize = true;
            this.courseTypeGRB.Location = new System.Drawing.Point(170, 0);
            this.courseTypeGRB.Name = "courseTypeGRB";
            this.courseTypeGRB.Size = new System.Drawing.Size(108, 17);
            this.courseTypeGRB.TabIndex = 11;
            this.courseTypeGRB.Text = "graduate course?";
            this.courseTypeGRB.UseVisualStyleBackColor = true;
            // 
            // generalElectiveCB
            // 
            this.generalElectiveCB.AutoSize = true;
            this.generalElectiveCB.Location = new System.Drawing.Point(12, 209);
            this.generalElectiveCB.Name = "generalElectiveCB";
            this.generalElectiveCB.Size = new System.Drawing.Size(101, 17);
            this.generalElectiveCB.TabIndex = 12;
            this.generalElectiveCB.Text = "general elective";
            this.generalElectiveCB.UseVisualStyleBackColor = true;
            // 
            // degreeElectiveCB
            // 
            this.degreeElectiveCB.AutoSize = true;
            this.degreeElectiveCB.Location = new System.Drawing.Point(12, 232);
            this.degreeElectiveCB.Name = "degreeElectiveCB";
            this.degreeElectiveCB.Size = new System.Drawing.Size(99, 17);
            this.degreeElectiveCB.TabIndex = 13;
            this.degreeElectiveCB.Text = "degree elective";
            this.degreeElectiveCB.UseVisualStyleBackColor = true;
            // 
            // dualCreditCB
            // 
            this.dualCreditCB.AutoSize = true;
            this.dualCreditCB.Location = new System.Drawing.Point(11, 255);
            this.dualCreditCB.Name = "dualCreditCB";
            this.dualCreditCB.Size = new System.Drawing.Size(75, 17);
            this.dualCreditCB.TabIndex = 14;
            this.dualCreditCB.Text = "dual credit";
            this.dualCreditCB.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Course Types:";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(122, 289);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 15;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // yearBaseLabel
            // 
            this.yearBaseLabel.AutoSize = true;
            this.yearBaseLabel.Enabled = false;
            this.yearBaseLabel.Location = new System.Drawing.Point(12, 86);
            this.yearBaseLabel.Name = "yearBaseLabel";
            this.yearBaseLabel.Size = new System.Drawing.Size(59, 13);
            this.yearBaseLabel.TabIndex = 11;
            this.yearBaseLabel.Text = "Year Base:";
            // 
            // yearBaseTB
            // 
            this.yearBaseTB.Enabled = false;
            this.yearBaseTB.Location = new System.Drawing.Point(77, 83);
            this.yearBaseTB.Name = "yearBaseTB";
            this.yearBaseTB.Size = new System.Drawing.Size(67, 20);
            this.yearBaseTB.TabIndex = 3;
            // 
            // yearMultipleLabel
            // 
            this.yearMultipleLabel.AutoSize = true;
            this.yearMultipleLabel.Enabled = false;
            this.yearMultipleLabel.Location = new System.Drawing.Point(148, 86);
            this.yearMultipleLabel.Name = "yearMultipleLabel";
            this.yearMultipleLabel.Size = new System.Drawing.Size(71, 13);
            this.yearMultipleLabel.TabIndex = 13;
            this.yearMultipleLabel.Text = "Year Multiple:";
            // 
            // yearMultipleTB
            // 
            this.yearMultipleTB.Enabled = false;
            this.yearMultipleTB.Location = new System.Drawing.Point(225, 83);
            this.yearMultipleTB.Name = "yearMultipleTB";
            this.yearMultipleTB.Size = new System.Drawing.Size(71, 20);
            this.yearMultipleTB.TabIndex = 4;
            // 
            // minimumCreditsLabel
            // 
            this.minimumCreditsLabel.AutoSize = true;
            this.minimumCreditsLabel.Enabled = false;
            this.minimumCreditsLabel.Location = new System.Drawing.Point(12, 46);
            this.minimumCreditsLabel.Name = "minimumCreditsLabel";
            this.minimumCreditsLabel.Size = new System.Drawing.Size(132, 13);
            this.minimumCreditsLabel.TabIndex = 15;
            this.minimumCreditsLabel.Text = "Minimum Credits Required:";
            // 
            // minimumCreditsRequiredTB
            // 
            this.minimumCreditsRequiredTB.Enabled = false;
            this.minimumCreditsRequiredTB.Location = new System.Drawing.Point(150, 43);
            this.minimumCreditsRequiredTB.Name = "minimumCreditsRequiredTB";
            this.minimumCreditsRequiredTB.Size = new System.Drawing.Size(124, 20);
            this.minimumCreditsRequiredTB.TabIndex = 1;
            // 
            // standingFreshmenRB
            // 
            this.standingFreshmenRB.AutoSize = true;
            this.standingFreshmenRB.Checked = true;
            this.standingFreshmenRB.Enabled = false;
            this.standingFreshmenRB.Location = new System.Drawing.Point(22, 130);
            this.standingFreshmenRB.Name = "standingFreshmenRB";
            this.standingFreshmenRB.Size = new System.Drawing.Size(71, 17);
            this.standingFreshmenRB.TabIndex = 6;
            this.standingFreshmenRB.TabStop = true;
            this.standingFreshmenRB.Text = "Freshman";
            this.standingFreshmenRB.UseVisualStyleBackColor = true;
            // 
            // standingSophmoreRB
            // 
            this.standingSophmoreRB.AutoSize = true;
            this.standingSophmoreRB.Enabled = false;
            this.standingSophmoreRB.Location = new System.Drawing.Point(122, 130);
            this.standingSophmoreRB.Name = "standingSophmoreRB";
            this.standingSophmoreRB.Size = new System.Drawing.Size(79, 17);
            this.standingSophmoreRB.TabIndex = 7;
            this.standingSophmoreRB.Text = "Sophomore";
            this.standingSophmoreRB.UseVisualStyleBackColor = true;
            // 
            // standingJuniorRB
            // 
            this.standingJuniorRB.AutoSize = true;
            this.standingJuniorRB.Enabled = false;
            this.standingJuniorRB.Location = new System.Drawing.Point(22, 150);
            this.standingJuniorRB.Name = "standingJuniorRB";
            this.standingJuniorRB.Size = new System.Drawing.Size(53, 17);
            this.standingJuniorRB.TabIndex = 8;
            this.standingJuniorRB.Text = "Junior";
            this.standingJuniorRB.UseVisualStyleBackColor = true;
            // 
            // standingSeniorRB
            // 
            this.standingSeniorRB.AutoSize = true;
            this.standingSeniorRB.Enabled = false;
            this.standingSeniorRB.Location = new System.Drawing.Point(122, 150);
            this.standingSeniorRB.Name = "standingSeniorRB";
            this.standingSeniorRB.Size = new System.Drawing.Size(55, 17);
            this.standingSeniorRB.TabIndex = 9;
            this.standingSeniorRB.Text = "Senior";
            this.standingSeniorRB.UseVisualStyleBackColor = true;
            // 
            // segment1
            // 
            this.segment1.AutoSize = true;
            this.segment1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.segment1.Location = new System.Drawing.Point(-10, 180);
            this.segment1.Name = "segment1";
            this.segment1.Size = new System.Drawing.Size(337, 13);
            this.segment1.TabIndex = 21;
            this.segment1.Text = "_______________________________________________________";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Location = new System.Drawing.Point(-10, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(337, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "_______________________________________________________";
            // 
            // courseTypeGB
            // 
            this.courseTypeGB.Controls.Add(this.courseTypeUGRB);
            this.courseTypeGB.Controls.Add(this.courseTypeGRB);
            this.courseTypeGB.Location = new System.Drawing.Point(-7, 173);
            this.courseTypeGB.Name = "courseTypeGB";
            this.courseTypeGB.Size = new System.Drawing.Size(320, 17);
            this.courseTypeGB.TabIndex = 23;
            this.courseTypeGB.TabStop = false;
            // 
            // CourseAddDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 329);
            this.Controls.Add(this.standingSeniorRB);
            this.Controls.Add(this.standingJuniorRB);
            this.Controls.Add(this.standingSophmoreRB);
            this.Controls.Add(this.standingFreshmenRB);
            this.Controls.Add(this.minimumCreditsRequiredTB);
            this.Controls.Add(this.minimumCreditsLabel);
            this.Controls.Add(this.yearMultipleTB);
            this.Controls.Add(this.yearMultipleLabel);
            this.Controls.Add(this.yearBaseTB);
            this.Controls.Add(this.yearBaseLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dualCreditCB);
            this.Controls.Add(this.degreeElectiveCB);
            this.Controls.Add(this.generalElectiveCB);
            this.Controls.Add(this.standingRequirementCB);
            this.Controls.Add(this.yearRotationCB);
            this.Controls.Add(this.minimumCreditsCB);
            this.Controls.Add(this.requirementsLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.courseTypeGB);
            this.Controls.Add(this.segment1);
            this.Name = "CourseAddDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CourseDetails";
            this.Load += new System.EventHandler(this.CourseAddDetails_Load);
            this.courseTypeGB.ResumeLayout(false);
            this.courseTypeGB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label requirementsLabel;
        private System.Windows.Forms.CheckBox minimumCreditsCB;
        private System.Windows.Forms.CheckBox yearRotationCB;
        private System.Windows.Forms.CheckBox standingRequirementCB;
        private System.Windows.Forms.RadioButton courseTypeUGRB;
        private System.Windows.Forms.RadioButton courseTypeGRB;
        private System.Windows.Forms.CheckBox generalElectiveCB;
        private System.Windows.Forms.CheckBox degreeElectiveCB;
        private System.Windows.Forms.CheckBox dualCreditCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label yearBaseLabel;
        private System.Windows.Forms.TextBox yearBaseTB;
        private System.Windows.Forms.Label yearMultipleLabel;
        private System.Windows.Forms.TextBox yearMultipleTB;
        private System.Windows.Forms.Label minimumCreditsLabel;
        private System.Windows.Forms.TextBox minimumCreditsRequiredTB;
        private System.Windows.Forms.RadioButton standingFreshmenRB;
        private System.Windows.Forms.RadioButton standingSophmoreRB;
        private System.Windows.Forms.RadioButton standingJuniorRB;
        private System.Windows.Forms.RadioButton standingSeniorRB;
        private System.Windows.Forms.Label segment1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox courseTypeGB;
    }
}