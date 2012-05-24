using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using AMS.Profile;
using Checker.Properties;

namespace Checker
{
    
    public partial class Form1 : Form
    {
        //private Ini ini=new Ini(Application.StartupPath+"\\checker.ini");
        //private Ini ini = new Ini(Application.StartupPath + "\\checker.ini");
        //private Ini Xml=new Ini("checker.ini");
        private Profile ini = new Ini(Application.StartupPath + "\\checker.ini");
        
        private int ReloadTime=0;
        //private DataTable DirsTable;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void globalLoad()
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //MessageBox.Show(CheckerProfile.chekerDS.DirsDT.TableName);
            dirsDTBindingSource.DataSource = CheckerProfile.chekerDS;
            CheckerProfile.ChangeState += TimerEvent;
            if (CheckerProfile.MinimazeOnStart)
            {
                Hide();
            }
            if (CheckerProfile.RunOnStart)
            {
                button1_Click_1(this,new EventArgs());
            }
            //Settings.Default.SettingsKey = "form";
            ////Settings.Default["form"] = this;
            //ini.SetValue("Main","ReloadTime",10);
            //foreach (string sectionName in ini.GetSectionNames())
            //{
            //    FileSystemWatcher watcher = new FileSystemWatcher();
            //}
            //CheckerProfile.chekerDS;
            ////Profile.SetValue("Main","Test",this);
        }
        private class Dir
        {

            private String sectionName;
            private FileSystemWatcher Watcher1;
            private String filter;
            private String dirPath;
            
            public Dir(String SectionName,String Path,String Filter)
            {
                
            }

            public string SectionName
            {
                get { return sectionName; }
                set { sectionName = value; }
            }

            public FileSystemWatcher Watcher
            {
                get { return Watcher1; }
                set { Watcher1 = value; }
            }

            public string Filter
            {
                get { return filter; }
                set { filter = value; }
            }

            public string DirPath
            {
                get { return dirPath; }
                set { dirPath = value; }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            CheckerProfile.StartTreat();
            
        }
        private void button1_Click_2(object sender, EventArgs e)
        {
            CheckerProfile.StopTreat();

        }

        private void MainWindowMenuItem_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
               
                //this.Visible = true;
                Show();
                WindowState = FormWindowState.Normal;
            }
            // Activate the form.
            //this.Activate();
           
           
        }
        private void TimerEvent(Object myObject,
                                        CheckerProfileEventArgs e)
        {
            if (!this.IsDisposed)
            {
                if (e.IsChecerRunning)
                {
                    trayContextMenu.Items["StartMenuItem"].Enabled = false;
                    trayContextMenu.Items["StopMenuItem"].Enabled = true;
                    runButton.Click -= button1_Click_1;
                    runButton.Click += button1_Click_2;
                    runButton.Text = "Стоп";
                    runButton.BackColor = Color.Red;
                    checkerTray.BalloonTipText = "Наблюдатель активен";
                    checkerTray.Text = "Наблюдатель активен";
                    checkerTray.ShowBalloonTip(10);
                }
                else
                {
                    trayContextMenu.Items["StartMenuItem"].Enabled = true;
                    trayContextMenu.Items["StopMenuItem"].Enabled = false;
                    runButton.Click -= button1_Click_2;
                    runButton.Click += button1_Click_1;
                    runButton.Text = "Старт";
                    runButton.BackColor = Color.LightGreen;
                    checkerTray.BalloonTipText = "Наблюдатель не активен";
                    checkerTray.Text = "Наблюдатель не активен";
                    checkerTray.ShowBalloonTip(10);
                } 
            }
        }
        
        private void StartMenuItem_Click(object sender, EventArgs e)
        {
            CheckerProfile.StartTreat();
        }

        private void StopMenuItem_Click(object sender, EventArgs e)
        {
            CheckerProfile.StopTreat();
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            CheckerProfile.StopTreat();
            Application.Exit();
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                checkerTray.Visible = true;
                
                this.Visible=false;
                
            }
            
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {

                Hide();
                //this.Visible = false;

            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //private void button1_Click_3(object sender, EventArgs e)
        //{
        //    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
        //        textBox1.Text = folderBrowserDialog1.SelectedPath;
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    if (openFileDialog1.ShowDialog() == DialogResult.OK)
        //        textBox2.Text = openFileDialog1.FileName;
        //}


    }
}
