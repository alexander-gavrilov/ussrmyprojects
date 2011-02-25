namespace Poll
{
    partial class QuestControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.questLabel = new System.Windows.Forms.Label();
            this.satisfactionUpDown = new System.Windows.Forms.NumericUpDown();
            this.importanceUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.satisfactionUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.importanceUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // questLabel
            // 
            this.questLabel.Location = new System.Drawing.Point(3, 5);
            this.questLabel.Name = "questLabel";
            this.questLabel.Size = new System.Drawing.Size(196, 29);
            this.questLabel.TabIndex = 0;
            this.questLabel.Text = "label1";
            // 
            // satisfactionUpDown
            // 
            this.satisfactionUpDown.Location = new System.Drawing.Point(323, 3);
            this.satisfactionUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.satisfactionUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.satisfactionUpDown.Name = "satisfactionUpDown";
            this.satisfactionUpDown.Size = new System.Drawing.Size(34, 20);
            this.satisfactionUpDown.TabIndex = 1;
            this.satisfactionUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // importanceUpDown
            // 
            this.importanceUpDown.Location = new System.Drawing.Point(436, 3);
            this.importanceUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.importanceUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.importanceUpDown.Name = "importanceUpDown";
            this.importanceUpDown.Size = new System.Drawing.Size(34, 20);
            this.importanceUpDown.TabIndex = 2;
            this.importanceUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(205, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Удовлетворенность:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(370, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Важность:";
            // 
            // QuestControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.importanceUpDown);
            this.Controls.Add(this.satisfactionUpDown);
            this.Controls.Add(this.questLabel);
            this.Name = "QuestControl";
            this.Size = new System.Drawing.Size(475, 40);
            ((System.ComponentModel.ISupportInitialize)(this.satisfactionUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.importanceUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label questLabel;
        private System.Windows.Forms.NumericUpDown satisfactionUpDown;
        private System.Windows.Forms.NumericUpDown importanceUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
