using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Poll
{
    public partial class DeposPollsTableForm : PollsTable
    {
        
        public DeposPollsTableForm()
        {

            //Pol
            //InitializeComponent();
            //pollsDataSet=
            pollsBindingSource.DataSource = pollsDataSet1.POLL_DEPOS;
            //pollsBindingSource.ResetBindings(true);
            //PollsDataGridView.
            PollsDataGridView.DataSource = pollsBindingSource;
        }

        

        
    }
}
