namespace Poll
{
    partial class PollsTable
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.PollsDataGridView = new System.Windows.Forms.DataGridView();
            this.buttonChangePoll = new System.Windows.Forms.Button();
            this.buttonDeletePoll = new System.Windows.Forms.Button();
            this.buttonAddPoll = new System.Windows.Forms.Button();
            this.pollsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pollsDataSet1 = new Poll.PollsDataSet();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PollsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pollsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pollsDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.PollsDataGridView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.buttonChangePoll);
            this.splitContainer1.Panel2.Controls.Add(this.buttonDeletePoll);
            this.splitContainer1.Panel2.Controls.Add(this.buttonAddPoll);
            this.splitContainer1.Size = new System.Drawing.Size(544, 330);
            this.splitContainer1.SplitterDistance = 292;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // PollsDataGridView
            // 
            this.PollsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PollsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PollsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.PollsDataGridView.Name = "PollsDataGridView";
            this.PollsDataGridView.Size = new System.Drawing.Size(544, 292);
            this.PollsDataGridView.TabIndex = 0;
            // 
            // buttonChangePoll
            // 
            this.buttonChangePoll.Location = new System.Drawing.Point(84, 2);
            this.buttonChangePoll.Name = "buttonChangePoll";
            this.buttonChangePoll.Size = new System.Drawing.Size(75, 23);
            this.buttonChangePoll.TabIndex = 2;
            this.buttonChangePoll.Text = "Изменить";
            this.buttonChangePoll.UseVisualStyleBackColor = true;
            // 
            // buttonDeletePoll
            // 
            this.buttonDeletePoll.Location = new System.Drawing.Point(165, 2);
            this.buttonDeletePoll.Name = "buttonDeletePoll";
            this.buttonDeletePoll.Size = new System.Drawing.Size(75, 23);
            this.buttonDeletePoll.TabIndex = 1;
            this.buttonDeletePoll.Text = "Удалить";
            this.buttonDeletePoll.UseVisualStyleBackColor = true;
            // 
            // buttonAddPoll
            // 
            this.buttonAddPoll.Location = new System.Drawing.Point(3, 2);
            this.buttonAddPoll.Name = "buttonAddPoll";
            this.buttonAddPoll.Size = new System.Drawing.Size(75, 23);
            this.buttonAddPoll.TabIndex = 0;
            this.buttonAddPoll.Text = "Добавить";
            this.buttonAddPoll.UseVisualStyleBackColor = true;
            this.buttonAddPoll.Click += new System.EventHandler(this.buttonAddPoll_Click);
            // 
            // pollsDataSet1
            // 
            this.pollsDataSet1.DataSetName = "PollsDataSet";
            this.pollsDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PollsTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "PollsTable";
            this.Size = new System.Drawing.Size(544, 330);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PollsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pollsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pollsDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.DataGridView PollsDataGridView;
        public System.Windows.Forms.Button buttonChangePoll;
        public System.Windows.Forms.Button buttonDeletePoll;
        public System.Windows.Forms.Button buttonAddPoll;
        public System.Windows.Forms.BindingSource pollsBindingSource;
        public PollsDataSet pollsDataSet1;

    }
}
