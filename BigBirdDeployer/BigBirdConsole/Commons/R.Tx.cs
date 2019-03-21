using Azylee.YeahWeb.SocketUtils.TcpUtils;
using BigBird.Models.ProjectModels;
using BigBird.Models.SystemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BigBirdConsole.Commons
{
    public static partial class R
    {
        public static class Tx
        {
            internal static int TcppPort = 52830;
            internal static TcppServer TcppServer = null;
            internal static List<string> Hosts = new List<string>();
            internal static string ConnectKey = "BigBird.Deployer.201903151446.tcpp";//Tcp通信连接认证密钥
            internal static List<ProjectStatusModel> ProjectStatusList = new List<ProjectStatusModel>();
            internal static List<SystemStatusModel> SystemStatusList = new List<SystemStatusModel>();

            internal static short ReadQueueInterval = 1;
        }
    }
}
