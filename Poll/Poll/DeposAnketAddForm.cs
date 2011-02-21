using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using admin;

namespace Poll
{
    public partial class DeposAnketAddForm : Form
    {
        public PollsDataSet.RKCDataTable tmpRKCTable;
        public User _user;
        public DeposAnketAddForm(User user)
        {
            InitializeComponent();
            _user = user;
            pollsDataSet.Sex.AddSexRow('m', "Мужской");
            pollsDataSet.Sex.AddSexRow('f', "Женский");
            //PollsDataSet.FILIALDataTable tempTable=new PollsDataSet.FILIALDataTable();)
            if(_user.PrivilegesCodObl!=0)
            {
                fILIALBindingSource.DataSource =
                    fILIALTableAdapter.GetData(System.DateTime.Now, System.DateTime.Now).Where(
                        c => c.COD_FIL == (decimal)_user.PrivilegesCodObl).AsDataView();

            }
            else
            {
                fILIALBindingSource.DataSource =
                    fILIALTableAdapter.GetData(System.DateTime.Now, System.DateTime.Now);


            }
            
            sTRUCTUNITBindingSource.DataSource = sTRUCT_UNITTableAdapter.GetData(System.DateTime.Now,
                                                                                 System.DateTime.Now,
                                                                                 (decimal) filialСomboBox.SelectedValue);
            //rKCBindingSource.DataSource = rKCTableAdapter.GetData(System.DateTime.Now, System.DateTime.Now,
            //                                                      (decimal) otdComboBox.SelectedValue);
            tmpRKCTable = new PollsDataSet.RKCDataTable();
            //rKCTableAdapter.ClearBeforeFill;
            tmpRKCTable.AddRKCRow("<Отделение>", 0);
            rKCTableAdapter.ClearBeforeFill = false;
            rKCTableAdapter.Fill(tmpRKCTable, System.DateTime.Now, System.DateTime.Now,
                                 (decimal) otdComboBox.SelectedValue);
            
            rKCBindingSource.DataSource = tmpRKCTable;
            //DataRow nullRKCRow = pollsDataSet1.RKC.Rows[0];
            //nullRKCRow.
            //new DataRow();
            //PollsDataSet.RKCRow nullRKCRow = new PollsDataSet.RKCRow(drb);
           
            //rkcComboBox.Items.Add() rkcComboBox.Items.GetType()
            //rkcComboBox.Items.;
            
        }

        private void filialСomboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            sTRUCTUNITBindingSource.DataSource = sTRUCT_UNITTableAdapter.GetData(System.DateTime.Now, System.DateTime.Now, (decimal)filialСomboBox.SelectedValue);
            rKCBindingSource.DataSource = rKCTableAdapter.GetData(System.DateTime.Now, System.DateTime.Now,
                                                                  (decimal)otdComboBox.SelectedValue);
            tmpRKCTable.Clear();
            tmpRKCTable.AddRKCRow("<Отделение>", 0);
            rKCTableAdapter.ClearBeforeFill = false;
            rKCTableAdapter.Fill(tmpRKCTable, System.DateTime.Now, System.DateTime.Now,
                     (decimal)otdComboBox.SelectedValue);
            //tmpRKCTable.AddRKCRow("", 0);
            rKCBindingSource.DataSource = tmpRKCTable;


        }

        private void otdComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            rKCBindingSource.DataSource = rKCTableAdapter.GetData(System.DateTime.Now, System.DateTime.Now,
                                                                  (decimal)otdComboBox.SelectedValue);
            tmpRKCTable.Clear();
            tmpRKCTable.AddRKCRow("<Отделение>", 0);
            rKCTableAdapter.ClearBeforeFill = false;
            rKCTableAdapter.Fill(tmpRKCTable, System.DateTime.Now, System.DateTime.Now,
                     (decimal)otdComboBox.SelectedValue);
            //tmpRKCTable.AddRKCRow("", 0);
            rKCBindingSource.DataSource = tmpRKCTable;


        }
    }
}
