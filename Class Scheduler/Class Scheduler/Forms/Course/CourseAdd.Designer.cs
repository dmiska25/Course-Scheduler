namespace Class_Scheduler
{
    partial class CourseAdd
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.courseDependencyLabel = new System.Windows.Forms.Label();
            this.courseNameTB = new System.Windows.Forms.TextBox();
            this.courseIDTB = new System.Windows.Forms.TextBox();
            this.courseCreditsTB = new System.Windows.Forms.TextBox();
            this.ListCourseToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.courseDependenciesTB = new System.Windows.Forms.TextBox();
            this.addCourseButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.coursePrefixLabel = new System.Windows.Forms.Label();
            this.coursePrefixTB = new System.Windows.Forms.TextBox();
            this.validSemestersTB = new System.Windows.Forms.TextBox();
            this.courseValidSemLabel = new System.Windows.Forms.Label();
            this.courseCopendenciesTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.courseDescriptionLabel = new System.Windows.Forms.Label();
            this.courseDescriptionTB = new System.Windows.Forms.TextBox();
            this.advancedDetailsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Course Name: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Course ID: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Credits: ";
            // 
            // courseDependencyLabel
            // 
            this.courseDependencyLabel.AutoSize = true;
            this.courseDependencyLabel.Location = new System.Drawing.Point(13, 236);
            this.courseDependencyLabel.Name = "courseDependencyLabel";
            this.courseDependencyLabel.Size = new System.Drawing.Size(287, 13);
            this.courseDependencyLabel.TabIndex = 3;
            this.courseDependencyLabel.Text = "List Course Dependencies ie. CSCI 231,Math 452,Stat 121:";
            // 
            // courseNameTB
            // 
            this.courseNameTB.Location = new System.Drawing.Point(106, 13);
            this.courseNameTB.Name = "courseNameTB";
            this.courseNameTB.Size = new System.Drawing.Size(280, 20);
            this.courseNameTB.TabIndex = 0;
            // 
            // courseIDTB
            // 
            this.courseIDTB.Location = new System.Drawing.Point(106, 59);
            this.courseIDTB.Name = "courseIDTB";
            this.courseIDTB.Size = new System.Drawing.Size(88, 20);
            this.courseIDTB.TabIndex = 2;
            // 
            // courseCreditsTB
            // 
            this.courseCreditsTB.Location = new System.Drawing.Point(106, 81);
            this.courseCreditsTB.Name = "courseCreditsTB";
            this.courseCreditsTB.Size = new System.Drawing.Size(88, 20);
            this.courseCreditsTB.TabIndex = 3;
            // 
            // courseDependenciesTB
            // 
            this.courseDependenciesTB.Location = new System.Drawing.Point(12, 252);
            this.courseDependenciesTB.Name = "courseDependenciesTB";
            this.courseDependenciesTB.Size = new System.Drawing.Size(374, 20);
            this.courseDependenciesTB.TabIndex = 4;
            // 
            // addCourseButton
            // 
            this.addCourseButton.Location = new System.Drawing.Point(27, 423);
            this.addCourseButton.Name = "addCourseButton";
            this.addCourseButton.Size = new System.Drawing.Size(125, 23);
            this.addCourseButton.TabIndex = 8;
            this.addCourseButton.Text = "Add Course";
            this.addCourseButton.UseVisualStyleBackColor = true;
            this.addCourseButton.Click += new System.EventHandler(this.addCourseButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(261, 423);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(125, 23);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // coursePrefixLabel
            // 
            this.coursePrefixLabel.AutoSize = true;
            this.coursePrefixLabel.Location = new System.Drawing.Point(13, 39);
            this.coursePrefixLabel.Name = "coursePrefixLabel";
            this.coursePrefixLabel.Size = new System.Drawing.Size(69, 13);
            this.coursePrefixLabel.TabIndex = 12;
            this.coursePrefixLabel.Text = "Course Prefix";
            // 
            // coursePrefixTB
            // 
            this.coursePrefixTB.Location = new System.Drawing.Point(106, 36);
            this.coursePrefixTB.Name = "coursePrefixTB";
            this.coursePrefixTB.Size = new System.Drawing.Size(88, 20);
            this.coursePrefixTB.TabIndex = 1;
            // 
            // validSemestersTB
            // 
            this.validSemestersTB.Location = new System.Drawing.Point(12, 330);
            this.validSemestersTB.Name = "validSemestersTB";
            this.validSemestersTB.Size = new System.Drawing.Size(374, 20);
            this.validSemestersTB.TabIndex = 6;
            // 
            // courseValidSemLabel
            // 
            this.courseValidSemLabel.AutoSize = true;
            this.courseValidSemLabel.Location = new System.Drawing.Point(13, 314);
            this.courseValidSemLabel.Name = "courseValidSemLabel";
            this.courseValidSemLabel.Size = new System.Drawing.Size(185, 13);
            this.courseValidSemLabel.TabIndex = 14;
            this.courseValidSemLabel.Text = "List valid Terms(Fall, Spring, Summer):";
            // 
            // courseCopendenciesTB
            // 
            this.courseCopendenciesTB.Location = new System.Drawing.Point(12, 291);
            this.courseCopendenciesTB.Name = "courseCopendenciesTB";
            this.courseCopendenciesTB.Size = new System.Drawing.Size(374, 20);
            this.courseCopendenciesTB.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 275);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(286, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "List Course Copendencies ie. CSCI 231,Math 452,Stat 121:";
            // 
            // courseDescriptionLabel
            // 
            this.courseDescriptionLabel.AutoSize = true;
            this.courseDescriptionLabel.Location = new System.Drawing.Point(14, 116);
            this.courseDescriptionLabel.Name = "courseDescriptionLabel";
            this.courseDescriptionLabel.Size = new System.Drawing.Size(99, 13);
            this.courseDescriptionLabel.TabIndex = 16;
            this.courseDescriptionLabel.Text = "Course Description:";
            // 
            // courseDescriptionTB
            // 
            this.courseDescriptionTB.Location = new System.Drawing.Point(12, 132);
            this.courseDescriptionTB.Multiline = true;
            this.courseDescriptionTB.Name = "courseDescriptionTB";
            this.courseDescriptionTB.Size = new System.Drawing.Size(374, 86);
            this.courseDescriptionTB.TabIndex = 17;
            // 
            // advancedDetailsButton
            // 
            this.advancedDetailsButton.Location = new System.Drawing.Point(27, 356);
            this.advancedDetailsButton.Name = "advancedDetailsButton";
            this.advancedDetailsButton.Size = new System.Drawing.Size(125, 23);
            this.advancedDetailsButton.TabIndex = 18;
            this.advancedDetailsButton.Text = "Advanced Details";
            this.advancedDetailsButton.UseVisualStyleBackColor = true;
            this.advancedDetailsButton.Click += new System.EventHandler(this.advancedDetailsButton_Click);
            // 
            // CourseAdd
            // 
            this.AcceptButton = this.addCourseButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(415, 458);
            this.Controls.Add(this.advancedDetailsButton);
            this.Controls.Add(this.courseDescriptionTB);
            this.Controls.Add(this.courseDescriptionLabel);
            this.Controls.Add(this.courseCopendenciesTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.validSemestersTB);
            this.Controls.Add(this.courseValidSemLabel);
            this.Controls.Add(this.coursePrefixTB);
            this.Controls.Add(this.coursePrefixLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addCourseButton);
            this.Controls.Add(this.courseNameTB);
            this.Controls.Add(this.courseDependenciesTB);
            this.Controls.Add(this.courseCreditsTB);
            this.Controls.Add(this.courseIDTB);
            this.Controls.Add(this.courseDependencyLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CourseAdd";
            this.Text = " ";
            this.Load += new System.EventHandler(this.CourseAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label courseDependencyLabel;
        private System.Windows.Forms.ToolTip ListCourseToolTip;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label coursePrefixLabel;
        private System.Windows.Forms.Label courseValidSemLabel;
        protected System.Windows.Forms.Button addCourseButton;
        protected System.Windows.Forms.TextBox courseNameTB;
        protected System.Windows.Forms.TextBox courseIDTB;
        protected System.Windows.Forms.TextBox courseCreditsTB;
        protected System.Windows.Forms.TextBox courseDependenciesTB;
        protected System.Windows.Forms.TextBox coursePrefixTB;
        protected System.Windows.Forms.TextBox validSemestersTB;
        protected System.Windows.Forms.TextBox courseCopendenciesTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label courseDescriptionLabel;
        private System.Windows.Forms.Button advancedDetailsButton;
        protected System.Windows.Forms.TextBox courseDescriptionTB;
    }
}