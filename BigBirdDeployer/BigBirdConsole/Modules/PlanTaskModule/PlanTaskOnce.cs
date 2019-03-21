using Azylee.YeahWeb.EmailUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BigBirdConsole.Modules.PlanTaskModule
{
    public class PlanTaskOnce
    { 
        /// <summary>
        /// 1分钟任务
        /// </summary>
        public static void Do()
        {
            string toMail = "yuzhyn@163.com";
            string subject = $"服务器状态报表:日报:{DateTime.Now.ToString("yyyy年MM月dd日")}";
            string emailBody = "测试内容";
            EmailTool et = new EmailTool(
                "bigbird_server@163.com", 
                toMail, subject, emailBody, 
                "bigbird_server","bigbird528");
            et.Send();
        }
    }
}
