using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.IOUtils.FileUtils;
using Azylee.Jsons;
using BigBirdConsole.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BigBirdConsole.Views.UpdateViews
{
    public partial class UpdateForm : Form
    {
        public UpdateForm()
        {
            InitializeComponent();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            R.AppointFile = textBox1.Text;
            string filename = Path.GetFileName(R.AppointFile);
            string filemd5 = FileTool.GetMD5(R.AppointFile);
            if (Ls.Ok(R.Tx.Hosts))
            {
                foreach (var item in R.Tx.Hosts)
                {
                    R.Tx.TcppServer.Write(item, 90001000, Json.Object2Byte(new Tuple<string, string>(filename, filemd5)));
                }
            }
        }
    }
}
