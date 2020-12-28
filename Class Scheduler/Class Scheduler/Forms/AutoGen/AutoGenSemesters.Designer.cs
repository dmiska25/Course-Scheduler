
namespace Class_Scheduler.Forms.AutoGen
{
    partial class AutoGenSemesters
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
            this.startingYearLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.startingYearTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numSemToGenTB = new System.Windows.Forms.TextBox();
            this.autoGenSemButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.includeSumTermCB = new System.Windows.Forms.CheckBox();
            this.overloadingLabel = new System.Windows.Forms.Label();
            this.overloadingCB = new System.Windows.Forms.CheckBox();
            this.fallRB = new System.Windows.Forms.RadioButton();
            this.springRB = new System.Windows.Forms.RadioButton();
            this.summerRB = new System.Windows.Forms.RadioButton();
            this.minimumCredLabel = new System.Windows.Forms.Label();
            this.maxCreditsLabel = new System.Windows.Forms.Label();
            this.minimumCreditsTB = new System.Windows.Forms.TextBox();
            this.maximumCreditsTB = new System.Windows.Forms.TextBox();
            this.sumMinCreditsLabel = new System.Windows.Forms.Label();
            this.sumMaxCreditsLabel = new System.Windows.Forms.Label();
            this.sumMinCreditsTB = new System.Windows.Forms.TextBox();
            this.sumMaxCreditsTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Auto Generation Config";
            // 
            // startingYearLabel
            // 
            this.startingYearLabel.AutoSize = true;
            this.startingYearLabel.Location = new System.Drawing.Point(13, 42);
            this.startingYearLabel.Name = "startingYearLabel";
            this.startingYearLabel.Size = new System.Drawing.Size(71, 13);
            this.startingYearLabel.TabIndex = 1;
            this.startingYearLabel.Text = "Starting Year:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Starting Term:";
            // 
            // startingYearTB
            // 
            this.startingYearTB.Location = new System.Drawing.Point(112, 39);
            this.startingYearTB.Name = "startingYearTB";
            this.startingYearTB.Size = new System.Drawing.Size(100, 20);
            this.startingYearTB.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Number of Semesters To Generate:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Include Summer Terms?:";
            // 
            // numSemToGenTB
            // 
            this.numSemToGenTB.Location = new System.Drawing.Point(192, 131);
            this.numSemToGenTB.Name = "numSemToGenTB";
            this.numSemToGenTB.Size = new System.Drawing.Size(100, 20);
            this.numSemToGenTB.TabIndex = 7;
            // 
            // autoGenSemButton
            // 
            this.autoGenSemButton.Location = new System.Drawing.Point(62, 353);
            this.autoGenSemButton.Name = "autoGenSemButton";
            this.autoGenSemButton.Size = new System.Drawing.Size(75, 23);
            this.autoGenSemButton.TabIndex = 9;
            this.autoGenSemButton.Text = "Generate";
            this.autoGenSemButton.UseVisualStyleBackColor = true;
            this.autoGenSemButton.Click += new System.EventHandler(this.autoGenSemButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(170, 353);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // includeSumTermCB
            // 
            this.includeSumTermCB.AutoSize = true;
            this.includeSumTermCB.Location = new System.Drawing.Point(194, 179);
            this.includeSumTermCB.Name = "includeSumTermCB";
            this.includeSumTermCB.Size = new System.Drawing.Size(15, 14);
            this.includeSumTermCB.TabIndex = 11;
            this.includeSumTermCB.UseVisualStyleBackColor = true;
            this.includeSumTermCB.CheckedChanged += new System.EventHandler(this.includeSumTermCB_CheckedChanged);
            // 
            // overloadingLabel
            // 
            this.overloadingLabel.AutoSize = true;
            this.overloadingLabel.Location = new System.Drawing.Point(13, 157);
            this.overloadingLabel.Name = "overloadingLabel";
            this.overloadingLabel.Size = new System.Drawing.Size(109, 13);
            this.overloadingLabel.TabIndex = 12;
            this.overloadingLabel.Text = "Enable Overloading?:";
            // 
            // overloadingCB
            // 
            this.overloadingCB.AutoSize = true;
            this.overloadingCB.Location = new System.Drawing.Point(194, 157);
            this.overloadingCB.Name = "overloadingCB";
            this.overloadingCB.Size = new System.Drawing.Size(15, 14);
            this.overloadingCB.TabIndex = 13;
            this.overloadingCB.UseVisualStyleBackColor = true;
            // 
            // fallRB
            // 
            this.fallRB.AutoSize = true;
            this.fallRB.Checked = true;
            this.fallRB.Location = new System.Drawing.Point(92, 63);
            this.fallRB.Name = "fallRB";
            this.fallRB.Size = new System.Drawing.Size(41, 17);
            this.fallRB.TabIndex = 14;
            this.fallRB.TabStop = true;
            this.fallRB.Text = "Fall";
            this.fallRB.UseVisualStyleBackColor = true;
            // 
            // springRB
            // 
            this.springRB.AutoSize = true;
            this.springRB.Location = new System.Drawing.Point(139, 63);
            this.springRB.Name = "springRB";
            this.springRB.Size = new System.Drawing.Size(55, 17);
            this.springRB.TabIndex = 15;
            this.springRB.Text = "Spring";
            this.springRB.UseVisualStyleBackColor = true;
            // 
            // summerRB
            // 
            this.summerRB.AutoSize = true;
            this.summerRB.Location = new System.Drawing.Point(201, 64);
            this.summerRB.Name = "summerRB";
            this.summerRB.Size = new System.Drawing.Size(63, 17);
            this.summerRB.TabIndex = 16;
            this.summerRB.Text = "Summer";
            this.summerRB.UseVisualStyleBackColor = true;
            // 
            // minimumCredLabel
            // 
            this.minimumCredLabel.AutoSize = true;
            this.minimumCredLabel.Location = new System.Drawing.Point(13, 87);
            this.minimumCredLabel.Name = "minimumCredLabel";
            this.minimumCredLabel.Size = new System.Drawing.Size(86, 13);
            this.minimumCredLabel.TabIndex = 17;
            this.minimumCredLabel.Text = "Minimum Credits:";
            // 
            // maxCreditsLabel
            // 
            this.maxCreditsLabel.AutoSize = true;
            this.maxCreditsLabel.Location = new System.Drawing.Point(13, 110);
            this.maxCreditsLabel.Name = "maxCreditsLabel";
            this.maxCreditsLabel.Size = new System.Drawing.Size(89, 13);
            this.maxCreditsLabel.TabIndex = 18;
            this.maxCreditsLabel.Text = "Maximum Credits:";
            // 
            // minimumCreditsTB
            // 
            this.minimumCreditsTB.Location = new System.Drawing.Point(192, 84);
            this.minimumCreditsTB.Name = "minimumCreditsTB";
            this.minimumCreditsTB.Size = new System.Drawing.Size(100, 20);
            this.minimumCreditsTB.TabIndex = 19;
            // 
            // maximumCreditsTB
            // 
            this.maximumCreditsTB.Location = new System.Drawing.Point(192, 107);
            this.maximumCreditsTB.Name = "maximumCreditsTB";
            this.maximumCreditsTB.Size = new System.Drawing.Size(100, 20);
            this.maximumCreditsTB.TabIndex = 20;
            // 
            // sumMinCreditsLabel
            // 
            this.sumMinCreditsLabel.AutoSize = true;
            this.sumMinCreditsLabel.Location = new System.Drawing.Point(40, 205);
            this.sumMinCreditsLabel.Name = "sumMinCreditsLabel";
            this.sumMinCreditsLabel.Size = new System.Drawing.Size(127, 13);
            this.sumMinCreditsLabel.TabIndex = 21;
            this.sumMinCreditsLabel.Text = "Summer Minimum Credits:";
            this.sumMinCreditsLabel.Visible = false;
            // 
            // sumMaxCreditsLabel
            // 
            this.sumMaxCreditsLabel.AutoSize = true;
            this.sumMaxCreditsLabel.Location = new System.Drawing.Point(40, 227);
            this.sumMaxCreditsLabel.Name = "sumMaxCreditsLabel";
            this.sumMaxCreditsLabel.Size = new System.Drawing.Size(130, 13);
            this.sumMaxCreditsLabel.TabIndex = 22;
            this.sumMaxCreditsLabel.Text = "Summer Maximum Credits:";
            this.sumMaxCreditsLabel.Visible = false;
            // 
            // sumMinCreditsTB
            // 
            this.sumMinCreditsTB.Location = new System.Drawing.Point(192, 202);
            this.sumMinCreditsTB.Name = "sumMinCreditsTB";
            this.sumMinCreditsTB.Size = new System.Drawing.Size(100, 20);
            this.sumMinCreditsTB.TabIndex = 23;
            this.sumMinCreditsTB.Visible = false;
            // 
            // sumMaxCreditsTB
            // 
            this.sumMaxCreditsTB.Location = new System.Drawing.Point(192, 224);
            this.sumMaxCreditsTB.Name = "sumMaxCreditsTB";
            this.sumMaxCreditsTB.Size = new System.Drawing.Size(100, 20);
            this.sumMaxCreditsTB.TabIndex = 24;
            this.sumMaxCreditsTB.Visible = false;
            // 
            // AutoGenSemesters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 397);
            this.Controls.Add(this.sumMaxCreditsTB);
            this.Controls.Add(this.sumMinCreditsTB);
            this.Controls.Add(this.sumMaxCreditsLabel);
            this.Controls.Add(this.sumMinCreditsLabel);
            this.Controls.Add(this.maximumCreditsTB);
            this.Controls.Add(this.minimumCreditsTB);
            this.Controls.Add(this.maxCreditsLabel);
            this.Controls.Add(this.minimumCredLabel);
            this.Controls.Add(this.summerRB);
            this.Controls.Add(this.springRB);
            this.Controls.Add(this.fallRB);
            this.Controls.Add(this.overloadingCB);
            this.Controls.Add(this.overloadingLabel);
            this.Controls.Add(this.includeSumTermCB);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.autoGenSemButton);
            this.Controls.Add(this.numSemToGenTB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.startingYearTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.startingYearLabel);
            this.Controls.Add(this.label1);
            this.Name = "AutoGenSemesters";
            this.Text = "AutoGenSemesters";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label startingYearLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox startingYearTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox numSemToGenTB;
        private System.Windows.Forms.Button autoGenSemButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox includeSumTermCB;
        private System.Windows.Forms.Label overloadingLabel;
        private System.Windows.Forms.CheckBox overloadingCB;
        private System.Windows.Forms.RadioButton fallRB;
        private System.Windows.Forms.RadioButton springRB;
        private System.Windows.Forms.RadioButton summerRB;
        private System.Windows.Forms.Label minimumCredLabel;
        private System.Windows.Forms.Label maxCreditsLabel;
        private System.Windows.Forms.TextBox minimumCreditsTB;
        private System.Windows.Forms.TextBox maximumCreditsTB;
        private System.Windows.Forms.Label sumMinCreditsLabel;
        private System.Windows.Forms.Label sumMaxCreditsLabel;
        private System.Windows.Forms.TextBox sumMinCreditsTB;
        private System.Windows.Forms.TextBox sumMaxCreditsTB;
    }
}