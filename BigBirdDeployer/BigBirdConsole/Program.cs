using Azylee.Core.AppUtils;
using Azylee.Core.IOUtils.TxtUtils;
using Azylee.Core.LogUtils.SimpleLogUtils;
using Azylee.Core.WindowsUtils.APIUtils;
using BigBirdConsole.Commons;
using BigBirdConsole.Modules.CommandModule;
using BigBirdConsole.Modules.PlanTaskModule;
using BigBirdConsole.Modules.StoreModule;
using BigBirdConsole.Modules.TxConvertModule;
using BigBirdConsole.Modules.TxModule;
using BigBirdConsole.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BigBirdConsole
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
            if (appUnique.IsUnique("BigBirdConsole"))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                R.MainUI = new MainForm();

                //初始化配置信息
                InitConfig();
                R.Log = new Log();//启动日志记录
                SystemSleepAPI.PreventSleep(false);//禁用计算机息屏和待机

                //启动进程
                TxHelper.Start();
                TxConvertHelper.Connect();
                TxReadQueue.Start();
                PlanTaskCore.Start();
                StorePersistanceTask.Start();
                CommandReader.Start();

                Application.Run(R.MainUI);
            }
        }
        private static void InitConfig()
        {
            //通讯接受 Tx
            R.Tx.Port = IniTool.GetInt(R.Files.Settings, "Tx", "Port", 52830);
            IniTool.Set(R.Files.Settings, "Tx", "Port", R.Tx.Port);

            R.Tx.ConnectKey = IniTool.GetString(R.Files.Settings, "Tx", "ConnectKey", R.Tx.ConnectKey);
            IniTool.Set(R.Files.Settings, "Tx", "ConnectKey", R.Tx.ConnectKey);

            //通讯转发 TxConvert
            R.TxConvert.IP = IniTool.GetString(R.Files.Settings, "TxConvert", "IP", "vaselee.com");
            IniTool.Set(R.Files.Settings, "TxConvert", "IP", R.TxConvert.IP);

            R.TxConvert.Port = IniTool.GetInt(R.Files.Settings, "TxConvert", "Port", 0);
            IniTool.Set(R.Files.Settings, "TxConvert", "Port", R.TxConvert.Port);

            R.TxConvert.ConnectKey = IniTool.GetString(R.Files.Settings, "TxConvert", "ConnectKey", R.TxConvert.ConnectKey);
            IniTool.Set(R.Files.Settings, "TxConvert", "ConnectKey", R.TxConvert.ConnectKey);
        }
    }
}
