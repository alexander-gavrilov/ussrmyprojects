using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Components
{
    public partial class UserControlsCollectionForm : UserControl,ICollection<UserControl>
    {
        private Collection<UserControl> _userControlsCollection;
        //private int _count;
        private bool _isReadOnly=false;
        //public virtual IEnumerator GetEnumerator()
        //{
            
        //}
        public UserControlsCollectionForm()
        {
            //_userControlsCollection = this.;
            _userControlsCollection=new Collection<UserControl>();
            InitializeComponent();
        }
        public void Add(UserControl userControl)
        {
            _userControlsCollection.Add(userControl);
            Controls.Add(userControl);
        }
        public void Clear()
        {
            _userControlsCollection.Clear();
        }
        public bool Contains(UserControl userControl)
        {
            return _userControlsCollection.Contains(userControl);
        }
        public void CopyTo(UserControl[] userControls,int i)
        {
            _userControlsCollection.CopyTo(userControls,i);
        }
        public int Count
        {
            get { return _userControlsCollection.Count; }
        }
        public bool IsReadOnly
        {
            get { return _isReadOnly; }
        }
        public bool Remove(UserControl userControl)
        {
            return _userControlsCollection.Remove(userControl);
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return _userControlsCollection.GetEnumerator();
        }
        public  IEnumerator<UserControl> GetEnumerator()
        {
            return _userControlsCollection.GetEnumerator();
        }
        public void Refresh()
        {
            InitializeComponent();
        }

    }
}
