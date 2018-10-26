using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Oreo.BigBirdDeployer.Views.HelpViews
{
    public partial class UpdateLogForm : Form
    {
        public UpdateLogForm()
        {
            InitializeComponent();
        }

        private void UpdateLogForm_Load(object sender, EventArgs e)
        {
            TopMost = true;
        }

        private void BTConfirm_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpdateLogForm_Deactivate(object sender, EventArgs e)
        {
            Close();
        }
    }
}
