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
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.pollsGridView = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addPollToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.delPollToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.changePollToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pollsDataSet = new bapbpolls.PollsDataSet();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pollsGridView)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pollsDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            resources.ApplyResources(this.toolStripContainer1.ContentPanel, "toolStripContainer1.ContentPanel");
            this.toolStripContainer1.ContentPanel.Controls.Add(this.pollsGridView);
            resources.ApplyResources(this.toolStripContainer1, "toolStripContainer1");
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.TopToolStripPanelVisible = false;
            // 
            // pollsGridView
            // 
            this.pollsGridView.AllowUserToAddRows = false;
            this.pollsGridView.AllowUserToDeleteRows = false;
            this.pollsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.pollsGridView, "pollsGridView");
            this.pollsGridView.MultiSelect = false;
            this.pollsGridView.Name = "pollsGridView";
            this.pollsGridView.ReadOnly = true;
            this.pollsGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.pollsGridView_CellContentClick);
            this.pollsGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.pollsGridView_CellContentDoubleClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addPollToolStripButton,
            this.delPollToolStripButton,
            this.changePollToolStripButton});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            // 
            // addPollToolStripButton
            // 
            resources.ApplyResources(this.addPollToolStripButton, "addPollToolStripButton");
            this.addPollToolStripButton.Name = "addPollToolStripButton";
            this.addPollToolStripButton.Click += new System.EventHandler(this.addPollToolStripButton_Click);
            // 
            // delPollToolStripButton
            // 
            resources.ApplyResources(this.delPollToolStripButton, "delPollToolStripButton");
            this.delPollToolStripButton.Name = "delPollToolStripButton";
            this.delPollToolStripButton.Click += new System.EventHandler(this.delPollToolStripButton_Click);
            // 
            // changePollToolStripButton
            // 
            resources.ApplyResources(this.changePollToolStripButton, "changePollToolStripButton");
            this.changePollToolStripButton.Name = "changePollToolStripButton";
            this.changePollToolStripButton.Click += new System.EventHandler(this.changePollToolStripButton_Click);
            // 
            // statusStrip1
            // 
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // pollsDataSet
            // 
            this.pollsDataSet.DataSetName = "PollsDataSet";
            this.pollsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // MainPollsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "MainPollsForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pollsGridView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
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

