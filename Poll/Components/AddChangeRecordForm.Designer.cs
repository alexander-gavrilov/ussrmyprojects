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
            this.SuspendLayout();
            // 
            // rejectChangesButton
            // 
            this.rejectChangesButton.Location = new System.Drawing.Point(354, 349);
            this.rejectChangesButton.Name = "rejectChangesButton";
            this.rejectChangesButton.Size = new System.Drawing.Size(75, 23);
            this.rejectChangesButton.TabIndex = 0;
            this.rejectChangesButton.Text = "button1";
            this.rejectChangesButton.UseVisualStyleBackColor = true;
            this.rejectChangesButton.Click += new System.EventHandler(this.rejectChangesButton_Click);
            // 
            // acceptChangesButton
            // 
            this.acceptChangesButton.Location = new System.Drawing.Point(273, 349);
            this.acceptChangesButton.Name = "acceptChangesButton";
            this.acceptChangesButton.Size = new System.Drawing.Size(75, 23);
            this.acceptChangesButton.TabIndex = 1;
            this.acceptChangesButton.Text = "button2";
            this.acceptChangesButton.UseVisualStyleBackColor = true;
            this.acceptChangesButton.Click += new System.EventHandler(this.acceptChangesButton_Click);
            // 
            // AddChangeRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 384);
            this.Controls.Add(this.acceptChangesButton);
            this.Controls.Add(this.rejectChangesButton);
            this.Name = "AddChangeRecordForm";
            this.Text = "AddChangeRecordForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button rejectChangesButton;
        private System.Windows.Forms.Button acceptChangesButton;
    }
}