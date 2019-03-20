using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BigBird.Models.ProjectModels
{
    public class ProjectStatusModel
    {
        public string Name { get; set; }
        public int CurrentVersion { get; set; }
        public string IP { get; set; }
        public int Port { get; set; }
        public int Cpu { get; set; }
        public long UseRam { get; set; }
    }
}
