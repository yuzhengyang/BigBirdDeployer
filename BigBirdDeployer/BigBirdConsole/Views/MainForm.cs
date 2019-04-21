using Azylee.Core.DataUtils.DateTimeUtils;
using Azylee.Core.ThreadUtils.SleepUtils;
using Azylee.Jsons;
using Azylee.YeahWeb.SocketUtils.TcpUtils;
using BigBirdConsole.Commons;
using BigBirdConsole.Modules.PlanTaskModule;
using BigBirdConsole.Modules.TxConvertModule;
using BigBirdConsole.Modules.TxModule;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigBirdConsole.Views
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
        private void TmMain_Tick(object sender, EventArgs e)
        {
            TsslConnectCount.Text = $"已连接 : {R.Tx.Hosts.Count} 台主机";
            TsslWebCenterConnect.Text = R.TxConvert.IsConnect ? "已连接服务器" : "未连接服务器";
        }

        #region UI 处理
        public void UIConnectCount(int count)
        {
        }
        #endregion 
    }
}
