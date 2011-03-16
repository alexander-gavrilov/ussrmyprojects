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
            polL_DEPOSTableAdapter.FillByFil(pollsDataSet.POLL_DEPOS,(decimal) _user.PrivilegesCodObl);
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
            // buttonChangePoll
            // 
            this.buttonChangePoll.Click += new System.EventHandler(this.buttonChangePoll_Click);
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
            tmpF.Owner = this;
            tmpF.PollsDataSet = pollsDataSet;
            tmpF.PollsBindingSource = pollsBindingSource;
            
            tmpF.ShowDialog();
            //tmpF.ShowDialog();
            
        }
        public void UpdateGrid()
        {
            polL_DEPOSTableAdapter.FillByFil(pollsDataSet.POLL_DEPOS, (decimal)_user.PrivilegesCodObl);
        }

        private void buttonChangePoll_Click(object sender, EventArgs e)
        {

        }
        public override void showFormChange()
        {
            //base.showFormChange();
            CurrencyManager currencyManager =
                (CurrencyManager)
                PollsDataGridView.BindingContext[PollsDataGridView.DataSource, PollsDataGridView.DataMember];
            if (currencyManager.Count > 0)
            {
                //PollsDataSet.POLL_DEPOSRow tmpRow = (PollsDataSet.POLL_DEPOSRow) currencyManager.Current;

                DeposAnketAddForm tmpF = new DeposAnketAddForm(_user,
                                                               pollsDataSet.POLL_DEPOS.First(
                                                                   c =>
                                                                   c.DATE_POLL_DEPOS ==
                                                                   (DateTime)
                                                                   PollsDataGridView.SelectedRows[0].Cells[
                                                                       "DATE_POLL_DEPOS"].Value &&
                                                                   c.NUMBER_POLL_DEPOS == (decimal)
                                                                   PollsDataGridView.SelectedRows[0].Cells[
                                                                       "NUMBER_POLL_DEPOS"].Value && 
                                                                       c.REF_OTD == (decimal)
                                                                   PollsDataGridView.SelectedRows[0].Cells[
                                                                       "REF_OTD"].Value));
                
                tmpF.Owner = this;
                tmpF.PollsDataSet = pollsDataSet;
                tmpF.PollsBindingSource = pollsBindingSource;
                tmpF.ShowDialog();
            }


        }
        

        
    }
}
