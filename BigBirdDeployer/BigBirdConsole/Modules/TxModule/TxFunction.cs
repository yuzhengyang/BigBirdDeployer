using Azylee.Core.IOUtils.BinaryUtils;
using Azylee.Jsons;
using Azylee.YeahWeb.SocketUtils.TcpUtils;
using BigBird.Models.ProjectModels;
using BigBird.Models.SystemModels;
using BigBirdConsole.Commons;
using BigBirdConsole.Modules.TxConvertModule;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                            TxConvertHelper.Send(model);//转发给上游服务
                            string data = Json.Byte2Object<string>(model.Data);
                            var status = Json.String2Object<SystemStatusModel>(data);

                            R.Store.AddSystemStatus(status);
                            TxHostMapTool.AddHost(host, $"{status.IP}");
                            R.MainUI.systemListControl1.AddOrUpdate(status);
                            R.MainUI.txConsoleControl1.Write(host, model.Type, $"{Json.Byte2Object<string>(model.Data)}");
                            break;
                        }
                    //服务信息
                    case 20003000: /* 服务状态 */
                        {
                            TxConvertHelper.Send(model);//转发给上游服务
                            string data = Json.Byte2Object<string>(model.Data);
                            var status = Json.String2Object<ProjectStatusModel>(data);

                            R.Store.AddProjectStatus(status);
                            R.MainUI.projectListControl1.AddOrUpdate(status);
                            R.MainUI.txConsoleControl1.Write(host, model.Type, $"{data}");
                            break;
                        }
                    //程序更新
                    case 90001000:
                        {
                            Task.Factory.StartNew(() =>
                            {
                                try
                                {
                                    string fire = Json.Byte2Object<string>(model.Data);
                                    if (File.Exists(R.AppointFile))
                                    {
                                        byte[] data = BinaryFileTool.read(R.AppointFile);
                                        R.Tx.TcppServer.Write(host, 90002000, data);
                                    }
                                }
                                catch { }
                            });
                        }
                        break;
                    case 90002000: { } break;
                    default:
                        R.MainUI.txConsoleControl1.Write(host, model.Type, $"{model.Data.Length}");
                        break;
                }
            }
        }
    }
}
