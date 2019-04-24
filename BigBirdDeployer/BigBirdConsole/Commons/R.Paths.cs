using Azylee.Core.IOUtils.DirUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BigBirdConsole.Commons
{
    public static partial class R
    {
        public static class Paths
        {
            public static string App = AppDomain.CurrentDomain.BaseDirectory;
            public static string DefaultStorage = DirTool.Combine(App, "Storage");
            public static string DefaultPublishStorage = DirTool.Combine(DefaultStorage, "Publish");
            public static string DefaultNewStorage = DirTool.Combine(DefaultStorage, "New");
            public static string Temp = DirTool.Combine(App, "Temp");

            public static string Settings = DirTool.Combine(App, "Settings");
            public static string Projects = DirTool.Combine(App, "Projects");

            public static string Storage = DefaultStorage;
            public static string PublishStorage = DefaultPublishStorage;
            public static string NewStorage = DefaultNewStorage;

            public static string Store = DirTool.Combine(App, "Store");
            public static string Command = DirTool.Combine(App, "Command");
        }
    }
}
