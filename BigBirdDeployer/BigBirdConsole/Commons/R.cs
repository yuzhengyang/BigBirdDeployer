using Azylee.Core.AppUtils;
using Azylee.Core.FormUtils;
using Azylee.Core.LogUtils.SimpleLogUtils;
using BigBirdConsole.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BigBirdConsole.Commons
{
    public static partial class R
    {
        internal static string AppName = "BigBirdConsole";
        internal static string AppNameCn = "BigBird 控制台";
        internal static DateTime StartTime = DateTime.Now;
        internal static string MachineName = Environment.MachineName;
        internal static Module Module = Assembly.GetExecutingAssembly().GetModules()[0];
        internal static Log Log { get; set; }
        internal static string AesKey = "12345678901234567890123456789012";
        internal static MainForm MainUI;
        internal static FormManTool FormMan = new FormManTool();//窗体管理器
        internal static bool IsAdministrator = PermissionTool.IsAdministrator();
        internal static string NewStorageReadmeTxt = "请将要发布的项目文件夹复制到该目录，然后点击界面的装载按钮。";

        internal static string AppointFile = "";
    }
}
