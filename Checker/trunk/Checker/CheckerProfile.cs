using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using AMS.Profile;

namespace Checker
{
    public static class CheckerProfile
    {
        
        public static ChekerDS chekerDS=new ChekerDS();
        private static Profile ini = new Ini(Application.StartupPath + "\\checker.ini");
        private static Byte updateInterval=10;
        public static bool RunOnStart = false;
        public static bool MinimazeOnStart = false;
        private static DateTime NextUpdateTime = DateTime.Now;
        public static System.Windows.Forms.Timer UpdateTimer = new System.Windows.Forms.Timer();
        private static Dictionary<String, FileSystemWatcher> Watchers = new Dictionary<string, FileSystemWatcher>();
        private static Dictionary<String,List<FileSystemInfo>> FileSystemInfoses = new Dictionary<string, List<FileSystemInfo>>();
        private static Dictionary<String,List<String>> FilesHashesDic = new Dictionary<string, List<string>>();
        public static event EventHandler<CheckerProfileEventArgs> ChangeState;
        private static Form1 _form1=new Form1();
        static CheckerProfile()
        {
            
            chekerDS.DirsDT.Clear();
            UpdateInterval = (Byte) ini.GetValue("Main", "UpdateInterval", 60);
            RunOnStart = ini.GetValue("Main", "RunOnStart", false);
            MinimazeOnStart = ini.GetValue("Main", "MinimazeOnStart", false);
            foreach (string sectionName in ini.GetSectionNames())
            {
                if (sectionName.StartsWith("Catalog",StringComparison.CurrentCultureIgnoreCase))
                {
                    chekerDS.DirsDT.AddDirsDTRow(ini.GetValue(sectionName, "path", ""),
                                                 ini.GetValue(sectionName, "execute", ""),
                                                 ini.GetValue(sectionName, "process", ""),
                                                 ini.GetValue(sectionName, "comment", ""), sectionName, false,
                                                 ini.GetValue(sectionName, "mask", "*.*"),
                                                 ini.GetValue(sectionName, "runprocess", false),false);
                    FilesHashesDic.Add(sectionName,new List<string>());
                }

            }
        }
        public static void Init()
        {
            
           Application.Run(_form1);
           
           if (CheckerProfile.RunOnStart)
           {
               CheckerProfile.StartTreat();
           }
          

        }

        public static byte UpdateInterval
        {
            get { return updateInterval; }
            set { updateInterval = value; }
        }
        private static void TimerEventProcessor(Object myObject,
                                        EventArgs myEventArgs)
        {
            UpdateTimer.Stop();
            UpdateTimer.Interval = UpdateInterval * 1000;
            Treat();
            UpdateTimer.Enabled = true;

        }
        private static bool IsProcessRuning(String processName)
        {
            
            return Process.GetProcessesByName(processName).Length > 0;
            //foreach (Process process in processes)
            //{

            //    try
            //    {

            //        if (process.MainModule.ModuleName == processName)
            //            return true;
            //    }
            //    catch (System.ComponentModel.Win32Exception win32Exception)
            //    {
                    
            //    }
            //})
            
        }
        private static void Treat()
        {
            foreach (ChekerDS.DirsDTRow row in chekerDS.DirsDT.Rows)
            {
                //Watchers.Add(row.section,new FileSystemWatcher(row.path,row.mask));
                DirectoryInfo currentDir = new DirectoryInfo(row.path);
                if (row.avalible = currentDir.Exists)
                {

                    //FileSystemInfoses[row.section].Contains()
                    List<FileSystemInfo> fileSystemInfos = new List<FileSystemInfo>(currentDir.GetFiles(row.mask));
                    foreach (FileInfo fileSystemInfo in fileSystemInfos)
                    {
                        if (!FilesHashesDic[row.section].Contains(MD5String.getMd5Hash(fileSystemInfo.Name + fileSystemInfo.Attributes + fileSystemInfo.CreationTime +
                                             fileSystemInfo.Length + fileSystemInfo.LastWriteTime)))
                        {
                            row.treatment = true;
                        }
                    }
                    FileSystemInfoses[row.section] = fileSystemInfos;
                    if (row.treatment) FilesHashesDic[row.section] = GetFilesHash(currentDir.GetFiles(row.mask));
                }

            }

            //if (chekerDS.DirsDT.Select(chekerDS.DirsDT.treatmentColumn.ColumnName+"=true").Length>0)
            //{
            //    MessageBox.Show("True");
            //    chekerDS.DirsDT.
            //}
            //Process[] processes = Process.GetProcesses();

            if (chekerDS.DirsDT.Select(chekerDS.DirsDT.treatmentColumn.ColumnName + "=true").Length > 0)
            {
                ReminderForm reminderForm = new ReminderForm();
                if (reminderForm.ShowDialog() == DialogResult.OK)
                {
                    foreach (ChekerDS.DirsDTRow row in chekerDS.DirsDT.Select("avalible=true"))
                    {
                        row.treatment = false;
                        FileInfo fileInfoExec = new FileInfo(row.execute);
                        if (row.runprocess && fileInfoExec.Exists && !IsProcessRuning(row.process))
                        {
                            Process.Start(row.execute);
                        }

                    }
                }
                else
                {
                    UpdateTimer.Interval = Decimal.ToInt32(reminderForm.numericUpDown1.Value)*60*1000;
                }

            }
            //foreach (ChekerDS.DirsDTRow dataRow in chekerDS.DirsDT.Select(chekerDS.DirsDT.treatmentColumn.ColumnName + "=true"))
            //{
            //    dataRow.treatment = false;
            //}
            chekerDS.DirsDT.AcceptChanges();

        }

        public static void StartTreat()
        {
            //foreach (ChekerDS.DirsDTRow row in chekerDS.DirsDT.Rows)
            //{
            //    //Watchers.Add(row.section,new FileSystemWatcher(row.path,row.mask));
            //    DirectoryInfo currentDir=new DirectoryInfo(row.path);
            //    FileSystemInfoses.Add(row.section,new List<FileSystemInfo>(currentDir.GetFileSystemInfos(row.mask)));
            //    FilesHashesDic.Add(row.section, new List<string>());
            //    //foreach (FileInfo fileSystemInfo in currentDir.GetFiles(row.mask))
            //    //{
            //    //    FilesHashesDic[row.section].Add(MD5String.getMd5Hash(fileSystemInfo.Name + fileSystemInfo.Attributes + fileSystemInfo.CreationTime +
            //    //                         fileSystemInfo.Length + fileSystemInfo.LastWriteTime));
            //    //}
            //}

            UpdateTimer.Tick += TimerEventProcessor;

            // Sets the timer interval to 5 seconds.
            UpdateTimer.Interval = UpdateInterval*1000;
            Treat();
            UpdateTimer.Start();
            OnChangeState(new CheckerProfileEventArgs(true));
        }
        public static void StopTreat()
        {
            UpdateTimer.Stop();
            OnChangeState(new CheckerProfileEventArgs(false));
        }
        private static List<String> GetFilesHash(FileInfo[] fileInfos)
        {
            List<String> resultList= new List<string>();
            foreach (FileInfo fileSystemInfo in fileInfos)
                {
                    resultList.Add(MD5String.getMd5Hash(fileSystemInfo.Name + fileSystemInfo.Attributes + fileSystemInfo.CreationTime +
                                         fileSystemInfo.Length + fileSystemInfo.LastWriteTime));
                }
            return resultList;
        }
        public static void OnChangeState(CheckerProfileEventArgs e)
        {
            // Make a temporary copy of the event to avoid possibility of
            // a race condition if the last subscriber unsubscribes
            // immediately after the null check and before the event is raised.
            EventHandler<CheckerProfileEventArgs> handler = ChangeState;

            // Event will be null if there are no subscribers
            if (handler != null)
            {
                // Format the string to send inside the CustomEventArgs parameter
                

                // Use the () operator to raise the event.
                handler(UpdateTimer,e);
            }
        }
        //private static bool Compare
    }
}
