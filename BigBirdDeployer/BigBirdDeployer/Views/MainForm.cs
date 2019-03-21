using Azylee.Core.AppUtils;
using Azylee.Core.DataUtils.StringUtils;
using Azylee.Core.DataUtils.UnitConvertUtils;
using Azylee.Core.IOUtils.TxtUtils;
using Azylee.Core.WindowsUtils.APIUtils;
using Azylee.Core.WindowsUtils.InfoUtils;
using Azylee.Jsons;
using Azylee.WinformSkin.FormUI.CustomTitle;
using Azylee.WinformSkin.FormUI.Toast;
using BigBird.Models.SystemModels;
using BigBirdDeployer.Commons;
using BigBirdDeployer.Modules.TxModule;
using BigBirdDeployer.Views.HelpViews;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigBirdDeployer.Views
{
    public partial class MainForm : BigIconForm
    {
        private bool RunStatusTask = false;//APP程序运行状态任务是否执行
        private int STATUS_INTERVAL = 2500;//APP程序运行状态监测间隔
        private Process Process = Process.GetCurrentProcess();
        private PerformanceCounter ComputerProcessor = ComputerStatusTool.Processor();//电脑CPU监控
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            BigIconFormLBHeadTitle.Text = $"{R.AppNameCn}  {(R.IsAdministrator ? "(管理员)" : "(受限权限)")}";
            LBVersion.Text = $"版本：{Application.ProductVersion}";
            TBPublishStorage.Text = R.Paths.PublishStorage == R.Paths.DefaultPublishStorage ? "" : R.Paths.PublishStorage;
            TBNewStorage.Text = R.Paths.NewStorage == R.Paths.DefaultNewStorage ? "" : R.Paths.NewStorage;
            TBConsoleIP.Text = R.Tx.IP;
            TBConsolePort.Text = R.Tx.Port == 0 ? "" : $"{R.Tx.Port}";
            TBLocalIP.Text = R.Tx.LocalIP;
            TBLocalName.Text = R.Tx.LocalName;
            TaskOfStatus();
            TxHelper.Connect();
        }

        private void BTSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        #region 方法
        private bool SaveSettings()
        {
            bool flag = false;
            if (StringTool.Ok(TBPublishStorage.Text))
            {
                if (Directory.Exists(TBPublishStorage.Text))
                {
                    R.Paths.PublishStorage = TBPublishStorage.Text;
                    IniTool.Set(R.Files.Settings, "Paths", "PublishStorage", R.Paths.PublishStorage);
                    flag = true;
                }
                else
                {
                    LBDesc.Text = "发布资料库目录不存在";
                }
            }
            else
            {
                R.Paths.PublishStorage = R.Paths.DefaultPublishStorage;
                //IniTool.WriteValue(R.Files.Settings, "Paths", "PublishStorage", R.Paths.PublishStorage);
                flag = true;
            }

            if (StringTool.Ok(TBNewStorage.Text))
            {
                if (Directory.Exists(TBNewStorage.Text))
                {
                    R.Paths.NewStorage = TBNewStorage.Text;
                    IniTool.Set(R.Files.Settings, "Paths", "NewStorage", R.Paths.NewStorage);
                    flag = true;
                }
                else
                {
                    LBDesc.Text = "新增资料库目录不存在";
                }
            }
            else
            {
                R.Paths.NewStorage = R.Paths.DefaultNewStorage;
                //IniTool.WriteValue(R.Files.Settings, "Paths", "NewStorage", R.Paths.NewStorage);
                flag = true;
            }

            if (Str.Ok(TBConsoleIP.Text))
            {
                R.Tx.IP = TBConsoleIP.Text;
                IniTool.Set(R.Files.Settings, "Console", "IP", R.Tx.IP);
            }

            if (Str.Ok(TBConsolePort.Text))
            {
                if (int.TryParse(TBConsolePort.Text, out int port))
                {
                    R.Tx.Port = port;
                    IniTool.Set(R.Files.Settings, "Console", "Port", R.Tx.Port);
                }
            }

            if (Str.Ok(TBLocalIP.Text))
            {
                R.Tx.LocalIP = TBLocalIP.Text;
                IniTool.Set(R.Files.Settings, "Local", "IP", R.Tx.IP);
            }

            if (Str.Ok(TBLocalName.Text))
            {
                R.Tx.LocalName = TBLocalName.Text;
                IniTool.Set(R.Files.Settings, "Local", "Name", R.Tx.LocalName);
            }
            return flag;
        }
        #endregion

        #region 按钮事件
        private void BTOpenNewStorage_Click(object sender, EventArgs e)
        {
            ExplorerAPI.Open(R.Paths.NewStorage);
            ToastForm.Display("正在打开", $"正在打开添加新工程的仓库文件夹，请稍候...", 'i', 5000);
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
        private void NIMain_MouseClick(object sender, MouseEventArgs e)
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

        #region 任务函数
        /// <summary>
        /// 启动监测APP自身资源占用情况
        /// </summary>
        private void TaskOfStatus()
        {
            if (!RunStatusTask)
            {
                Task.Factory.StartNew(() =>
                {
                    RunStatusTask = true;
                    TimeSpan beginTime = TimeSpan.Zero;
                    while (!IsDisposed)
                    {
                        try
                        {
                            bool cpuflag = ComputerStatusTool.TryGetNextValue(ComputerProcessor, out float cpu);
                            string ram = ByteConvertTool.Fmt(ComputerInfoTool.AvailablePhysicalMemory() * 1024);
                            int appcpu = (int)AppInfoTool.CalcCpuRate(Process, ref beginTime, STATUS_INTERVAL);
                            string appram = ByteConvertTool.Fmt(AppInfoTool.RAM() * 1024);

                            SystemStatusModel model = new SystemStatusModel()
                            {
                                Name = R.Tx.LocalName,
                                IP = R.Tx.LocalIP,
                                Cpu = (int)cpu,
                                Ram = (long)ComputerInfoTool.TotalPhysicalMemory() / 1024,
                                FreeRam = (long)ComputerInfoTool.AvailablePhysicalMemory() / 1024,
                                AppCpu = appcpu,
                                AppUseRam = AppInfoTool.RAM() / 1024,
                                NowTime = DateTime.Now
                            };
                            TxSendQueue.Add(20002000, Json.Object2String(model));

                            Invoke(new Action(() =>
                            {
                                LBStatus.Text = $"CPU: {(int)cpu}% , RAM: {ram} [ cpu: {appcpu}% , ram: {appram} ]";
                            }));
                        }
                        catch { }
                        Thread.Sleep(STATUS_INTERVAL);
                    }
                });
            }
        }
        #endregion

        #region 菜单：右下角图标
        private void TSMIExit_Click(object sender, EventArgs e)
        {
            try
            {
                FormClosing -= MainForm_FormClosing;
                Application.Exit();
            }
            catch { }
        }
        private void 显示主界面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            Activate();
        }
        #endregion

        private void BTUpdateLog_Click(object sender, EventArgs e)
        {
            R.FormMan.GetUnique<UpdateLogForm>().Show();
            R.FormMan.GetUnique<UpdateLogForm>().WindowState = FormWindowState.Normal;
            R.FormMan.GetUnique<UpdateLogForm>().Activate();
        }
        public void UITxStatus()
        {
            try
            {
                Invoke(new Action(() =>
                {
                    if (R.Tx.IsConnect) { LBTxStatus.Text = "已连接"; }
                    else { LBTxStatus.Text = "未连接"; }
                }));
            }
            catch { }
        }
    }
}
