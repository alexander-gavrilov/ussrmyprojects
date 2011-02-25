using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Poll
{
    public partial class QuestControl : UserControl
    {
        //private string _nameQuest;
        //private string _textQuest;
        //private int _satisfaction;
        //private int _importance;
        private Criterion _criter;
        public QuestControl(Criterion criterion)
        {
            //
            _criter = new Criterion();
            InitializeComponent();
            NameQuset = criterion.Name;
            IdQuest = criterion.Id;
            Value = criterion.Value;
            Importance = criterion.Importance;
            //_criter = criterion;

        }
        public QuestControl()
        {
            //
            _criter = new Criterion();
            InitializeComponent();
 

        }

        public string IdQuest { get { return _criter.Id; } set { _criter.Id = value; } }
        public string NameQuset
        {
            get
            {
                _criter.Name = questLabel.Text;
                return _criter.Name;
            }
            set
            {
                _criter.Name = value;
                questLabel.Text = _criter.Name;
            }
        }
        public int Value
        {
            get
            {
                _criter.Value = (int) satisfactionUpDown.Value;
                return _criter.Value;
            }
            set
            {
                _criter.Value = value;
                satisfactionUpDown.Value = (decimal) _criter.Value;
            }
        }
        public int Importance
        {
            get
            {
                _criter.Importance = (int)importanceUpDown.Value;
                return _criter.Importance;
            }
            set
            {
                _criter.Importance = value;
                importanceUpDown.Value = (decimal) _criter.Importance;
            }
        }

        public Criterion Criter ()
        {
            return _criter;
        }
       
    }
}
