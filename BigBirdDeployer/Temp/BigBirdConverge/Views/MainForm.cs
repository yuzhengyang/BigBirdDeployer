using BigBirdConverge.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BigBirdConverge.Views
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        public void UIConnect()
        {
            try
            {
                Invoke(new Action(() =>
                {
                    label2.Text = $"{R.Tx.Hosts.Count}";
                }));
            }
            catch { }
        }
        public void UIDisconnect()
        {
            try
            {
                Invoke(new Action(() =>
                {
                    label2.Text = $"{R.Tx.Hosts.Count}";
                }));
            }
            catch { }
        }
    }
}
