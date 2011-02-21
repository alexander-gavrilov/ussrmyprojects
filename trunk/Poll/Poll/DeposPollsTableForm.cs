using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using Poll.PollsDataSetTableAdapters;

namespace Poll
{
    //public string login;
    public partial class DeposPollsTableForm : PollsTable
    {
        
        public DeposPollsTableForm()
        {

            //Pol
            //InitializeComponent();
            //pollsDataSet=
            //pollsDataSet1.POLL_DEPOS.DATE_POLL_DEPOSColumn.Caption = "Дата анкетирования";

            //polL_DEPOSTableAdapter1.FillBy(pollsDataSet1.POLL_DEPOS,0, 461);
            polL_DEPOSTableAdapter1.FillBy(pollsDataSet1.POLL_DEPOS,0, 964);
            //polL_DEPOSTableAdapter1.Fill(pollsDataSet1.POLL_DEPOS);
            pollsBindingSource.DataSource = pollsDataSet1.POLL_DEPOS;
            //PollsDataSetTableAdapters.POLL_DEPOSTableAdapter
            //PollsDataSetTableAdapters.POLL_DEPOSTableAdapter
            //pollsBindingSource.ResetBindings(true);
            //PollsDataGridView.
            PollsDataGridView.DataSource = pollsBindingSource;
            foreach (DataGridViewColumn tmpColumn in PollsDataGridView.Columns)
            {
                tmpColumn.HeaderText = pollsDataSet1.POLL_DEPOS.Columns[tmpColumn.Name].Caption;
                
            }
            //PollsDataGridView.Columns[]
        }

        

        
    }
}
