using Azylee.Jsons;
using Azylee.YeahWeb.SocketUtils.TcpUtils;
using BigBirdConsole.Commons;
using System;

namespace BigBirdConsole.Modules.TxConvertModule
{
    public static class TxConvertEvent
    {
        /// <summary>
        /// 已连接
        /// </summary>
        /// <param name="host"></param>
        public static void OnConnect(string host)
        {
            R.TxConvert.IsConnect = true;
            R.TxConvert.TcppClient.Write(new TcpDataModel()
            {
                Type = 10001000,
                Data = Json.Object2Byte(R.TxConvert.ConnectKey)
            });
        }
        /// <summary>
        /// 已断开
        /// </summary>
        /// <param name="host"></param>
        public static void OnDisconnect(string host)
        {
            R.TxConvert.IsConnect = false;
            R.TxConvert.IsAuth = false;
        }
        /// <summary>
        /// 接受消息
        /// </summary>
        /// <param name="host"></param>
        /// <param name="model"></param>
        public static void ReceiveMessage(string host, TcpDataModel model)
        {
            switch (model.Type)
            {
                case 10001000:
                    R.TxConvert.IsAuth = true;
                    R.TxConvert.ConnectTime = DateTime.Now;
                    break;

                //状态信息
                case 20001000: /* 普通应答 */
                    break;
                case 20001001: /* 状态 */
                    //R.MainUI.UIStatus(model);
                    break;
                case 20001002: /* 状态（二维码） */
                    break;

                case 20002000:
                    //R.MainUI.UILog(Json.Byte2Object<string>(model.Data));
                    break;
                case 20003000:
                    //R.MainUI.UIScreen(model);
                    break;

                case 20004000: /* 系统信息 */
                    //R.MainUI.UIInfo(model);
                    break;
                case 20004001: /* 软件信息 */
                    //R.MainUI.UIInfo(model);
                    break;
                case 20004002: /* 硬件信息 */
                    //R.MainUI.UIInfo(model);
                    break;
                case 20004003: /* 共享信息 */
                    //R.MainUI.UIInfo(model);
                    break;
                case 20004004: /* APP信息 */
                    //R.MainUI.UIInfo(model);
                    break;
                case 30001000:
                    //R.MainUI.UIConsole(Json.Byte2Object<List<string>>(model.Data));
                    break;

                default: break;
            }
        }
    }
}
