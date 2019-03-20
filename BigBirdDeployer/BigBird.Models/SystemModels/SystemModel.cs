using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BigBird.Models.SystemModels
{
    public class SystemModel
    {
        public string IP { get; set; }
        public string Name { get; set; }
        public List<SystemProjectModel> Projects { get; set; }
    }
}
