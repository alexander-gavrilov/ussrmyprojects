namespace Components
{
    partial class AddChangeRecordForm
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
            this.rejectChangesButton = new System.Windows.Forms.Button();
            this.acceptChangesButton = new System.Windows.Forms.Button();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bottomPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rejectChangesButton
            // 
            this.rejectChangesButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.rejectChangesButton.Location = new System.Drawing.Point(79, 0);
            this.rejectChangesButton.Name = "rejectChangesButton";
            this.rejectChangesButton.Size = new System.Drawing.Size(75, 21);
            this.rejectChangesButton.TabIndex = 1;
            this.rejectChangesButton.Text = "button1";
            this.rejectChangesButton.UseVisualStyleBackColor = true;
            this.rejectChangesButton.Click += new System.EventHandler(this.rejectChangesButton_Click);
            // 
            // acceptChangesButton
            // 
            this.acceptChangesButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.acceptChangesButton.Location = new System.Drawing.Point(0, 0);
            this.acceptChangesButton.Name = "acceptChangesButton";
            this.acceptChangesButton.Size = new System.Drawing.Size(75, 21);
            this.acceptChangesButton.TabIndex = 0;
            this.acceptChangesButton.Text = "button2";
            this.acceptChangesButton.UseVisualStyleBackColor = true;
            this.acceptChangesButton.Click += new System.EventHandler(this.acceptChangesButton_Click);
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.panel1);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 356);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Padding = new System.Windows.Forms.Padding(0, 0, 7, 7);
            this.bottomPanel.Size = new System.Drawing.Size(441, 28);
            this.bottomPanel.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.acceptChangesButton);
            this.panel1.Controls.Add(this.rejectChangesButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(280, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(154, 21);
            this.panel1.TabIndex = 3;
            // 
            // AddChangeRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 384);
            this.Controls.Add(this.bottomPanel);
            this.Name = "AddChangeRecordForm";
            this.Text = "AddChangeRecordForm";
            this.bottomPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel bottomPanel;
        public System.Windows.Forms.Button rejectChangesButton;
        public System.Windows.Forms.Button acceptChangesButton;
        private System.Windows.Forms.Panel panel1;

    }
}