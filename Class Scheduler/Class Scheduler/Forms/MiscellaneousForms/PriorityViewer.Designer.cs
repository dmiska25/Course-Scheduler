namespace Class_Scheduler.Forms.MiscellaneousForms
{
    partial class PriorityViewer<T>
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
            this.itemList1 = new System.Windows.Forms.ListBox();
            this.itemList2 = new System.Windows.Forms.ListBox();
            this.moveRightButton = new System.Windows.Forms.Button();
            this.moveLeftButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.upButton = new System.Windows.Forms.Button();
            this.downButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // itemList1
            // 
            this.itemList1.FormattingEnabled = true;
            this.itemList1.Location = new System.Drawing.Point(12, 12);
            this.itemList1.Name = "itemList1";
            this.itemList1.Size = new System.Drawing.Size(141, 186);
            this.itemList1.TabIndex = 0;
            // 
            // itemList2
            // 
            this.itemList2.FormattingEnabled = true;
            this.itemList2.Location = new System.Drawing.Point(240, 12);
            this.itemList2.Name = "itemList2";
            this.itemList2.Size = new System.Drawing.Size(141, 186);
            this.itemList2.TabIndex = 1;
            // 
            // moveRightButton
            // 
            this.moveRightButton.Location = new System.Drawing.Point(159, 75);
            this.moveRightButton.Name = "moveRightButton";
            this.moveRightButton.Size = new System.Drawing.Size(75, 23);
            this.moveRightButton.TabIndex = 2;
            this.moveRightButton.Text = ">>>";
            this.moveRightButton.UseVisualStyleBackColor = true;
            this.moveRightButton.Click += new System.EventHandler(this.moveRightButton_Click);
            // 
            // moveLeftButton
            // 
            this.moveLeftButton.Location = new System.Drawing.Point(159, 104);
            this.moveLeftButton.Name = "moveLeftButton";
            this.moveLeftButton.Size = new System.Drawing.Size(75, 23);
            this.moveLeftButton.TabIndex = 3;
            this.moveLeftButton.Text = "<<<";
            this.moveLeftButton.UseVisualStyleBackColor = true;
            this.moveLeftButton.Click += new System.EventHandler(this.moveLeftButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(159, 252);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 4;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // upButton
            // 
            this.upButton.Location = new System.Drawing.Point(274, 204);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(25, 23);
            this.upButton.TabIndex = 5;
            this.upButton.Text = "↑";
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // downButton
            // 
            this.downButton.Location = new System.Drawing.Point(321, 204);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(25, 23);
            this.downButton.TabIndex = 6;
            this.downButton.Text = "↓";
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Click += new System.EventHandler(this.downButton_Click);
            // 
            // PriorityViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 287);
            this.Controls.Add(this.downButton);
            this.Controls.Add(this.upButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.moveLeftButton);
            this.Controls.Add(this.moveRightButton);
            this.Controls.Add(this.itemList2);
            this.Controls.Add(this.itemList1);
            this.Name = "PriorityViewer";
            this.Text = "Priority Viewer";
            this.Load += new System.EventHandler(this.PriorityViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button moveRightButton;
        private System.Windows.Forms.Button moveLeftButton;
        private System.Windows.Forms.Button closeButton;
        public System.Windows.Forms.Button upButton;
        public System.Windows.Forms.Button downButton;
        protected System.Windows.Forms.ListBox itemList1;
        protected System.Windows.Forms.ListBox itemList2;
    }
}