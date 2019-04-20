using Azylee.Core.IOUtils.TxtUtils;
using Azylee.Jsons;
using BigBirdConverge.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BigBirdConverge.Modules.PlanTaskModule
{
    public class PlanTaskM1
    {
        /// <summary>
        /// 1分钟任务
        /// </summary>
        public static void Do()
        {
            R.Store.Persistence();
        }
    }
}
