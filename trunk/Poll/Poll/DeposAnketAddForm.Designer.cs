namespace Poll
{
    partial class DeposAnketAddForm
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
            this.filialСomboBox = new System.Windows.Forms.ComboBox();
            this.fILIALBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pollsDataSet = new Poll.PollsDataSet();
            this.otdLabel = new System.Windows.Forms.Label();
            this.fILIALTableAdapter = new Poll.PollsDataSetTableAdapters.FILIALTableAdapter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rkcLabel = new System.Windows.Forms.Label();
            this.otdLable = new System.Windows.Forms.Label();
            this.rkcComboBox = new System.Windows.Forms.ComboBox();
            this.rKCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.otdComboBox = new System.Windows.Forms.ComboBox();
            this.sTRUCTUNITBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sTRUCT_UNITTableAdapter = new Poll.PollsDataSetTableAdapters.STRUCT_UNITTableAdapter();
            this.rKCTableAdapter = new Poll.PollsDataSetTableAdapters.RKCTableAdapter();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ageUpDown = new System.Windows.Forms.NumericUpDown();
            this.ageLabel = new System.Windows.Forms.Label();
            this.sexСomboBox = new System.Windows.Forms.ComboBox();
            this.sexBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sexLabel = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pollsTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.numberTextBox = new System.Windows.Forms.TextBox();
            this.numberLabel = new System.Windows.Forms.Label();
            this.questionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pollsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fILIALBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pollsDataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rKCBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTRUCTUNITBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ageUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sexBindingSource)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.pollsTabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.questionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pollsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // filialСomboBox
            // 
            this.filialСomboBox.DataSource = this.fILIALBindingSource;
            this.filialСomboBox.DisplayMember = "NAME";
            this.filialСomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filialСomboBox.FormattingEnabled = true;
            this.filialСomboBox.Location = new System.Drawing.Point(138, 19);
            this.filialСomboBox.Name = "filialСomboBox";
            this.filialСomboBox.Size = new System.Drawing.Size(174, 21);
            this.filialСomboBox.TabIndex = 0;
            this.filialСomboBox.ValueMember = "COD_FIL";
            this.filialСomboBox.SelectionChangeCommitted += new System.EventHandler(this.filialСomboBox_SelectionChangeCommitted);
            // 
            // fILIALBindingSource
            // 
            this.fILIALBindingSource.DataMember = "FILIAL";
            this.fILIALBindingSource.DataSource = this.pollsDataSet;
            // 
            // pollsDataSet
            // 
            this.pollsDataSet.DataSetName = "PollsDataSet";
            this.pollsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // otdLabel
            // 
            this.otdLabel.AutoSize = true;
            this.otdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.otdLabel.Location = new System.Drawing.Point(6, 22);
            this.otdLabel.Name = "otdLabel";
            this.otdLabel.Size = new System.Drawing.Size(61, 13);
            this.otdLabel.TabIndex = 1;
            this.otdLabel.Text = "Область:";
            // 
            // fILIALTableAdapter
            // 
            this.fILIALTableAdapter.ClearBeforeFill = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rkcLabel);
            this.groupBox1.Controls.Add(this.otdLable);
            this.groupBox1.Controls.Add(this.rkcComboBox);
            this.groupBox1.Controls.Add(this.otdComboBox);
            this.groupBox1.Controls.Add(this.filialСomboBox);
            this.groupBox1.Controls.Add(this.otdLabel);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 106);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Подразделение проводившее опрос:";
            // 
            // rkcLabel
            // 
            this.rkcLabel.AutoSize = true;
            this.rkcLabel.Location = new System.Drawing.Point(6, 78);
            this.rkcLabel.Name = "rkcLabel";
            this.rkcLabel.Size = new System.Drawing.Size(32, 13);
            this.rkcLabel.TabIndex = 5;
            this.rkcLabel.Text = "РКЦ:";
            // 
            // otdLable
            // 
            this.otdLable.AutoSize = true;
            this.otdLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.otdLable.Location = new System.Drawing.Point(6, 50);
            this.otdLable.Name = "otdLable";
            this.otdLable.Size = new System.Drawing.Size(124, 13);
            this.otdLable.TabIndex = 4;
            this.otdLable.Text = "Отделение/ОПЕРУ:";
            // 
            // rkcComboBox
            // 
            this.rkcComboBox.DataSource = this.rKCBindingSource;
            this.rkcComboBox.DisplayMember = "NAME";
            this.rkcComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rkcComboBox.FormattingEnabled = true;
            this.rkcComboBox.Location = new System.Drawing.Point(138, 75);
            this.rkcComboBox.Name = "rkcComboBox";
            this.rkcComboBox.Size = new System.Drawing.Size(174, 21);
            this.rkcComboBox.TabIndex = 3;
            this.rkcComboBox.ValueMember = "CODE_RKC";
            // 
            // rKCBindingSource
            // 
            this.rKCBindingSource.DataMember = "RKC";
            this.rKCBindingSource.DataSource = this.pollsDataSet;
            // 
            // otdComboBox
            // 
            this.otdComboBox.DataSource = this.sTRUCTUNITBindingSource;
            this.otdComboBox.DisplayMember = "NAME";
            this.otdComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.otdComboBox.DropDownWidth = 300;
            this.otdComboBox.FormattingEnabled = true;
            this.otdComboBox.Location = new System.Drawing.Point(138, 47);
            this.otdComboBox.Name = "otdComboBox";
            this.otdComboBox.Size = new System.Drawing.Size(174, 21);
            this.otdComboBox.TabIndex = 2;
            this.otdComboBox.ValueMember = "BRANCH";
            this.otdComboBox.SelectionChangeCommitted += new System.EventHandler(this.otdComboBox_SelectionChangeCommitted);
            // 
            // sTRUCTUNITBindingSource
            // 
            this.sTRUCTUNITBindingSource.DataMember = "STRUCT_UNIT";
            this.sTRUCTUNITBindingSource.DataSource = this.pollsDataSet;
            // 
            // sTRUCT_UNITTableAdapter
            // 
            this.sTRUCT_UNITTableAdapter.ClearBeforeFill = true;
            // 
            // rKCTableAdapter
            // 
            this.rKCTableAdapter.ClearBeforeFill = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ageUpDown);
            this.groupBox2.Controls.Add(this.numberTextBox);
            this.groupBox2.Controls.Add(this.ageLabel);
            this.groupBox2.Controls.Add(this.numberLabel);
            this.groupBox2.Controls.Add(this.sexСomboBox);
            this.groupBox2.Controls.Add(this.sexLabel);
            this.groupBox2.Location = new System.Drawing.Point(339, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(207, 106);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Данные респондента:";
            // 
            // ageUpDown
            // 
            this.ageUpDown.Location = new System.Drawing.Point(76, 48);
            this.ageUpDown.Maximum = new decimal(new int[] {
            130,
            0,
            0,
            0});
            this.ageUpDown.Minimum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.ageUpDown.Name = "ageUpDown";
            this.ageUpDown.Size = new System.Drawing.Size(39, 20);
            this.ageUpDown.TabIndex = 3;
            this.ageUpDown.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            // 
            // ageLabel
            // 
            this.ageLabel.AutoSize = true;
            this.ageLabel.Location = new System.Drawing.Point(6, 50);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new System.Drawing.Size(52, 13);
            this.ageLabel.TabIndex = 2;
            this.ageLabel.Text = "Возраст:";
            // 
            // sexСomboBox
            // 
            this.sexСomboBox.DataSource = this.sexBindingSource;
            this.sexСomboBox.DisplayMember = "SexName";
            this.sexСomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sexСomboBox.FormattingEnabled = true;
            this.sexСomboBox.Location = new System.Drawing.Point(76, 19);
            this.sexСomboBox.Name = "sexСomboBox";
            this.sexСomboBox.Size = new System.Drawing.Size(121, 21);
            this.sexСomboBox.TabIndex = 1;
            this.sexСomboBox.ValueMember = "SexID";
            // 
            // sexBindingSource
            // 
            this.sexBindingSource.DataMember = "Sex";
            this.sexBindingSource.DataSource = this.pollsDataSet;
            // 
            // sexLabel
            // 
            this.sexLabel.AutoSize = true;
            this.sexLabel.Location = new System.Drawing.Point(6, 22);
            this.sexLabel.Name = "sexLabel";
            this.sexLabel.Size = new System.Drawing.Size(30, 13);
            this.sexLabel.TabIndex = 0;
            this.sexLabel.Text = "Пол:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pollsTabControl);
            this.groupBox3.Location = new System.Drawing.Point(12, 126);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(534, 470);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Анкета по вкладам:";
            // 
            // pollsTabControl
            // 
            this.pollsTabControl.Controls.Add(this.tabPage1);
            this.pollsTabControl.Controls.Add(this.tabPage2);
            this.pollsTabControl.Location = new System.Drawing.Point(10, 19);
            this.pollsTabControl.Name = "pollsTabControl";
            this.pollsTabControl.SelectedIndex = 0;
            this.pollsTabControl.Size = new System.Drawing.Size(513, 445);
            this.pollsTabControl.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(505, 419);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(505, 303);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // numberTextBox
            // 
            this.numberTextBox.Location = new System.Drawing.Point(100, 80);
            this.numberTextBox.Name = "numberTextBox";
            this.numberTextBox.Size = new System.Drawing.Size(96, 20);
            this.numberTextBox.TabIndex = 1;
            this.numberTextBox.TextChanged += new System.EventHandler(this.numberTextBox_TextChanged);
            this.numberTextBox.Validated += new System.EventHandler(this.numberTextBox_Validated);
            // 
            // numberLabel
            // 
            this.numberLabel.AutoSize = true;
            this.numberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numberLabel.Location = new System.Drawing.Point(6, 83);
            this.numberLabel.Name = "numberLabel";
            this.numberLabel.Size = new System.Drawing.Size(97, 13);
            this.numberLabel.TabIndex = 0;
            this.numberLabel.Text = "Номер анкеты:";
            // 
            // questionBindingSource
            // 
            this.questionBindingSource.DataMember = "Question";
            this.questionBindingSource.DataSource = this.pollsDataSet;
            // 
            // DeposAnketAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 630);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "DeposAnketAddForm";
            this.Text = "Новая анкета";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeposAnketAddForm_FormClosing);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fILIALBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pollsDataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rKCBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTRUCTUNITBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ageUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sexBindingSource)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.pollsTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.questionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pollsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox filialСomboBox;
        private System.Windows.Forms.Label otdLabel;
        private System.Windows.Forms.BindingSource fILIALBindingSource;
        private PollsDataSet pollsDataSet;
        private PollsDataSetTableAdapters.FILIALTableAdapter fILIALTableAdapter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox otdComboBox;
        private System.Windows.Forms.BindingSource sTRUCTUNITBindingSource;
        private PollsDataSetTableAdapters.STRUCT_UNITTableAdapter sTRUCT_UNITTableAdapter;
        private System.Windows.Forms.ComboBox rkcComboBox;
        private System.Windows.Forms.BindingSource rKCBindingSource;
        private PollsDataSetTableAdapters.RKCTableAdapter rKCTableAdapter;
        private System.Windows.Forms.Label rkcLabel;
        private System.Windows.Forms.Label otdLable;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox sexСomboBox;
        private System.Windows.Forms.Label sexLabel;
        private System.Windows.Forms.BindingSource sexBindingSource;
        private System.Windows.Forms.NumericUpDown ageUpDown;
        private System.Windows.Forms.Label ageLabel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox numberTextBox;
        private System.Windows.Forms.Label numberLabel;
        private System.Windows.Forms.BindingSource questionBindingSource;
        private System.Windows.Forms.TabControl pollsTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.BindingSource pollsBindingSource;
    }
}