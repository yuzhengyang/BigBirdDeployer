using Azylee.Jsons;
using Azylee.YeahWeb.SocketUtils.TcpUtils;
using BigBird.Models.ProjectModels;
using BigBird.Models.SystemModels;
using BigBirdConverge.Commons;

namespace BigBirdConverge.Modules.TxModule
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
                            R.Store.AddSystemStatus(model);
                            break;
                        }
                    //服务信息
                    case 20003000: /* 服务状态 */
                        {
                            //TxHelper.TcppServer.Write(host, 20003000, "~");
                            R.Store.AddProjectStatus(model);
                            break;
                        }
                    default: break;
                }
            }
        }
    }
}
