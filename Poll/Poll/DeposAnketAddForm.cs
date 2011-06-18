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
using Components;
using Poll.PollsDataSetTableAdapters;
using Poll.Properties;

namespace Poll
{
    public partial class DeposAnketAddForm : AddChangeRecordForm
    {
        public PollsDataSet.RKCDataTable tmpRKCTable;
        public User _user;
        private decimal _numberPoll;
        private ErrorProvider _numberErr;
        //private Collection<Criterion> _collectionCriterion;
        private DeposPollsTableForm _owner;
        private PollsDataSet.POLL_DEPOSRow _oldRowDepos;
        private PollsDataSet.POLL_BANKRow _oldRowBank;
        
        private bool _isChanges;
        //private Criterion _criterion;
        public DeposAnketAddForm(User user)
        {
            InitializeComponent();
            _user = user;
            InitializeForm();
            _isChanges = false;
            acceptChangesButton.Text = "Добавить";
            //acceptChangesButton.DialogResult = DialogResult.OK;
            acceptChangesButton.Enabled = false;
            rejectChangesButton.Text = "Закрыть";


        }
        public DeposAnketAddForm(User user, PollsDataSet.POLL_DEPOSRow inputRow)
        {
            InitializeComponent();
            _user = user;
            _oldRowDepos = inputRow;
           
            InitializeForm();
            SetDefault();
            _isChanges = true;
            acceptChangesButton.Text = "Изменить";
            acceptChangesButton.DialogResult = DialogResult.OK;
            acceptChangesButton.Enabled = true;
            rejectChangesButton.Text = "Закрыть";


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
        public override void acceptChanges()
        {
            base.acceptChanges();
            if (_isChanges)
            {
                updatePollRow();
            }
            else
            {
                addPollRow();
            }

        }
        private void addPollButton_Click(object sender, EventArgs e)
        {
        }
        private void generateRow()
        {
            //PollsDataSet.POLL_DEPOSRow tmpRow = Owner.pollsDataSet.POLL_DEPOS.NewPOLL_DEPOSRow();
            //_oldRow.DATE_POLL_DEPOS = System.DateTime.Now;
            _oldRowDepos.SEX = sexСomboBox.SelectedValue.ToString();
            _oldRowDepos.AGE = ageUpDown.Value;
            //_oldRow.NUMBER_POLL_DEPOS = _numberPoll;
            //if (!decimal.TryParse(numberTextBox.Text,out tmpRow.NUMBER_POLL_DEPOS))
            //{
            //    MessageBox.Show("Ошибка ввода! Номер анкеты числовое поле!!!");
            //}

            _oldRowDepos.REF_RKC = (decimal)rkcComboBox.SelectedValue;
            //_oldRow.REF_OTD = (decimal)otdComboBox.SelectedValue;
            _oldRowDepos.REF_OBL = (decimal)filialСomboBox.SelectedValue;
            _oldRowDepos.REF_USER = (decimal)_user.Id_user;
            _oldRowDepos.DT_LAST_ACSESS = System.DateTime.Now;
            foreach (QuestControl currentQuestControl in pollsTabControl.TabPages[0].Controls)
            {
                _oldRowDepos["S_" + currentQuestControl.IdQuest.ToUpper()] = (decimal)currentQuestControl.Value;
                _oldRowDepos["I_" + currentQuestControl.IdQuest.ToUpper()] = (decimal)currentQuestControl.Importance;

            }
            foreach (QuestControl currentQuestControl in pollsTabControl.TabPages[1].Controls)
            {
                _oldRowBank["S_" + currentQuestControl.IdQuest.ToUpper()] = (decimal)currentQuestControl.Value;
                _oldRowBank["I_" + currentQuestControl.IdQuest.ToUpper()] = (decimal)currentQuestControl.Importance;

            }
            //return tmpRow;

        }

        private void addPollRow()
        {
            PollsDataSet.POLL_DEPOSRow _oldRow = Owner.pollsDataSet.POLL_DEPOS.NewPOLL_DEPOSRow();
            Poll.PollsDataSet.POLL_BANKRow _newBankRow = Owner.pollsDataSet.POLL_BANK.NewPOLL_BANKRow();
            _newBankRow.DATE_POLL_BANK = System.DateTime.Now;
            _oldRow.DATE_POLL_DEPOS = System.DateTime.Now;

            _newBankRow.SEX = sexСomboBox.SelectedValue.ToString();
            _oldRow.SEX = sexСomboBox.SelectedValue.ToString();

            _newBankRow.AGE = ageUpDown.Value;
            _oldRow.AGE = ageUpDown.Value;

            _newBankRow.NUMBER_POLL_BANK = _numberPoll;
            _oldRow.NUMBER_POLL_DEPOS = _numberPoll;
            //if (!decimal.TryParse(numberTextBox.Text,out tmpRow.NUMBER_POLL_DEPOS))
            //{
            //    MessageBox.Show("Ошибка ввода! Номер анкеты числовое поле!!!");
            //}

            _oldRow.REF_RKC = (decimal)rkcComboBox.SelectedValue;
            _newBankRow.REF_RKC = (decimal)rkcComboBox.SelectedValue;

            _oldRow.REF_OTD = (decimal)otdComboBox.SelectedValue;
            _newBankRow.REF_OTD = (decimal)otdComboBox.SelectedValue;

            _newBankRow.REF_OBL = (decimal)filialСomboBox.SelectedValue;
            _oldRow.REF_OBL = (decimal)filialСomboBox.SelectedValue;

            _newBankRow.REF_USER = (decimal)_user.Id_user;
            _oldRow.REF_USER = (decimal)_user.Id_user;

            _newBankRow.DT_LAST_ACSESS = System.DateTime.Now;
            _oldRow.DT_LAST_ACSESS = System.DateTime.Now;
            foreach (QuestControl currentQuestControl in pollsTabControl.TabPages[0].Controls)
            {
                _oldRow["S_" + currentQuestControl.IdQuest.ToUpper()] = (decimal)currentQuestControl.Value;
                _oldRow["I_" + currentQuestControl.IdQuest.ToUpper()] = (decimal)currentQuestControl.Importance;

            }
            foreach (QuestControl currentQuestControl in pollsTabControl.TabPages[1].Controls)
            {
                _newBankRow["S_" + currentQuestControl.IdQuest.ToUpper()] = (decimal)currentQuestControl.Value;
                _newBankRow["I_" + currentQuestControl.IdQuest.ToUpper()] = (decimal)currentQuestControl.Importance;

            }


            Owner.pollsDataSet.POLL_DEPOS.AddPOLL_DEPOSRow(_oldRow);
            Owner.polL_DEPOSTableAdapter.Update(Owner.pollsDataSet.POLL_DEPOS);
            Owner.pollsDataSet.POLL_BANK.AddPOLL_BANKRow(_newBankRow);
            POLL_BANKTableAdapter pollBankTableAdapter=new POLL_BANKTableAdapter();
            pollBankTableAdapter.Update(Owner.pollsDataSet.POLL_BANK);
            Owner.pollsDataSet.POLL_DEPOS.AcceptChanges();
            if(MessageBox.Show(this,Resources.DeposAnketAddForm_addPollRow_QuestString,"Выбор",MessageBoxButtons.YesNo)==DialogResult.No)
            {
                Close();
            }
            InitializeForm();

        }
        private void updatePollRow()
        {

            _oldRowDepos = Owner.pollsDataSet.POLL_DEPOS.FindByDATE_POLL_DEPOSNUMBER_POLL_DEPOSREF_OTD(_oldRowDepos.DATE_POLL_DEPOS,
                                                                                        _oldRowDepos.NUMBER_POLL_DEPOS,
                                                                                        _oldRowDepos.REF_OTD);
            _oldRowDepos.SEX = sexСomboBox.SelectedValue.ToString();
            _oldRowDepos.AGE = ageUpDown.Value;
            _oldRowDepos.REF_RKC = (decimal)rkcComboBox.SelectedValue;
            _oldRowDepos.REF_OBL = (decimal)filialСomboBox.SelectedValue;
            _oldRowDepos.REF_USER = (decimal)_user.Id_user;
            _oldRowDepos.DT_LAST_ACSESS = System.DateTime.Now;
            foreach (QuestControl currentQuestControl in pollsTabControl.TabPages[0].Controls)
            {
                _oldRowDepos["S_" + currentQuestControl.IdQuest.ToUpper()] = (decimal)currentQuestControl.Value;
                _oldRowDepos["I_" + currentQuestControl.IdQuest.ToUpper()] = (decimal)currentQuestControl.Importance;

            }
            foreach (QuestControl currentQuestControl in pollsTabControl.TabPages[1].Controls)
            {
                _oldRowBank["S_" + currentQuestControl.IdQuest.ToUpper()] = (decimal)currentQuestControl.Value;
                _oldRowBank["I_" + currentQuestControl.IdQuest.ToUpper()] = (decimal)currentQuestControl.Importance;

            }

    
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
                acceptChangesButton.Enabled = false;
            }
            else
            {
                _numberErr.SetError(this.numberTextBox, "");
                acceptChangesButton.Enabled = true;

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
            //pollsDataSet = Owner.pollsDataSet;
            

            //Устанавливаем начальные значения возраста и номера анкеты.
            ageUpDown.Value = ageUpDown.Minimum;
            numberTextBox.Text = "";
            acceptChangesButton.Enabled = false;


            //Заполняем таблице Sex

            pollsDataSet.Sex.Clear();
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
            pollsTabControl.TabPages[1].Controls.Clear();

            //_collectionCriterion = new Collection<Criterion>();
            fillTabDepos(0);
            fillTabBank(1);

        }
        private void SetDefault()
        {
            filialСomboBox.SelectedValue = _oldRowDepos.REF_OBL;
            updateOtdComboBox();
            filialСomboBox.Enabled = false;
            otdComboBox.SelectedValue = _oldRowDepos.REF_OTD;
            updateRkcComboBox();
            otdComboBox.Enabled = false;
            rkcComboBox.SelectedValue = _oldRowDepos.REF_RKC;
            
            sexСomboBox.SelectedValue = _oldRowDepos.SEX;
            ageUpDown.Value = _oldRowDepos.AGE;
            numberTextBox.Text = _oldRowDepos.NUMBER_POLL_DEPOS.ToString();
            numberTextBox.Enabled = false;

            foreach (QuestControl currentQuestControl in pollsTabControl.TabPages[0].Controls)
            {
                currentQuestControl.Value = _oldRowDepos["S_" + currentQuestControl.IdQuest.ToUpper()].ToString();
                currentQuestControl.Importance = _oldRowDepos["I_" + currentQuestControl.IdQuest.ToUpper()].ToString();

            }



        }
        private void fillTabDepos(Int32 indexTab)
        {
            pollsTabControl.TabPages[indexTab].Controls.Add(new QuestControl()
            {
                Location = new Point(7, 15),
                IdQuest = "depos_period",
                NameQuset = "Срок размещения денежных средств",
                Value = 1,
                Importance = 1
            });

            pollsTabControl.TabPages[indexTab].Controls.Add(new QuestControl()
            {
                Location = new Point(7, 55),
                IdQuest = "interest_rate",
                NameQuset = "Процентная ставка по вкладу",
                Value = 1,
                Importance = 1
            });

            pollsTabControl.TabPages[indexTab].Controls.Add(new QuestControl()
            {
                Location = new Point(7, 95),
                IdQuest = "select_curr",
                NameQuset = "Выбор валюты вклада",
                Value = 1,
                Importance = 1
            });

            pollsTabControl.TabPages[indexTab].Controls.Add(new QuestControl()
            {
                Location = new Point(7, 135),
                IdQuest = "registr_speed",
                NameQuset = "Скорость оформления перевода",
                Value = 1,
                Importance = 1
            });

            pollsTabControl.TabPages[indexTab].Controls.Add(new QuestControl()
            {
                Location = new Point(7, 175),
                IdQuest = "cont_intelli",
                NameQuset = "Понятность условий",
                Value = 1,
                Importance = 1
            });

            pollsTabControl.TabPages[indexTab].Controls.Add(new QuestControl()
            {
                Location = new Point(7, 215),
                IdQuest = "depos_choice",
                NameQuset = "Возможность выбора варианта вклада",
                Value = 1,
                Importance = 1
            });

            pollsTabControl.TabPages[indexTab].Controls.Add(new QuestControl()
            {
                Location = new Point(7, 255),
                IdQuest = "add_service",
                NameQuset = "Наличие дополнительных услуг и предложений",
                Value = 1,
                Importance = 1
            });

        }
        private void fillTabBank(Int32 indexTab)
        {
            pollsTabControl.TabPages[indexTab].Controls.Add(new QuestControl()
            {
                Location = new Point(7, 15),
                IdQuest = "speed_service",
                NameQuset = "Скорость обслуживания",
                Value = 1,
                Importance = 1
            });

            pollsTabControl.TabPages[indexTab].Controls.Add(new QuestControl()
            {
                Location = new Point(7, 55),
                IdQuest = "office_location",
                NameQuset = "Удобство расположения офисов",
                Value = 1,
                Importance = 1
            });

            pollsTabControl.TabPages[indexTab].Controls.Add(new QuestControl()
            {
                Location = new Point(7, 95),
                IdQuest = "bank_reliabitily",
                NameQuset = "Надежность банка",
                Value = 1,
                Importance = 1
            });

            pollsTabControl.TabPages[indexTab].Controls.Add(new QuestControl()
            {
                Location = new Point(7, 135),
                IdQuest = "mode",
                NameQuset = "Режим работы",
                Value = 1,
                Importance = 1
            });

            pollsTabControl.TabPages[indexTab].Controls.Add(new QuestControl()
            {
                Location = new Point(7, 175),
                IdQuest = "staff_competence",
                NameQuset = "Профессионализм и компетентность сотрудников",
                Value = 1,
                Importance = 1
            });

            pollsTabControl.TabPages[indexTab].Controls.Add(new QuestControl()
            {
                Location = new Point(7, 215),
                IdQuest = "services_choice",
                NameQuset = "Широкий выбор услуг",
                Value = 1,
                Importance = 1
            });

            pollsTabControl.TabPages[indexTab].Controls.Add(new QuestControl()
            {
                Location = new Point(7, 255),
                IdQuest = "service_culture",
                NameQuset = "Культура обслуживания",
                Value = 1,
                Importance = 1
            });

            pollsTabControl.TabPages[indexTab].Controls.Add(new QuestControl()
            {
                Location = new Point(7, 295),
                IdQuest = "bank_image",
                NameQuset = "Имидж банка (репутация; известность)",
                Value = 1,
                Importance = 1
            });

            pollsTabControl.TabPages[indexTab].Controls.Add(new QuestControl()
            {
                Location = new Point(7, 335),
                IdQuest = "service_terms",
                NameQuset = "Стоимость и условия предоставления услуг",
                Value = 1,
                Importance = 1
            });

            pollsTabControl.TabPages[indexTab].Controls.Add(new QuestControl()
            {
                Location = new Point(7, 375),
                IdQuest = "add_service",
                NameQuset = "Наличие дополнительных услуг и предложений",
                Value = 1,
                Importance = 1
            });

        }


    }
}
