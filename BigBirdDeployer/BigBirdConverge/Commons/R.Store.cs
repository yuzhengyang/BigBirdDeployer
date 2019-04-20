using Azylee.Core.DataUtils.StringUtils;
using Azylee.Core.IOUtils.DirUtils;
using Azylee.Core.IOUtils.TxtUtils;
using Azylee.Jsons;
using Azylee.YeahWeb.SocketUtils.TcpUtils;
using BigBird.Models.ProjectModels;
using BigBird.Models.SystemModels;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace BigBirdConverge.Commons
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
                TxtTool.Create(R.Files.SystemStatus, Json.Object2String(SystemStatus));
                TxtTool.Create(R.Files.ProjectStatus, Json.Object2String(ProjectStatus));
            }
        }
    }
}
