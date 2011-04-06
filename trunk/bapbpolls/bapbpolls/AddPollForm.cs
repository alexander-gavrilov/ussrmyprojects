using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using admin;
using Components;
using bapbpolls.PollsDataSetTableAdapters;

namespace bapbpolls
{
    public partial class AddPollForm : AddChangeRecordForm
    {
        private MainPollsForm _owner;
        private User _user;
        private PollsDataSet _pollsDataSet;
        private List<String> _qTexts;
        private List<String> _iTexts;
        private ErrorProvider _numberErr;
        //private STRUCT_UNITTableAdapter structTableAdapter;
        //private BindingSource structBindingSource;
        private TYPESTableAdapter typesAdapter;
        private BindingSource typesBinding;
        //private FILIALTableAdapter filialTableAdapter;
        //private BindingSource filialBindingSource;
        //private RKCViewTableAdapter rkcTableAdapter;
        //private BindingSource rkcBindingSource;

        public AddPollForm(User user,MainPollsForm owner)
        {
            _user = user;
            Owner = owner;
            
            InitializeComponent();
            _qTexts = new List<string>()
                          {
                              "Совершенно удовлетворен",
                              "Скорее удовлетворен",
                              "В целом меня все устраивает",
                              "Скорее не удовлетворен",
                              "Совершенно не удовлетворен"
                          };



            _iTexts = new List<string>()
                          {
                              "Очень важно",
                              "Скорее важно",
                              "Имеет нейтральное значение",
                              "Скорее неважно",
                              "Совершенно неважно"
                          };

            LoadControls();
            //componentsComboBoxRegion.label.Text = "Область:";
        }

        public MainPollsForm Owner
        {
            get { return _owner; }
            set
            {
                _owner = value;
                _pollsDataSet = value.pollsDataSet;
            }
        }

        public User User { get { return _user; } }
        private void LoadControls()
        {
            typesAdapter = new TYPESTableAdapter();
            typesBinding = new BindingSource(_owner.pollsDataSet, "TYPES");
            typesAdapter.Fill(_owner.pollsDataSet.TYPES);
            checkedListBoxType.DataSource = typesBinding;
            checkedListBoxType.DisplayMember = "NAME";
            checkedListBoxType.ValueMember = "TYPE";
            maskedTextBoxNumber.Text="";

            //Инициализируем ErrorProvider отвечающий за контроль номера анкеты
            _numberErr = new ErrorProvider();
            _numberErr.SetIconAlignment(maskedTextBoxNumber, ErrorIconAlignment.MiddleRight);
            _numberErr.SetIconPadding(maskedTextBoxNumber, 2);
            _numberErr.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.BlinkIfDifferentError;

            //filialTableAdapter = new FILIALTableAdapter();
            //filialBindingSource = new BindingSource(_owner.pollsDataSet,"FILIAL");
            if (_user.PrivilegesCodObl != 0)
            {
               // filialBindingSource.Filter = "COD_FIL=" + _user.PrivilegesCodObl;
                fILIALBindingSource.Filter = "COD_FIL=" + _user.PrivilegesCodObl;
            }
            fILIALTableAdapter.Fill(pollsDataSet.FILIAL, DateTime.Now);
            sTRUCT_UNITTableAdapter.Fill(pollsDataSet.STRUCT_UNIT, DateTime.Now);
            rKCViewTableAdapter.ClearBeforeFill = false;
            pollsDataSet.RKCView.AddRKCViewRow(0, "<Отделение>");
            //structTableAdapter = new STRUCT_UNITTableAdapter();
            //structBindingSource = new BindingSource(_owner.pollsDataSet, "STRUCT_UNIT");

            pollsDataSet.SEX.AddSEXRow("М", "Мужской");
            pollsDataSet.SEX.AddSEXRow("Ж", "Женский");
            //filialTableAdapter.Fill(_owner.pollsDataSet.FILIAL, DateTime.Now);

            //comboBoxRegion.DataSource = filialBindingSource;
            //comboBoxRegion.DisplayMember = _owner.pollsDataSet.FILIAL.NAMEColumn.ColumnName;
            //comboBoxRegion.ValueMember = _owner.pollsDataSet.FILIAL.COD_FILColumn.ColumnName;


            //structTableAdapter.Fill(_owner.pollsDataSet.STRUCT_UNIT, DateTime.Now);
            //comboBoxStructUnite.DataSource = structBindingSource;
            //comboBoxStructUnite.DisplayMember = _owner.pollsDataSet.STRUCT_UNIT.NAMEColumn.ColumnName;
            //comboBoxStructUnite.ValueMember = _owner.pollsDataSet.STRUCT_UNIT.BRANCHColumn.ColumnName;

            //rkcTableAdapter = new RKCViewTableAdapter();
            //rkcBindingSource = new BindingSource(_owner.pollsDataSet, "RKCView");
            //rkcTableAdapter.ClearBeforeFill = false;
            //comboBoxRKC.DataSource = rkcBindingSource;
            //comboBoxRKC.DisplayMember = _owner.pollsDataSet.RKC.NAMEColumn.ColumnName;
            //comboBoxRKC.ValueMember = _owner.pollsDataSet.RKC.CODE_RKCColumn.ColumnName;




        }

        private void checkedListBoxType_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue==CheckState.Checked)
            {
                tabControlPolls.TabPages.Add(GetTabPage(_owner.pollsDataSet.TYPES[e.Index].TYPE));
                //tabControlPolls.TabPages.Add(_owner.pollsDataSet.TYPES[e.Index].TYPE, _owner.pollsDataSet.TYPES[e.Index].NAME);
                //FillTabPage(_owner.pollsDataSet.TYPES[e.Index].TYPE);
                //tabControlPolls.TabPages[_owner.pollsDataSet.TYPES[e.Index].TYPE].Select();
                //tabControlPolls.TabPages.Add();
            }
            else
            {
                tabControlPolls.TabPages.Remove(tabControlPolls.TabPages[_owner.pollsDataSet.TYPES[e.Index].TYPE]);
            }

            
            //checkedListBoxType.ite
            
        }

        private TabPage GetTabPage(String Key)
        {
            var newTab = new TabPage() { Text = _owner.pollsDataSet.TYPES.First(c=>c.TYPE==Key).NAME, Name = Key};
            var rbDictQ = new Dictionary<String,RowRadioButtons>();
            var rbDictI = new Dictionary<String,RowRadioButtons>();
            var typePolls = new TYPEPOLLSTableAdapter();
            var splitQI = new SplitContainer() { Dock = DockStyle.Fill, Orientation = Orientation.Horizontal, Name = "SplitQI",AutoSize = true,AutoScroll = true};
            
            newTab.Controls.Add(splitQI);

            typePolls.Fill(_owner.pollsDataSet.TYPEPOLLS);


            var qPollRadioTable = new PollRadioTable() { Name = "QTABLE", AutoSize = true, AutoSizeMode = AutoSizeMode.GrowOnly,Dock = DockStyle.Fill ,AutoScroll = true};
            var iPollRadioTable = new PollRadioTable() { Name = "ITABLE", AutoSize = true, AutoSizeMode = AutoSizeMode.GrowOnly, Dock = DockStyle.Fill, AutoScroll = true };
            //qPollRadioTable.AddRow("HEADERS");
            var qHeadersRow = new GroupeRow(){Dock = DockStyle.Fill};
            var iHeadersRow = new GroupeRow() { Dock = DockStyle.Fill };

            qHeadersRow.tableLayoutPanel.RowStyles[0].SizeType = SizeType.Absolute;
            iHeadersRow.tableLayoutPanel.RowStyles[0].SizeType = SizeType.Absolute;

            for (int j = 0; j < qHeadersRow.tableLayoutPanel.ColumnCount && j < iHeadersRow.tableLayoutPanel.ColumnCount; j++)
            {
                //qPollRadioTable.tableLayoutPanel.Controls["HEADERS"].Controls.Add();
                //qPollRadioTable.tableLayoutPanel.Controls.Add(new Label {Text = _qTexts[j-1],TextAlign = ContentAlignment.MiddleCenter,AutoSize=true},j,0);

                var qHeaderLabel = new Label()
                                      {
                                          Text = _qTexts[j],
                                          Name = "Header" + j,
                                          TextAlign = ContentAlignment.MiddleCenter,
                                          AutoSize = true,
                                          Dock = DockStyle.Fill
                                          
                                      };
                var iHeaderLabel = new Label()
                                       {
                                           Text = _iTexts[j],
                                           Name = "Header" + j,
                                           TextAlign = ContentAlignment.MiddleCenter,
                                           AutoSize = true,
                                           Dock = DockStyle.Fill

                                       };

                qHeadersRow.tableLayoutPanel.Controls.Add(qHeaderLabel , j, 0);
                iHeadersRow.tableLayoutPanel.Controls.Add(iHeaderLabel, j, 0);

                //qHeadersRow.tableLayoutPanel.Controls["Header" + j].AutoSize = true;

               // Console.WriteLine("Header " + j + " " + qHeadersRow.tableLayoutPanel.Controls["Header" + j].Height + "x" + qHeadersRow.tableLayoutPanel.Controls["Header" + j].Width);
                //qHeadersRow.tableLayoutPanel.AutoSize
                //qPollRadioTable.tableLayoutPanel.Controls[]
            }
            qHeadersRow.tableLayoutPanel.RowStyles[0].Height = 30;
            iHeadersRow.tableLayoutPanel.RowStyles[0].Height = 30;

            //qHeadersRow.tableLayoutPanel.RowStyles[0].SizeType = SizeType.Absolute;
            int i = 0;
            qHeadersRow.tableLayoutPanel.AutoSize = true;
            iHeadersRow.tableLayoutPanel.AutoSize = true;
            
            //qHeadersRow.tableLayoutPanel.LayoutSettings.RowStyles[0].SizeType = SizeType.AutoSize;
            qPollRadioTable.tableLayoutPanel.Controls.Add(qHeadersRow,1,0);
            iPollRadioTable.tableLayoutPanel.Controls.Add(iHeadersRow, 1, 0);

            qHeadersRow.AutoSize = true;
            iHeadersRow.AutoSize = true;
            Console.WriteLine("Header "+qHeadersRow.Height);
            

            foreach (var currentRow in _owner.pollsDataSet.TYPEPOLLS.Where(c=>c.TYPE==Key))
            {
                
                var qRadioRow = new RowRadioButtons(5){Text = currentRow.NAMEQUEST};
               
                //qRadioRow.Mark[0].Text = "Совершенно удовлетворен";
                //qRadioRow.Mark[1].Text = "Скорее удовлетворен";
                //qRadioRow.Mark[2].Text = "В целом меня все устраивает";
                //qRadioRow.Mark[3].Text = "Скорее не удовлетворен";
                //qRadioRow.Mark[4].Text = "Совершенно не удовлетворен";
                rbDictQ.Add(currentRow.IDQUEST,qRadioRow);
                var iRadioRow = new RowRadioButtons(5){Text = currentRow.NAMEQUEST};

                //iRadioRow.Mark[0].Text = "Очень важно";
                //iRadioRow.Mark[1].Text = "Скорее важно";
                //iRadioRow.Mark[2].Text = "Имеет нейтральное значение";
                //iRadioRow.Mark[3].Text = "Скорее неважно";
                //iRadioRow.Mark[4].Text = "Совершенно неважно";
                rbDictI.Add(currentRow.IDQUEST,iRadioRow);
                qPollRadioTable.tableLayoutPanel.Controls.Add(new Label(){Name = currentRow.IDQUEST,Text = qRadioRow.Text,AutoSize = true,Height = 0},0,i+1);
                iPollRadioTable.tableLayoutPanel.Controls.Add(new Label() { Name = currentRow.IDQUEST, Text = qRadioRow.Text, AutoSize = true, Height = 0 }, 0, i + 1);

                var qCurentRadioRow = new GroupeRow() { Dock = DockStyle.Fill, Name = "R" + currentRow.IDQUEST };
                var iCurentRadioRow = new GroupeRow() { Dock = DockStyle.Fill, Name = "R" + currentRow.IDQUEST }; 

                for (int j = 0; j < 5; j++)
                {
                    //qPollRadioTable.tableLayoutPanel.Controls.Add(qRadioRow.Mark[j], j + 1, i+1);
                    ////qPollRadioTable.tableLayoutPanel.RowStyles[i + 1] = new RowStyle(qPollRadioTable.tableLayoutPanel.RowStyles[0]);
                    //iPollRadioTable.tableLayoutPanel.Controls.Add(iRadioRow.Mark[j], j + 1, i+1);
                    qCurentRadioRow.tableLayoutPanel.Controls.Add(qRadioRow.Mark[j], j, 0);

                    iCurentRadioRow.tableLayoutPanel.Controls.Add(iRadioRow.Mark[j], j, 0);
                }
                qPollRadioTable.tableLayoutPanel.Controls.Add(qCurentRadioRow, 1, i + 1);
                iPollRadioTable.tableLayoutPanel.Controls.Add(iCurentRadioRow, 1, i + 1);




                i++;
            }
            if (newTab.Name != "TRANS")
            {
               // var newTableControls = new TableLayoutPanel();
                qPollRadioTable.BorderStyle = BorderStyle.FixedSingle;
                //qPollRadioTable.MaximumSize.Width
                    //= splitQI.Panel1.Size.Width - 4;
                qPollRadioTable.AutoSize = true;
                qPollRadioTable.tableLayoutPanel.AutoSize = true;
                iPollRadioTable.BorderStyle = BorderStyle.FixedSingle;
                
                splitQI.Panel1.Controls.Add(qPollRadioTable);
                //splitQI.Panel1.AutoSize = true;
                //splitQI.Panel1.Dock = DockStyle.Fill;
                //splitQI.Panel1.AutoScroll = true;
                //splitQI.Panel1.Controls[newTab.Controls.IndexOfKey("QTABLE")].Dock = DockStyle.Fill;
                qPollRadioTable.tableLayoutPanel.AutoScroll = true;
                iPollRadioTable.tableLayoutPanel.AutoScroll = true;
                splitQI.Panel2.Controls.Add(iPollRadioTable);
                //splitQI.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
                //newTab.Controls[newTab.Controls.IndexOfKey("ITABLE")].Dock = DockStyle.Bottom;
                newTab.AutoSizeMode = AutoSizeMode.GrowOnly;
                newTab.AutoSize = true;
                newTab.AutoScroll = true;


                //tabControlPolls.TabPages[_owner.pollsDataSet.TYPES[index].TYPE]
            }
            return newTab;
        }



        private void FillTabPage(String Key)
        {
            var newTab = tabControlPolls.TabPages[Key];
            //var newTab = new TabPage(_owner.pollsDataSet.TYPES[index].TYPE) { Text = _owner.pollsDataSet.TYPES[index].NAME };
            var rbDictQ = new Dictionary<String, RowRadioButtons>();
            var rbDictI = new Dictionary<String, RowRadioButtons>();
            var splitQI = new SplitContainer()
                              {Dock = DockStyle.Fill, Orientation = Orientation.Horizontal, Name = "SplitQI"};
            newTab.Controls.Add(splitQI);
            //splitQI.Panel1.Controls.Add(new Label(){Text = "Test"});
            var qPollRadioTable = new PollRadioTable()
                                      {
                                          Name = "QTABLE",
                                          AutoSize = true,
                                          AutoSizeMode = AutoSizeMode.GrowAndShrink,
                                          BorderStyle = BorderStyle.Fixed3D,
                                          Dock = DockStyle.Fill
                                      };
            var iPollRadioTable = new PollRadioTable()
                                      {
                                          Name = "ITABLE",
                                          AutoSize = true,
                                          AutoSizeMode = AutoSizeMode.GrowAndShrink,
                                          BorderStyle = BorderStyle.Fixed3D,
                                          Dock = DockStyle.Fill
                                      };


            int i = 0;
            var typePolls = new TYPEPOLLSTableAdapter();
            typePolls.Fill(_owner.pollsDataSet.TYPEPOLLS);
            foreach (var currentRow in _owner.pollsDataSet.TYPEPOLLS.Where(c => c.TYPE == newTab.Name))
            {
                var qRadioRow = new RowRadioButtons(5) { Text = currentRow.NAMEQUEST };

                qRadioRow.Mark[0].Text = "Совершенно удовлетворен";
                qRadioRow.Mark[1].Text = "Скорее удовлетворен";
                qRadioRow.Mark[2].Text = "В целом меня все устраивает";
                qRadioRow.Mark[3].Text = "Скорее не удовлетворен";
                qRadioRow.Mark[4].Text = "Совершенно не удовлетворен";
                rbDictQ.Add(currentRow.IDQUEST, qRadioRow);
                var iRadioRow = new RowRadioButtons(5) { Text = currentRow.NAMEQUEST };

                iRadioRow.Mark[0].Text = "Очень важно";
                iRadioRow.Mark[1].Text = "Скорее важно";
                iRadioRow.Mark[2].Text = "Имеет нейтральное значение";
                iRadioRow.Mark[3].Text = "Скорее неважно";
                iRadioRow.Mark[4].Text = "Совершенно неважно";
                rbDictI.Add(currentRow.IDQUEST, iRadioRow);
                qPollRadioTable.tableLayoutPanel.Controls.Add(new Label() { Name = currentRow.IDQUEST, Text = qRadioRow.Text }, 0, i + 1);
                for (int j = 0; j < 5; j++)
                {
                    qPollRadioTable.tableLayoutPanel.Controls.Add(qRadioRow.Mark[j], j + 1, i+1);
                    iPollRadioTable.tableLayoutPanel.Controls.Add(iRadioRow.Mark[j], j + 1, i+1);

                }



                i++;
            }
            if (newTab.Name != "TRANS")
            {
                // var newTableControls = new TableLayoutPanel();
                //splitQI.Panel1.Controls.Add(qPollRadioTable);
                //splitQI.Panel1.Controls[newTab.Controls.IndexOfKey("QTABLE")].Dock = DockStyle.Fill;
                splitQI.Panel1MinSize = splitQI.Size.Height - splitQI.SplitterWidth;
                
                //splitQI.Panel2.Controls.Add(iPollRadioTable);
                //splitQI.Panel2.Controls[newTab.Controls.IndexOfKey("ITABLE")].Dock = DockStyle.Fill;
                splitQI.Panel2MinSize = splitQI.Size.Height - splitQI.SplitterWidth;
                splitQI.AutoSize = true;
                splitQI.Dock = DockStyle.Fill;
                newTab.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                newTab.AutoSize = true;
                newTab.AutoScroll = true;
                newTab.Dock = DockStyle.Fill;

                //tabControlPolls.TabPages[_owner.pollsDataSet.TYPES[index].TYPE]
            }
            //return newTab;
        }

        private void AddPollForm_Load(object sender, EventArgs e)
        {

        }

        private void acceptChangesButton_Click(object sender, EventArgs e)
        {
            foreach (TabPage currentListBoxItem in tabControlPolls.TabPages)
            {
                var _newCommonRow = _owner.pollsDataSet.POLLSCOMMON.NewPOLLSCOMMONRow();
                _newCommonRow.NUM = Convert.ToDecimal(maskedTextBoxNumber.Text);
                _newCommonRow.RDAY = dateTimePicker.Value;
                _newCommonRow.TYPE = currentListBoxItem.Name;
                _newCommonRow.FILIAL = Convert.ToDecimal(comboBoxRegion.SelectedValue);
                _newCommonRow.BRANCH = Convert.ToDecimal(comboBoxStructUnite.SelectedValue);
                _newCommonRow.RKC = Convert.ToDecimal(comboBoxRKC.SelectedValue);
                _newCommonRow.SEX = comboBoxSex.SelectedValue.ToString();
                _newCommonRow.AGE = numericUpDown1.Value;
                _newCommonRow.LASTCHANGE = DateTime.Now;
                _newCommonRow.REFUSER = _user.Id_user;


                


                if(
                currentListBoxItem.Name == "TRANS")
                {}
                var typesPoll = new TYPEPOLLSTableAdapter();
                typesPoll.Fill(_owner.pollsDataSet.TYPEPOLLS);
                var splitQI = (SplitContainer) currentListBoxItem.Controls["SplitQI"];
                var qPollRadioTable = (PollRadioTable) splitQI.Panel1.Controls["QTABLE"];
                var iPollRadioTable = (PollRadioTable) splitQI.Panel2.Controls["ITABLE"];
                _owner.pollsDataSet.POLLSCOMMON.AddPOLLSCOMMONRow(_newCommonRow);
                var pollsCommonAdapter = new POLLSCOMMONTableAdapter();
                pollsCommonAdapter.Update(_owner.pollsDataSet.POLLSCOMMON);
                _owner.pollsDataSet.POLLSCOMMON.AcceptChanges();

                //c => c.TYPE == currentListBoxItem.Name/*"TYPE="+currentListBoxItem.Name*/)
                foreach (PollsDataSet.TYPEPOLLSRow curCrit in _owner.pollsDataSet.TYPEPOLLS.Where(c=>c.TYPE==currentListBoxItem.Name))
                {
                    var qCurRadioRow = (GroupeRow)qPollRadioTable.tableLayoutPanel.Controls["R" + curCrit.IDQUEST];
                    var iCurRadioRow = (GroupeRow)iPollRadioTable.tableLayoutPanel.Controls["R" + curCrit.IDQUEST];
                    int markQ = 0;
                    int markI = 0;
                    for (int i = 1; i <= 5; i++)
                    {
                        var rbQ = (RadioButton) qCurRadioRow.tableLayoutPanel.Controls["Mark" + i];
                        if (rbQ.Checked)
                            markQ = i;
                        var rbI = (RadioButton)iCurRadioRow.tableLayoutPanel.Controls["Mark" + i];
                        if (rbI.Checked)
                            markI = i;
 
                    }
                    var newPollsDataRow = _owner.pollsDataSet.POLLSDATA.NewPOLLSDATARow();
                    newPollsDataRow.IDQUEST = curCrit.IDQUEST;
                    newPollsDataRow.BRANCH = _newCommonRow.BRANCH;
                    newPollsDataRow.RKC = _newCommonRow.RKC;
                    newPollsDataRow.NUM = _newCommonRow.NUM;
                    newPollsDataRow.RDAY = _newCommonRow.RDAY;
                    newPollsDataRow.TYPE = _newCommonRow.TYPE;
                    newPollsDataRow.QUALITY = markQ;
                    newPollsDataRow.IMPOTANCE = markI;
                    _owner.pollsDataSet.POLLSDATA.AddPOLLSDATARow(newPollsDataRow);
                    var pollsDataAdapter = new POLLSDATATableAdapter();
                    pollsDataAdapter.Update(_owner.pollsDataSet.POLLSDATA);
                    _owner.pollsDataSet.POLLSDATA.AcceptChanges();
                    tabControlPolls.TabPages.Clear();
                    LoadControls();
                   
                    //Console.WriteLine(qCurRadioRow.Name+ "  "+markQ);
                }


            }

        }

        private void comboBoxRegion_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxRegion.SelectedValue!=null)
            {
                sTRUCTUNITBindingSource.Filter = "REF_FILIAL=" + comboBoxRegion.SelectedValue.ToString();
            }
            

        }

        private void comboBoxStructUnite_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxStructUnite.SelectedValue!=null)
            {
                pollsDataSet.RKCView.Clear();
                pollsDataSet.RKCView.AddRKCViewRow(0, "<Отделение>");
                rKCViewTableAdapter.Fill(pollsDataSet.RKCView, DateTime.Now, Convert.ToDecimal(comboBoxStructUnite.SelectedValue));

            }
            //rkcBindingSource.Filter = "REF_OTD=" + comboBoxStructUnite.SelectedValue.ToString();

        }

        private void maskedTextBoxNumber_Validated(object sender, EventArgs e)
        {
            if (!IsNamberValid())
            {
                _numberErr.SetError(this.maskedTextBoxNumber, "Значение должно быть целым числом либо такой номер уже используется");
                acceptChangesButton.Enabled = false;
            }
            else
            {
                _numberErr.SetError(this.maskedTextBoxNumber, "");
                acceptChangesButton.Enabled = true;

            }

        }
        private bool IsNamberValid()
        {
            var pollscommonTableAdapter=new POLLSCOMMONTableAdapter();
            decimal num;
            return Decimal.TryParse(maskedTextBoxNumber.Text, out num) &&
                   Convert.ToInt32(pollscommonTableAdapter.CountByNum(Convert.ToDecimal(num),
                                                                      Convert.ToDecimal(
                                                                          comboBoxStructUnite.SelectedValue),
                                                                      Convert.ToDecimal(comboBoxRKC.SelectedValue))) ==
                   0;

            //return (decimal.TryParse(maskedTextBoxNumber.Text, out _numberPoll));
        }
    }
}
