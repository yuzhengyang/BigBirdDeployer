using Azylee.Core.AppUtils;
using Azylee.Core.IOUtils.DirUtils;
using Azylee.Core.IOUtils.TxtUtils;
using Azylee.Core.LogUtils.SimpleLogUtils;
using Azylee.Core.WindowsUtils.APIUtils;
using BigBirdDeployer.Commons;
using BigBirdDeployer.Views;
using System;
using System.IO;
using System.Windows.Forms;

namespace BigBirdDeployer
{
    static class Program
    {
        static AppUnique appUnique = new AppUnique();
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (appUnique.IsUnique("BigBirdDeployer"))
            {
                R.Log = new Log(true);//启动日志记录
                SystemSleepAPI.PreventSleep(false);//禁用计算机息屏和待机
                InitIni();//初始化Ini配置信息

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                R.MainUI = new MainForm();
                Application.Run(R.MainUI);
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

            if (!File.Exists(R.Files.NewStorageReadme)) TxtTool.Create(R.Files.NewStorageReadme, R.NewStorageReadmeTxt);
        }
    }
}
