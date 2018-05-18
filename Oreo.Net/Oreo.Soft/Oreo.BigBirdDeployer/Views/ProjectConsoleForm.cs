using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.DataUtils.StringUtils;
using Azylee.Core.DataUtils.UnitConvertUtils;
using Oreo.BigBirdDeployer.Commons;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Oreo.BigBirdDeployer.Views
{
    public partial class ProjectConsoleForm : Form
    {
        private int ConsoleLength = 0;
        private string Caption = "";
        private int WriteInterval = 2500;
        private ConcurrentQueue<string> Lines = new ConcurrentQueue<string>();
        public ProjectConsoleForm()
        {
            InitializeComponent();
            TMConsoleWrite.Interval = WriteInterval;
        }

        private void BTClean_Click(object sender, EventArgs e)
        {
            RTBConsole.Text = "";
        }
        public void AddToQueue(string s)
        {
            Lines.Enqueue(s);
        }
        private void TMConsoleWrite_Tick(object sender, EventArgs e)
        {
            if (Lines.Any() && Lines.Count > 0)
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
                UIConsole(sb.ToString());
            }
        }

        #region UI操作
        /// <summary>
        /// 修改窗口标题
        /// </summary>
        /// <param name="s"></param>
        public void UICaption(string s)
        {
            try
            {
                Invoke(new Action(() =>
                {
                    Caption = s;
                    Text = $"{Caption} 的输出窗口    [ {ByteConvertTool.Fmt(ConsoleLength)} ]";
                }));
            }
            catch { }
        }
        /// <summary>
        /// 添加文本内容
        /// </summary>
        /// <param name="s"></param>
        private void UIConsole(string s)
        {
            try
            {
                Invoke(new Action(() =>
                {
                    ConsoleLength += s.Length;//更新文本长度
                    UICaption(Caption);//更新标题，带文本长度提示 
                    RTBConsole.AppendText(s);//追加内容到文本框 
                    UIConsoleHighlight(s.Length);//高亮关键字
                    RTBConsole.ScrollToCaret();//滚动到底部
                }));
            }
            catch { }
        }
        /// <summary>
        /// 高亮文本内容
        /// </summary>
        /// <param name="length"></param>
        private void UIConsoleHighlight(int length)
        {
            try
            {
                Invoke(new Action(() =>
                {
                    //高亮关键字
                    string[] keywords = R.HighlightKeywords;
                    if (ListTool.HasElements(keywords))
                    {
                        foreach (var key in keywords)
                        {
                            if (!StringTool.Ok(key)) continue;//不正常关键字跳出

                            int start = ConsoleLength - length;
                            while ((start = RTBConsole.Text.IndexOf(key, start)) >= 0)
                            {
                                RTBConsole.Select(start, key.Length);
                                RTBConsole.SelectionBackColor = Color.Yellow;
                                start++;
                            }
                        }
                    }
                }));
            }
            catch { }
        }
        #endregion
    }
}
