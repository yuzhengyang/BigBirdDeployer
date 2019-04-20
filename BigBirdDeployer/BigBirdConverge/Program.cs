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

            PlanTaskCore.Start();
            TxHelper.Start();

            R.MainUI = new MainForm();
            Application.Run(R.MainUI);
        }
    }
}
