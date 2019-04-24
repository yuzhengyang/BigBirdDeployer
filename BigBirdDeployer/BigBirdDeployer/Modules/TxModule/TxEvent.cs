using Azylee.Jsons;
using Azylee.YeahWeb.SocketUtils.TcpUtils;
using BigBirdDeployer.Commons;
using BigBirdDeployer.Modules.CleanerModule;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BigBirdDeployer.Modules.TxModule
{
    public static class TxEvent
    {
        /// <summary>
        /// 已连接
        /// </summary>
        /// <param name="host"></param>
        public static void OnConnect(string host)
        {
            R.Tx.IsConnect = true;
            R.Tx.TcppClient.Write(new TcpDataModel()
            {
                Type = 10001000,
                Data = Json.Object2Byte(R.Tx.ConnectKey)
            });
        }
        /// <summary>
        /// 已断开
        /// </summary>
        /// <param name="host"></param>
        public static void OnDisconnect(string host)
        {
            R.Tx.IsConnect = false;
            R.Tx.IsAuth = false;
            R.MainUI.UITxStatus();
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
                    R.Tx.IsAuth = true;
                    R.Tx.ConnectTime = DateTime.Now;
                    R.MainUI.UITxStatus();
                    TxSendQueue.Start();
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

                //指令操作
                case 40001000: /* 清除过期日志 */
                    R.Log.I("收到指令操作：40001000：清除过期日志：15天之前日志");
                    LogCleaner.CleanLogFile();
                    break;
                case 40002000: /* 重启服务 */
                    try
                    {
                        R.Log.I("收到指令操作：40002000：重启服务");
                        string ss = Json.Byte2Object<string>(model.Data);
                        Tuple<string, int> info = Json.String2Object<Tuple<string, int>>(ss);
                        if (R.Tx.LocalIP == info.Item1 && R.ProjectItems.Any(x => x.Port == info.Item2))
                        {
                            Parts.ProjectItemPart item = R.ProjectItems.FirstOrDefault(x => x.Port == info.Item2);
                            if (item != null)
                            {
                                item.Restart();
                            }
                        }
                    }
                    catch { }
                    break;

                default: break;
            }
        }
    }
}
