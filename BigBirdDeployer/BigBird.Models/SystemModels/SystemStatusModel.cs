using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BigBird.Models.SystemModels
{
    public class SystemStatusModel
    {
        public string Name { get; set; }
        public string IP { get; set; }
        public int Cpu { get; set; }
        public long Ram { get; set; }
        public long FreeRam { get; set; }
        public int AppCpu { get; set; }
        public long AppUseRam { get; set; }
        public DateTime NowTime { get; set; }
    }
}
