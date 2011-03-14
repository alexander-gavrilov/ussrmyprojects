using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using admin;
using Poll;


namespace BAPBForms
{
    public partial class BAPBFormsMainForm : Form
    {
        private User _userBAPB;
        public BAPBFormsMainForm()
        {
            
            InitializeComponent();
            _userBAPB = new User();
            _userBAPB.Login = "br_964_avilkovskaya_001";
            _userBAPB.CodMfo = 964;
            _userBAPB.CodObl = 8;
            _userBAPB.CodRKC = 0;
            _userBAPB.PrivilegesCodMfo = 0;
            _userBAPB.PrivilegesCodObl = 6;
            _userBAPB.PrivilegesCodRKC = 0;

        }

        private void pollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PollsMainForm newMDIChild = new PollsMainForm(_userBAPB);
            
            newMDIChild.MdiParent = this;
            newMDIChild.Show();

        }
    }
}
