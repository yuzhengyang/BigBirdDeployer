using Azylee.Core.DataUtils.StringUtils;
using Azylee.Core.ProcessUtils;
using Azylee.Core.WindowsUtils.AdminUtils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBirdDeployer.Modules.CMDModule
{
    public static class CMDHelper
    {
        /// <summary>
        /// 开始运行CMD命令
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="output">输出动作</param>
        public static void Execute(string cmd, Action<string> output)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = @"/c C:\Windows\System32\cmd.exe";
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            Process process = new Process();
            process.StartInfo = startInfo;
            
            StreamReader outReader = null;
            StreamReader errReader = null;
            try
            {
                process.Start();
                process.StandardInput.AutoFlush = true;
                process.StandardInput.WriteLine(cmd);
                process.StandardInput.WriteLine("exit");
                outReader = process.StandardOutput;
                errReader = process.StandardError;

                ReaderAction(outReader, output);
                ReaderAction(errReader, output);

                process.WaitForExit();
                process.Close();
            }
            catch { }
        }
        private static void ReaderAction(StreamReader reader, Action<string> output)
        {
            try
            {
                Task.Factory.StartNew(() =>
                {
                    do
                    {
                        string line = reader.ReadLine();
                        output?.Invoke(line);
                    } while (!reader.EndOfStream);
                    string s = "reader process is end";
                });
            }
            catch { }
        }
    }
}
