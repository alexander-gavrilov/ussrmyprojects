using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using admin;
using Poll.PollsDataSetTableAdapters;

namespace Poll
{
    public partial class DeposAnketAddForm : Form
    {
        public PollsDataSet.RKCDataTable tmpRKCTable;
        public User _user;
        private decimal _numberPoll;
        private ErrorProvider _numberErr;
        private Collection<Criterion> _collectionCriterion;
        //private Criterion _criterion;
        public DeposAnketAddForm(User user)
        {
            InitializeComponent();
            _numberErr =new ErrorProvider();
            _numberErr.SetIconAlignment(this.numberTextBox, ErrorIconAlignment.MiddleRight);
            _numberErr.SetIconPadding(this.numberTextBox, 2);
            _numberErr.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            //numberTextBox_Validated(this, 0);
            addPollButton.Enabled = false;


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
            pollsTabControl.TabPages[0].Name = "DEPOS";
            pollsTabControl.TabPages[0].Text = "Вклады";
            pollsTabControl.TabPages[1].Name = "BANK";
            pollsTabControl.TabPages[1].Text = "Банк";

            //DataRow nullRKCRow = pollsDataSet1.RKC.Rows[0];
            //nullRKCRow.
            //new DataRow();
            //PollsDataSet.RKCRow nullRKCRow = new PollsDataSet.RKCRow(drb);
           
            //rkcComboBox.Items.Add() rkcComboBox.Items.GetType()
            //rkcComboBox.Items.;
            //Criterion criterion = new Criterion();
            //foreach (DataColumn currentColumn in pollsDataSet.POLL_DEPOS.Columns.)
            //{
            //    criterion.Id = currentColumn.ColumnName;
            //    criterion.Name = currentColumn.Caption;

            //}


            _collectionCriterion=new Collection<Criterion>();
            //_collectionCriterion.Add(new Criterion()
            //                             {
            //                                 Id = "depos_period",
            //                                 Name = "Срок размещения денежных средств",
            //                                 Value = 1,
            //                                 Importance = 1
            //                             });
            //QuestControl questControl = new QuestControl(criterion);
            //questControl.Location = new Point(7, y);
            //List<String> t;
            //t.Where()
            
            pollsTabControl.TabPages[0].Controls.Add(new QuestControl()
                                                         {
                                                             Location = new Point(7, 15),
                                                             IdQuest = "depos_period",
                                                             NameQuset = "Срок размещения денежных средств",
                                                             Value = 1,
                                                             Importance = 1
                                                         });
            

            //pollsTabControl.TabPages[0].Controls.

            //pollsTabControl.TabPages[0].Controls
            //criterion.Id = "interest_rate";
            //criterion.Name = "Процентная ставка по вкладу";
            //criterion.Value = 1;
            //criterion.Importance = 1;
           
            pollsTabControl.TabPages[0].Controls.Add(new QuestControl()
                                                         {
                                                             Location = new Point(7, 55),
                                                             IdQuest = "interest_rate",
                                                             NameQuset = "Процентная ставка по вкладу",
                                                             Value = 1,
                                                             Importance = 1
                                                         });
            


            //criterion.Id = "select_curr";
            //criterion.Name = "Выбор валюты вклада";
            //criterion.Value = 1;
            //criterion.Importance = 1;
            //pollsTabControl.TabPages[0].Controls.Add(new QuestControl(criterion) { Location = new Point(7, 95) });
            //_collectionCriterion.Add(new Criterion()
            //                             {
            //                                 Id = "select_curr",
            //                                 Name = "Выбор валюты вклада",
            //                                 Value = 1,
            //                                 Importance = 1
            //                             });
            pollsTabControl.TabPages[0].Controls.Add(new QuestControl()
                                                         {
                                                             Location = new Point(7, 95),
                                                             IdQuest = "select_curr",
                                                             NameQuset = "Выбор валюты вклада",
                                                             Value = 1,
                                                             Importance = 1
                                                         });

            pollsTabControl.TabPages[0].Controls.Add(new QuestControl()
                                                         {
                                                             Location = new Point(7, 135),
                                                             IdQuest = "registr_speed",
                                                             NameQuset = "Скорость оформления перевода",
                                                             Value = 1,
                                                             Importance = 1
                                                         });
            pollsTabControl.TabPages[0].Controls.Add(new QuestControl()
                                                         {
                                                             Location = new Point(7, 175),
                                                             IdQuest = "cont_intelli",
                                                             NameQuset = "Понятность условий",
                                                             Value = 1,
                                                             Importance = 1
                                                         });
            pollsTabControl.TabPages[0].Controls.Add(new QuestControl()
                                                         {
                                                             Location = new Point(7, 215),
                                                             IdQuest = "depos_choice",
                                                             NameQuset = "Возможность выбора варианта вклада",
                                                             Value = 1,
                                                             Importance = 1
                                                         });
            pollsTabControl.TabPages[0].Controls.Add(new QuestControl()
                                                         {
                                                             Location = new Point(7, 255),
                                                             IdQuest = "add_service",
                                                             NameQuset = "Наличие дополнительных услуг и предложений",
                                                             Value = 1,
                                                             Importance = 1
                                                         });

            //foreach (QuestControl currentQuestControl in pollsTabControl.TabPages[0].Controls)
            //{
            //    _collectionCriterion.Add(currentQuestControl.Criter());
            //}







            //questDeposControlsCollectionForm.Add(new QuestControl(criterion));
            //questDeposControlsCollectionForm.Refresh();
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

        private void DeposAnketAddForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //MessageBox.Show(_collectionCriterion.Where(c => c.Id == "depos_period").First().Name + " " +
            //                _collectionCriterion.Where(c => c.Id == "depos_period").First().Value.ToString());
            pollsBindingSource.ResetItem(0);
            
        }

        private void addPollButton_Click(object sender, EventArgs e)
        {
            PollsDataSet.POLL_DEPOSRow tmpRow = pollsDataSet.POLL_DEPOS.NewPOLL_DEPOSRow();
            tmpRow.DATE_POLL_DEPOS = System.DateTime.Now;
            tmpRow.SEX = sexСomboBox.SelectedValue.ToString();
            tmpRow.AGE = ageUpDown.Value;
            tmpRow.NUMBER_POLL_DEPOS = _numberPoll;
            //if (!decimal.TryParse(numberTextBox.Text,out tmpRow.NUMBER_POLL_DEPOS))
            //{
            //    MessageBox.Show("Ошибка ввода! Номер анкеты числовое поле!!!");
            //}
            
            tmpRow.REF_RKC = (decimal) rkcComboBox.SelectedValue;
            tmpRow.REF_OTD = (decimal) otdComboBox.SelectedValue;
            tmpRow.REF_OBL = (decimal) filialСomboBox.SelectedValue;
            tmpRow.REF_USER = (decimal) _user.Id_user;
            tmpRow.DT_LAST_ACSESS = System.DateTime.Now;
            foreach (QuestControl currentQuestControl in pollsTabControl.TabPages[0].Controls)
            {
                tmpRow["S_" + currentQuestControl.IdQuest.ToUpper()] = (decimal) currentQuestControl.Value;
                tmpRow["I_" + currentQuestControl.IdQuest.ToUpper()] = (decimal) currentQuestControl.Importance;

            }
            
            pollsDataSet.POLL_DEPOS.AddPOLL_DEPOSRow(tmpRow);
            
            PollsDataSetTableAdapters.POLL_DEPOSTableAdapter tmp = new POLL_DEPOSTableAdapter();
            //int t = tmp.Update(pollsDataSet.POLL_DEPOS);
           // pollsDataSet.POLL_DEPOS.AcceptChanges();
           // MessageBox.Show(t.ToString());
            tmp.Dispose();
            
        }

        private void numberTextBox_TextChanged(object sender, EventArgs e)
        {
            _numberErr.Clear();
        }

        private void numberTextBox_Validated(object sender, EventArgs e)
        {
            if(!IsNamberValid())
            {
                _numberErr.SetError(this.numberTextBox,"Значение должнобыть целым числом");
                addPollButton.Enabled = false;
            }
            else
            {
                _numberErr.SetError(this.numberTextBox, "");
                addPollButton.Enabled = true;

            }
        }
        private bool IsNamberValid()
        {
            return (decimal.TryParse(numberTextBox.Text, out _numberPoll));
        }

        public PollsDataSet PollsDataSet { get; set; }
        public BindingSource PollsBindingSource { get; set; } 
    }
}
