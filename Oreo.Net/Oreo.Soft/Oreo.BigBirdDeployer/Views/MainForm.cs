using Azylee.Core.AppUtils;
using Azylee.Core.DataUtils.StringUtils;
using Azylee.Core.DataUtils.UnitConvertUtils;
using Azylee.Core.IOUtils.TxtUtils;
using Azylee.Core.WindowsUtils.APIUtils;
using Azylee.Core.WindowsUtils.InfoUtils;
using Azylee.WinformSkin.FormUI.CustomTitle;
using Azylee.WinformSkin.FormUI.Toast;
using Oreo.BigBirdDeployer.Commons;
using Oreo.BigBirdDeployer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oreo.BigBirdDeployer.Views
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
            LBVersion.Text = $"版本：{Application.ProductVersion}";
            TBPublishStorage.Text = R.Paths.PublishStorage == R.Paths.DefaultPublishStorage ? "" : R.Paths.PublishStorage;
            TBNewStorage.Text = R.Paths.NewStorage == R.Paths.DefaultNewStorage ? "" : R.Paths.NewStorage;
            TaskOfStatus();
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
                    IniTool.WriteValue(R.Files.Settings, "Paths", "PublishStorage", R.Paths.PublishStorage);
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
                    IniTool.WriteValue(R.Files.Settings, "Paths", "NewStorage", R.Paths.NewStorage);
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
            try
            {
                Hide();
                e.Cancel = true;
            }
            catch { }
        }

        private void NIMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                Show();
            }
            catch { }
        }

        private void TSMIExit_Click(object sender, EventArgs e)
        {
            try
            {
                FormClosing -= MainForm_FormClosing;
                Application.Exit();
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
    }
}
