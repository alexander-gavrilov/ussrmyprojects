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
        private DeposPollsTableForm _owner;
        private PollsDataSet.POLL_DEPOSRow _oldRow;
        private bool _isChanges;
        //private Criterion _criterion;
        public DeposAnketAddForm(User user)
        {
            InitializeComponent();
            _user = user;
            InitializeForm();
            _isChanges = false;
        }
        public DeposAnketAddForm(User user, PollsDataSet.POLL_DEPOSRow inputRow)
        {
            InitializeComponent();
            _user = user;
            _oldRow = inputRow;
            InitializeForm();
            SetDefault();
            _isChanges = true;
        }

        private void filialСomboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            updateOtdComboBox();
        }
        private void updateOtdComboBox()
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
            updateRkcComboBox();
        }
        private void updateRkcComboBox()
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
            //pollsBindingSource.ResetItem(0);
            
        }

        private void addPollButton_Click(object sender, EventArgs e)
        {
            if (_isChanges)
            {
                updatePollRow();
            }
            else
            {
                addPollRow();
            }
        }
        private PollsDataSet.POLL_DEPOSRow generatedRow()
        {
            PollsDataSet.POLL_DEPOSRow tmpRow = Owner.pollsDataSet.POLL_DEPOS.NewPOLL_DEPOSRow();
            tmpRow.DATE_POLL_DEPOS = System.DateTime.Now;
            tmpRow.SEX = sexСomboBox.SelectedValue.ToString();
            tmpRow.AGE = ageUpDown.Value;
            tmpRow.NUMBER_POLL_DEPOS = _numberPoll;
            //if (!decimal.TryParse(numberTextBox.Text,out tmpRow.NUMBER_POLL_DEPOS))
            //{
            //    MessageBox.Show("Ошибка ввода! Номер анкеты числовое поле!!!");
            //}

            tmpRow.REF_RKC = (decimal)rkcComboBox.SelectedValue;
            tmpRow.REF_OTD = (decimal)otdComboBox.SelectedValue;
            tmpRow.REF_OBL = (decimal)filialСomboBox.SelectedValue;
            tmpRow.REF_USER = (decimal)_user.Id_user;
            tmpRow.DT_LAST_ACSESS = System.DateTime.Now;
            foreach (QuestControl currentQuestControl in pollsTabControl.TabPages[0].Controls)
            {
                tmpRow["S_" + currentQuestControl.IdQuest.ToUpper()] = (decimal)currentQuestControl.Value;
                tmpRow["I_" + currentQuestControl.IdQuest.ToUpper()] = (decimal)currentQuestControl.Importance;

            }
            return tmpRow;

        }

        private void addPollRow()
        {

            Owner.pollsDataSet.POLL_DEPOS.AddPOLL_DEPOSRow(generatedRow());
            Owner.polL_DEPOSTableAdapter.Update(Owner.pollsDataSet.POLL_DEPOS);
            Owner.pollsDataSet.POLL_DEPOS.AcceptChanges();
            InitializeForm();

        }
        private void updatePollRow()
        {
            _oldRow = generatedRow();
            //Owner.pollsDataSet.POLL_DEPOS.Select(c=>c.NUMBER_POLL_DEPOS==_oldRow.NUMBER_POLL_DEPOS&&c.DATE_POLL_DEPOS==_oldRow.DATE_POLL_DEPOS&&c.r)
            //PollsDataSet.POLL_DEPOSRow tmpR = generatedRow();
            Owner.polL_DEPOSTableAdapter.Update(Owner.pollsDataSet.POLL_DEPOS);
            Owner.pollsDataSet.POLL_DEPOS.AcceptChanges();

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
        public DeposPollsTableForm Owner { get; set; }
        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void InitializeForm()
        {
            //Инициализируем ErrorProvider отвечающий за контроль номера анкеты
            _numberErr = new ErrorProvider();
            _numberErr.SetIconAlignment(this.numberTextBox, ErrorIconAlignment.MiddleRight);
            _numberErr.SetIconPadding(this.numberTextBox, 2);
            _numberErr.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            

            //Устанавливаем начальные значения возраста и номера анкеты.
            ageUpDown.Value = ageUpDown.Minimum;
            numberTextBox.Text = "";
            addPollButton.Enabled = false;


            //Заполняем таблице Sex
            pollsDataSet.Sex.AddSexRow('m', "Мужской");
            pollsDataSet.Sex.AddSexRow('f', "Женский");
            

            
            if (_user.PrivilegesCodObl != 0)
            //Заполняем поле область в зависимости от предоставленых прав доступа
            //Если это ЦА то CodObl=0 - доступ к анкетам всех подразделений
            //Иначе - доступ к анкетам в пределах одной области
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
            
            //Заполняем таблицу отделений
            sTRUCTUNITBindingSource.DataSource = sTRUCT_UNITTableAdapter.GetData(System.DateTime.Now,
                                                                                 System.DateTime.Now,
                                                                                 (decimal)filialСomboBox.SelectedValue);

         //{ Запоняем таблицу РКЦ с добавлением кода РКЦ 0 для выбора самого отделения
            tmpRKCTable = new PollsDataSet.RKCDataTable();

            tmpRKCTable.AddRKCRow("<Отделение>", 0);
            rKCTableAdapter.ClearBeforeFill = false;
            rKCTableAdapter.Fill(tmpRKCTable, System.DateTime.Now, System.DateTime.Now,
                                 (decimal)otdComboBox.SelectedValue);

            rKCBindingSource.DataSource = tmpRKCTable;
         //}
            pollsTabControl.TabPages[0].Name = "DEPOS";
            pollsTabControl.TabPages[0].Text = "Вклады";
            pollsTabControl.TabPages[1].Name = "BANK";
            pollsTabControl.TabPages[1].Text = "Банк";
            pollsTabControl.TabPages[0].Controls.Clear();


            _collectionCriterion = new Collection<Criterion>();

            pollsTabControl.TabPages[0].Controls.Add(new QuestControl()
            {
                Location = new Point(7, 15),
                IdQuest = "depos_period",
                NameQuset = "Срок размещения денежных средств",
                Value = 1,
                Importance = 1
            });

            pollsTabControl.TabPages[0].Controls.Add(new QuestControl()
            {
                Location = new Point(7, 55),
                IdQuest = "interest_rate",
                NameQuset = "Процентная ставка по вкладу",
                Value = 1,
                Importance = 1
            });

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

        }
        private void SetDefault()
        {
            filialСomboBox.SelectedValue = _oldRow.REF_OBL;
            updateOtdComboBox();
            filialСomboBox.Enabled = false;
            otdComboBox.SelectedValue = _oldRow.REF_OTD;
            updateRkcComboBox();
            otdComboBox.Enabled = false;
            rkcComboBox.SelectedValue = _oldRow.REF_RKC;
            
            sexСomboBox.SelectedValue = _oldRow.SEX;
            ageUpDown.Value = _oldRow.AGE;
            numberTextBox.Text = _oldRow.NUMBER_POLL_DEPOS.ToString();
            numberTextBox.Enabled = false;
            addPollButton.Text = "Изменить";
            addPollButton.DialogResult = DialogResult.OK;
            addPollButton.Enabled = true;


        }

    }
}
