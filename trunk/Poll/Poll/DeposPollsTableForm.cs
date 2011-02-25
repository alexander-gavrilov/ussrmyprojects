using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using admin;

//using Poll.PollsDataSetTableAdapters;

namespace Poll
{
    //public string login;
     
    public partial class DeposPollsTableForm : PollsTable
    {
        //private User _user;
        public DeposPollsTableForm(User user)
        {
            _user = user;
            //Pol
            //InitializeComponent();
            //pollsDataSet=
            //pollsDataSet1.POLL_DEPOS.DATE_POLL_DEPOSColumn.Caption = "Дата анкетирования";

            //polL_DEPOSTableAdapter1.FillBy(pollsDataSet1.POLL_DEPOS,0, 461);
            //polL_DEPOSTableAdapter1.FillBy(pollsDataSet1.POLL_DEPOS,0, 964);
            

            //polL_DEPOSTableAdapter1.Fill(pollsDataSet1.POLL_DEPOS);
            pollsBindingSource.DataSource = pollsDataSet.POLL_DEPOS;
            //PollsDataSetTableAdapters.POLL_DEPOSTableAdapter
            //PollsDataSetTableAdapters.POLL_DEPOSTableAdapter
            //pollsBindingSource.ResetBindings(true);
            //PollsDataGridView.
            //pollsBindingSource.
            PollsDataGridView.DataSource = pollsBindingSource;
            //showFormAdd();
            foreach (DataGridViewColumn tmpColumn in PollsDataGridView.Columns)
            {
                tmpColumn.HeaderText = pollsDataSet.POLL_DEPOS.Columns[tmpColumn.Name].Caption;
                
            }
            //PollsDataGridView.Columns[]
        }

        private void InitializeComponent()
        {
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pollsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pollsDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // DeposPollsTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "DeposPollsTableForm";
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pollsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pollsDataSet)).EndInit();
            this.ResumeLayout(false);

        }
        public override void showFormAdd() 
        {
            DeposAnketAddForm tmpF = new DeposAnketAddForm(_user);
            tmpF.PollsDataSet = pollsDataSet;
            tmpF.PollsBindingSource = pollsBindingSource;
            tmpF.ShowDialog();
            
        }
        private void UpdateGrid()
        {
            polL_DEPOSTableAdapter.FillByFil(pollsDataSet.POLL_DEPOS, (decimal)_user.PrivilegesCodObl);
        }

        

        
    }
}
