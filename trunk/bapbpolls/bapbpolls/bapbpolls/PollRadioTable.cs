using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace bapbpolls
{
    public partial class PollRadioTable : UserControl
    {
        public PollRadioTable(int capacility)
        {
            for (int i = 0; i < capacility; i++)
            {
                this.tableLayoutPanel.RowStyles[i + 1] = this.tableLayoutPanel.RowStyles[0];
            }
            InitializeComponent();
        }
        public PollRadioTable()
        {
            InitializeComponent();
        }
        public void AddRow(string rowName)
        {
            tableLayoutPanel.Controls.Add(new Panel
                                              {
                                                  Dock = DockStyle.Fill,
                                                  Controls =
                                                      {
                                                          new TableLayoutPanel
                                                              {
                                                                  Name = rowName,
                                                                  RowCount = 1,
                                                                  ColumnCount = 5,
                                                                  Dock = DockStyle.Fill,
                                                                  AutoSize = true
                                                              }
                                                      }
                                              });
        }

    }
}
