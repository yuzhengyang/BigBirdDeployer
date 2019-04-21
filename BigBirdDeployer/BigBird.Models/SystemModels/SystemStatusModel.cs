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
        public long RamAvail { get; set; }
        public int AppCpu { get; set; }
        public long AppRam { get; set; }
        public DateTime CreateTime { get; set; }
        public long DriveTotal { get; set; }
        public long DriveAvail { get; set; }
    }
}
