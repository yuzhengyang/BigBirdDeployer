using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.DataUtils.UnitConvertUtils;
using Azylee.Core.IOUtils.FileUtils;
using Azylee.Core.WindowsUtils.InfoUtils;
using BigBirdDeployer.Commons;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBirdDeployer.Modules.CleanerModule
{
    public static class LogCleaner
    {
        private static bool IsCleaning = false;

        /// <summary>
        /// 查询程序目录下所有日志文件
        /// </summary>
        /// <returns></returns>
        private static List<string> GetAllLogFile()
        {
            List<string> result = FileTool.GetAllFile(R.Paths.App, new[] { "*.log" });
            return result;
        }
        /// <summary>
        /// 查询过期的日志文件（15天前）
        /// </summary>
        /// <returns></returns>
        private static List<string> GetExpireLogFile(List<string> list, out long allSize, out long expireSize)
        {
            List<string> result = new List<string>();
            allSize = 0;
            expireSize = 0;
            if (Ls.Ok(list))
            {
                foreach (var file in list)
                {
                    try
                    {
                        FileInfo file_info = new FileInfo(file);
                        if (file_info.LastWriteTime.AddDays(15) < DateTime.Now)
                        {
                            result.Add(file);
                            expireSize += file_info.Length;
                        }
                        allSize += file_info.Length;
                    }
                    catch { }
                }
            }
            return result;
        }
        /// <summary>
        /// 日志文件分析
        /// </summary>
        public static void LogFileAnalyse()
        {
            List<string> all_log = GetAllLogFile();
            List<string> expire_log = GetExpireLogFile(all_log, out long allSize, out long expireSize);
            int all_log_count = Ls.Ok(all_log) ? all_log.Count : 0;
            int expire_log_count = Ls.Ok(expire_log) ? expire_log.Count : 0;

            R.SystemStatus.AllLogCount = all_log_count;
            R.SystemStatus.AllLogSize = (long)ByteConvertTool.Cvt(allSize, "KB");
            R.SystemStatus.ExpireLogCount = expire_log_count;
            R.SystemStatus.ExpireLogSize = (long)ByteConvertTool.Cvt(expireSize, "KB");

            //R.Log.I($"全部日志文件：{all_log_count} 个， 共计：{ByteConvertTool.Cvt(allSize, "GB")} GB");
            //R.Log.I($"过期日志文件：{expire_log_count} 个， 共计：{ByteConvertTool.Cvt(expireSize, "GB")} GB");
        }
        /// <summary>
        /// 清理日志文件
        /// </summary>
        public static void CleanLogFile()
        {
            Task.Factory.StartNew(() =>
            {
                if (IsCleaning == false)
                {
                    IsCleaning = true;

                    List<string> all_log = GetAllLogFile();
                    List<string> expire_log = GetExpireLogFile(all_log, out long allSize, out long expireSize);

                    if (Ls.Ok(expire_log))
                    {
                        foreach (var file in expire_log)
                        {
                            FileTool.Delete(file);
                        }

                        R.SystemStatus.DriveTotal = DriveTool.GetDriveTotalSize(R.Paths.App);
                        R.SystemStatus.DriveAvail = DriveTool.GetDriveAvailableSize(R.Paths.App);
                        LogCleaner.LogFileAnalyse();
                    }

                    IsCleaning = false;
                }
            });
        }
    }
}
