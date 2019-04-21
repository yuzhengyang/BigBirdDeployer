using Azylee.Core.IOUtils.DirUtils;
using Azylee.YeahWeb.SocketUtils.TcpUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BigBirdDeployer.Commons
{
    public static partial class R
    {
        public static class Tx
        {
            internal static string LocalIP = "";
            internal static string LocalName = "";

            internal static string IP = "";
            internal static int Port = 0;
            internal static bool IsConnect = false;
            internal static bool IsAuth = false;

            internal static bool AutoReConnect = true;
            internal static short AutoReConnectInterval = 10; 

            internal static DateTime ConnectTime = DateTime.MinValue;
            internal static DateTime LastSendTime = DateTime.MinValue;
            internal static DateTime LastReadTime = DateTime.MinValue;

            internal static short SendQueueInterval = 1;
            internal static short SendQueueErrorInterval = 10;

            internal static TcppClient TcppClient = null;
            internal static string ConnectKey = "BigBird.Deployer.201903151446.tcpp";//Tcp通信连接认证密钥

        }
    }
}
