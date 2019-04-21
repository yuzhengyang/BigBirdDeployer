using Azylee.Core.AppUtils;
using Azylee.Core.IOUtils.DirUtils;
using Azylee.Core.IOUtils.TxtUtils;
using Azylee.Core.LogUtils.SimpleLogUtils;
using Azylee.Core.LogUtils.StatusLogUtils;
using Azylee.Core.WindowsUtils.APIUtils;
using BigBirdDeployer.Commons;
using BigBirdDeployer.Modules.PlanTaskModule;
using BigBirdDeployer.Views;
using System;
using System.IO;
using System.Windows.Forms;

namespace BigBirdDeployer
{
    static class Program
    {
        static AppUnique AppUnique = new AppUnique();
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {  
            //解决进程互斥
            if (!AppUnique.IsUnique(R.AppName)) return;

            try
            {
                //处理未捕获的异常  
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                //处理UI线程异常  
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                //处理非UI线程异常  
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

                R.Log.i("========== 程序启动：BigBirdDeployer（正常启动） ==========");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                R.MainUI = new MainForm();

                InitIni();//初始化Ini配置信息
                StatusLog.Instance.Start();//启动计算机状态日志记录
                R.Log.SetCacheDays(10);//保存最近10天的普通日志信息
                StatusLog.Instance.SetCacheDays(10);//保存最近10天的状态日志信息
                SystemSleepAPI.PreventSleep(false);//禁用计算机息屏和待机
                PlanTaskCore.Start();//启动定时任务

                Application.Run(R.MainUI);//启动主UI
            }
            catch (Exception ex)
            {
                R.Log.e("应用程序异常 App Main Exception");
                WriteExceptionAndRestart(ex);
            }
        }
        /// <summary>
        /// 初始化Ini配置信息
        /// </summary>
        static void InitIni()
        {
            DirTool.Create(R.Paths.Settings);
            DirTool.Create(R.Paths.Projects);
            DirTool.Create(R.Paths.DefaultPublishStorage);
            DirTool.Create(R.Paths.DefaultNewStorage);

            R.Paths.PublishStorage = IniTool.GetString(R.Files.Settings, "Paths", "PublishStorage", R.Paths.DefaultPublishStorage);
            if (string.IsNullOrWhiteSpace(R.Paths.PublishStorage)) R.Paths.PublishStorage = R.Paths.DefaultPublishStorage;

            R.Paths.NewStorage = IniTool.GetString(R.Files.Settings, "Paths", "NewStorage", R.Paths.DefaultNewStorage);
            if (string.IsNullOrWhiteSpace(R.Paths.NewStorage)) R.Paths.NewStorage = R.Paths.DefaultNewStorage;

            R.Tx.IP = IniTool.GetString(R.Files.Settings, "Console", "IP", "");
            R.Tx.Port = IniTool.GetInt(R.Files.Settings, "Console", "Port", 0);
            R.Tx.LocalIP = IniTool.GetString(R.Files.Settings, "Local", "IP", "");
            R.Tx.LocalName = IniTool.GetString(R.Files.Settings, "Local", "Name", "");

            if (!File.Exists(R.Files.NewStorageReadme)) TxtTool.Create(R.Files.NewStorageReadme, R.NewStorageReadmeTxt);
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            R.Log.e("应用程序异常 Application ThreadException");
            Exception ex = e.Exception as Exception;
            WriteExceptionAndRestart(ex);
        }
        static void CurrentDomain_UnhandledException(object sender, System.UnhandledExceptionEventArgs e)
        {
            R.Log.e("应用程序异常 CurrentDomain UnhandledException");
            Exception ex = e.ExceptionObject as Exception;
            WriteExceptionAndRestart(ex);
        }
        /// <summary>
        /// 输出异常
        /// </summary>
        /// <param name="ex"></param>
        static void WriteExceptionAndRestart(Exception ex)
        {
            if (ex != null)
            {
                R.Log.e(string.Format("异常类型：{0}  异常消息：{1}  异常信息：{2}", ex.GetType().Name, ex.Message, ex.StackTrace));
            }
            R.Log.i("========== 程序退出：BigBirdDeployer（异常退出） ==========");
        }
    }
}
