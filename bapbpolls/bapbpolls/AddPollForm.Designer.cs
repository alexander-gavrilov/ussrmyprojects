namespace bapbpolls
{
    partial class AddPollForm
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
            this.lableRegion = new System.Windows.Forms.Label();
            this.comboBoxRegion = new System.Windows.Forms.ComboBox();
            this.fILIALBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pollsDataSet = new bapbpolls.PollsDataSet();
            this.labelStructUnite = new System.Windows.Forms.Label();
            this.comboBoxStructUnite = new System.Windows.Forms.ComboBox();
            this.sTRUCTUNITBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBoxRKC = new System.Windows.Forms.ComboBox();
            this.rKCViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelRKC = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.labelSex = new System.Windows.Forms.Label();
            this.comboBoxSex = new System.Windows.Forms.ComboBox();
            this.sEXBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.maskedTextBoxNumber = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkedListBoxType = new System.Windows.Forms.CheckedListBox();
            this.tabControlPolls = new System.Windows.Forms.TabControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.labelAge = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.sTRUCT_UNITTableAdapter = new bapbpolls.PollsDataSetTableAdapters.STRUCT_UNITTableAdapter();
            this.fILIALTableAdapter = new bapbpolls.PollsDataSetTableAdapters.FILIALTableAdapter();
            this.rKCViewTableAdapter = new bapbpolls.PollsDataSetTableAdapters.RKCViewTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.fILIALBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pollsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTRUCTUNITBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rKCViewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sEXBindingSource)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rejectChangesButton
            // 
            this.rejectChangesButton.Text = "Закрыть";
            // 
            // acceptChangesButton
            // 
            this.acceptChangesButton.Enabled = false;
            this.acceptChangesButton.Text = "Добавить";
            this.acceptChangesButton.Click += new System.EventHandler(this.acceptChangesButton_Click);
            // 
            // lableRegion
            // 
            this.lableRegion.AutoSize = true;
            this.lableRegion.Location = new System.Drawing.Point(3, 9);
            this.lableRegion.Name = "lableRegion";
            this.lableRegion.Size = new System.Drawing.Size(53, 13);
            this.lableRegion.TabIndex = 3;
            this.lableRegion.Text = "Область:";
            // 
            // comboBoxRegion
            // 
            this.comboBoxRegion.DataSource = this.fILIALBindingSource;
            this.comboBoxRegion.DisplayMember = "NAME";
            this.comboBoxRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRegion.FormattingEnabled = true;
            this.comboBoxRegion.Location = new System.Drawing.Point(62, 6);
            this.comboBoxRegion.Name = "comboBoxRegion";
            this.comboBoxRegion.Size = new System.Drawing.Size(177, 21);
            this.comboBoxRegion.TabIndex = 4;
            this.comboBoxRegion.ValueMember = "COD_FIL";
            this.comboBoxRegion.SelectedValueChanged += new System.EventHandler(this.comboBoxRegion_SelectedValueChanged);
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
            // labelStructUnite
            // 
            this.labelStructUnite.AutoSize = true;
            this.labelStructUnite.Location = new System.Drawing.Point(264, 9);
            this.labelStructUnite.Name = "labelStructUnite";
            this.labelStructUnite.Size = new System.Drawing.Size(108, 13);
            this.labelStructUnite.TabIndex = 5;
            this.labelStructUnite.Text = "Отделение/ОПЕРУ:";
            // 
            // comboBoxStructUnite
            // 
            this.comboBoxStructUnite.DataSource = this.sTRUCTUNITBindingSource;
            this.comboBoxStructUnite.DisplayMember = "NAME";
            this.comboBoxStructUnite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStructUnite.DropDownWidth = 300;
            this.comboBoxStructUnite.FormattingEnabled = true;
            this.comboBoxStructUnite.Location = new System.Drawing.Point(378, 6);
            this.comboBoxStructUnite.Name = "comboBoxStructUnite";
            this.comboBoxStructUnite.Size = new System.Drawing.Size(186, 21);
            this.comboBoxStructUnite.TabIndex = 4;
            this.comboBoxStructUnite.ValueMember = "BRANCH";
            this.comboBoxStructUnite.SelectedIndexChanged += new System.EventHandler(this.comboBoxStructUnite_SelectedIndexChanged);
            // 
            // sTRUCTUNITBindingSource
            // 
            this.sTRUCTUNITBindingSource.DataMember = "STRUCT_UNIT";
            this.sTRUCTUNITBindingSource.DataSource = this.pollsDataSet;
            // 
            // comboBoxRKC
            // 
            this.comboBoxRKC.DataSource = this.rKCViewBindingSource;
            this.comboBoxRKC.DisplayMember = "NAME";
            this.comboBoxRKC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRKC.DropDownWidth = 300;
            this.comboBoxRKC.FormattingEnabled = true;
            this.comboBoxRKC.Location = new System.Drawing.Point(665, 6);
            this.comboBoxRKC.Name = "comboBoxRKC";
            this.comboBoxRKC.Size = new System.Drawing.Size(189, 21);
            this.comboBoxRKC.TabIndex = 4;
            this.comboBoxRKC.ValueMember = "CODE_RKC";
            // 
            // rKCViewBindingSource
            // 
            this.rKCViewBindingSource.DataMember = "RKCView";
            this.rKCViewBindingSource.DataSource = this.pollsDataSet;
            // 
            // labelRKC
            // 
            this.labelRKC.AutoSize = true;
            this.labelRKC.Location = new System.Drawing.Point(627, 9);
            this.labelRKC.Name = "labelRKC";
            this.labelRKC.Size = new System.Drawing.Size(32, 13);
            this.labelRKC.TabIndex = 5;
            this.labelRKC.Text = "РКЦ:";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(3, 36);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(36, 13);
            this.labelDate.TabIndex = 6;
            this.labelDate.Text = "Дата:";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(62, 35);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(177, 20);
            this.dateTimePicker.TabIndex = 7;
            // 
            // labelSex
            // 
            this.labelSex.AutoSize = true;
            this.labelSex.Location = new System.Drawing.Point(342, 36);
            this.labelSex.Name = "labelSex";
            this.labelSex.Size = new System.Drawing.Size(30, 13);
            this.labelSex.TabIndex = 8;
            this.labelSex.Text = "Пол:";
            // 
            // comboBoxSex
            // 
            this.comboBoxSex.DataSource = this.sEXBindingSource;
            this.comboBoxSex.DisplayMember = "text";
            this.comboBoxSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSex.FormattingEnabled = true;
            this.comboBoxSex.Location = new System.Drawing.Point(378, 33);
            this.comboBoxSex.Name = "comboBoxSex";
            this.comboBoxSex.Size = new System.Drawing.Size(186, 21);
            this.comboBoxSex.TabIndex = 4;
            this.comboBoxSex.ValueMember = "idSex";
            // 
            // sEXBindingSource
            // 
            this.sEXBindingSource.DataMember = "SEX";
            this.sEXBindingSource.DataSource = this.pollsDataSet;
            // 
            // maskedTextBoxNumber
            // 
            this.maskedTextBoxNumber.Location = new System.Drawing.Point(665, 33);
            this.maskedTextBoxNumber.Mask = "######";
            this.maskedTextBoxNumber.Name = "maskedTextBoxNumber";
            this.maskedTextBoxNumber.PromptChar = ' ';
            this.maskedTextBoxNumber.Size = new System.Drawing.Size(189, 20);
            this.maskedTextBoxNumber.TabIndex = 9;
            this.maskedTextBoxNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.maskedTextBoxNumber.ValidatingType = typeof(int);
            this.maskedTextBoxNumber.Validated += new System.EventHandler(this.maskedTextBoxNumber_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(586, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "№ интервью:";
            // 
            // checkedListBoxType
            // 
            this.checkedListBoxType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxType.FormattingEnabled = true;
            this.checkedListBoxType.Location = new System.Drawing.Point(0, 0);
            this.checkedListBoxType.Name = "checkedListBoxType";
            this.checkedListBoxType.Size = new System.Drawing.Size(142, 609);
            this.checkedListBoxType.TabIndex = 10;
            this.checkedListBoxType.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxType_ItemCheck);
            // 
            // tabControlPolls
            // 
            this.tabControlPolls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPolls.Location = new System.Drawing.Point(0, 0);
            this.tabControlPolls.Name = "tabControlPolls";
            this.tabControlPolls.SelectedIndex = 0;
            this.tabControlPolls.Size = new System.Drawing.Size(855, 609);
            this.tabControlPolls.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.numericUpDown1);
            this.panel3.Controls.Add(this.comboBoxRKC);
            this.panel3.Controls.Add(this.comboBoxSex);
            this.panel3.Controls.Add(this.lableRegion);
            this.panel3.Controls.Add(this.comboBoxStructUnite);
            this.panel3.Controls.Add(this.maskedTextBoxNumber);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.dateTimePicker);
            this.panel3.Controls.Add(this.comboBoxRegion);
            this.panel3.Controls.Add(this.labelSex);
            this.panel3.Controls.Add(this.labelDate);
            this.panel3.Controls.Add(this.labelStructUnite);
            this.panel3.Controls.Add(this.labelAge);
            this.panel3.Controls.Add(this.labelRKC);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1001, 59);
            this.panel3.TabIndex = 13;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(941, 7);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(53, 20);
            this.numericUpDown1.TabIndex = 10;
            this.numericUpDown1.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            // 
            // labelAge
            // 
            this.labelAge.AutoSize = true;
            this.labelAge.Location = new System.Drawing.Point(883, 9);
            this.labelAge.Name = "labelAge";
            this.labelAge.Size = new System.Drawing.Size(52, 13);
            this.labelAge.TabIndex = 5;
            this.labelAge.Text = "Возраст:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 59);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.checkedListBoxType);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControlPolls);
            this.splitContainer1.Size = new System.Drawing.Size(1001, 609);
            this.splitContainer1.SplitterDistance = 142;
            this.splitContainer1.TabIndex = 14;
            // 
            // sTRUCT_UNITTableAdapter
            // 
            this.sTRUCT_UNITTableAdapter.ClearBeforeFill = true;
            // 
            // fILIALTableAdapter
            // 
            this.fILIALTableAdapter.ClearBeforeFill = true;
            // 
            // rKCViewTableAdapter
            // 
            this.rKCViewTableAdapter.ClearBeforeFill = true;
            // 
            // AddPollForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1001, 696);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel3);
            this.Name = "AddPollForm";
            this.ShowInTaskbar = false;
            this.Text = "AddPollForm";
            this.Load += new System.EventHandler(this.AddPollForm_Load);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fILIALBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pollsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTRUCTUNITBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rKCViewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sEXBindingSource)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lableRegion;
        private System.Windows.Forms.ComboBox comboBoxRegion;
        private System.Windows.Forms.Label labelStructUnite;
        private System.Windows.Forms.ComboBox comboBoxStructUnite;
        private System.Windows.Forms.ComboBox comboBoxRKC;
        private System.Windows.Forms.Label labelRKC;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label labelSex;
        private System.Windows.Forms.ComboBox comboBoxSex;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedListBoxType;
        private System.Windows.Forms.TabControl tabControlPolls;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private PollsDataSet pollsDataSet;
        private System.Windows.Forms.BindingSource sTRUCTUNITBindingSource;
        private PollsDataSetTableAdapters.STRUCT_UNITTableAdapter sTRUCT_UNITTableAdapter;
        private System.Windows.Forms.BindingSource fILIALBindingSource;
        private PollsDataSetTableAdapters.FILIALTableAdapter fILIALTableAdapter;
        private System.Windows.Forms.BindingSource rKCViewBindingSource;
        private PollsDataSetTableAdapters.RKCViewTableAdapter rKCViewTableAdapter;
        private System.Windows.Forms.BindingSource sEXBindingSource;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label labelAge;

    }
}