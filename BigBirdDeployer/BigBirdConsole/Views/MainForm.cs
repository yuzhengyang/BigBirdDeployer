using BigBirdConsole.Commons;
using BigBirdConsole.Views.UpdateViews;
using System;
using System.Windows.Forms;

namespace BigBirdConsole.Views
{
    public partial class MainForm : Form
    {
        #region 窗体事件处理
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            switch (e.CloseReason)
            {
                case CloseReason.None:
                    e.Cancel = true;//阻止关闭
                    R.Log.i("AccessSecurity::关闭事件：阻止：闭包的原因未定义，或者无法确定。");
                    break;
                case CloseReason.WindowsShutDown:
                    R.Log.i("AccessSecurity::关闭事件：允许：操作系统正在关机之前关闭所有应用程序。");
                    break;
                case CloseReason.MdiFormClosing:
                    e.Cancel = true;//阻止关闭
                    R.Log.i("AccessSecurity::关闭事件:阻止：正在关闭此多文档界面 (MDI) 窗体的父窗体。");
                    break;
                case CloseReason.UserClosing:
                    e.Cancel = true;//阻止关闭
                    R.Log.i("AccessSecurity::关闭事件:阻止：用户是通过关闭窗体用户界面 (UI)，例如通过单击 关闭 窗体的窗口上的按钮选择 关闭 从窗口的控制菜单，或按 ALT + F4。");
                    break;
                case CloseReason.TaskManagerClosing:
                    e.Cancel = true;//阻止关闭
                    R.Log.i("AccessSecurity::关闭事件:阻止：Microsoft Windows 任务管理器正在关闭该应用程序。");
                    break;
                case CloseReason.FormOwnerClosing:
                    e.Cancel = true;//阻止关闭
                    R.Log.i("AccessSecurity::关闭事件:阻止：所有者窗体正在关闭。");
                    break;
                case CloseReason.ApplicationExitCall:
                    R.Log.i("AccessSecurity::关闭事件:允许：System.Windows.Forms.Application.Exit 方法 System.Windows.Forms.Application 类调用。");
                    break;
            }
        }
        #endregion

        #region 菜单事件处理
        private void 显示主界面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            Activate();
        }
        private void 退出程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormClosing -= MainForm_FormClosing;
                Application.Exit();
            }
            catch { }
        }
        private void 分发更新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new UpdateForm().ShowDialog();
        }
        #endregion

        #region 控件事件处理
        private void TmMain_Tick(object sender, EventArgs e)
        {
            TsslConnectCount.Text = $"已连接 : {R.Tx.Hosts.Count} 台主机";
            TsslWebCenterConnect.Text = R.TxConvert.IsConnect ? "已连接服务器" : "未连接服务器";
        }
        private void NiMain_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    WindowState = FormWindowState.Normal;
                    Show();
                    Activate();
                }
            }
            catch { }
        } 
        #endregion

        #region UI 处理
        public void UIConnectCount(int count)
        {
        }
        #endregion

    }
}
