using Azylee.Core.AppUtils;
using Azylee.Core.FormUtils;
using Azylee.Core.LogUtils.SimpleLogUtils;
using System;
using System.Reflection;
using static Azylee.Core.LogUtils.SimpleLogUtils.Log;

namespace BigBirdWebCenter.Commons
{
    public static partial class R
    {
        internal static string AppName = "BigBirdConsole";
        internal static string AppNameCn = "BigBird 控制台";
        internal static DateTime StartTime = DateTime.Now;
        internal static string MachineName = Environment.MachineName;
        internal static Module Module = Assembly.GetExecutingAssembly().GetModules()[0];
        internal static Log Log = new Log(LogLevel.None, LogLevel.None, LogEvent);
        internal static string AesKey = "12345678901234567890123456789012";
        internal static FormManTool FormMan = new FormManTool();//窗体管理器
        internal static bool IsAdministrator = PermissionTool.IsAdministrator();
        internal static string NewStorageReadmeTxt = "请将要发布的项目文件夹复制到该目录，然后点击界面的装载按钮。";

        public static void LogEvent(LogType type, string msg) { }
    }
}
