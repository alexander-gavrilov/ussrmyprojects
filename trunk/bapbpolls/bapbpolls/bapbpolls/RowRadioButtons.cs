using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace bapbpolls
{

    class RowRadioButtons:UserControl
    {
        //public String Name;
        public String Text;

        //public RadioButton Mark1;
        //public RadioButton Mark2;
        //public RadioButton Mark3;
        //public RadioButton Mark4;
        //public RadioButton Mark5;
        public List<RadioButton> Mark;
        public List<String> Texts;
        public RowRadioButtons(int capacity)
    {
        //Name = new String();
        //Mark1 = new RadioButton(){TextAlign = System.Drawing.ContentAlignment.BottomCenter,CheckAlign = System.Drawing.ContentAlignment.TopCenter,Text = };
        //Mark2 = new RadioButton();
        //Mark3 = new RadioButton();
        //Mark4 = new RadioButton();
        //Mark5 = new RadioButton();
        //Mark = new List<RadioButton>() { new RadioButton() { TextAlign = System.Drawing.ContentAlignment.BottomCenter, CheckAlign = System.Drawing.ContentAlignment.TopCenter } };
        //Mark = new List<RadioButton>() { new RadioButton() { TextAlign = System.Drawing.ContentAlignment.BottomCenter, CheckAlign = System.Drawing.ContentAlignment.TopCenter } };
        //Mark = new List<RadioButton>() { new RadioButton() { TextAlign = System.Drawing.ContentAlignment.BottomCenter, CheckAlign = System.Drawing.ContentAlignment.TopCenter } };
        //Mark = new List<RadioButton>() { new RadioButton() { TextAlign = System.Drawing.ContentAlignment.BottomCenter, CheckAlign = System.Drawing.ContentAlignment.TopCenter } };
        //Mark = new List<RadioButton>() { new RadioButton() { TextAlign = System.Drawing.ContentAlignment.BottomCenter, CheckAlign = System.Drawing.ContentAlignment.TopCenter } };

        Mark = new List<RadioButton>();
        for (int i = 0; i < capacity; i++)
        {
            Mark.Add(new RadioButton() { TextAlign = System.Drawing.ContentAlignment.MiddleCenter, CheckAlign = System.Drawing.ContentAlignment.MiddleCenter, AutoSize = true, Dock = DockStyle.Fill, Name = "Mark" + (capacity - i) });
            //Texts.Add("");
        }


    }
        public int GetResault()
        {
            for (int i = 0; i < Mark.Capacity; i++)
            {
                if (Mark[i].Checked)
                {
                    return Mark.Capacity-i;
                }
            }
            return 0;
        }
    }
}
