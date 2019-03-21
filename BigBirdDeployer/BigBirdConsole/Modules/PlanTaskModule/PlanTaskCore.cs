using Azylee.Core.ThreadUtils.SleepUtils;
using BigBirdConsole.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBirdConsole.Modules.PlanTaskModule
{
    public class PlanTaskCore
    {
        private static int Runtime = 1;//总运行时长
        public static void Start()
        {
            Once();//一次性任务
            Loop();//启动重复的计划任务
        }
        private static void Once()
        {
            Task.Factory.StartNew(() =>
            {
                PlanTaskOnce.Do();
            });
        }
        private static void Loop()
        {
            Task.Factory.StartNew(() =>
            {
                //Thread.Sleep(Interval);//等待第一分钟
                while (!R.MainUI.IsDisposed)
                {
                    try
                    {
                        // 1 分钟任务
                        if (Runtime % 1 == 0) try { Task.Factory.StartNew(() => { PlanTaskM1.Do(); }); } catch { }
                        // 5 分钟任务
                        if (Runtime % 5 == 0) try { Task.Factory.StartNew(() => { PlanTaskM5.Do(); }); } catch { }
                        // 10 分钟任务
                        if (Runtime % 10 == 0) try { Task.Factory.StartNew(() => { PlanTaskM10.Do(); }); } catch { }
                        // 180 分钟任务（3小时）
                        if (Runtime % 180 == 0) try { Task.Factory.StartNew(() => { PlanTaskM180.Do(); }); } catch { }
                    }
                    catch { }
                    finally
                    {
                        Runtime++;//增加运行时长 
                        Sleep.S(R.TimeInterval.PlanTask);//延迟等待
                    }
                }
            });
        }
    }
}
