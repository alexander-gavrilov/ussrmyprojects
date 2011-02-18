using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Poll.Properties;

//using Poll.Properties;

namespace Poll
{
    public partial class PollsMainForm : Form
    {
        private DeposPollsTableForm _deposPollsTable;
        private Properties.Settings settings;
        public PollsMainForm()
        {
            InitializeComponent();
            _deposPollsTable = new DeposPollsTableForm();
            splitContainer1.Panel2.Controls.Add(_deposPollsTable);
            _deposPollsTable.Dock = DockStyle.Fill;
            settings = global::Poll.Properties.Settings.Default;
            //Console.WriteLine(settings.Test);
            //settings.Test = "проверка";
            //Console.WriteLine(settings.Test);
            MessageBox.Show(settings.Test);
            foreach (DataColumn t in _deposPollsTable.pollsDataSet1.POLL_DEPOS.Columns)
            {
                settings.DeposTableColumnsText=new OrderedDictionary();
                settings.DeposTableColumnsText.Add(t.ColumnName,"");
            }
            settings.Save();
            
            //_deposPollsTable.buttonAddPoll.
            //Refresh();
            Update();

        }
    }
}
