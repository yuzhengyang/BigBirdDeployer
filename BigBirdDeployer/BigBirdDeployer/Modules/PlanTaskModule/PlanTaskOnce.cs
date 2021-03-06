﻿using Azylee.Core.DataUtils.UnitConvertUtils;
using Azylee.Core.WindowsUtils.InfoUtils;
using BigBirdDeployer.Commons;
using BigBirdDeployer.Modules.CleanerModule;

namespace BigBirdDeployer.Modules.PlanTaskModule
{
    public class PlanTaskOnce
    {
        /// <summary>
        /// 1分钟任务
        /// </summary>
        public static void Do()
        {
            R.SystemStatus.DriveTotal = DriveTool.GetDriveTotalSize(R.Paths.App);
            R.SystemStatus.DriveAvail = DriveTool.GetDriveAvailableSize(R.Paths.App);

            LogCleaner.LogFileAnalyse();
            R.Log.I($"全部日志文件：{R.SystemStatus.AllLogCount} 个， 共计：{ByteConvertTool.Cvt(R.SystemStatus.AllLogSize, "MB")} GB");
            R.Log.I($"过期日志文件：{R.SystemStatus.ExpireLogCount} 个， 共计：{ByteConvertTool.Cvt(R.SystemStatus.ExpireLogSize, "MB")} GB");

            //string toMail = "yuzhyn@163.com";
            //string subject = $"服务器状态报表:日报:{DateTime.Now.ToString("yyyy年MM月dd日")}";
            //string emailBody = "测试内容";
            //EmailTool et = new EmailTool(
            //    "bigbird_server@163.com", 
            //    toMail, subject, emailBody, 
            //    "bigbird_server","bigbird528");
            //et.Send();

        }
    }
}
