using Azylee.Core.LogUtils.SimpleLogUtils;
using BigBirdConverge.Commons;
using BigBirdConverge.Modules.PlanTaskModule;
using BigBirdConverge.Modules.TxModule;
using BigBirdConverge.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BigBirdConverge
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            R.MainUI = new MainForm();

            //初始化信息
            R.Log = new Log();
            //启动相应任务
            PlanTaskCore.Start();
            TxHelper.Start();
            TxReadQueue.Start();

            //启动程序
            Application.Run(R.MainUI);
        }
    }
}
