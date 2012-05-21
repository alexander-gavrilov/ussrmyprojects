using System;
using System.Collections.Generic;
using System.Text;

namespace Checker
{
    public class CheckerProfileEventArgs : EventArgs
    {
        public CheckerProfileEventArgs(bool runing)
        {
            isChecerRunning = runing;
        }
        private bool isChecerRunning;


        public bool IsChecerRunning
        {
            get { return isChecerRunning; }
            set { isChecerRunning = value; }
        }
    }
}
