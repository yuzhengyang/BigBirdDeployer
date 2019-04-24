using Azylee.Core.DataUtils.CollectionUtils;
using BigBirdConsole.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BigBirdConsole.Modules.TxModule
{
    public static class TxHostMapTool
    {
        /// <summary>
        /// 连接端应用IP对照（Item1：实际地址，Item2：标准地址）
        /// </summary>
        private static List<Tuple<string, string>> HostMap = new List<Tuple<string, string>>();

        public static List<string> GetHost(string ipport)
        {
            List<string> result = new List<string>();
            try
            {
                if (Ls.Ok(R.Tx.Hosts))
                {
                    List<Tuple<string, string>> list = HostMap.Where(x => x.Item2 == ipport).ToList();
                    if (Ls.Ok(list))
                    {
                        foreach (var item in list)
                        {
                            result.Add(item.Item1);
                        }
                    }
                }
            }
            catch { }
            return result;
        }

        public static void AddHost(string host, string ipport)
        {
            if (!HostMap.Any(x => x.Item1 == host && x.Item2 == ipport))
            {
                HostMap.Add(new Tuple<string, string>(host, ipport));
            }
        }
        public static void DelHost(string host)
        {
            try
            {
                HostMap.RemoveAll(x => x.Item1 == host);
            }
            catch { }
        }
    }
}
