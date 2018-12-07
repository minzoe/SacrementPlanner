using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacrementPlanner.Models
{
    public class Speakers
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Topic { get; set; }
        public int PlannerId { get; set; }
    }
}
