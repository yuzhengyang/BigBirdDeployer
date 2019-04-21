using Azylee.Core.DataUtils.StringUtils;
using Azylee.Core.IOUtils.DirUtils;
using Azylee.Core.IOUtils.TxtUtils;
using Azylee.Jsons;
using Azylee.YeahWeb.SocketUtils.TcpUtils;
using BigBird.Models.ProjectModels;
using BigBird.Models.SystemModels;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace BigBirdConsole.Commons
{
    public static partial class R
    {
        public static class Store
        {
            internal static ConcurrentDictionary<string, ProjectStatusModel> ProjectStatus = new ConcurrentDictionary<string, ProjectStatusModel>();
            internal static ConcurrentDictionary<string, SystemStatusModel> SystemStatus = new ConcurrentDictionary<string, SystemStatusModel>();
            public static void AddSystemStatus(TcpDataModel model)
            {
                try
                {
                    //TxHelper.TcppServer.Write(host, 20002000, "~");
                    string data = Json.Byte2Object<string>(model.Data);
                    var status = Json.String2Object<SystemStatusModel>(data);
                    if (Str.Ok(status.IP))
                    {
                        if (R.Store.SystemStatus.TryGetValue(status.IP, out SystemStatusModel _status))
                        {
                            bool a = R.Store.SystemStatus.TryUpdate(status.IP, status, _status);
                        }
                        else
                        {
                            bool b = R.Store.SystemStatus.TryAdd(status.IP, status);
                        }
                    }
                }
                catch { }
            }
            public static void AddProjectStatus(TcpDataModel model)
            {
                try
                {
                    //TxHelper.TcppServer.Write(host, 20003000, "~");
                    string data = Json.Byte2Object<string>(model.Data);
                    var status = Json.String2Object<ProjectStatusModel>(data);
                    if (Str.Ok(status.IP, status.Port.ToString()))
                    {
                        string key = $"{status.IP}-{status.Port}";
                        if (R.Store.ProjectStatus.TryGetValue(key, out ProjectStatusModel _status))
                        {
                            bool a = R.Store.ProjectStatus.TryUpdate(key, status, _status);
                        }
                        else
                        {
                            bool b = R.Store.ProjectStatus.TryAdd(key, status);
                        }
                    }
                }
                catch { }
            }
            public static void Persistence()
            {
                DirTool.Create(R.Paths.Store);

                List<SystemStatusModel> ssm = new List<SystemStatusModel>();
                List<ProjectStatusModel> psm = new List<ProjectStatusModel>();

                foreach (var item in SystemStatus.ToArray()) ssm.Add(item.Value);
                foreach (var item in ProjectStatus.ToArray()) psm.Add(item.Value);
                
                string ss = Json.Object2String(ssm);
                string ps = Json.Object2String(psm);

                bool ss_flag = TxtTool.Create(R.Files.SystemStatus, ss);
                bool ps_flag = TxtTool.Create(R.Files.ProjectStatus, ps);
            }
        }
    }
}
