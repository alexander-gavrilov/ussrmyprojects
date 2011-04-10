using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;

namespace Helpers
{
    public class MyDataGridView : DataGridView, IPersistComponentSettings
    {
        private bool _save = true;
        private MySettings _settings;

        public MyDataGridView()
        {
            _settings = new MySettings(Name);
        }

        #region IPersistComponentSettings Members
        public void LoadComponentSettings()
        {
            _settings.Reload();

            foreach (MyColumnInfo colInfo in _settings.ColumnInfo)
            {
                DataGridViewColumn col = Columns[colInfo.Name];
                if (col != null)
                {
                    col.Width = colInfo.Width;
                    //col.DisplayIndex = colInfo.DisplayIndex;
                }
            }
        }

        public void ResetComponentSettings()
        {
            _settings.Reset();
        }

        public void SaveComponentSettings()
        {
            _settings.ColumnInfo.Clear();

            foreach (DataGridViewColumn col in this.Columns)
            {
                MyColumnInfo colInfo = new MyColumnInfo();
                colInfo.Name = col.Name;
                colInfo.Width = col.Width;
                //colInfo.DisplayIndex = col.DisplayIndex;
                _settings.ColumnInfo.Add(colInfo);
            }
            _settings.Save();
        }
        public bool SaveSettings
        {
            get { return _save; }
            set { _save = value; }
        }
        public string SettingsKey
        {
            get { return Name; }
            set { _settings.SettingsKey = value; }
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing && SaveSettings)
            {
                SaveComponentSettings();
            }
            base.Dispose(disposing);
        }

        protected override void OnRowPrePaint(DataGridViewRowPrePaintEventArgs e)
        {
            Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.WhiteSmoke;

            base.OnRowPrePaint(e);
        }

        public class MyColumnInfo
        {
            public MyColumnInfo() { }
            public String Name;         // имя столбца
            public Int32 Width;         // ширина столбца
           // public Int32 DisplayIndex;  // порядок расположения
        }

        //Создаем свой класс свойств 
        class MySettings : ApplicationSettingsBase
        {
            public MySettings(string settingsKey) : base(settingsKey) { }

            [UserScopedSetting()]
            [DefaultSettingValueAttribute("")]
            public List<MyColumnInfo> ColumnInfo
            {
                get { return (List<MyColumnInfo>)this["ColumnInfo"]; }
                set { this["ColumnInfo"] = value; }
            }
        }
    }
}