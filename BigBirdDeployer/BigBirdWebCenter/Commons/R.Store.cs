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
            internal static ConcurrentDictionary<string, ProjectStatusModel> ProjectStatus = new ConcurrentDictionary<string, ProjectStatusModel>();
            internal static ConcurrentDictionary<string, SystemStatusModel> SystemStatus = new ConcurrentDictionary<string, SystemStatusModel>();


        }
    }
}
