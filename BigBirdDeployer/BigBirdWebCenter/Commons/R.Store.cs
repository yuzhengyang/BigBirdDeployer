using Azylee.YeahWeb.SocketUtils.TcpUtils;
using BigBird.Models.ProjectModels;
using BigBird.Models.SystemModels;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace BigBirdWebCenter.Commons
{
    public static partial class R
    {
        public static class Store
        {
            internal static ConcurrentQueue<ProjectStatusModel> ProjectStatus = new ConcurrentQueue<ProjectStatusModel>();
            internal static ConcurrentQueue<SystemStatusModel> SystemStatus = new ConcurrentQueue<SystemStatusModel>();
        }
    }
}
