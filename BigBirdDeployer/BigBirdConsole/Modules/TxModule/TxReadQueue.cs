using Azylee.Core.DataUtils.StringUtils;
using Azylee.Core.ThreadUtils.SleepUtils;
using Azylee.YeahWeb.SocketUtils.TcpUtils;
using BigBirdConsole.Commons;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BigBirdConsole.Modules.TxModule
{
    public static class TxReadQueue
    {
        private static bool IsStart = false;
        private static CancellationTokenSource ConnectCancelToken = new CancellationTokenSource();
        private static ConcurrentQueue<Tuple<string, TcpDataModel>> Queue = new ConcurrentQueue<Tuple<string, TcpDataModel>>();
        public static void Start()
        {
            if (!IsStart)
            {
                IsStart = true;
                StartReadQueue();
            }
        }
        public static void Add(string host, TcpDataModel model)
        {
            try
            {
                Queue.Enqueue(new Tuple<string, TcpDataModel>(host, model));
            }
            catch { R.Log.v($"SocketReadQueue:[{Queue.Count}]:Add:Error"); }
        }
        private static void StartReadQueue()
        {
            //启动任务
            Task.Factory.StartNew(() =>
            {
                //设置退出条件
                while (!ConnectCancelToken.IsCancellationRequested)
                {
                    //如果队列中存在元素
                    if (Queue.Any())
                    {
                        //循环进行操作
                        for (int i = 0; i < Queue.Count; i++)
                        {
                            try
                            {
                                Tuple<string, TcpDataModel> model = null;
                                if (Queue.TryDequeue(out model))
                                {
                                    //读取成功后，进行相关处理
                                    TxFunction.ExecuteMessage(model.Item1, model.Item2);
                                }
                            }
                            catch { }
                        }
                    }
                    Sleep.S(R.Tx.ReadQueueInterval);
                }
            });
        }
    }
}
