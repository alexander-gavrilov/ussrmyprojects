namespace bapbpolls
{
    partial class SelectionAnketControl
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
            this.components = new System.ComponentModel.Container();
            this.labelYear = new System.Windows.Forms.Label();
            this.labelQuarter = new System.Windows.Forms.Label();
            this.comboBoxYear = new System.Windows.Forms.ComboBox();
            this.yearsBindungSource = new System.Windows.Forms.BindingSource(this.components);
            this.pollsDataSet = new bapbpolls.PollsDataSet();
            this.comboBoxQuarter = new System.Windows.Forms.ComboBox();
            this.quartersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelRegion = new System.Windows.Forms.Label();
            this.comboBoxRegion = new System.Windows.Forms.ComboBox();
            this.filialBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBoxPollType = new System.Windows.Forms.ComboBox();
            this.typesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelPollType = new System.Windows.Forms.Label();
            this.yEARSTableAdapter = new bapbpolls.PollsDataSetTableAdapters.YEARSTableAdapter();
            this.fILIALTableAdapter = new bapbpolls.PollsDataSetTableAdapters.FILIALTableAdapter();
            this.qUARTERSTableAdapter = new bapbpolls.PollsDataSetTableAdapters.QUARTERSTableAdapter();
            this.tYPESTableAdapter = new bapbpolls.PollsDataSetTableAdapters.TYPESTableAdapter();
            this.fILIALVIEWTableAdapter = new bapbpolls.PollsDataSetTableAdapters.FILIALVIEWTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.yearsBindungSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pollsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quartersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filialBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.typesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // labelYear
            // 
            this.labelYear.AutoSize = true;
            this.labelYear.Location = new System.Drawing.Point(4, 7);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(28, 13);
            this.labelYear.TabIndex = 0;
            this.labelYear.Text = "Год:";
            // 
            // labelQuarter
            // 
            this.labelQuarter.AutoSize = true;
            this.labelQuarter.Location = new System.Drawing.Point(174, 7);
            this.labelQuarter.Name = "labelQuarter";
            this.labelQuarter.Size = new System.Drawing.Size(52, 13);
            this.labelQuarter.TabIndex = 1;
            this.labelQuarter.Text = "Квартал:";
            // 
            // comboBoxYear
            // 
            this.comboBoxYear.DataSource = this.yearsBindungSource;
            this.comboBoxYear.DisplayMember = "YEARS";
            this.comboBoxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxYear.FormattingEnabled = true;
            this.comboBoxYear.Location = new System.Drawing.Point(38, 4);
            this.comboBoxYear.Name = "comboBoxYear";
            this.comboBoxYear.Size = new System.Drawing.Size(121, 21);
            this.comboBoxYear.TabIndex = 2;
            this.comboBoxYear.ValueMember = "YEARS";
            this.comboBoxYear.SelectedValueChanged += new System.EventHandler(this.comboBoxYear_SelectedValueChanged);
            // 
            // yearsBindungSource
            // 
            this.yearsBindungSource.DataMember = "YEARS";
            this.yearsBindungSource.DataSource = this.pollsDataSet;
            // 
            // pollsDataSet
            // 
            this.pollsDataSet.DataSetName = "PollsDataSet";
            this.pollsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // comboBoxQuarter
            // 
            this.comboBoxQuarter.DataSource = this.quartersBindingSource;
            this.comboBoxQuarter.DisplayMember = "TEXT";
            this.comboBoxQuarter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxQuarter.FormattingEnabled = true;
            this.comboBoxQuarter.Location = new System.Drawing.Point(232, 4);
            this.comboBoxQuarter.Name = "comboBoxQuarter";
            this.comboBoxQuarter.Size = new System.Drawing.Size(121, 21);
            this.comboBoxQuarter.TabIndex = 3;
            this.comboBoxQuarter.ValueMember = "QUARTER";
            this.comboBoxQuarter.SelectedIndexChanged += new System.EventHandler(this.comboBoxQuarter_SelectedIndexChanged);
            // 
            // quartersBindingSource
            // 
            this.quartersBindingSource.DataMember = "QUARTERS";
            this.quartersBindingSource.DataSource = this.pollsDataSet;
            // 
            // labelRegion
            // 
            this.labelRegion.AutoSize = true;
            this.labelRegion.Location = new System.Drawing.Point(371, 7);
            this.labelRegion.Name = "labelRegion";
            this.labelRegion.Size = new System.Drawing.Size(53, 13);
            this.labelRegion.TabIndex = 4;
            this.labelRegion.Text = "Область:";
            // 
            // comboBoxRegion
            // 
            this.comboBoxRegion.DataSource = this.filialBindingSource;
            this.comboBoxRegion.DisplayMember = "NAME";
            this.comboBoxRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRegion.FormattingEnabled = true;
            this.comboBoxRegion.Location = new System.Drawing.Point(430, 4);
            this.comboBoxRegion.Name = "comboBoxRegion";
            this.comboBoxRegion.Size = new System.Drawing.Size(121, 21);
            this.comboBoxRegion.TabIndex = 3;
            this.comboBoxRegion.ValueMember = "COD_FIL";
            this.comboBoxRegion.SelectedValueChanged += new System.EventHandler(this.comboBoxRegion_SelectedValueChanged);
            // 
            // filialBindingSource
            // 
            this.filialBindingSource.DataMember = "FILIALVIEW";
            this.filialBindingSource.DataSource = this.pollsDataSet;
            // 
            // comboBoxPollType
            // 
            this.comboBoxPollType.DataSource = this.typesBindingSource;
            this.comboBoxPollType.DisplayMember = "NAME";
            this.comboBoxPollType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPollType.FormattingEnabled = true;
            this.comboBoxPollType.Location = new System.Drawing.Point(647, 4);
            this.comboBoxPollType.Name = "comboBoxPollType";
            this.comboBoxPollType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPollType.TabIndex = 3;
            this.comboBoxPollType.ValueMember = "TYPE";
            this.comboBoxPollType.SelectedIndexChanged += new System.EventHandler(this.comboBoxPollType_SelectedIndexChanged);
            // 
            // typesBindingSource
            // 
            this.typesBindingSource.DataMember = "TYPES";
            this.typesBindingSource.DataSource = this.pollsDataSet;
            // 
            // labelPollType
            // 
            this.labelPollType.AutoSize = true;
            this.labelPollType.Location = new System.Drawing.Point(572, 7);
            this.labelPollType.Name = "labelPollType";
            this.labelPollType.Size = new System.Drawing.Size(69, 13);
            this.labelPollType.TabIndex = 4;
            this.labelPollType.Text = "Тип анкеты:";
            // 
            // yEARSTableAdapter
            // 
            this.yEARSTableAdapter.ClearBeforeFill = true;
            // 
            // fILIALTableAdapter
            // 
            this.fILIALTableAdapter.ClearBeforeFill = true;
            // 
            // qUARTERSTableAdapter
            // 
            this.qUARTERSTableAdapter.ClearBeforeFill = true;
            // 
            // tYPESTableAdapter
            // 
            this.tYPESTableAdapter.ClearBeforeFill = true;
            // 
            // fILIALVIEWTableAdapter
            // 
            this.fILIALVIEWTableAdapter.ClearBeforeFill = true;
            // 
            // SelectionAnketControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelPollType);
            this.Controls.Add(this.comboBoxPollType);
            this.Controls.Add(this.labelRegion);
            this.Controls.Add(this.comboBoxRegion);
            this.Controls.Add(this.comboBoxQuarter);
            this.Controls.Add(this.comboBoxYear);
            this.Controls.Add(this.labelQuarter);
            this.Controls.Add(this.labelYear);
            this.Name = "SelectionAnketControl";
            this.Size = new System.Drawing.Size(779, 30);
            ((System.ComponentModel.ISupportInitialize)(this.yearsBindungSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pollsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quartersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filialBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.typesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label labelYear;
        public System.Windows.Forms.Label labelQuarter;
        public System.Windows.Forms.ComboBox comboBoxYear;
        public System.Windows.Forms.ComboBox comboBoxQuarter;
        public System.Windows.Forms.Label labelRegion;
        public System.Windows.Forms.ComboBox comboBoxRegion;
        public System.Windows.Forms.ComboBox comboBoxPollType;
        public System.Windows.Forms.Label labelPollType;
        public System.Windows.Forms.BindingSource filialBindingSource;
        public System.Windows.Forms.BindingSource yearsBindungSource;
        public PollsDataSet pollsDataSet;
        public PollsDataSetTableAdapters.YEARSTableAdapter yEARSTableAdapter;
        public PollsDataSetTableAdapters.FILIALTableAdapter fILIALTableAdapter;
        public System.Windows.Forms.BindingSource quartersBindingSource;
        public PollsDataSetTableAdapters.QUARTERSTableAdapter qUARTERSTableAdapter;
        public System.Windows.Forms.BindingSource typesBindingSource;
        public PollsDataSetTableAdapters.TYPESTableAdapter tYPESTableAdapter;
        private PollsDataSetTableAdapters.FILIALVIEWTableAdapter fILIALVIEWTableAdapter;

    }
}
