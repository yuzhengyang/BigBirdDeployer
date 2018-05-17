using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.DataUtils.StringUtils;
using Azylee.Core.DataUtils.UnitConvertUtils;
using Oreo.BigBirdDeployer.Commons;
using System;
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
        public ProjectConsoleForm()
        {
            InitializeComponent();
        }

        private void BTClean_Click(object sender, EventArgs e)
        {
            RTBConsole.Text = "";
        }
        public void UICaption(string s)
        {
            try
            {
                Invoke(new Action(() =>
                {
                    Caption = s;
                    Text = $"{Caption} 的输出窗口    [ length : {ByteConvertTool.Fmt(ConsoleLength)} ]";
                }));
            }
            catch { }
        }
        public void UIConsole(string s)
        {
            try
            {
                Invoke(new Action(() =>
                {
                    ConsoleLength += s.Length;//更新文本长度
                    UICaption(Caption);//更新标题，带文本长度提示

                    RTBConsole.AppendText(s);//追加内容到文本框
                    RTBConsole.AppendText(Environment.NewLine);//追加内容到文本框（换行）

                    //高亮关键字
                    string[] keywords = R.HighlightKeywords;
                    if (ListTool.HasElements(keywords))
                    {
                        foreach (var key in keywords)
                        {
                            if (!StringTool.Ok(key)) continue;//不正常关键字跳出

                            int start = ConsoleLength - s.Length;
                            while ((start = RTBConsole.Text.IndexOf(key, start)) >= 0)
                            {
                                RTBConsole.Select(start, key.Length);
                                RTBConsole.SelectionBackColor = Color.Yellow;
                                start++;
                            }
                        }
                    }

                    RTBConsole.ScrollToCaret();
                }));
            }
            catch { }
        }
    }
}
