using Azylee.Core.AppUtils;
using Azylee.Core.FormUtils;
using Azylee.Core.LogUtils.SimpleLogUtils;
using Azylee.YeahWeb.SocketUtils.TcpUtils;
using BigBird.Models.SystemModels;
using BigBirdDeployer.Parts;
using BigBirdDeployer.Views;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace BigBirdDeployer.Commons
{
    public static partial class R
    {
        internal static string AppID = "";
        internal static string AppName = "BigBirdDeployer";
        internal static string AppNameCn = "    Java 服务启动管理工具";
        internal static string AppointName = "";
        internal static string AppointMD5 = "";
        internal static string Version = Application.ProductVersion;
        internal static DateTime StartTime = DateTime.Now;
        internal static string MachineName = Environment.MachineName;
        internal static Module Module = Assembly.GetExecutingAssembly().GetModules()[0];
        internal static Log Log = new Log();
        internal static string AesKey = "12345678901234567890123456789012";
        internal static MainForm MainUI;
        internal static FormManTool FormMan = new FormManTool();//窗体管理器
        internal static bool IsAdministrator = PermissionTool.IsAdministrator();
        internal static string NewStorageReadmeTxt = "请将要发布的项目文件夹复制到该目录，然后点击界面的装载按钮。";

        internal static SystemStatusModel SystemStatus = new SystemStatusModel();
        internal static List<ProjectItemPart> ProjectItems = new List<ProjectItemPart>();
    }
}
