namespace Poll
{
    partial class FiltrControl
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
            this.labelFilial = new System.Windows.Forms.Label();
            this.labelSutructUnion = new System.Windows.Forms.Label();
            this.labelRKC = new System.Windows.Forms.Label();
            this.comboBoxFilial = new System.Windows.Forms.ComboBox();
            this.comboBoxStructUnion = new System.Windows.Forms.ComboBox();
            this.comboBoxRKC = new System.Windows.Forms.ComboBox();
            this.labelAgeFrom = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxAgeFrom = new System.Windows.Forms.ComboBox();
            this.labelAgeTo = new System.Windows.Forms.Label();
            this.comboBoxAgeTo = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelFilial
            // 
            this.labelFilial.AutoSize = true;
            this.labelFilial.Location = new System.Drawing.Point(4, 13);
            this.labelFilial.Name = "labelFilial";
            this.labelFilial.Size = new System.Drawing.Size(53, 13);
            this.labelFilial.TabIndex = 0;
            this.labelFilial.Text = "Область:";
            // 
            // labelSutructUnion
            // 
            this.labelSutructUnion.AutoSize = true;
            this.labelSutructUnion.Location = new System.Drawing.Point(4, 35);
            this.labelSutructUnion.Name = "labelSutructUnion";
            this.labelSutructUnion.Size = new System.Drawing.Size(65, 13);
            this.labelSutructUnion.TabIndex = 1;
            this.labelSutructUnion.Text = "Отделение:";
            // 
            // labelRKC
            // 
            this.labelRKC.AutoSize = true;
            this.labelRKC.Location = new System.Drawing.Point(4, 57);
            this.labelRKC.Name = "labelRKC";
            this.labelRKC.Size = new System.Drawing.Size(32, 13);
            this.labelRKC.TabIndex = 2;
            this.labelRKC.Text = "РКЦ:";
            // 
            // comboBoxFilial
            // 
            this.comboBoxFilial.FormattingEnabled = true;
            this.comboBoxFilial.Location = new System.Drawing.Point(79, 10);
            this.comboBoxFilial.Name = "comboBoxFilial";
            this.comboBoxFilial.Size = new System.Drawing.Size(152, 21);
            this.comboBoxFilial.TabIndex = 3;
            // 
            // comboBoxStructUnion
            // 
            this.comboBoxStructUnion.FormattingEnabled = true;
            this.comboBoxStructUnion.Location = new System.Drawing.Point(79, 32);
            this.comboBoxStructUnion.Name = "comboBoxStructUnion";
            this.comboBoxStructUnion.Size = new System.Drawing.Size(152, 21);
            this.comboBoxStructUnion.TabIndex = 4;
            // 
            // comboBoxRKC
            // 
            this.comboBoxRKC.FormattingEnabled = true;
            this.comboBoxRKC.Location = new System.Drawing.Point(79, 54);
            this.comboBoxRKC.Name = "comboBoxRKC";
            this.comboBoxRKC.Size = new System.Drawing.Size(152, 21);
            this.comboBoxRKC.TabIndex = 5;
            // 
            // labelAgeFrom
            // 
            this.labelAgeFrom.AutoSize = true;
            this.labelAgeFrom.Location = new System.Drawing.Point(258, 13);
            this.labelAgeFrom.Name = "labelAgeFrom";
            this.labelAgeFrom.Size = new System.Drawing.Size(63, 13);
            this.labelAgeFrom.TabIndex = 6;
            this.labelAgeFrom.Text = "Возраст от";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(258, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Пол:";
            // 
            // comboBoxAgeFrom
            // 
            this.comboBoxAgeFrom.FormattingEnabled = true;
            this.comboBoxAgeFrom.Location = new System.Drawing.Point(327, 10);
            this.comboBoxAgeFrom.Name = "comboBoxAgeFrom";
            this.comboBoxAgeFrom.Size = new System.Drawing.Size(38, 21);
            this.comboBoxAgeFrom.TabIndex = 8;
            // 
            // labelAgeTo
            // 
            this.labelAgeTo.AutoSize = true;
            this.labelAgeTo.Location = new System.Drawing.Point(371, 13);
            this.labelAgeTo.Name = "labelAgeTo";
            this.labelAgeTo.Size = new System.Drawing.Size(19, 13);
            this.labelAgeTo.TabIndex = 9;
            this.labelAgeTo.Text = "до";
            // 
            // comboBoxAgeTo
            // 
            this.comboBoxAgeTo.FormattingEnabled = true;
            this.comboBoxAgeTo.Location = new System.Drawing.Point(396, 10);
            this.comboBoxAgeTo.Name = "comboBoxAgeTo";
            this.comboBoxAgeTo.Size = new System.Drawing.Size(38, 21);
            this.comboBoxAgeTo.TabIndex = 8;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(313, 32);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 10;
            // 
            // FiltrControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.labelAgeTo);
            this.Controls.Add(this.comboBoxAgeTo);
            this.Controls.Add(this.comboBoxAgeFrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelAgeFrom);
            this.Controls.Add(this.comboBoxRKC);
            this.Controls.Add(this.comboBoxStructUnion);
            this.Controls.Add(this.comboBoxFilial);
            this.Controls.Add(this.labelRKC);
            this.Controls.Add(this.labelSutructUnion);
            this.Controls.Add(this.labelFilial);
            this.Name = "FiltrControl";
            this.Size = new System.Drawing.Size(702, 91);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFilial;
        private System.Windows.Forms.Label labelSutructUnion;
        private System.Windows.Forms.Label labelRKC;
        private System.Windows.Forms.ComboBox comboBoxFilial;
        private System.Windows.Forms.ComboBox comboBoxStructUnion;
        private System.Windows.Forms.ComboBox comboBoxRKC;
        private System.Windows.Forms.Label labelAgeFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxAgeFrom;
        private System.Windows.Forms.Label labelAgeTo;
        private System.Windows.Forms.ComboBox comboBoxAgeTo;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}
