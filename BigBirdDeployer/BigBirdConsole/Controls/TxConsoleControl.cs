using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BigBirdConsole.Controls
{
    public partial class TxConsoleControl : UserControl
    {
        private bool IsWrite = false;
        private short WriteInterval = 1000;
        private int MaxLength = 1 * 200 * 1024;

        public TxConsoleControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 添加文本内容
        /// </summary>
        /// <param name="s"></param>
        public void Write(string ip, int type, string data)
        {
            try
            {
                string s = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} {ip} : {type} : {data}";
                Invoke(new Action(() =>
                {
                    //截断文本内容
                    if (RtbTxLog.TextLength > MaxLength)
                        RtbTxLog.Text = RtbTxLog.Text.Substring(RtbTxLog.TextLength / 2);

                    RtbTxLog.AppendText(s + Environment.NewLine);//追加内容到文本框
                    RtbTxLog.ScrollToCaret();//滚动到底部

                    LBTextLength.Text = $"{RtbTxLog.TextLength} / {MaxLength}";
                }));
            }
            catch { }
        }
    }
}
