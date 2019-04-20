using Azylee.Core.DataUtils.StringUtils;
using Azylee.Core.ThreadUtils.SleepUtils;
using Azylee.YeahWeb.SocketUtils.TcpUtils;
using BigBirdConsole.Commons;
using System.Threading.Tasks;

namespace BigBirdConsole.Modules.TxConvertModule
{
    public static class TxConvertHelper
    {
        public static void Connect()
        {
            Task.Factory.StartNew(() =>
            {
                while (R.TxConvert.AutoReConnect)
                {
                    if (Str.Ok(R.TxConvert.IP) && R.TxConvert.Port > 0)
                    {
                        if (R.TxConvert.TcppClient != null && R.TxConvert.IsConnect)
                        { }
                        else
                        {
                            R.TxConvert.TcppClient?.Disconnect();
                            R.TxConvert.TcppClient = new TcppClient(R.TxConvert.IP, R.TxConvert.Port,
                                TxConvertEvent.ReceiveMessage, TxConvertEvent.OnConnect, TxConvertEvent.OnDisconnect);
                            bool a = R.TxConvert.TcppClient.Connect();
                        }
                    }
                    Sleep.S(R.TxConvert.AutoReConnectInterval);
                }
            });
        }
        public static bool Send(TcpDataModel model)
        {
            bool flag = false;
            if (R.TxConvert.TcppClient != null)
            {
                flag = R.TxConvert.TcppClient.Write(model);
            }
            return flag;
        }
    }
}
