﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using admin;

namespace Poll
{
    public partial class PollsTable : UserControl
    {
        public User _user;
        public PollsTable()
        {
            
            InitializeComponent();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        public void buttonAddPoll_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("all bad");
            showFormAdd();

        }
        public virtual void showFormAdd()
        {
            
        }
        public virtual void showFormChange()
        {
            
        }

        private void buttonChangePoll_Click(object sender, EventArgs e)
        {
            showFormChange();
        }
    }
}
