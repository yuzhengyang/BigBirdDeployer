using Azylee.Core.LogUtils.SimpleLogUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Oreo.BigBirdDeployer.Commons
{
    public static partial class R
    {
        internal static string AppName = "Oreo.BigBirdDeployer";
        internal static DateTime StartTime = DateTime.Now;
        internal static string MachineName = Environment.MachineName;
        internal static Module Module = Assembly.GetExecutingAssembly().GetModules()[0];
        internal static Log Log { get; set; }
        internal static string AesKey = "12345678901234567890123456789012";
        internal static string HighlightKeyword = "";
        internal static string[] HighlightKeywords
        {
            get
            {
                try
                {
                    return HighlightKeyword.Trim()
                        .Replace('，', ',')//替换中文逗号[，]
                        .Replace('；', ',')//替换中文分号[；]
                        .Replace('。', ',')//替换中文句号[。]
                        .Replace(';', ',')//替换英文分号[;]
                        .Replace(' ', ',')//替换空格（1次）[ ]
                        .Replace(' ', ',')//替换空格（2次）[ ]
                        .Split(',');//按英文逗号分隔高亮关键字[,]
                }
                catch { return null; }
            }
        }
    }
}
