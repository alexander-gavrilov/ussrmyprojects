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
using admin;

//using Poll.Properties;

namespace Poll
{
    public partial class PollsMainForm : Form
    {
        private DeposPollsTableForm _deposPollsTable;
        private Properties.Settings settings;
        private User _anketsUser;
        public PollsMainForm()
        {
            InitializeComponent();
            _anketsUser=new User();
            _anketsUser.Login = "br_964_avilkovskaya_001";
            _anketsUser.CodMfo = 964;
            _anketsUser.CodObl = 8;
            _anketsUser.CodRKC = 0;
            _anketsUser.PrivilegesCodMfo = 0;
            _anketsUser.PrivilegesCodObl = 6;
            _anketsUser.PrivilegesCodRKC = 0;
            //_anketsUser.
            
            _deposPollsTable = new DeposPollsTableForm(_anketsUser);
            splitContainer1.Panel2.Controls.Add(_deposPollsTable);
            _deposPollsTable.Dock = DockStyle.Fill;
            settings = global::Poll.Properties.Settings.Default;
            //Console.WriteLine(settings.Test);
            //settings.Test = "проверка";
            //Console.WriteLine(settings.Test);
            MessageBox.Show(settings.Test);
            OrderedDictionary ttt = new OrderedDictionary();
            foreach (DataColumn t in _deposPollsTable.pollsDataSet.POLL_DEPOS.Columns)
            {
                ttt.Add(t.ColumnName, "");
                //settings.DeposTableColumnsText.Add(t.ColumnName,"");
            }
            settings.DeposTableColumnsText = ttt;
            settings.Save();
            
            //_deposPollsTable.buttonAddPoll.
            //Refresh();
            Update();

        }

        private void PollsMainForm_Activated(object sender, EventArgs e)
        {
            //_deposPollsTable.pollsDataSet.POLL_DEPOS.
            //_deposPollsTable.pollsBindingSource.Insert();
            _deposPollsTable.pollsBindingSource.ResetItem(0);

        }
    }
}
