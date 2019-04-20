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
        public static class TxConvert
        {
            internal static string IP = "vaselee.com";
            internal static int Port = 52840;
            internal static bool IsConnect = false;
            internal static bool IsAuth = false;

            internal static bool AutoReConnect = true;
            internal static short AutoReConnectInterval = 60;

            internal static DateTime ConnectTime = DateTime.MinValue;
            internal static DateTime LastSendTime = DateTime.MinValue;
            internal static DateTime LastReadTime = DateTime.MinValue;

            internal static short SendQueueInterval = 1;
            internal static short SendQueueErrorInterval = 10;

            internal static TcppClient TcppClient = null;
            internal static string ConnectKey = "BigBird.Converge.201904201215.tcpp";//Tcp通信连接认证密钥
        }
    }
}
