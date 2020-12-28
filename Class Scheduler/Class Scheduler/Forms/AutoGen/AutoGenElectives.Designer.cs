
namespace Class_Scheduler.Forms.AutoGen
{
    partial class AutoGenElectives
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.genElectRB = new System.Windows.Forms.RadioButton();
            this.majorElectRB = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.creditsTB = new System.Windows.Forms.TextBox();
            this.validTermsLabel = new System.Windows.Forms.Label();
            this.FallCB = new System.Windows.Forms.CheckBox();
            this.springCB = new System.Windows.Forms.CheckBox();
            this.summerCB = new System.Windows.Forms.CheckBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.autoGenElectButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.electToGenTB = new System.Windows.Forms.TextBox();
            this.gradeLevelReqLabel = new System.Windows.Forms.Label();
            this.creditsReqLabel = new System.Windows.Forms.Label();
            this.gradeLevelReqCB = new System.Windows.Forms.CheckBox();
            this.creditCountReqCB = new System.Windows.Forms.CheckBox();
            this.creditsCountReqTB = new System.Windows.Forms.TextBox();
            this.creditCountReqLabel = new System.Windows.Forms.Label();
            this.FreshmanRB = new System.Windows.Forms.RadioButton();
            this.sophmoreRB = new System.Windows.Forms.RadioButton();
            this.juniorRB = new System.Windows.Forms.RadioButton();
            this.seniorRB = new System.Windows.Forms.RadioButton();
            this.gradeLevelGB = new System.Windows.Forms.GroupBox();
            this.gradeLevelGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Auto Generation Config";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Elective Type:";
            // 
            // genElectRB
            // 
            this.genElectRB.AutoSize = true;
            this.genElectRB.Checked = true;
            this.genElectRB.Location = new System.Drawing.Point(95, 40);
            this.genElectRB.Name = "genElectRB";
            this.genElectRB.Size = new System.Drawing.Size(103, 17);
            this.genElectRB.TabIndex = 3;
            this.genElectRB.TabStop = true;
            this.genElectRB.Text = "General Elective";
            this.genElectRB.UseVisualStyleBackColor = true;
            // 
            // majorElectRB
            // 
            this.majorElectRB.AutoSize = true;
            this.majorElectRB.Location = new System.Drawing.Point(205, 40);
            this.majorElectRB.Name = "majorElectRB";
            this.majorElectRB.Size = new System.Drawing.Size(92, 17);
            this.majorElectRB.TabIndex = 4;
            this.majorElectRB.Text = "Major Elective";
            this.majorElectRB.UseVisualStyleBackColor = true;
            this.majorElectRB.CheckedChanged += new System.EventHandler(this.majorElectRB_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Credits:";
            // 
            // creditsTB
            // 
            this.creditsTB.Location = new System.Drawing.Point(89, 68);
            this.creditsTB.Name = "creditsTB";
            this.creditsTB.Size = new System.Drawing.Size(100, 20);
            this.creditsTB.TabIndex = 6;
            // 
            // validTermsLabel
            // 
            this.validTermsLabel.AutoSize = true;
            this.validTermsLabel.Location = new System.Drawing.Point(13, 95);
            this.validTermsLabel.Name = "validTermsLabel";
            this.validTermsLabel.Size = new System.Drawing.Size(65, 13);
            this.validTermsLabel.TabIndex = 7;
            this.validTermsLabel.Text = "Valid Terms:";
            // 
            // FallCB
            // 
            this.FallCB.AutoSize = true;
            this.FallCB.Location = new System.Drawing.Point(89, 95);
            this.FallCB.Name = "FallCB";
            this.FallCB.Size = new System.Drawing.Size(42, 17);
            this.FallCB.TabIndex = 8;
            this.FallCB.Text = "Fall";
            this.FallCB.UseVisualStyleBackColor = true;
            // 
            // springCB
            // 
            this.springCB.AutoSize = true;
            this.springCB.Location = new System.Drawing.Point(138, 95);
            this.springCB.Name = "springCB";
            this.springCB.Size = new System.Drawing.Size(56, 17);
            this.springCB.TabIndex = 9;
            this.springCB.Text = "Spring";
            this.springCB.UseVisualStyleBackColor = true;
            // 
            // summerCB
            // 
            this.summerCB.AutoSize = true;
            this.summerCB.Location = new System.Drawing.Point(201, 95);
            this.summerCB.Name = "summerCB";
            this.summerCB.Size = new System.Drawing.Size(64, 17);
            this.summerCB.TabIndex = 10;
            this.summerCB.Text = "Summer";
            this.summerCB.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(173, 362);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 12;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // autoGenElectButton
            // 
            this.autoGenElectButton.Location = new System.Drawing.Point(65, 362);
            this.autoGenElectButton.Name = "autoGenElectButton";
            this.autoGenElectButton.Size = new System.Drawing.Size(75, 23);
            this.autoGenElectButton.TabIndex = 11;
            this.autoGenElectButton.Text = "Generate";
            this.autoGenElectButton.UseVisualStyleBackColor = true;
            this.autoGenElectButton.Click += new System.EventHandler(this.autoGenElectButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Number of Electives To Generate:";
            // 
            // electToGenTB
            // 
            this.electToGenTB.Location = new System.Drawing.Point(186, 114);
            this.electToGenTB.Name = "electToGenTB";
            this.electToGenTB.Size = new System.Drawing.Size(100, 20);
            this.electToGenTB.TabIndex = 14;
            // 
            // gradeLevelReqLabel
            // 
            this.gradeLevelReqLabel.AutoSize = true;
            this.gradeLevelReqLabel.Location = new System.Drawing.Point(16, 145);
            this.gradeLevelReqLabel.Name = "gradeLevelReqLabel";
            this.gradeLevelReqLabel.Size = new System.Drawing.Size(120, 13);
            this.gradeLevelReqLabel.TabIndex = 15;
            this.gradeLevelReqLabel.Text = "Grade Level Required?:";
            this.gradeLevelReqLabel.Visible = false;
            // 
            // creditsReqLabel
            // 
            this.creditsReqLabel.AutoSize = true;
            this.creditsReqLabel.Location = new System.Drawing.Point(16, 187);
            this.creditsReqLabel.Name = "creditsReqLabel";
            this.creditsReqLabel.Size = new System.Drawing.Size(94, 13);
            this.creditsReqLabel.TabIndex = 16;
            this.creditsReqLabel.Text = "Credits Required?:";
            this.creditsReqLabel.Visible = false;
            // 
            // gradeLevelReqCB
            // 
            this.gradeLevelReqCB.AutoSize = true;
            this.gradeLevelReqCB.Location = new System.Drawing.Point(143, 145);
            this.gradeLevelReqCB.Name = "gradeLevelReqCB";
            this.gradeLevelReqCB.Size = new System.Drawing.Size(15, 14);
            this.gradeLevelReqCB.TabIndex = 17;
            this.gradeLevelReqCB.UseVisualStyleBackColor = true;
            this.gradeLevelReqCB.Visible = false;
            this.gradeLevelReqCB.CheckedChanged += new System.EventHandler(this.gradeLevelReqCB_CheckedChanged);
            // 
            // creditCountReqCB
            // 
            this.creditCountReqCB.AutoSize = true;
            this.creditCountReqCB.Location = new System.Drawing.Point(116, 186);
            this.creditCountReqCB.Name = "creditCountReqCB";
            this.creditCountReqCB.Size = new System.Drawing.Size(15, 14);
            this.creditCountReqCB.TabIndex = 18;
            this.creditCountReqCB.UseVisualStyleBackColor = true;
            this.creditCountReqCB.Visible = false;
            this.creditCountReqCB.CheckedChanged += new System.EventHandler(this.creditCountReqCB_CheckedChanged);
            // 
            // creditsCountReqTB
            // 
            this.creditsCountReqTB.Location = new System.Drawing.Point(164, 206);
            this.creditsCountReqTB.Name = "creditsCountReqTB";
            this.creditsCountReqTB.Size = new System.Drawing.Size(100, 20);
            this.creditsCountReqTB.TabIndex = 19;
            this.creditsCountReqTB.Visible = false;
            // 
            // creditCountReqLabel
            // 
            this.creditCountReqLabel.AutoSize = true;
            this.creditCountReqLabel.Location = new System.Drawing.Point(18, 209);
            this.creditCountReqLabel.Name = "creditCountReqLabel";
            this.creditCountReqLabel.Size = new System.Drawing.Size(140, 13);
            this.creditCountReqLabel.TabIndex = 20;
            this.creditCountReqLabel.Text = "Required Number of Credits:";
            this.creditCountReqLabel.Visible = false;
            // 
            // FreshmanRB
            // 
            this.FreshmanRB.AutoSize = true;
            this.FreshmanRB.Checked = true;
            this.FreshmanRB.Location = new System.Drawing.Point(96, -1);
            this.FreshmanRB.Name = "FreshmanRB";
            this.FreshmanRB.Size = new System.Drawing.Size(71, 17);
            this.FreshmanRB.TabIndex = 21;
            this.FreshmanRB.TabStop = true;
            this.FreshmanRB.Text = "Freshman";
            this.FreshmanRB.UseVisualStyleBackColor = true;
            this.FreshmanRB.UseWaitCursor = true;
            this.FreshmanRB.Visible = false;
            // 
            // sophmoreRB
            // 
            this.sophmoreRB.AutoSize = true;
            this.sophmoreRB.Location = new System.Drawing.Point(173, -1);
            this.sophmoreRB.Name = "sophmoreRB";
            this.sophmoreRB.Size = new System.Drawing.Size(73, 17);
            this.sophmoreRB.TabIndex = 22;
            this.sophmoreRB.TabStop = true;
            this.sophmoreRB.Text = "Sophmore";
            this.sophmoreRB.UseVisualStyleBackColor = true;
            this.sophmoreRB.UseWaitCursor = true;
            this.sophmoreRB.Visible = false;
            // 
            // juniorRB
            // 
            this.juniorRB.AutoSize = true;
            this.juniorRB.Location = new System.Drawing.Point(253, -1);
            this.juniorRB.Name = "juniorRB";
            this.juniorRB.Size = new System.Drawing.Size(53, 17);
            this.juniorRB.TabIndex = 23;
            this.juniorRB.TabStop = true;
            this.juniorRB.Text = "Junior";
            this.juniorRB.UseVisualStyleBackColor = true;
            this.juniorRB.UseWaitCursor = true;
            this.juniorRB.Visible = false;
            // 
            // seniorRB
            // 
            this.seniorRB.AutoSize = true;
            this.seniorRB.Location = new System.Drawing.Point(313, -1);
            this.seniorRB.Name = "seniorRB";
            this.seniorRB.Size = new System.Drawing.Size(55, 17);
            this.seniorRB.TabIndex = 24;
            this.seniorRB.TabStop = true;
            this.seniorRB.Text = "Senior";
            this.seniorRB.UseVisualStyleBackColor = true;
            this.seniorRB.UseWaitCursor = true;
            this.seniorRB.Visible = false;
            // 
            // gradeLevelGB
            // 
            this.gradeLevelGB.Controls.Add(this.FreshmanRB);
            this.gradeLevelGB.Controls.Add(this.seniorRB);
            this.gradeLevelGB.Controls.Add(this.sophmoreRB);
            this.gradeLevelGB.Controls.Add(this.juniorRB);
            this.gradeLevelGB.Location = new System.Drawing.Point(-81, 162);
            this.gradeLevelGB.Name = "gradeLevelGB";
            this.gradeLevelGB.Size = new System.Drawing.Size(458, 18);
            this.gradeLevelGB.TabIndex = 25;
            this.gradeLevelGB.TabStop = false;
            this.gradeLevelGB.UseWaitCursor = true;
            this.gradeLevelGB.Visible = false;
            // 
            // AutoGenElectives
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 397);
            this.Controls.Add(this.gradeLevelGB);
            this.Controls.Add(this.creditCountReqLabel);
            this.Controls.Add(this.creditsCountReqTB);
            this.Controls.Add(this.creditCountReqCB);
            this.Controls.Add(this.gradeLevelReqCB);
            this.Controls.Add(this.creditsReqLabel);
            this.Controls.Add(this.gradeLevelReqLabel);
            this.Controls.Add(this.electToGenTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.autoGenElectButton);
            this.Controls.Add(this.summerCB);
            this.Controls.Add(this.springCB);
            this.Controls.Add(this.FallCB);
            this.Controls.Add(this.validTermsLabel);
            this.Controls.Add(this.creditsTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.majorElectRB);
            this.Controls.Add(this.genElectRB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AutoGenElectives";
            this.Text = "AutoGenElectives";
            this.gradeLevelGB.ResumeLayout(false);
            this.gradeLevelGB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton genElectRB;
        private System.Windows.Forms.RadioButton majorElectRB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox creditsTB;
        private System.Windows.Forms.Label validTermsLabel;
        private System.Windows.Forms.CheckBox FallCB;
        private System.Windows.Forms.CheckBox springCB;
        private System.Windows.Forms.CheckBox summerCB;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button autoGenElectButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox electToGenTB;
        private System.Windows.Forms.Label gradeLevelReqLabel;
        private System.Windows.Forms.Label creditsReqLabel;
        private System.Windows.Forms.CheckBox gradeLevelReqCB;
        private System.Windows.Forms.CheckBox creditCountReqCB;
        private System.Windows.Forms.TextBox creditsCountReqTB;
        private System.Windows.Forms.Label creditCountReqLabel;
        private System.Windows.Forms.RadioButton FreshmanRB;
        private System.Windows.Forms.RadioButton sophmoreRB;
        private System.Windows.Forms.RadioButton juniorRB;
        private System.Windows.Forms.RadioButton seniorRB;
        private System.Windows.Forms.GroupBox gradeLevelGB;
    }
}