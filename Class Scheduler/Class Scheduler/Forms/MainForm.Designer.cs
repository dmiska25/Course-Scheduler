namespace Class_Scheduler
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.genSchedules = new System.Windows.Forms.Button();
            this.CourseView = new System.Windows.Forms.ListView();
            this.EditElementMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.semesterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.semesterToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.classToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classListFromTxtFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.semesterListFromTxtFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classListToTxtFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.semesterListToTxtFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SemesterViewer = new System.Windows.Forms.ListView();
            this.classViewLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileWindow = new System.Windows.Forms.OpenFileDialog();
            this.saveFileWindow = new System.Windows.Forms.SaveFileDialog();
            this.EditElementMenuStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Location = new System.Drawing.Point(588, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 363);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
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
            this.deleteToolStripMenuItem});
            this.EditElementMenuStrip.Name = "EditElementMenuStrip";
            this.EditElementMenuStrip.Size = new System.Drawing.Size(118, 70);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.viewToolStripMenuItem.Text = "View";
            this.viewToolStripMenuItem.Click += new System.EventHandler(this.viewToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.deleteToolStripMenuItem.Text = "Remove";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.semesterToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 24);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "Add...";
            // 
            // semesterToolStripMenuItem
            // 
            this.semesterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.semesterToolStripMenuItem1,
            this.classToolStripMenuItem});
            this.semesterToolStripMenuItem.Name = "semesterToolStripMenuItem";
            this.semesterToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.semesterToolStripMenuItem.Text = "Add...";
            // 
            // semesterToolStripMenuItem1
            // 
            this.semesterToolStripMenuItem1.Name = "semesterToolStripMenuItem1";
            this.semesterToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.semesterToolStripMenuItem1.Text = "Semester";
            this.semesterToolStripMenuItem1.Click += new System.EventHandler(this.semesterToolStripMenuItem1_Click);
            // 
            // classToolStripMenuItem
            // 
            this.classToolStripMenuItem.Name = "classToolStripMenuItem";
            this.classToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.classToolStripMenuItem.Text = "Course";
            this.classToolStripMenuItem.Click += new System.EventHandler(this.classToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.classListFromTxtFileToolStripMenuItem,
            this.semesterListFromTxtFileToolStripMenuItem});
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.loadToolStripMenuItem.Text = "load...";
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
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.classListToTxtFileToolStripMenuItem,
            this.semesterListToTxtFileToolStripMenuItem});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.saveToolStripMenuItem.Text = "Save...";
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.classViewLabel);
            this.Controls.Add(this.SemesterViewer);
            this.Controls.Add(this.CourseView);
            this.Controls.Add(this.genSchedules);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Class Scheduler";
            this.Load += new System.EventHandler(this.Main_Load);
            this.EditElementMenuStrip.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button genSchedules;
        private System.Windows.Forms.ListView CourseView;
        private System.Windows.Forms.MenuStrip menuStrip;
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
    }
}

