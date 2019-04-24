using Azylee.Core.WindowsUtils.InfoUtils;
using BigBirdDeployer.Commons;
using BigBirdDeployer.Modules.CleanerModule;

namespace BigBirdDeployer.Modules.PlanTaskModule
{
    public class PlanTaskM10
    {
        /// <summary>
        /// 1分钟任务
        /// </summary>
        public static void Do()
        {
            R.SystemStatus.DriveTotal = DriveTool.GetDriveTotalSize(R.Paths.App);
            R.SystemStatus.DriveAvail = DriveTool.GetDriveAvailableSize(R.Paths.App);
            LogCleaner.LogFileAnalyse();
        }
    }
}
