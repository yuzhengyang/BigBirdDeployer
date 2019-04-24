using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.DataUtils.StringUtils;
using Azylee.Core.IOUtils.FileUtils;
using Azylee.Core.IOUtils.TxtUtils;
using Azylee.Core.ThreadUtils.SleepUtils;
using Azylee.Jsons;
using BigBirdConsole.Commons;
using BigBirdConsole.Modules.TxModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBirdConsole.Modules.CommandModule
{
    public static class CommandReader
    {
        //[Command]
        //IP=127.0.0.1
        //Port=8001
        //Type=40002000
        //Data={"Item1":"127.0.0.1","Item2":8001}

        public static void Start()
        {
            Task.Factory.StartNew(() =>
            {
                while (!R.MainUI.IsDisposed)
                {
                    if (Ls.Ok(R.Tx.Hosts))
                    {
                        List<string> cmd_files = FileTool.GetAllFile(R.Paths.Command, new[] { "*.cmd.ini" });
                        string tuple_string = Json.Object2String(new Tuple<string, int>("abc", 123));
                        if (Ls.Ok(cmd_files))
                        {
                            foreach (var file in cmd_files)
                            {
                                string ip = IniTool.GetString(file, "Command", "IP", "");
                                int port = IniTool.GetInt(file, "Command", "Port", 0);
                                int type = IniTool.GetInt(file, "Command", "Type", 0);
                                string data = IniTool.GetString(file, "Command", "Data", "");

                                if (Str.Ok(ip) && port > 0 && type > 0)
                                {
                                    List<string> hosts = TxHostMapTool.GetHost($"{ip}:{port}");
                                    if (Ls.Ok(hosts))
                                    {
                                        foreach (var host in hosts)
                                        {
                                            Tuple<string, int> info = new Tuple<string, int>(ip, port);
                                            string ss = Json.Object2String(info);
                                            R.Tx.TcppServer.Write(host, type, Json.Object2Byte(ss));
                                        }
                                    }
                                }
                                FileTool.Delete(file);
                            }
                        }
                    }
                    Sleep.S(10);
                }
            });
        }
    }
}
