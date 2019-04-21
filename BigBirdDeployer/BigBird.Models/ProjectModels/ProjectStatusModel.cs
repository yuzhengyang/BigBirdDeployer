using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BigBird.Models.ProjectModels
{
    public class ProjectStatusModel
    {
        public string Name { get; set; }
        public int Version { get; set; }
        public string IP { get; set; }
        public int Port { get; set; }
        public int Cpu { get; set; }
        public long Ram { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsRun { get; set; }
    }
}
