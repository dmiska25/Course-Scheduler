namespace Class_Scheduler.Forms
{
    partial class MainForm
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
            this.optionsMenu = new System.Windows.Forms.GroupBox();
            this.overloadableLabel = new System.Windows.Forms.Label();
            this.overloadableCB = new System.Windows.Forms.CheckBox();
            this.labPairGroupingCB = new System.Windows.Forms.CheckBox();
            this.labpairLabel = new System.Windows.Forms.Label();
            this.lowerLevelCB = new System.Windows.Forms.CheckBox();
            this.prioritizeLowerLevelCourcesLabel = new System.Windows.Forms.Label();
            this.prefixPrioritiesFormButton = new System.Windows.Forms.Button();
            this.prioritizePrefixesCB = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.delayGradCoursesCB = new System.Windows.Forms.CheckBox();
            this.gradCoursesLabel = new System.Windows.Forms.Label();
            this.PriorityLabel = new System.Windows.Forms.Label();
            this.genSchedules = new System.Windows.Forms.Button();
            this.CourseView = new System.Windows.Forms.ListView();
            this.EditElementMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.semesterToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.classToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classListToTxtFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.semesterListToTxtFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classListFromTxtFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.semesterListFromTxtFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.semesterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SemesterViewer = new System.Windows.Forms.ListView();
            this.classViewLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileWindow = new System.Windows.Forms.OpenFileDialog();
            this.saveFileWindow = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
<<<<<<< HEAD
            this.scheduleCoursesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
=======
            this.generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.semestersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.electivesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
>>>>>>> master
            this.optionsMenu.SuspendLayout();
            this.EditElementMenuStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // optionsMenu
            // 
            this.optionsMenu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.optionsMenu.Controls.Add(this.overloadableLabel);
            this.optionsMenu.Controls.Add(this.overloadableCB);
            this.optionsMenu.Controls.Add(this.labPairGroupingCB);
            this.optionsMenu.Controls.Add(this.labpairLabel);
            this.optionsMenu.Controls.Add(this.lowerLevelCB);
            this.optionsMenu.Controls.Add(this.prioritizeLowerLevelCourcesLabel);
            this.optionsMenu.Controls.Add(this.prefixPrioritiesFormButton);
            this.optionsMenu.Controls.Add(this.prioritizePrefixesCB);
            this.optionsMenu.Controls.Add(this.label2);
            this.optionsMenu.Controls.Add(this.delayGradCoursesCB);
            this.optionsMenu.Controls.Add(this.gradCoursesLabel);
            this.optionsMenu.Controls.Add(this.PriorityLabel);
            this.optionsMenu.Location = new System.Drawing.Point(588, 12);
            this.optionsMenu.Name = "optionsMenu";
            this.optionsMenu.Size = new System.Drawing.Size(200, 363);
            this.optionsMenu.TabIndex = 0;
            this.optionsMenu.TabStop = false;
            this.optionsMenu.Text = "Options";
            // 
            // overloadableLabel
            // 
            this.overloadableLabel.AutoSize = true;
            this.overloadableLabel.Location = new System.Drawing.Point(13, 93);
            this.overloadableLabel.Name = "overloadableLabel";
            this.overloadableLabel.Size = new System.Drawing.Size(153, 13);
            this.overloadableLabel.TabIndex = 11;
            this.overloadableLabel.Tag = "";
            this.overloadableLabel.Text = "Enable Semester Overloading?";
            // 
            // overloadableCB
            // 
            this.overloadableCB.AutoSize = true;
            this.overloadableCB.Location = new System.Drawing.Point(172, 92);
            this.overloadableCB.Name = "overloadableCB";
            this.overloadableCB.Size = new System.Drawing.Size(15, 14);
            this.overloadableCB.TabIndex = 10;
            this.overloadableCB.UseVisualStyleBackColor = true;
            // 
            // labPairGroupingCB
            // 
            this.labPairGroupingCB.AutoSize = true;
            this.labPairGroupingCB.Location = new System.Drawing.Point(159, 80);
            this.labPairGroupingCB.Name = "labPairGroupingCB";
            this.labPairGroupingCB.Size = new System.Drawing.Size(15, 14);
            this.labPairGroupingCB.TabIndex = 9;
            this.labPairGroupingCB.UseVisualStyleBackColor = true;
            // 
            // labpairLabel
            // 
            this.labpairLabel.AutoSize = true;
            this.labpairLabel.Location = new System.Drawing.Point(13, 80);
            this.labpairLabel.Name = "labpairLabel";
            this.labpairLabel.Size = new System.Drawing.Size(140, 13);
            this.labpairLabel.TabIndex = 8;
            this.labpairLabel.Text = "Prioritize Lab Pair Grouping?";
            // 
            // lowerLevelCB
            // 
            this.lowerLevelCB.AutoSize = true;
            this.lowerLevelCB.Location = new System.Drawing.Point(173, 67);
            this.lowerLevelCB.Name = "lowerLevelCB";
            this.lowerLevelCB.Size = new System.Drawing.Size(15, 14);
            this.lowerLevelCB.TabIndex = 7;
            this.lowerLevelCB.UseVisualStyleBackColor = true;
            // 
            // prioritizeLowerLevelCourcesLabel
            // 
            this.prioritizeLowerLevelCourcesLabel.AutoSize = true;
            this.prioritizeLowerLevelCourcesLabel.Location = new System.Drawing.Point(13, 67);
            this.prioritizeLowerLevelCourcesLabel.Name = "prioritizeLowerLevelCourcesLabel";
            this.prioritizeLowerLevelCourcesLabel.Size = new System.Drawing.Size(154, 13);
            this.prioritizeLowerLevelCourcesLabel.TabIndex = 6;
            this.prioritizeLowerLevelCourcesLabel.Text = "Prioritize Lower Level Courses?";
            // 
            // prefixPrioritiesFormButton
            // 
            this.prefixPrioritiesFormButton.Enabled = false;
            this.prefixPrioritiesFormButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prefixPrioritiesFormButton.Location = new System.Drawing.Point(133, 49);
            this.prefixPrioritiesFormButton.Name = "prefixPrioritiesFormButton";
            this.prefixPrioritiesFormButton.Size = new System.Drawing.Size(59, 18);
            this.prefixPrioritiesFormButton.TabIndex = 5;
            this.prefixPrioritiesFormButton.Text = "priorities";
            this.prefixPrioritiesFormButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.prefixPrioritiesFormButton.UseVisualStyleBackColor = true;
            this.prefixPrioritiesFormButton.Click += new System.EventHandler(this.prefixPrioritiesFormButton_Click);
            // 
            // prioritizePrefixesCB
            // 
            this.prioritizePrefixesCB.AutoSize = true;
            this.prioritizePrefixesCB.Location = new System.Drawing.Point(112, 50);
            this.prioritizePrefixesCB.Name = "prioritizePrefixesCB";
            this.prioritizePrefixesCB.Size = new System.Drawing.Size(15, 14);
            this.prioritizePrefixesCB.TabIndex = 4;
            this.prioritizePrefixesCB.UseVisualStyleBackColor = true;
            this.prioritizePrefixesCB.CheckedChanged += new System.EventHandler(this.prioritizePrefixesCB_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Prioritize Prefixes?";
            // 
            // delayGradCoursesCB
            // 
            this.delayGradCoursesCB.AutoSize = true;
            this.delayGradCoursesCB.Location = new System.Drawing.Point(174, 33);
            this.delayGradCoursesCB.Name = "delayGradCoursesCB";
            this.delayGradCoursesCB.Size = new System.Drawing.Size(15, 14);
            this.delayGradCoursesCB.TabIndex = 2;
            this.delayGradCoursesCB.UseVisualStyleBackColor = true;
            // 
            // gradCoursesLabel
            // 
            this.gradCoursesLabel.AutoSize = true;
            this.gradCoursesLabel.Location = new System.Drawing.Point(10, 33);
            this.gradCoursesLabel.Name = "gradCoursesLabel";
            this.gradCoursesLabel.Size = new System.Drawing.Size(157, 13);
            this.gradCoursesLabel.TabIndex = 1;
            this.gradCoursesLabel.Text = "Delay Graduate Level Courses?";
            // 
            // PriorityLabel
            // 
            this.PriorityLabel.AutoSize = true;
            this.PriorityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PriorityLabel.Location = new System.Drawing.Point(7, 16);
            this.PriorityLabel.Name = "PriorityLabel";
            this.PriorityLabel.Size = new System.Drawing.Size(60, 13);
            this.PriorityLabel.TabIndex = 0;
            this.PriorityLabel.Text = "Priorities:";
            // 
            // genSchedules
            // 
            this.genSchedules.Location = new System.Drawing.Point(588, 381);
            this.genSchedules.Name = "genSchedules";
            this.genSchedules.Size = new System.Drawing.Size(200, 57);
            this.genSchedules.TabIndex = 1;
            this.genSchedules.Text = "Generate";
            this.genSchedules.UseVisualStyleBackColor = true;
            this.genSchedules.Click += new System.EventHandler(this.genSchedulesButton);
            // 
            // CourseView
            // 
            this.CourseView.ContextMenuStrip = this.EditElementMenuStrip;
            this.CourseView.HideSelection = false;
            this.CourseView.Location = new System.Drawing.Point(13, 49);
            this.CourseView.Name = "CourseView";
            this.CourseView.Size = new System.Drawing.Size(355, 389);
            this.CourseView.TabIndex = 2;
            this.CourseView.UseCompatibleStateImageBehavior = false;
            this.CourseView.View = System.Windows.Forms.View.List;
            this.CourseView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.CourseView_ItemSelectionChanged);
            this.CourseView.DoubleClick += new System.EventHandler(this.CourseView_DoubleClick);
            // 
            // EditElementMenuStrip
            // 
            this.EditElementMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.scheduleCoursesToolStripMenuItem});
            this.EditElementMenuStrip.Name = "EditElementMenuStrip";
            this.EditElementMenuStrip.Size = new System.Drawing.Size(181, 114);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.viewToolStripMenuItem.Text = "View";
            this.viewToolStripMenuItem.Click += new System.EventHandler(this.viewToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteToolStripMenuItem.Text = "Remove";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // addStripMenuItem
            // 
            this.addStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.semesterToolStripMenuItem1,
            this.classToolStripMenuItem});
            this.addStripMenuItem.Name = "addStripMenuItem";
            this.addStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.addStripMenuItem.Text = "Add...";
            // 
            // semesterToolStripMenuItem1
            // 
            this.semesterToolStripMenuItem1.Name = "semesterToolStripMenuItem1";
            this.semesterToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.semesterToolStripMenuItem1.Text = "Semester";
            this.semesterToolStripMenuItem1.Click += new System.EventHandler(this.semesterToolStripMenuItem1_Click);
            // 
            // classToolStripMenuItem
            // 
            this.classToolStripMenuItem.Name = "classToolStripMenuItem";
            this.classToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.classToolStripMenuItem.Text = "Course";
            this.classToolStripMenuItem.Click += new System.EventHandler(this.classToolStripMenuItem_Click);
            // 
            // saveStripMenuItem
            // 
            this.saveStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.classListToTxtFileToolStripMenuItem,
            this.semesterListToTxtFileToolStripMenuItem});
            this.saveStripMenuItem.Name = "saveStripMenuItem";
            this.saveStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.saveStripMenuItem.Text = "Save...";
            // 
            // classListToTxtFileToolStripMenuItem
            // 
            this.classListToTxtFileToolStripMenuItem.Name = "classListToTxtFileToolStripMenuItem";
            this.classListToTxtFileToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.classListToTxtFileToolStripMenuItem.Text = "Course list to txt file";
            this.classListToTxtFileToolStripMenuItem.Click += new System.EventHandler(this.classListToTxtFileToolStripMenuItem_Click);
            // 
            // semesterListToTxtFileToolStripMenuItem
            // 
            this.semesterListToTxtFileToolStripMenuItem.Name = "semesterListToTxtFileToolStripMenuItem";
            this.semesterListToTxtFileToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.semesterListToTxtFileToolStripMenuItem.Text = "Semester list to txt file";
            this.semesterListToTxtFileToolStripMenuItem.Click += new System.EventHandler(this.semesterListToTxtFileToolStripMenuItem_Click);
            // 
            // loadStripMenuItem
            // 
            this.loadStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.classListFromTxtFileToolStripMenuItem,
            this.semesterListFromTxtFileToolStripMenuItem});
            this.loadStripMenuItem.Name = "loadStripMenuItem";
            this.loadStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.loadStripMenuItem.Text = "Load...";
            // 
            // classListFromTxtFileToolStripMenuItem
            // 
            this.classListFromTxtFileToolStripMenuItem.Name = "classListFromTxtFileToolStripMenuItem";
            this.classListFromTxtFileToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.classListFromTxtFileToolStripMenuItem.Text = "Course list from txt file";
            this.classListFromTxtFileToolStripMenuItem.Click += new System.EventHandler(this.classListFromTxtFileToolStripMenuItem_Click);
            // 
            // semesterListFromTxtFileToolStripMenuItem
            // 
            this.semesterListFromTxtFileToolStripMenuItem.Name = "semesterListFromTxtFileToolStripMenuItem";
            this.semesterListFromTxtFileToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.semesterListFromTxtFileToolStripMenuItem.Text = "Semester list from txt file";
            this.semesterListFromTxtFileToolStripMenuItem.Click += new System.EventHandler(this.semesterListFromTxtFileToolStripMenuItem_Click);
            // 
            // semesterToolStripMenuItem
            // 
            this.semesterToolStripMenuItem.Name = "semesterToolStripMenuItem";
            this.semesterToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // SemesterViewer
            // 
            this.SemesterViewer.ContextMenuStrip = this.EditElementMenuStrip;
            this.SemesterViewer.HideSelection = false;
            this.SemesterViewer.LabelWrap = false;
            this.SemesterViewer.Location = new System.Drawing.Point(374, 49);
            this.SemesterViewer.Name = "SemesterViewer";
            this.SemesterViewer.Size = new System.Drawing.Size(208, 389);
            this.SemesterViewer.TabIndex = 4;
            this.SemesterViewer.UseCompatibleStateImageBehavior = false;
            this.SemesterViewer.View = System.Windows.Forms.View.List;
            this.SemesterViewer.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.SemesterViewer_ItemSelectionChanged);
            this.SemesterViewer.DoubleClick += new System.EventHandler(this.SemesterViewer_DoubleClick);
            // 
            // classViewLabel
            // 
            this.classViewLabel.AutoSize = true;
            this.classViewLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.classViewLabel.Location = new System.Drawing.Point(163, 32);
            this.classViewLabel.Name = "classViewLabel";
            this.classViewLabel.Size = new System.Drawing.Size(59, 13);
            this.classViewLabel.TabIndex = 5;
            this.classViewLabel.Text = "Course List";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(450, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Semester List";
            // 
            // openFileWindow
            // 
            this.openFileWindow.FileName = "openFileDialog1";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addStripMenuItem,
            this.saveStripMenuItem,
            this.loadStripMenuItem});
            this.loadStripMenuItem,
            this.generateToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 24);
            this.menuStrip.TabIndex = 7;
            // 
<<<<<<< HEAD
            // scheduleCoursesToolStripMenuItem
            // 
            this.scheduleCoursesToolStripMenuItem.Name = "scheduleCoursesToolStripMenuItem";
            this.scheduleCoursesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.scheduleCoursesToolStripMenuItem.Text = "Schedule Courses";
            this.scheduleCoursesToolStripMenuItem.Click += new System.EventHandler(this.scheduleCoursesToolStripMenuItem_Click);
=======
            // generateToolStripMenuItem
            // 
            this.generateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.semestersToolStripMenuItem,
            this.electivesToolStripMenuItem});
            this.generateToolStripMenuItem.Name = "generateToolStripMenuItem";
            this.generateToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.generateToolStripMenuItem.Text = "Generate...";
            // 
            // semestersToolStripMenuItem
            // 
            this.semestersToolStripMenuItem.Name = "semestersToolStripMenuItem";
            this.semestersToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.semestersToolStripMenuItem.Text = "Semesters";
            this.semestersToolStripMenuItem.Click += new System.EventHandler(this.semestersToolStripMenuItem_Click);
            // 
            // electivesToolStripMenuItem
            // 
            this.electivesToolStripMenuItem.Name = "electivesToolStripMenuItem";
            this.electivesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.electivesToolStripMenuItem.Text = "Electives";
            this.electivesToolStripMenuItem.Click += new System.EventHandler(this.electivesToolStripMenuItem_Click);
>>>>>>> master
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.optionsMenu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.classViewLabel);
            this.Controls.Add(this.SemesterViewer);
            this.Controls.Add(this.CourseView);
            this.Controls.Add(this.genSchedules);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Class Scheduler";
            this.Load += new System.EventHandler(this.Main_Load);
            this.optionsMenu.ResumeLayout(false);
            this.optionsMenu.PerformLayout();
            this.EditElementMenuStrip.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox optionsMenu;
        private System.Windows.Forms.Button genSchedules;
        private System.Windows.Forms.ListView CourseView;
        private System.Windows.Forms.ToolStripMenuItem semesterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem semesterToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem classToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem classListFromTxtFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem semesterListFromTxtFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem classListToTxtFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem semesterListToTxtFileToolStripMenuItem;
        private System.Windows.Forms.ListView SemesterViewer;
        private System.Windows.Forms.Label classViewLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileWindow;
        private System.Windows.Forms.SaveFileDialog saveFileWindow;
        private System.Windows.Forms.ContextMenuStrip EditElementMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Button prefixPrioritiesFormButton;
        private System.Windows.Forms.CheckBox prioritizePrefixesCB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox delayGradCoursesCB;
        private System.Windows.Forms.Label gradCoursesLabel;
        private System.Windows.Forms.Label PriorityLabel;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem addStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadStripMenuItem;
        private System.Windows.Forms.CheckBox lowerLevelCB;
        private System.Windows.Forms.Label prioritizeLowerLevelCourcesLabel;
        private System.Windows.Forms.CheckBox labPairGroupingCB;
        private System.Windows.Forms.Label labpairLabel;
        private System.Windows.Forms.Label overloadableLabel;
        private System.Windows.Forms.CheckBox overloadableCB;
<<<<<<< HEAD
        private System.Windows.Forms.ToolStripMenuItem scheduleCoursesToolStripMenuItem;
=======
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem semestersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem electivesToolStripMenuItem;
>>>>>>> master
    }
}

