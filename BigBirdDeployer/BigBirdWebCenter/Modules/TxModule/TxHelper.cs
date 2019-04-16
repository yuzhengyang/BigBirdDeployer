using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.WindowsUtils.CMDUtils;
using Azylee.Jsons;
using Azylee.YeahWeb.SocketUtils.TcpUtils;
using BigBird.Models.ProjectModels;
using BigBird.Models.SystemModels;
using BigBirdWebCenter.Commons;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BigBirdWebCenter.Modules.TxModule
{
    public static class TxHelper
    {
        public static void Start()
        {
            Task.Factory.StartNew(() =>
            {
                List<int> ports = CMDNetstatTool.GetAvailablePorts(10, 52830);
                if (Ls.Ok(ports))
                {
                    foreach (var p in ports)
                    {
                        try
                        {
                            R.Tx.TcppPort = p;
                            R.Tx.TcppServer = new TcppServer(R.Tx.TcppPort, ReceiveMessage,
                                        OnConnect, OnDisconnect);
                            R.Tx.TcppServer.Start();//启动 Socket Tcp 通信机制
                            break;
                        }
                        catch { }
                    }
                }
            });
        }
        /// <summary>
        /// 已连接
        /// </summary>
        /// <param name="host"></param>
        public static void OnConnect(string host)
        {
        }
        /// <summary>
        /// 已断开
        /// </summary>
        /// <param name="host"></param>
        public static void OnDisconnect(string host)
        {
            if (R.Tx.Hosts.Contains(host))
            {
                R.Tx.Hosts.Remove(host);
                //R.MainUI.UIConnectCount(R.Tx.Hosts.Count);
            }
        }
        /// <summary>
        /// 接受消息
        /// </summary>
        /// <param name="host"></param>
        /// <param name="model"></param>
        public static void ReceiveMessage(string host, TcpDataModel model)
        {
            if (model == null) return;
            if (R.Tx.Hosts.Contains(host))
            {
                TxReadQueue.Add(host, model);
            }
            else
            {
                if (model.Type == 10001000)
                    Authentication(host, model);//身份认证
            }
        }
        /// <summary>
        /// 身份认证
        /// </summary>
        /// <param name="host"></param>
        /// <param name="model"></param>
        public static void Authentication(string host, TcpDataModel model)
        {
            string key = Json.Byte2Object<string>(model.Data);
            if (key == R.Tx.ConnectKey)
            {
                if (!R.Tx.Hosts.Contains(host))
                {
                    R.Tx.Hosts.Add(host);
                    //R.MainUI.UIConnectCount(R.Tx.Hosts.Count);
                    R.Tx.TcppServer.Write(host, 10001000, key);
                }
            }
        }
        /// <summary>
        /// 运行消息
        /// </summary>
        /// <param name="host"></param>
        /// <param name="model"></param>
        public static void ExecuteMessage(string host, TcpDataModel model)
        {
            if (R.Tx.Hosts.Contains(host))
            {
                switch (model.Type)
                {
                    //应答信息
                    case 20001000: /* 普通应答 */
                        R.Tx.TcppServer.Write(host, 20001000, "~");
                        break;
                    //系统状态
                    case 20002000: /* 系统状态 */
                        {
                            //TxHelper.TcppServer.Write(host, 20002000, "~");
                            string data = Json.Byte2Object<string>(model.Data);
                            var status = Json.String2Object<SystemStatusModel>(data);
                            R.Store.SystemStatus.Enqueue(status);
                            break;
                        }
                    //服务信息
                    case 20003000: /* 服务状态 */
                        {
                            //TxHelper.TcppServer.Write(host, 20003000, "~");
                            string data = Json.Byte2Object<string>(model.Data);
                            var status = Json.String2Object<ProjectStatusModel>(data);
                            R.Store.ProjectStatus.Enqueue(status);
                            break;
                        }
                    default:
                        break;
                }
            }
        }

    }
}
