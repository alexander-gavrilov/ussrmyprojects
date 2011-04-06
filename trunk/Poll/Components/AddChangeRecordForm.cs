using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Components
{
    
    public partial class AddChangeRecordForm : Form
    {
        //private Form _owner;
        public AddChangeRecordForm()
        {
            InitializeComponent();
        }

        private void acceptChangesButton_Click(object sender, EventArgs e)
        {
            acceptChanges();
        }
        public virtual void acceptChanges()
        {
            
        }

        private void rejectChangesButton_Click(object sender, EventArgs e)
        {
            rejectChanges();
        }
        public virtual void rejectChanges()
        {
            
        }

        public Form Owner { get; set; }
    }
}
