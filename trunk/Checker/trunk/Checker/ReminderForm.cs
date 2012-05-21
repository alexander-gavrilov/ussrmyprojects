using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Checker
{
    public partial class ReminderForm : Form
    {
        public ReminderForm()
        {
            InitializeComponent();
        }

        private void ReminderForm_Load(object sender, EventArgs e)
        {
            dirsDTBindingSource.DataSource = CheckerProfile.chekerDS;
            dirsDTBindingSource.Filter = "treatment=true";
            RefreshDG();
            this.Activate();
        }
        private void RefreshDG()
        {
            
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                ChekerDS.DirsDTRow dirsDtRow = ((DataRowView)row.DataBoundItem).Row as ChekerDS.DirsDTRow;

                if (dirsDtRow != null)
                {
                 
                    foreach (DataGridViewCell gridViewCell in row.Cells)
                    {
                        gridViewCell.ToolTipText=dirsDtRow.path + dirsDtRow.mask;
                    }
                    if (dirsDtRow.avalible)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                        row.DefaultCellStyle.SelectionBackColor = Color.DarkGreen;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                        row.DefaultCellStyle.SelectionBackColor = Color.DarkRed;

                    }
                }
                //row.DefaultCellStyle.
            }
            if (chekerDS.DirsDT.Select(chekerDS.DirsDT.avalibleColumn.ColumnName + "=false").Length > 0)
            {
                MessageBox.Show(this, "Красным цветом выделены не доступные каталоги", "Внимание!!!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
