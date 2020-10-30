namespace Class_Scheduler
{
    partial class SemesterAdd
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
            this.addSemesterButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.yearLabel = new System.Windows.Forms.Label();
            this.termLabel = new System.Windows.Forms.Label();
            this.yearTB = new System.Windows.Forms.TextBox();
            this.termTB = new System.Windows.Forms.TextBox();
            this.maxCreditsLabel = new System.Windows.Forms.Label();
            this.minCreditsLabel = new System.Windows.Forms.Label();
            this.maxCreditsTB = new System.Windows.Forms.TextBox();
            this.minCreditsTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // addSemesterButton
            // 
            this.addSemesterButton.Location = new System.Drawing.Point(28, 339);
            this.addSemesterButton.Name = "addSemesterButton";
            this.addSemesterButton.Size = new System.Drawing.Size(125, 23);
            this.addSemesterButton.TabIndex = 5;
            this.addSemesterButton.Text = "Add Semester";
            this.addSemesterButton.UseVisualStyleBackColor = true;
            this.addSemesterButton.Click += new System.EventHandler(this.addSemesterButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(183, 339);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(125, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // yearLabel
            // 
            this.yearLabel.AutoSize = true;
            this.yearLabel.Location = new System.Drawing.Point(28, 28);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(35, 13);
            this.yearLabel.TabIndex = 2;
            this.yearLabel.Text = "Year: ";
            // 
            // termLabel
            // 
            this.termLabel.AutoSize = true;
            this.termLabel.Location = new System.Drawing.Point(28, 53);
            this.termLabel.Name = "termLabel";
            this.termLabel.Size = new System.Drawing.Size(34, 13);
            this.termLabel.TabIndex = 3;
            this.termLabel.Text = "Term:";
            // 
            // yearTB
            // 
            this.yearTB.Location = new System.Drawing.Point(69, 25);
            this.yearTB.Name = "yearTB";
            this.yearTB.Size = new System.Drawing.Size(189, 20);
            this.yearTB.TabIndex = 1;
            // 
            // termTB
            // 
            this.termTB.Location = new System.Drawing.Point(69, 51);
            this.termTB.Name = "termTB";
            this.termTB.Size = new System.Drawing.Size(189, 20);
            this.termTB.TabIndex = 2;
            // 
            // maxCreditsLabel
            // 
            this.maxCreditsLabel.AutoSize = true;
            this.maxCreditsLabel.Location = new System.Drawing.Point(-2, 106);
            this.maxCreditsLabel.Name = "maxCreditsLabel";
            this.maxCreditsLabel.Size = new System.Drawing.Size(65, 13);
            this.maxCreditsLabel.TabIndex = 6;
            this.maxCreditsLabel.Text = "Max Credits:";
            // 
            // minCreditsLabel
            // 
            this.minCreditsLabel.AutoSize = true;
            this.minCreditsLabel.Location = new System.Drawing.Point(1, 80);
            this.minCreditsLabel.Name = "minCreditsLabel";
            this.minCreditsLabel.Size = new System.Drawing.Size(62, 13);
            this.minCreditsLabel.TabIndex = 7;
            this.minCreditsLabel.Text = "Min Credits:";
            // 
            // maxCreditsTB
            // 
            this.maxCreditsTB.Location = new System.Drawing.Point(69, 103);
            this.maxCreditsTB.Name = "maxCreditsTB";
            this.maxCreditsTB.Size = new System.Drawing.Size(100, 20);
            this.maxCreditsTB.TabIndex = 4;
            // 
            // minCreditsTB
            // 
            this.minCreditsTB.Location = new System.Drawing.Point(69, 77);
            this.minCreditsTB.Name = "minCreditsTB";
            this.minCreditsTB.Size = new System.Drawing.Size(100, 20);
            this.minCreditsTB.TabIndex = 3;
            // 
            // SemesterAdd
            // 
            this.AcceptButton = this.addSemesterButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(336, 383);
            this.Controls.Add(this.minCreditsTB);
            this.Controls.Add(this.maxCreditsTB);
            this.Controls.Add(this.minCreditsLabel);
            this.Controls.Add(this.maxCreditsLabel);
            this.Controls.Add(this.termTB);
            this.Controls.Add(this.yearTB);
            this.Controls.Add(this.termLabel);
            this.Controls.Add(this.yearLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addSemesterButton);
            this.Name = "SemesterAdd";
            this.Text = "Add Semester";
            this.Load += new System.EventHandler(this.SemesterAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label yearLabel;
        private System.Windows.Forms.Label termLabel;
        private System.Windows.Forms.Label maxCreditsLabel;
        private System.Windows.Forms.Label minCreditsLabel;
        protected System.Windows.Forms.Button addSemesterButton;
        protected System.Windows.Forms.TextBox yearTB;
        protected System.Windows.Forms.TextBox termTB;
        protected System.Windows.Forms.TextBox maxCreditsTB;
        protected System.Windows.Forms.TextBox minCreditsTB;
    }
}