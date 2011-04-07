using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using bapbpolls.PollsDataSetTableAdapters;


namespace bapbpolls
{
    public partial class SelectionAnketControl : UserControl
    {
        //private PollsDataSet _pollsDataSource;
        //private BindingSource _filialBindingSource;
        //private 
        //private BindingSource _BindingSource;
        private MainPollsForm _owner;

        public SelectionAnketControl()
        {
            InitializeComponent();
            LoadRegions();
            LoadYears();
            decimal year;
            year = (decimal) comboBoxYear.SelectedValue;
            LoadQuarter((int) year);

            LoadTypes();
        }

        public PollsDataSet PollsDataSource { get; set; }
        private void LoadRegions()
        {
            //var filialTbl=new PollsDataSet.FILIALDataTable();
            filialBindingSource.DataSource=
                fILIALTableAdapter.GetData(System.DateTime.Now);
           
            //comboBoxRegion.DataSource = filialBindingSource;
            //comboBoxRegion.DisplayMember="NAME";
            //comboBoxRegion.ValueMember = "COD_FIL";
        }
        private void LoadYears()
        {
            
            //var yearsTableAdapter=new YEARSTableAdapter();
            //yearsBindungSource.DataSource = _pollsDataSource;
            //yearsBindungSource.DataMember = "YEARS";
            yEARSTableAdapter.Fill(pollsDataSet.YEARS);
            //yearsBindungSource.DataSource =yEARSTableAdapter.GetData();
            if (pollsDataSet.YEARS.Rows.Count == 0)
            {
                pollsDataSet.YEARS.AddYEARSRow(DateTime.Now.Year);
                
            }
            //comboBoxYear.DataSource = yearsBindungSource;
            //comboBoxYear.ValueMember = "YEARS";
            //comboBoxYear.DisplayMember = "YEARS";
        }
        private  void LoadQuarter(int year)
        {
            //var quarterTableAdapter=new QUARTERTableAdapter();
            //quarterBindingSource.DataSource = _pollsDataSource;
            //quarterBindingSource.DataMember = "QUARTER";
            //qUARTERTableAdapter.Fill(pollsDataSet.QUARTER);
            //quarterBindingSource.DataSource = pollsDataSet.QUARTER;
            //quartersBindingSource.DataSource = qUARTERSTableAdapter.GetData();
            qUARTERSTableAdapter.Fill(pollsDataSet.QUARTERS);
            
            if(pollsDataSet.QUARTERS.Rows.Count==0)
            {
                pollsDataSet.QUARTERS.AddQUARTERSRow((Math.Truncate((decimal)((DateTime.Now.Month - 1) / 3))) + 1, ((Math.Truncate((decimal)((DateTime.Now.Month - 1) / 3))) + 1).ToString()+" квартал",year);
            }
            else
            {
                quartersBindingSource.Filter = "YEAR=" + year.ToString();
            }
            //comboBoxQuarter.DataSource = quarterBindingSource;
            //comboBoxQuarter.DataSource = quarterBindingSource;
            //comboBoxQuarter.DisplayMember = "TEXT";
            //comboBoxQuarter.ValueMember = "QUARTER";
        }
        private void LoadTypes()
        {
            typesBindingSource.DataSource = tYPESTableAdapter.GetData();
        }

        private void comboBoxRegion_SelectedValueChanged(object sender, EventArgs e)
        {
            if (Owner != null)
            {
                Owner.InitializePollsGridView();
                if (Owner._user.PrivilegesCodObl==Convert.ToInt32(comboBoxRegion.SelectedValue))
                {
                    Owner.addPollToolStripButton.Enabled = true;
                    Owner.delPollToolStripButton.Enabled = true;
                    Owner.changePollToolStripButton.Enabled = true;


                }
                else
                {
                    Owner.addPollToolStripButton.Enabled = false;
                    Owner.delPollToolStripButton.Enabled = false;
                    Owner.changePollToolStripButton.Enabled = false;

                }

            }
        }


        public MainPollsForm Owner { get { return _owner; } set { _owner = value; } }

        private void comboBoxYear_SelectedValueChanged(object sender, EventArgs e)
        {
            if (Owner != null)
                Owner.InitializePollsGridView();

        }

        private void comboBoxQuarter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Owner != null)
                Owner.InitializePollsGridView();

        }

        private void comboBoxPollType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Owner != null)
                Owner.InitializePollsGridView();

        }
    }
}
