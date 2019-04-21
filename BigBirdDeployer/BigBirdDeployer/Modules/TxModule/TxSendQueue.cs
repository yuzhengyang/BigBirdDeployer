using Azylee.Core.DataUtils.StringUtils;
using Azylee.Core.ThreadUtils.SleepUtils;
using BigBirdDeployer.Commons;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BigBirdDeployer.Modules.TxModule
{
    public static class TxSendQueue
    {
        private static bool IsStart = false;
        private static CancellationTokenSource ConnectCancelToken = new CancellationTokenSource();
        private static ConcurrentQueue<Tuple<int, string>> Queue = new ConcurrentQueue<Tuple<int, string>>();
        public static void Start()
        {
            if (!IsStart)
            {
                IsStart = true;
                StartSendQueue();
            }
        }
        public static void Add(int type, string value)
        {
            try
            {
                if (Str.Ok(value) && R.Tx.IsConnect)
                {
                    if (Queue.Any(x => x.Item1 == type && x.Item2 == value))
                    {
                        //R.Log.v($"SocketSendQueue:[{Queue.Count}]:Add:IsExist:" + type + value);
                    }
                    else
                    {
                        Queue.Enqueue(new Tuple<int, string>(type, value));
                        //R.Log.v($"SocketSendQueue:[{Queue.Count}]:Add:OK:" + type + value);
                    }
                }

            }
            catch { R.Log.v($"SocketSendQueue:[{Queue.Count}]:Add:Error"); }
        }
        private static void StartSendQueue()
        {
            //启动任务
            Task.Factory.StartNew(() =>
            {
                //设置退出条件
                while (!ConnectCancelToken.IsCancellationRequested)
                {
                    //如果通信正常，并且队列中存在元素
                    if (R.Tx.IsAuth && Queue.Any())
                    {
                        //循环进行操作
                        for (int i = 0; i < Queue.Count; i++)
                        {
                            try
                            {
                                Tuple<int, string> model = null;
                                if (Queue.TryDequeue(out model))
                                {
                                    //读取成功后，发送相关指令
                                    bool flag = TxHelper.Send(model.Item1, model.Item2);
                                    if (flag)
                                    {
                                        R.Tx.LastSendTime = DateTime.Now;//记录最后一次发送成功时间
                                        //R.Log.v(string.Format("socket send ok : {0} : {1}", model.Item1, model.Item2));
                                    }
                                    else
                                    {
                                        R.Log.v(string.Format("socket send error : {0} : {1}", model.Item1, model.Item2));
                                        //通信失败，延迟等待，跳出当前循环操作
                                        Sleep.S(R.Tx.SendQueueErrorInterval);
                                        break;
                                    }
                                }
                            }
                            catch { }
                        }
                    }
                    Sleep.S(R.Tx.SendQueueInterval);
                }
            });
        }
    }
}
