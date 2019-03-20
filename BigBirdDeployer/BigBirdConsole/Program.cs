using Azylee.Core.AppUtils;
using Azylee.Core.LogUtils.SimpleLogUtils;
using Azylee.Core.WindowsUtils.APIUtils;
using BigBirdConsole.Commons;
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
                R.Log = new Log(true);//启动日志记录
                SystemSleepAPI.PreventSleep(false);//禁用计算机息屏和待机
                //InitIni();//初始化Ini配置信息

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                R.MainUI = new MainForm();
                Application.Run(R.MainUI);
            }
        }
    }
}
