using Azylee.Jsons;
using Azylee.YeahWeb.SocketUtils.TcpUtils;
using BigBird.Models.ProjectModels;
using BigBird.Models.SystemModels;
using BigBirdConsole.Commons;
using BigBirdConsole.Modules.TxConvertModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BigBirdConsole.Modules.TxModule
{
    public static class TxFunction
    {
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
                            TxConvertHelper.Send(model);
                            R.Store.AddSystemStatus(model);

                            string data = Json.Byte2Object<string>(model.Data);
                            var status = Json.String2Object<SystemStatusModel>(data);
                            R.MainUI.systemListControl1.AddOrUpdate(status);
                            R.MainUI.txConsoleControl1.Write(host, model.Type, $"{Json.Byte2Object<string>(model.Data)}");
                            break;
                        }
                    //服务信息
                    case 20003000: /* 服务状态 */
                        {
                            //TxHelper.TcppServer.Write(host, 20003000, "~");
                            TxConvertHelper.Send(model);
                            R.Store.AddProjectStatus(model);

                            string data = Json.Byte2Object<string>(model.Data);
                            var status = Json.String2Object<ProjectStatusModel>(data);
                            R.MainUI.projectListControl1.AddOrUpdate(status);
                            R.MainUI.txConsoleControl1.Write(host, model.Type, $"{data}");
                            break;
                        }
                    default:
                        R.MainUI.txConsoleControl1.Write(host, model.Type, $"{model.Data.Length}");
                        break;
                }
            }
        }
    }
}
