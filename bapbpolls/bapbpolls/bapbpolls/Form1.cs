using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using admin;
using bapbpolls.PollsDataSetTableAdapters;
using Helpers;

namespace bapbpolls
{
    public partial class MainPollsForm : Form,IModules
    {
        private SelectionAnketControl _selectionAnketControl;
        private decimal quarter;
        private decimal year;
        private decimal region;
        private string type;
        public Int32 _num_module;
        //private PollsDataSet.Polls2GridCommonDataTable _polls2GridCommonDataTable;
        public User _user;
        private PollsDataSet.POLLSCOMMONDataTable pollscommonDataTable;
        public void Start(User user, Int32 num_module, String pathDLL, Form form)
        {
            MainPollsForm frmPolls = new MainPollsForm(user, num_module, pathDLL, form);
            frmPolls.MdiParent = form;
            frmPolls.Show();
        }

        public MainPollsForm(User user, Int32 num_module, String pathDLL, Form form)
        {
            //_user = new User
            //            {
            //                Login = "br_964_avilkovskaya_001",
            //                CodMfo = 964,
            //                CodObl = 8,
            //                CodRKC = 0,
            //                PrivilegesCodMfo = 0,
            //                PrivilegesCodObl = 6,
            //                PrivilegesCodRKC = 0
                            
            //            };
            //_polls2GridCommonDataTable=new PollsDataSet.Polls2GridCommonDataTable();

            // Проверка наличия конекта и БД
            


            
            _user = user;
            _num_module = num_module;
            InitializeComponent();

            var testConnection = new POLLSCOMMONTableAdapter();
            try
            {
                testConnection.Connection.Open();
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show(this, "Невозможно подключиться к БД");
                Close();
                
            }
            catch (System.Data.OracleClient.OracleException)
            {
                MessageBox.Show(this, "Ошибка подключения к БД");
                Close();
            }
            catch(Exception)
            {
                MessageBox.Show(this, "Непредвиденная ошибка. Обратитесь к разработчику");
                Close();
            }

            


            _selectionAnketControl = new SelectionAnketControl {Owner = this,Dock = DockStyle.Fill};
            panel1.Controls.Add(_selectionAnketControl);
            InitializePollsGridView();

      }
        public void InitializePollsGridView()
        {
            LoadPollCommons();
        }
        private void LoadPollCommons()
        {
            GetGridRow();
            //pollsGridView.Rows[0].HeaderCell.Value = "1";
            //pollsGridView.Rows[1].HeaderCell.Value = "2";
        }
        private void GetGridRow()
        {
            var pollscommonTableAdapter=new POLLSCOMMONTableAdapter();
            quarter = (decimal) _selectionAnketControl.comboBoxQuarter.SelectedValue;
            year = (decimal) _selectionAnketControl.comboBoxYear.SelectedValue;
            region = (decimal) _selectionAnketControl.comboBoxRegion.SelectedValue;
            type = _selectionAnketControl.comboBoxPollType.SelectedValue.ToString();
            //int countColumns = Convert.ToInt32(
            //                   pollscommonTableAdapter.CountPolls(quarter, year
            //                                                      , region
            //                                                      , type
            //                       ));
            var structTableAdapter = new STRUCT_UNITTableAdapter();
            structTableAdapter.Fill(pollsDataSet.STRUCT_UNIT, DateTime.Now);
            var rkcTableAdapter = new RKCTableAdapter();
            rkcTableAdapter.Fill(pollsDataSet.RKC, DateTime.Now);

            if (region ==0)
            {
                pollscommonDataTable = new PollsDataSet.POLLSCOMMONDataTable();
                pollscommonTableAdapter.FillByYT(pollscommonDataTable, year
                                                 , type);
                

            }
            else
            {
                pollscommonDataTable = new PollsDataSet.POLLSCOMMONDataTable();
                pollscommonTableAdapter.FillByFiltr(pollscommonDataTable, quarter, year
                                                    , region
                                                    , type);

            }

            pollsGridView.Columns.Clear();
            if (pollscommonDataTable.Rows.Count > 0)
            {


                //DataTable pollsGridTable=new DataTable();
                //pollscommonDataTable = new PollsDataSet.POLLSCOMMONDataTable();
                //pollscommonTableAdapter.FillByFiltr(pollscommonDataTable, quarter, year
                //                                    , region
                //                                    , type);
                var pollsDataTA = new POLLSDATATableAdapter();
                
                pollsDataTA.Fill(pollsDataSet.POLLSDATA);


                //pollsGridView.Columns.Add(new DataGridViewColumn { Name = "BRANCH", HeaderText = "Город", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells, CellTemplate = new DataGridViewTextBoxCell() });
                var newRow = new DataGridViewRow();
                //DataGridViewCell newCell = new
                //newRow.SetValues("QQQQQQ", "1");
                //pollsGridView.Columns.Add(new DataGridViewColumn{Visible = false,CellTemplate = new DataGridViewTextBoxCell()});
                List<String> columnIDs = new List<string>();
                pollsDataSet.Polls2GridCommon.Clear();
                foreach (var row in pollscommonDataTable.OrderBy(c => c.NUM))
                {
                    var newColumn = new DataGridViewColumn
                                        {
                                            Name = row.NUM.ToString(),
                                            AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                                            CellTemplate = new DataGridViewTextBoxCell()
                                        };
                    pollsGridView.Columns.Add(newColumn);
                    pollsDataSet.Polls2GridCommon.AddPolls2GridCommonRow(row.NUM, row.TYPE, row.RDAY, row.BRANCH, row.RKC,
                                                                      newColumn.Index);

                }

                pollsGridView.Columns.Add(new DataGridViewColumn
                                              {
                                                  Name = "Итого",
                                                  AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                                                  HeaderCell = new DataGridViewColumnHeaderCell(){Style=new DataGridViewCellStyle(){Font = new Font(DefaultFont, FontStyle.Bold),BackColor = Color.LightPink}},
                                                  CellTemplate =
                                                      new DataGridViewTextBoxCell()
                                                          {
                                                              Style =
                                                                  new DataGridViewCellStyle()
                                                                      {
                                                                          Alignment =
                                                                              DataGridViewContentAlignment.MiddleCenter,
                                                                          BackColor = Color.LightPink,
                                                                          Font = new Font(DefaultFont, FontStyle.Bold)
                                                                      
                                                                      }
                                                                    
                                                          }
                                              });
                

                //var newRow = new DataGridViewRow{};
                //pollsGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
                pollsGridView.RowHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
                pollsGridView.SelectionMode = DataGridViewSelectionMode.FullColumnSelect;
                var indRow =
                    pollsGridView.Rows.Add(new DataGridViewRow
                                               {Visible = false});
                columnIDs.Add("RDAY");
                //indRow =
                //    pollsGridView.Rows.Add(new DataGridViewRow { Visible = false });
                //columnIDs.Add("RDAY");
                 indRow =
                    pollsGridView.Rows.Add(new DataGridViewRow
                                               {
                                                   HeaderCell =
                                                       new DataGridViewRowHeaderCell()
                                                           {Value = "Социально-демографический портрет"}
                                               });
                pollsGridView.Rows[indRow].HeaderCell.Style.Font = new Font(DefaultFont, FontStyle.Bold);
                //pollsGridView.Rows[indRow].Cells[0].Value = "";
                columnIDs.Add("");

                indRow =
                    pollsGridView.Rows.Add(new DataGridViewRow
                                               {
                                                   HeaderCell = new DataGridViewRowHeaderCell() {Value = "Отделение/ОПЕРУ"}
                                               });
                columnIDs.Add("BRANCH");
                indRow =
                    pollsGridView.Rows.Add(new DataGridViewRow { HeaderCell = new DataGridViewRowHeaderCell() { Value = "РКЦ" } });
                columnIDs.Add("RKC");


                indRow =
                    pollsGridView.Rows.Add(new DataGridViewRow
                                               {
                                                   HeaderCell = new DataGridViewRowHeaderCell() {Value = "Пол"},
                                                   Tag = "SEX"
                                               });
                //pollsGridView.Rows[indRow].Cells[0].Value = "SEX";
                columnIDs.Add("SEX");
                indRow = pollsGridView.Rows.Add(new DataGridViewRow
                                                    {
                                                        HeaderCell = new DataGridViewRowHeaderCell() {Value = "Возраст"},
                                                        Tag = "AGE"
                                                    });
                //pollsGridView.Rows[indRow].Cells[0].Value = "AGE";
                columnIDs.Add("AGE");
                if (type=="TRANS")
                {
                    
                    indRow = pollsGridView.Rows.Add(new DataGridViewRow
                    {
                        HeaderCell = new DataGridViewRowHeaderCell() { Value = "Тип перевода" },
                        Tag = "TYPETRANS"
                    });
                    columnIDs.Add("TYPETRANS");

                }

                var typesPolls = new TYPEPOLLSTableAdapter();
                typesPolls.Fill(pollsDataSet.TYPEPOLLS);
                var dataPoll = new POLLSDATATableAdapter();
                dataPoll.FillByFiltr(pollsDataSet.POLLSDATA, quarter, year, region, type);
                indRow =
                    pollsGridView.Rows.Add(new DataGridViewRow
                                               {
                                                   HeaderCell =
                                                       new DataGridViewRowHeaderCell()
                                                           {Value = "Степень удовлетворенности:"}
                                               });
                pollsGridView.Rows[indRow].HeaderCell.Style.Font = new Font(DefaultFont, FontStyle.Bold);
                columnIDs.Add("");
                pollsDataSet.ResaultColumn.Clear();
                foreach (
                    var VARIABLE in
                        pollsDataSet.TYPEPOLLS.Where(
                            c => c.TYPE == _selectionAnketControl.comboBoxPollType.SelectedValue.ToString()).OrderBy(
                                c => c.POSITION))
                {

                    var ind =
                        pollsGridView.Rows.Add(new DataGridViewRow
                                                   {
                                                       HeaderCell =
                                                           new DataGridViewRowHeaderCell() {Value = VARIABLE.NAMEQUEST},
                                                       Tag = VARIABLE.IDQUEST
                                                   });
                    columnIDs.Add("Q"+VARIABLE.IDQUEST);
                    pollsDataSet.ResaultColumn.AddResaultColumnRow(VARIABLE.IDQUEST, pollscommonDataTable.Rows.Count, 0, 0);


                }






                pollsGridView.RowHeadersWidth = 200;
                pollsGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
                pollsGridView.AutoSizeRowsMode =
                    DataGridViewAutoSizeRowsMode.AllCells;
                //foreach (var VARIABLE in pollscommonDataTable.OrderBy(c => c.NUM))
                //{
                //    pollsGridView.Rows[columnIDs.FindIndex(c => c.Contains("SEX"))].Cells[VARIABLE.NUM.ToString()].Value
                //        = VARIABLE.SEX[0];
                //    pollsGridView.Rows[columnIDs.FindIndex(c => c.Contains("AGE"))].Cells[VARIABLE.NUM.ToString()].Value
                //        = VARIABLE.AGE.ToString();
                //    int firstDataRow = indRow;
                //    foreach (var curentRow in pollsDataSet.POLLSDATA.Where(
                //        c =>
                //        c.BRANCH == VARIABLE.BRANCH && c.NUM == VARIABLE.NUM && c.RDAY == VARIABLE.RDAY && c.RKC
                //        == VARIABLE.RKC))
                //    {
                //        pollsGridView.Rows[columnIDs.FindIndex(c => c.Contains("Q" + curentRow.IDQUEST))].Cells[
                //            VARIABLE.NUM.ToString()].Value = curentRow.QUALITY;
                //    }
                //    //for (int i = firstDataRow; i < pollsGridView.Rows.Count; i++)
                //    //{
                //    //    pollsGridView.Rows[i].Cells[VARIABLE.NUM.ToString()].Value =
                //    //        pollsDataSet.POLLSDATA.Where(
                //    //            c =>
                //    //            c.BRANCH == VARIABLE.BRANCH && c.NUM == VARIABLE.NUM && c.RDAY == VARIABLE.RDAY && c.RKC
                //    //            == VARIABLE.RKC && c.IDQUEST == pollsDataSet.TYPEPOLLS.Where(b=>b.POSITION==(i-1)&&b.TYPE==VARIABLE.TYPE).First().IDQUEST).First().QUALITY;
                //    //}



                //}
                indRow =
                    pollsGridView.Rows.Add(new DataGridViewRow
                                               {
                                                   HeaderCell =
                                                       new DataGridViewRowHeaderCell() {Value = "Степень важности:"}
                                               });
                pollsGridView.Rows[indRow].HeaderCell.Style.Font = new Font(DefaultFont, FontStyle.Bold);
                columnIDs.Add("");
                foreach (
                    var VARIABLE in
                        pollsDataSet.TYPEPOLLS.Where(
                            c => c.TYPE == _selectionAnketControl.comboBoxPollType.SelectedValue.ToString()).OrderBy(
                                c => c.POSITION))
                {

                    var ind =
                        pollsGridView.Rows.Add(new DataGridViewRow
                                                   {
                                                       HeaderCell =
                                                           new DataGridViewRowHeaderCell() {Value = VARIABLE.NAMEQUEST},
                                                       Tag = VARIABLE.IDQUEST
                                                   });
                    columnIDs.Add("I" + VARIABLE.IDQUEST);

                }

                indRow =
                    pollsGridView.Rows.Add(new DataGridViewRow
                                               {
                                                   HeaderCell =
                                                       new DataGridViewRowHeaderCell()
                                                           {Value = "Реальная удовлетворенность"}
                                               });
                pollsGridView.Rows[indRow].HeaderCell.Style.Font = new Font(DefaultFont, FontStyle.Bold);
                //pollsGridView.Rows[indRow].Cells[0].Value = "";
                columnIDs.Add("IP");

                indRow =
                    pollsGridView.Rows.Add(new DataGridViewRow
                                               {
                                                   HeaderCell =
                                                       new DataGridViewRowHeaderCell()
                                                           {Value = "Оптимальная удовлетворенность"}
                                               });
                pollsGridView.Rows[indRow].HeaderCell.Style.Font = new Font(DefaultFont, FontStyle.Bold);
                //pollsGridView.Rows[indRow].Cells[0].Value = "";
                columnIDs.Add("IO");

                indRow =
                    pollsGridView.Rows.Add(new DataGridViewRow
                                               {
                                                   HeaderCell =
                                                       new DataGridViewRowHeaderCell()
                                                           {Value = "Индекс удовлетворенности, %"}
                                               });
                pollsGridView.Rows[indRow].HeaderCell.Style.Font = new Font(DefaultFont, FontStyle.Bold);
                //pollsGridView.Rows[indRow].Cells[0].Value = "";
                columnIDs.Add("IPIO");

                //Заполняем столбцы
                decimal Ip=0;
                decimal Io=0;
                
                foreach (var VARIABLE in pollsDataSet.Polls2GridCommon.OrderBy(c=>c.Position))
                {
                    var curComRow = pollscommonDataTable.FindByNUMTYPERDAYBRANCHRKC(VARIABLE.Num, VARIABLE.Type,
                                                                                    VARIABLE.RDay, VARIABLE.Branch,
                                                                                    VARIABLE.RKC);

                    pollsGridView.Rows[columnIDs.FindIndex(c => c.Contains("SEX"))].Cells[(int) VARIABLE.Position].Value
                        = curComRow.SEX[0];
                    pollsGridView.Rows[columnIDs.FindIndex(c => c.Contains("AGE"))].Cells[(int)VARIABLE.Position].Value
                        = curComRow.AGE.ToString();
                    pollsGridView.Rows[columnIDs.FindIndex(c => c.Contains("BRANCH"))].Cells[(int)VARIABLE.Position].
                        Value
                        = curComRow.BRANCH.ToString();
                    pollsGridView.Rows[columnIDs.FindIndex(c => c.Contains("BRANCH"))].Cells[(int) VARIABLE.Position].
                        ToolTipText
                        = pollsDataSet.STRUCT_UNIT.FirstOrDefault(c => c.BRANCH == curComRow.BRANCH).NAME;
                    pollsGridView.Rows[columnIDs.FindIndex(c => c.Contains("RKC"))].Cells[(int) VARIABLE.Position].Value
                        = curComRow.RKC.ToString();
                    if (VARIABLE.RKC != 0)
                    {
                        pollsGridView.Rows[columnIDs.FindIndex(c => c.Contains("RKC"))].Cells[(int)VARIABLE.Position].
                            ToolTipText
                            =
                            pollsDataSet.RKC.FirstOrDefault(
                                c => c.REF_OTD == VARIABLE.Branch && c.CODE_RKC == VARIABLE.RKC).NAME;
                    }
                    else
                    {
                        pollsGridView.Rows[columnIDs.FindIndex(c => c.Contains("RKC"))].Cells[(int)VARIABLE.Position].
                            ToolTipText = pollsDataSet.STRUCT_UNIT.FirstOrDefault(c => c.BRANCH == VARIABLE.Branch).NAME;
                    }


                    if (type == "TRANS")
                    {

                        pollsGridView.Rows[columnIDs.FindIndex(c => c.Contains("TYPETRANS"))].Cells[
                            (int)VARIABLE.Position].Value
                            = curComRow.TYPETRANS.ToString();


                    }

                    int firstDataRow = indRow;
                    foreach (var curentRow in pollsDataSet.POLLSDATA.Where(
                        c =>
                        c.BRANCH == VARIABLE.Branch && c.NUM == VARIABLE.Num && c.RDAY == VARIABLE.RDay && c.RKC
                        == VARIABLE.RKC))
                    {
                        pollsGridView.Rows[columnIDs.FindIndex(c => c.Contains("Q" + curentRow.IDQUEST))].Cells[
                            (int)VARIABLE.Position].Value = curentRow.QUALITY;
                        pollsGridView.Rows[columnIDs.FindIndex(c => c.Contains("I" + curentRow.IDQUEST))].Cells[
                            (int)VARIABLE.Position].Value = curentRow.IMPOTANCE;
                        pollsDataSet.ResaultColumn.FindByIDQUEST(curentRow.IDQUEST).QSUM += curentRow.QUALITY;
                        pollsGridView.Rows[columnIDs.FindIndex(c => c.Contains("Q" + curentRow.IDQUEST))].Cells[
                            pollsGridView.ColumnCount - 1].Value =Math.Round(
                            pollsDataSet.ResaultColumn.FindByIDQUEST(curentRow.IDQUEST).QSUM/
                            pollsDataSet.ResaultColumn.FindByIDQUEST(curentRow.IDQUEST).COUNT,1);

                        pollsDataSet.ResaultColumn.FindByIDQUEST(curentRow.IDQUEST).ISUM += curentRow.IMPOTANCE;
                        pollsGridView.Rows[columnIDs.FindIndex(c => c.Contains("I" + curentRow.IDQUEST))].Cells[
                            pollsGridView.ColumnCount - 1].Value =Math.Round(
                            pollsDataSet.ResaultColumn.FindByIDQUEST(curentRow.IDQUEST).ISUM/
                            pollsDataSet.ResaultColumn.FindByIDQUEST(curentRow.IDQUEST).COUNT,1);




                    }
                    //for (int i = firstDataRow; i < pollsGridView.Rows.Count; i++)
                    //{
                    //    pollsGridView.Rows[i].Cells[VARIABLE.NUM.ToString()].Value =
                    //        pollsDataSet.POLLSDATA.Where(
                    //            c =>
                    //            c.BRANCH == VARIABLE.BRANCH && c.NUM == VARIABLE.NUM && c.RDAY == VARIABLE.RDAY && c.RKC
                    //            == VARIABLE.RKC && c.IDQUEST == pollsDataSet.TYPEPOLLS.Where(b=>b.POSITION==(i-1)&&b.TYPE==VARIABLE.TYPE).First().IDQUEST).First().QUALITY;
                    //}



                }
                foreach (var resRow in pollsDataSet.ResaultColumn)
                {
                    Ip += (resRow.QSUM / resRow.COUNT) * (resRow.ISUM / resRow.COUNT);
                    Io += resRow.ISUM*5;
                }
                pollsGridView.Rows[columnIDs.IndexOf("IP")].Cells[
                    pollsGridView.ColumnCount - 1].Value = Math.Round(Ip,1);
                pollsGridView.Rows[columnIDs.IndexOf("IP")].Cells[
                    pollsGridView.ColumnCount - 1].Style.BackColor = Color.Yellow;
                pollsGridView.Rows[columnIDs.IndexOf("IP")].DefaultCellStyle.BackColor = Color.Yellow;
                pollsGridView.Rows[columnIDs.IndexOf("IO")].Cells[
                    pollsGridView.ColumnCount - 1].Value = Io;
                pollsGridView.Rows[columnIDs.IndexOf("IO")].Cells[
                    pollsGridView.ColumnCount - 1].Style.BackColor = Color.LightGreen;
                pollsGridView.Rows[columnIDs.IndexOf("IO")].DefaultCellStyle.BackColor = Color.LightGreen;
                pollsGridView.Rows[columnIDs.IndexOf("IPIO")].Cells[
                    pollsGridView.ColumnCount - 1].Value = (Math.Round((Ip/Io)*100, 2));
                pollsGridView.Rows[columnIDs.IndexOf("IPIO")].Cells[
                    pollsGridView.ColumnCount - 1].Style.BackColor = Color.DarkRed;
                pollsGridView.Rows[columnIDs.IndexOf("IPIO")].Cells[
                    pollsGridView.ColumnCount - 1].Style.ForeColor = Color.White;
                pollsGridView.Rows[columnIDs.IndexOf("IPIO")].DefaultCellStyle.BackColor = Color.DarkRed;




            }
            //pollsGridView.Rows[0].SetValues("QQQQQQ", "1");
            //for (int i = 0; i < countColumns; i++)
            //{
            //    pollsGridView.Columns.Add(i+1.ToString(),i+1.ToString());

            //}
            //selectionAnketControl.comboBoxYear.SelectedIndexChanged
        }

        private void selectionAnketControl_Load(object sender, EventArgs e)
        {
           // InitializePollsGridView();
        }

        private void addPollToolStripButton_Click(object sender, EventArgs e)
        {
            var addPoll = new AddPollForm(_user,_num_module,this);
            addPoll.ShowDialog();
        }

        public User User { get; set; }

        private void pollsGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }

        private void changePollToolStripButton_Click(object sender, EventArgs e)
        {
            ChangePoll(pollsGridView.SelectedColumns[0].Index);
            
        }
        private void ChangePoll(int columnIndex)
        {
            if (columnIndex != pollsGridView.ColumnCount - 1)
            {

                var row = pollscommonDataTable.FindByNUMTYPERDAYBRANCHRKC(
                    pollsDataSet.Polls2GridCommon.FindByPosition(columnIndex).Num,
                    pollsDataSet.Polls2GridCommon.FindByPosition(columnIndex).Type,
                    pollsDataSet.Polls2GridCommon.FindByPosition(columnIndex).RDay,
                    pollsDataSet.Polls2GridCommon.FindByPosition(columnIndex).Branch,
                    pollsDataSet.Polls2GridCommon.FindByPosition(columnIndex).RKC);
                var changePoll = new ChangePollForm(_user,_num_module, this, row);
                //columnIndex
                if (changePoll.ShowDialog() == DialogResult.OK)
                {
                    GetGridRow();
                }
            }

        }

        private void pollsGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
                ChangePoll(e.ColumnIndex);
           
            
        }

        private void delPollToolStripButton_Click(object sender, EventArgs e)
        {
            if(
            MessageBox.Show(this, "Вы действительно хотите удалить анкету?", "Внимание", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                int columnIndex = pollsGridView.SelectedColumns[0].Index;
                pollscommonDataTable.FindByNUMTYPERDAYBRANCHRKC(
                pollsDataSet.Polls2GridCommon.FindByPosition(columnIndex).Num,
                pollsDataSet.Polls2GridCommon.FindByPosition(columnIndex).Type,
                pollsDataSet.Polls2GridCommon.FindByPosition(columnIndex).RDay,
                pollsDataSet.Polls2GridCommon.FindByPosition(columnIndex).Branch,
                pollsDataSet.Polls2GridCommon.FindByPosition(columnIndex).RKC).Delete();
                var pollscommonTA = new POLLSCOMMONTableAdapter();
                pollscommonTA.Update(pollscommonDataTable);
                pollscommonDataTable.AcceptChanges();
                foreach(var row in pollsDataSet.POLLSDATA.
                    Where(
                    c =>
                    c.NUM == pollsDataSet.Polls2GridCommon.FindByPosition(columnIndex).Num &&
                    c.RDAY == pollsDataSet.Polls2GridCommon.FindByPosition(columnIndex).RDay &&
                    c.BRANCH == pollsDataSet.Polls2GridCommon.FindByPosition(columnIndex).Branch &&
                    c.RKC == pollsDataSet.Polls2GridCommon.FindByPosition(columnIndex).RKC))
                {
                    row.Delete();
                }
                var pollsdataTa = new POLLSDATATableAdapter();
                pollsdataTa.Update(pollsDataSet.POLLSDATA);
                pollsDataSet.POLLSDATA.AcceptChanges();
                GetGridRow();

            }
        }
    }
}
