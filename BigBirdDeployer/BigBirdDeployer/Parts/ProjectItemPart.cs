using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Azylee.Core.WindowsUtils.CMDUtils;
using Azylee.Core.DataUtils.CollectionUtils;
using System.Threading.Tasks;
using System.Threading;
using BigBirdDeployer.Views;
using Azylee.Core.AppUtils;
using Azylee.Core.IOUtils.DirUtils;
using BigBirdDeployer.Utils;
using BigBirdDeployer.Commons;
using System.IO;
using Azylee.WinformSkin.FormUI.Toast;
using Azylee.Core.IOUtils.TxtUtils;
using Azylee.Core.WindowsUtils.APIUtils;
using Azylee.Jsons;
using BigBird.Models.ProjectModels;
using BigBird.Models.WorkModels;
using BigBirdDeployer.Modules.TxModule;
using Azylee.Core.ThreadUtils.SleepUtils;

namespace BigBirdDeployer.Parts
{
    public partial class ProjectItemPart : UserControl
    {
        const int STATUS_INTERVAL = 2500;//刷新状态时间间隔
        private DateTime StartTime { get; set; }
        private WorkStatus Status { get; set; }
        private ProjectModel Project { get; set; }
        private Process Process { get; set; }
        private ProjectConsoleForm ConsoleForm { get; set; }
        public int Port { get { return Project.Port; } }

        public ProjectItemPart()
        {
            InitializeComponent();
            Project = new ProjectModel();
        }
        private void ProjectItemPart_Load(object sender, EventArgs e)
        {
            //启动按钮默认不可用（Init初始化后变为可用）
            BTStartOrStop.Enabled = false;//禁止启动/关闭
            BTAddNew.Enabled = false;//禁止装载新版本
            CBVersion.Enabled = false;//禁止选择启动版本

            //持续监控端口及端口进程状态
            ProcessStatus();

            //加载项目资料（加载前检查是否存在）
            if (File.Exists(DirTool.Combine(R.Paths.Projects, Name)))
            {
                string txt = TxtTool.Read(DirTool.Combine(R.Paths.Projects, Name));
                var p = Json.String2Object<ProjectModel>(txt);
                if (p != null) SetProject(p);
            }

            //将控件加入到管理列表中
            R.ProjectItems.Add(this);
        }

        #region 功能方法
        /// <summary>
        /// 设置/重置工程信息
        /// </summary>
        /// <param name="model"></param>
        public void SetProject(ProjectModel model)
        {
            //初始化设置项目
            Project = model;
            //获取当前端口进程
            if (GetProcess())
            {
                //初始化时有进程占用端口号
                StatusUI(WorkStatus.端口占用);
            }
            else
            {
                //没有进程占用端口号
                StatusUI(WorkStatus.准备就绪);
            }
            //为控件更新显示
            LBProjectName.Text = Project.Name;//更新项目名称
            LBPort.Text = $"端口：{Project.Port}";//更新端口号信息

            //设置下拉框选择版本信息
            if (ListTool.HasElements(Project.Versions))
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt.TableName = "dt";
                    dt.Columns.Add("Code");
                    dt.Columns.Add("Name");
                    Project.Versions.OrderByDescending(x => x.Number).ToList().ForEach(x =>
                    {
                        DataRow row = dt.NewRow();
                        row["Code"] = x.Number.ToString();
                        row["Name"] = $"{x.Number}（{x.CreateTime.ToString("yyyy年MM月dd日 HH:mm")}）";
                        dt.Rows.Add(row);
                        if (x.Number > Project.CurrentVersion) Project.CurrentVersion = x.Number;
                    });
                    CBVersion.DataSource = dt;
                    CBVersion.DisplayMember = "Name";
                    CBVersion.ValueMember = "Code";
                }
                catch { }
            }
            else
            {
                DataTable dt = new DataTable();
                dt.TableName = "dt";
                dt.Columns.Add("Code");
                dt.Columns.Add("Name");
                DataRow row = dt.NewRow();
                row["Code"] = 0;
                row["Name"] = $"新建工程需要先加载工程";
                dt.Rows.Add(row);
                CBVersion.DataSource = dt;
                CBVersion.DisplayMember = "Name";
                CBVersion.ValueMember = "Code";
            }

            //保存工程信息到文件
            string str = Json.Object2String(Project);
            TxtTool.Create(DirTool.Combine(R.Paths.Projects, Name), str);

            //刷新进程
            GetProcess();
        }
        /// <summary>
        /// 通过设置的工程端口号获取进程
        /// </summary>
        /// <returns></returns>
        private bool GetProcess()
        {
            try
            {
                var pid = CMDNetstatTool.FindByPort(Project.Port, false);
                if (ListTool.HasElements(pid))
                {
                    var p = Process.GetProcessById(pid.First().Item2);
                    if (p != null)
                    {
                        Process = p;
                        return true;
                    }
                }
            }
            catch { }
            Process = null;
            return false;
        }
        /// <summary>
        /// 根据工程设置启动服务
        /// </summary>
        /// <returns></returns>
        private void Start()
        {
            StatusUI(WorkStatus.正在启动);
            StartTime = DateTime.Now;

            //端口号是0，玩个蛋
            if (Project.Port == 0)
            {
                ToastForm.Display("启动失败", $"没有为 {Project.Name} 工程配置正儿八经的端口号", 'e', 5000);
                StatusUI(WorkStatus.启动失败);
                return;
            }
            if (!(ListTool.HasElements(Project.Versions) && Project.CurrentVersion != 0 && Project.LastVersion != 0))
            {
                //不存在版本或错误的版本（版本为0），不启动工程
                ToastForm.Display("启动失败", $"没有发现 {Project.Name} 工程的相关文件", 'e', 5000);
                StatusUI(WorkStatus.启动失败);
                return;
            }

            //存在版本，准备启动
            Task.Factory.StartNew(() =>
            {
                string cmd = $"java -jar {Project.Parameter} \"{JarFileTool.GetFilePath(Project)}\"";
                CMDProcessTool.Execute(cmd,
                    new Action<string>((s) =>
                    {
                        if (ConsoleCodeTool.IsLunchSuccess(s))
                        {
                            R.Log.i(s);
                            StatusUI(WorkStatus.启动成功);
                            Invoke(new Action(() =>
                            {
                                ToastForm.Display("启动成功", $"启动 {Project.Name} 工程成功", 'i', 5000);
                            }));
                        }

                        string log = ConsoleCodeTool.GetLogInfo(s);
                        if (!string.IsNullOrWhiteSpace(log)) R.Log.v(log);

                        //输出到窗口
                        if (ConsoleForm != null && !ConsoleForm.IsDisposed && ConsoleForm.Visible == true)
                        {
                            ConsoleForm.AddToQueue(s);
                        }
                    }));

                if (Status == WorkStatus.启动成功 || Status == WorkStatus.端口占用 || Status == WorkStatus.正在关闭)
                {
                    StatusUI(WorkStatus.正在关闭);
                    Stop();
                }
                else
                {
                    StatusUI(WorkStatus.启动失败);
                }
            });
        }
        /// <summary>
        /// 关闭工程服务
        /// </summary>
        /// <returns></returns>
        private void Stop()
        {
            StatusUI(WorkStatus.正在关闭);

            Task.Factory.StartNew(() =>
            {
                try
                {
                    int count = 1;//尝试关闭次数
                    //如果能获取到端口的进程
                    while (GetProcess())
                    {
                        //停止进程
                        Process?.Kill();
                        Thread.Sleep(1000);
                        if (count >= 3) break;
                        count++;
                    }
                    StatusUI(WorkStatus.准备就绪);
                }
                catch { StatusUI(WorkStatus.端口占用); }
            });
        }
        private void ProcessStatus()
        {
            Task.Factory.StartNew(() =>
            {
                TimeSpan begin = TimeSpan.Zero;
                while (!IsDisposed)
                {
                    try
                    {
                        if (File.Exists(DirTool.Combine(R.Paths.Projects, Name)))
                        {
                            GetProcess();
                            if (Process != null && !Process.HasExited)
                            {
                                BeginInvoke(new Action(() =>
                                {
                                    double cpu = AppInfoTool.CalcCpuRate(Process, ref begin, STATUS_INTERVAL);
                                    LBCpu.Text = $"CPU：{Math.Round(cpu, 1)} %";
                                    CpCpuRate.SetValue((int)cpu);
                                    LBRam.Text = $"内存：{AppInfoTool.RAM(Process.Id) / 1024} MB";

                                    //发送正常启动状态的项目信息
                                    ProjectStatusModel model = new ProjectStatusModel()
                                    {
                                        IP = R.Tx.LocalIP,
                                        Port = Project.Port,
                                        Name = Project.Name,
                                        Version = Project.CurrentVersion,
                                        Cpu = (int)cpu,
                                        Ram = AppInfoTool.RAM(Process.Id) / 1024,
                                        StartTime = StartTime,
                                        IsRun = true,
                                        CreateTime = DateTime.Now
                                    };
                                    TxSendQueue.Add(20003000, Json.Object2String(model));
                                }));
                                if (Status == WorkStatus.启动成功)
                                    StatusUI(WorkStatus.启动成功);
                                else
                                    StatusUI(WorkStatus.端口占用);
                            }
                            else
                            {
                                BeginInvoke(new Action(() =>
                                {
                                    LBCpu.Text = $"CPU：0 %";
                                    LBRam.Text = $"内存：0 MB";

                                    //发送未启动状态的项目信息
                                    ProjectStatusModel model = new ProjectStatusModel()
                                    {
                                        IP = R.Tx.LocalIP,
                                        Port = Project.Port,
                                        Name = Project.Name,
                                        Version = Project.CurrentVersion,
                                        Cpu = 0,
                                        Ram = 0,
                                        StartTime = StartTime,
                                        IsRun = false,
                                        CreateTime = DateTime.Now
                                    };
                                    TxSendQueue.Add(20003000, Json.Object2String(model));
                                }));
                                if (Status == WorkStatus.正在启动) StatusUI(WorkStatus.正在启动);
                                else if (Status == WorkStatus.启动失败) StatusUI(WorkStatus.启动失败);
                                else StatusUI(WorkStatus.准备就绪);

                                //if (Status == WorkStatus.准备就绪 && Project.AutoStart && StartTime.Year < 2000)
                                //    Start();
                            }
                        }
                    }
                    catch { }
                    Thread.Sleep(STATUS_INTERVAL);
                }
            });
        }
        /// <summary>
        /// 强制重启服务
        /// </summary>
        public void Restart()
        {
            //端口号是0，玩个蛋
            if (Project.Port == 0)
            {
                return;
            }
            if (!(ListTool.HasElements(Project.Versions) && Project.CurrentVersion != 0 && Project.LastVersion != 0))
            {
                //不存在版本或错误的版本（版本为0），不启动工程
                return;
            }

            Task.Factory.StartNew(() =>
            {
                //停止服务
                Stop();
                //等待一下，防止未停止进程的情况发生
                Sleep.S(3);
                //没有端口占用则正常启动
                if (!GetProcess()) Start();
            });
        }
        #endregion

        #region 事件方法
        /// <summary>
        /// 启动工程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTStartOrStop_Click(object sender, EventArgs e)
        {
            //没有端口占用则正常启动
            if (!GetProcess())
            {
                Start();
            }
            else
            {
                Stop();
            }
        }
        /// <summary>
        /// 设置工程信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LBProjectName_Click(object sender, EventArgs e)
        {
            new ProjectConfigForm(this, Project).ShowDialog();
        }
        /// <summary>
        /// 装载新版本工程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTAddNew_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Project.Folder) && !string.IsNullOrWhiteSpace(Project.JarFile))
            {
                //查询New仓库中，该工程的新版本
                string newPath = JarFileTool.GetNewPath(Project);
                if (Directory.Exists(newPath) && File.Exists(DirTool.Combine(newPath, Project.JarFile)))
                {
                    try
                    {
                        ToastForm.Display("装载中", $"正在装载 {Project.Name} 的新版本...", 'i', 5000);
                        //移动文件到发布仓库中
                        string aimPath = DirTool.Combine(R.Paths.PublishStorage, Project.Folder);//组合目标路径
                        DirTool.Create(aimPath);//创建目标路径
                        if (Directory.Exists(DirTool.Combine(aimPath, (Project.LastVersion + 1).ToString())))//如果存在目标文件夹
                            Directory.Delete(DirTool.Combine(aimPath, (Project.LastVersion + 1).ToString()), true);//删除目标文件夹（防止重复）
                        Directory.Move(newPath, DirTool.Combine(aimPath, (Project.LastVersion + 1).ToString()));//开始移动
                                                                                                                //添加新版本信息
                        Project.LastVersion++;
                        Project.CurrentVersion = Project.LastVersion;
                        ProjectVersionModel version = new ProjectVersionModel()
                        {
                            CreateTime = DateTime.Now,
                            Number = Project.LastVersion,
                        };
                        if (Project.Versions == null) Project.Versions = new List<ProjectVersionModel>();
                        Project.Versions.Add(version);
                        ToastForm.Display("装载成功", $"成功装载 {Project.Name} 的新版本", 'i', 5000);
                    }
                    catch
                    {
                        ToastForm.Display("装载失败", $"装载 {Project.Name} 的新版本失败", 'e', 5000);
                    }
                }
                else
                {
                    //没有发现新版本，不做处理
                    ToastForm.Display("装载失败", $"没有发现 {Project.Name} 的新版本", 'w', 5000);
                }
            }
            else
            {
                //没有工程配置信息，不做处理
                ToastForm.Display("装载失败", $"没有发现工程的配置信息", 'e', 5000);
            }

            //清除多余版本
            if (Project.VersionCache > 0 &&
                !string.IsNullOrWhiteSpace(Project.Folder) &&
                ListTool.HasElements(Project.Versions))
            {
                if (Project.Versions.Count > Project.VersionCache)
                {
                    List<ProjectVersionModel> _tempVers = Project.Versions.OrderByDescending(x => x.CreateTime).ToList();
                    List<ProjectVersionModel> _newVers = new List<ProjectVersionModel>();
                    for (int i = 0; i < Project.VersionCache; i++)
                    {
                        _newVers.Add(_tempVers[i]);
                    }
                    for (int i = Project.VersionCache; i < Project.Versions.Count; i++)
                    {
                        string path = DirTool.Combine(R.Paths.PublishStorage, Project.Folder, (_tempVers[i].Number).ToString());
                        try
                        {
                            //如果文件夹存在，则删除文件夹及内容
                            if (Directory.Exists(path)) Directory.Delete(path, true);
                        }
                        catch
                        {
                            //如果删除失败，则继续保留该版本，等待下次继续删除
                            _newVers.Add(_tempVers[i]);
                        }
                    }
                    Project.Versions = _newVers;
                }
            }

            //重置项目信息
            SetProject(Project);
        }
        /// <summary>
        /// 选择要启动的版本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CBVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(CBVersion.SelectedValue.ToString(), out int v))
            {
                Project.CurrentVersion = v;
            }
        }
        #endregion

        #region 菜单功能
        private void 输出窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ConsoleForm != null && !ConsoleForm.IsDisposed && ConsoleForm.Visible == true)
            {
                ConsoleForm.Show();
                ConsoleForm.WindowState = FormWindowState.Normal;
                ConsoleForm.Activate();
            }
            else
            {
                ConsoleForm = new ProjectConsoleForm();
                ConsoleForm.Show();
                ConsoleForm.WindowState = FormWindowState.Normal;
                ConsoleForm.Activate();
                ConsoleForm.UICaption(Project.Name);
            }
        }
        private void 工程配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ProjectConfigForm(this, Project).ShowDialog();
        }
        private void 浏览运行目录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExplorerAPI.ExplorerFile(JarFileTool.GetFilePath(Project));
            ToastForm.Display("浏览", $"正在打开运行目录，请稍候...", 'i', 5000);
        }
        private void 浏览装载目录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExplorerAPI.ExplorerFile(R.Files.NewStorageReadme);
            ToastForm.Display("浏览", $"正在打开装载目录，请稍候...", 'i', 5000);
        }
        private void 过程日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region UI操作
        private void StatusUI(WorkStatus status)
        {
            Status = status;
            try
            {
                Invoke(new Action(() =>
                {
                    LBStatus.Text = status.ToString();
                    switch (status)
                    {
                        case WorkStatus.准备就绪:
                            BackColor = ColorTranslator.FromHtml("#6a9c78");
                            LBStatus.BackColor = ColorTranslator.FromHtml("#446e5c");
                            LBProjectName.BackColor = ColorTranslator.FromHtml("#7dc383");
                            BTStartOrStop.Text = "启动";
                            UIEnable(BTStartOrStop);//允许启动/关闭
                            UIEnable(BTAddNew);//允许装载新版本
                            //UIEnable(BTConfig);//允许配置工程
                            UIEnable(CBVersion);//允许选择启动版本
                            break;
                        case WorkStatus.启动成功:
                            BackColor = ColorTranslator.FromHtml("#26adaf");
                            LBStatus.BackColor = ColorTranslator.FromHtml("#0081c6");
                            LBProjectName.BackColor = ColorTranslator.FromHtml("#1fd1c6");
                            BTStartOrStop.Text = "停止";
                            UIEnable(BTStartOrStop);//允许启动/关闭
                            UIEnable(BTAddNew, false);//禁止装载新版本
                            //UIEnable(BTConfig, false);//禁止配置工程
                            UIEnable(CBVersion, false);//禁止选择启动版本
                            break;

                        case WorkStatus.正在启动:
                            BackColor = ColorTranslator.FromHtml("#ff8264");
                            LBStatus.BackColor = ColorTranslator.FromHtml("#ff6464");
                            LBProjectName.BackColor = ColorTranslator.FromHtml("#ffaa64");
                            BTStartOrStop.Text = "启~";
                            UIEnable(BTStartOrStop, false);//禁止启动/关闭
                            UIEnable(BTAddNew, false);//禁止装载新版本
                            //UIEnable(BTConfig, false);//禁止配置工程
                            UIEnable(CBVersion, false);//禁止选择启动版本
                            break;
                        case WorkStatus.正在关闭:
                            BackColor = ColorTranslator.FromHtml("#ff8264");
                            LBStatus.BackColor = ColorTranslator.FromHtml("#ff6464");
                            LBProjectName.BackColor = ColorTranslator.FromHtml("#ffaa64");
                            BTStartOrStop.Text = "关~";
                            UIEnable(BTStartOrStop, false);//禁止启动/关闭
                            UIEnable(BTAddNew, false);//禁止装载新版本
                            //UIEnable(BTConfig, false);//禁止配置工程
                            UIEnable(CBVersion, false);//禁止选择启动版本
                            break;

                        case WorkStatus.端口占用:
                            BackColor = ColorTranslator.FromHtml("#ff467e");
                            LBStatus.BackColor = ColorTranslator.FromHtml("#f12b6b");
                            LBProjectName.BackColor = ColorTranslator.FromHtml("#fd94b4");
                            BTStartOrStop.Text = "停止";
                            UIEnable(BTStartOrStop);//允许启动/关闭
                            UIEnable(BTAddNew, false);//禁止装载新版本
                            //UIEnable(BTConfig);//允许配置工程
                            UIEnable(CBVersion, false);//禁止选择启动版本
                            break;
                        case WorkStatus.启动失败:
                            BackColor = ColorTranslator.FromHtml("#ff467e");
                            LBStatus.BackColor = ColorTranslator.FromHtml("#f12b6b");
                            LBProjectName.BackColor = ColorTranslator.FromHtml("#fd94b4");
                            BTStartOrStop.Text = "启动";
                            UIEnable(BTStartOrStop);//允许启动/关闭
                            UIEnable(BTAddNew);//允许装载新版本
                            //UIEnable(BTConfig);//允许配置工程
                            UIEnable(CBVersion);//允许选择启动版本
                            break;
                    }

                    StringBuilder tip = new StringBuilder();
                    if (StartTime.Year > 2000)
                        tip.AppendLine($"启动时间：{StartTime.ToString("yyyy年MM月dd日 HH时mm分ss秒")}");
                    else
                        tip.AppendLine($"启动时间：未使用程序启动");
                    TTInfo.SetToolTip(LBStatus, tip.ToString());
                }));
            }
            catch { }
        }
        private void ConsoleUI(string s)
        {
            try
            {
                BeginInvoke(new Action(() =>
                {
                }));
            }
            catch { }
        }
        private void UIEnable(Control ctrl, bool enable = true)
        {
            try
            {
                Invoke(new Action(() =>
                {
                    ctrl.Enabled = enable;
                    if (enable) ctrl.BackColor = Color.White;
                    else ctrl.BackColor = Color.LightGray;
                }));
            }
            catch { }
        }
        #endregion
    }
}
