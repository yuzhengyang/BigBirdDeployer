using Azylee.Core.DataUtils.DateTimeUtils;
using Azylee.Core.ThreadUtils.SleepUtils;
using Azylee.Jsons;
using Azylee.YeahWeb.SocketUtils.TcpUtils;
using BigBirdConsole.Commons;
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
        private bool IsWrite = false;
        private short WriteInterval = 1000;
        private int MaxLength = 10 * 1024 * 1024;
        private ConcurrentQueue<string> Lines = new ConcurrentQueue<string>();
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            TxHelper.Start();
        }
        private void TmMain_Tick(object sender, EventArgs e)
        {
            TsslConnectCount.Text = $"已连接 : {R.Tx.Hosts.Count} 台主机";
        }

        #region Task 进程
        private void WriteTask()
        {
            if (!IsWrite)
            {
                Task.Factory.StartNew(() =>
                {
                    IsWrite = true;
                    while (!IsDisposed)
                    { 
                        if (Lines.Any() && Lines.Count > 0)
                        {
                            try
                            {
                                StringBuilder sb = new StringBuilder();
                                for (int i = 0; i < Lines.Count; i++)
                                {
                                    if (Lines.TryDequeue(out string s))
                                    {  
                                        sb.Append(s);
                                        sb.Append(Environment.NewLine);

                                    }
                                }
                                if (sb.Length > 0) UITxLog(sb.ToString());
                            }
                            catch { }
                        }
                        Sleep.S(WriteInterval);
                    }
                });
            }
        }
        #endregion

        #region UI 处理
        public void UIConnectCount(int count)
        {
        }

        /// <summary>
        /// 添加文本内容
        /// </summary>
        /// <param name="s"></param>
        public void UITxLog(string ip, int type, string data)
        {
            try
            {
                string s = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} {ip} : {type} : {data}";
                Invoke(new Action(() =>
                {
                    //截断文本内容
                    if (RtbTxLog.TextLength > MaxLength)
                        RtbTxLog.Text = RtbTxLog.Text.Substring(RtbTxLog.TextLength / 2);

                    RtbTxLog.AppendText(s);//追加内容到文本框
                    RtbTxLog.AppendText(Environment.NewLine);//追加内容到文本框
                    RtbTxLog.ScrollToCaret();//滚动到底部
                }));
            }
            catch { }
        }
        public void UITxLog(string s)
        {
            try
            {
                Invoke(new Action(() =>
                {
                    //截断文本内容
                    if (RtbTxLog.TextLength > MaxLength)
                        RtbTxLog.Text = RtbTxLog.Text.Substring(RtbTxLog.TextLength / 2);

                    RtbTxLog.AppendText(s);//追加内容到文本框
                    RtbTxLog.AppendText(Environment.NewLine);//追加内容到文本框
                    RtbTxLog.ScrollToCaret();//滚动到底部
                }));
            }
            catch { }
        }
        #endregion 
    }
}
