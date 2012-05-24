using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Checker
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           // CheckerProfile.checkerTray.Icon = ;
            
            if (CheckerProfile.RunOnStart)
            {
                CheckerProfile.StartTreat();
            }
            Application.Run();
        }
    }
}
