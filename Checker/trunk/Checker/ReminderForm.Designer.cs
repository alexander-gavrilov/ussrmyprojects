namespace Checker
{
    partial class ReminderForm
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
            this.runButton = new System.Windows.Forms.Button();
            this.holdButton = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.executeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.processDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sectionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.treatmentDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.maskDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.runprocessDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dirsDTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chekerDS = new Checker.ChekerDS();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dirsDTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chekerDS)).BeginInit();
            this.SuspendLayout();
            // 
            // runButton
            // 
            this.runButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.runButton.Location = new System.Drawing.Point(411, 325);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 23);
            this.runButton.TabIndex = 1;
            this.runButton.Text = "Обработать";
            this.runButton.UseVisualStyleBackColor = true;
            // 
            // holdButton
            // 
            this.holdButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.holdButton.Location = new System.Drawing.Point(492, 325);
            this.holdButton.Name = "holdButton";
            this.holdButton.Size = new System.Drawing.Size(84, 23);
            this.holdButton.TabIndex = 2;
            this.holdButton.Text = "Отложить на";
            this.holdButton.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(583, 326);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            240,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(46, 20);
            this.numericUpDown1.TabIndex = 3;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(635, 330);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "минут";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.pathDataGridViewTextBoxColumn,
            this.executeDataGridViewTextBoxColumn,
            this.processDataGridViewTextBoxColumn,
            this.commentDataGridViewTextBoxColumn,
            this.sectionDataGridViewTextBoxColumn,
            this.treatmentDataGridViewCheckBoxColumn,
            this.maskDataGridViewTextBoxColumn,
            this.runprocessDataGridViewCheckBoxColumn});
            this.dataGridView1.DataSource = this.dirsDTBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(676, 319);
            this.dataGridView1.TabIndex = 5;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // pathDataGridViewTextBoxColumn
            // 
            this.pathDataGridViewTextBoxColumn.DataPropertyName = "path";
            this.pathDataGridViewTextBoxColumn.HeaderText = "path";
            this.pathDataGridViewTextBoxColumn.Name = "pathDataGridViewTextBoxColumn";
            this.pathDataGridViewTextBoxColumn.Visible = false;
            // 
            // executeDataGridViewTextBoxColumn
            // 
            this.executeDataGridViewTextBoxColumn.DataPropertyName = "execute";
            this.executeDataGridViewTextBoxColumn.HeaderText = "execute";
            this.executeDataGridViewTextBoxColumn.Name = "executeDataGridViewTextBoxColumn";
            this.executeDataGridViewTextBoxColumn.Visible = false;
            // 
            // processDataGridViewTextBoxColumn
            // 
            this.processDataGridViewTextBoxColumn.DataPropertyName = "process";
            this.processDataGridViewTextBoxColumn.HeaderText = "process";
            this.processDataGridViewTextBoxColumn.Name = "processDataGridViewTextBoxColumn";
            this.processDataGridViewTextBoxColumn.Visible = false;
            // 
            // commentDataGridViewTextBoxColumn
            // 
            this.commentDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.commentDataGridViewTextBoxColumn.DataPropertyName = "comment";
            this.commentDataGridViewTextBoxColumn.HeaderText = "Описание";
            this.commentDataGridViewTextBoxColumn.Name = "commentDataGridViewTextBoxColumn";
            this.commentDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sectionDataGridViewTextBoxColumn
            // 
            this.sectionDataGridViewTextBoxColumn.DataPropertyName = "section";
            this.sectionDataGridViewTextBoxColumn.HeaderText = "section";
            this.sectionDataGridViewTextBoxColumn.Name = "sectionDataGridViewTextBoxColumn";
            this.sectionDataGridViewTextBoxColumn.Visible = false;
            // 
            // treatmentDataGridViewCheckBoxColumn
            // 
            this.treatmentDataGridViewCheckBoxColumn.DataPropertyName = "treatment";
            this.treatmentDataGridViewCheckBoxColumn.HeaderText = "treatment";
            this.treatmentDataGridViewCheckBoxColumn.Name = "treatmentDataGridViewCheckBoxColumn";
            this.treatmentDataGridViewCheckBoxColumn.Visible = false;
            // 
            // maskDataGridViewTextBoxColumn
            // 
            this.maskDataGridViewTextBoxColumn.DataPropertyName = "mask";
            this.maskDataGridViewTextBoxColumn.HeaderText = "mask";
            this.maskDataGridViewTextBoxColumn.Name = "maskDataGridViewTextBoxColumn";
            this.maskDataGridViewTextBoxColumn.Visible = false;
            // 
            // runprocessDataGridViewCheckBoxColumn
            // 
            this.runprocessDataGridViewCheckBoxColumn.DataPropertyName = "runprocess";
            this.runprocessDataGridViewCheckBoxColumn.HeaderText = "Запуск обработчика";
            this.runprocessDataGridViewCheckBoxColumn.Name = "runprocessDataGridViewCheckBoxColumn";
            // 
            // dirsDTBindingSource
            // 
            this.dirsDTBindingSource.DataMember = "DirsDT";
            this.dirsDTBindingSource.DataSource = this.chekerDS;
            // 
            // chekerDS
            // 
            this.chekerDS.DataSetName = "ChekerDS";
            this.chekerDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ReminderForm
            // 
            this.AcceptButton = this.runButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.holdButton;
            this.ClientSize = new System.Drawing.Size(676, 351);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.holdButton);
            this.Controls.Add(this.runButton);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(692, 389);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(692, 389);
            this.Name = "ReminderForm";
            this.Text = "ReminderForm";
            this.Load += new System.EventHandler(this.ReminderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dirsDTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chekerDS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Button holdButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn executeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn processDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sectionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn treatmentDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maskDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn runprocessDataGridViewCheckBoxColumn;
        private System.Windows.Forms.BindingSource dirsDTBindingSource;
        private ChekerDS chekerDS;
        public System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}