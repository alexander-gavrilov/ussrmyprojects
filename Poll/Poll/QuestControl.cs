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
        private string _nameQuest;
        private string _textQuest;
        private int _satisfaction;
        private int _importance;
        public QuestControl()
        {
            InitializeComponent();
        }

        public string NameQuest { get; set; }
        public string TextQuset
        {
            get
            {
                _textQuest = label1.Text;
                return _textQuest;
            }
            set
            {
                _textQuest = value;
                label1.Text = _textQuest;
            }
        }
        public int Satisfaction
        {
            get
            {
                _satisfaction = (int) satisfactionUpDown.Value;
                return _satisfaction;
            }
            set
            {
                _satisfaction = value;
                satisfactionUpDown.Value = (decimal) _satisfaction;
            }
        }
        public int Importance
        {
            get
            {
                _importance = (int)importanceUpDown.Value;
                return _importance;
            }
            set
            {
                _importance = value;
                importanceUpDown.Value = (decimal)_importance;
            }
        }
       
    }
}
