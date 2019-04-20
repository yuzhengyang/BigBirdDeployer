using Azylee.Core.WindowsUtils.InfoUtils;
using BigBirdDeployer.Commons;

namespace BigBirdDeployer.Modules.PlanTaskModule
{
    public class PlanTaskM10
    {
        /// <summary>
        /// 1分钟任务
        /// </summary>
        public static void Do()
        {
            R.DriveTotal = DriveTool.GetDriveTotalSize(R.Paths.App);
            R.DriveAvail = DriveTool.GetDriveAvailableSize(R.Paths.App);
        }
    }
}
