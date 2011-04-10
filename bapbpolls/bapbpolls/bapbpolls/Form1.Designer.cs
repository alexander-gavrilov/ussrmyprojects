namespace bapbpolls
{
    partial class MainPollsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPollsForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addPollToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.delPollToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.changePollToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.pollsGridView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pollsDataSet = new bapbpolls.PollsDataSet();
            this.toolStrip1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pollsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pollsDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addPollToolStripButton,
            this.delPollToolStripButton,
            this.changePollToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(865, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // addPollToolStripButton
            // 
            this.addPollToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("addPollToolStripButton.Image")));
            this.addPollToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addPollToolStripButton.Name = "addPollToolStripButton";
            this.addPollToolStripButton.Size = new System.Drawing.Size(118, 22);
            this.addPollToolStripButton.Text = "Добавить анкету";
            this.addPollToolStripButton.Click += new System.EventHandler(this.addPollToolStripButton_Click);
            // 
            // delPollToolStripButton
            // 
            this.delPollToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("delPollToolStripButton.Image")));
            this.delPollToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.delPollToolStripButton.Name = "delPollToolStripButton";
            this.delPollToolStripButton.Size = new System.Drawing.Size(110, 22);
            this.delPollToolStripButton.Text = "Удалить анкету";
            this.delPollToolStripButton.Click += new System.EventHandler(this.delPollToolStripButton_Click);
            // 
            // changePollToolStripButton
            // 
            this.changePollToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("changePollToolStripButton.Image")));
            this.changePollToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.changePollToolStripButton.Name = "changePollToolStripButton";
            this.changePollToolStripButton.Size = new System.Drawing.Size(113, 22);
            this.changePollToolStripButton.Text = "Измеить анкету";
            this.changePollToolStripButton.Click += new System.EventHandler(this.changePollToolStripButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 326);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(865, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.AutoScroll = true;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.pollsGridView);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(865, 272);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 54);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(865, 272);
            this.toolStripContainer1.TabIndex = 3;
            this.toolStripContainer1.Text = "toolStripContainer1";
            this.toolStripContainer1.TopToolStripPanelVisible = false;
            // 
            // pollsGridView
            // 
            this.pollsGridView.AllowUserToAddRows = false;
            this.pollsGridView.AllowUserToDeleteRows = false;
            this.pollsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pollsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pollsGridView.Location = new System.Drawing.Point(0, 0);
            this.pollsGridView.MultiSelect = false;
            this.pollsGridView.Name = "pollsGridView";
            this.pollsGridView.ReadOnly = true;
            this.pollsGridView.Size = new System.Drawing.Size(865, 272);
            this.pollsGridView.TabIndex = 0;
            this.pollsGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.pollsGridView_CellContentClick);
            this.pollsGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.pollsGridView_CellContentDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(865, 29);
            this.panel1.TabIndex = 4;
            // 
            // pollsDataSet
            // 
            this.pollsDataSet.DataSetName = "PollsDataSet";
            this.pollsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // MainPollsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 348);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "MainPollsForm";
            this.Text = "Анкеты";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pollsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pollsDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.DataGridView pollsGridView;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.ToolStripButton addPollToolStripButton;
        public System.Windows.Forms.ToolStripButton delPollToolStripButton;
        public System.Windows.Forms.ToolStripButton changePollToolStripButton;
        public PollsDataSet pollsDataSet;
    }
}

