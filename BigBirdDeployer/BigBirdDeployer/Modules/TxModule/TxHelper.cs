using Azylee.Core.DataUtils.StringUtils;
using Azylee.Core.ThreadUtils.SleepUtils;
using Azylee.YeahWeb.SocketUtils.TcpUtils;
using BigBirdDeployer.Commons;
using System.Threading.Tasks;

namespace BigBirdDeployer.Modules.TxModule
{
    public static class TxHelper
    {
        public static void Connect()
        {
            Task.Factory.StartNew(() =>
            {
                while (R.Tx.AutoReConnect)
                {
                    if (Str.Ok(R.Tx.IP) && R.Tx.Port > 0)
                    {
                        if (R.Tx.TcppClient != null && R.Tx.IsConnect)
                        { }
                        else
                        {
                            R.Tx.TcppClient?.Disconnect();
                            R.Tx.TcppClient = new TcppClient(R.Tx.IP, R.Tx.Port,
                                TxEvent.ReceiveMessage, TxEvent.OnConnect, TxEvent.OnDisconnect);
                            R.Tx.TcppClient.Connect();
                        }
                    }
                    Sleep.S(R.Tx.AutoReConnectInterval);
                }
            });
        }
        public static bool Send(int type, string s)
        {
            bool flag = false;
            if (R.Tx.TcppClient != null)
            {
                flag = R.Tx.TcppClient.Write(type, s);
            }
            return flag;
        }
    }
}
