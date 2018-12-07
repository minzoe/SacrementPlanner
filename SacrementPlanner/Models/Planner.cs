using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacrementPlanner.Models
{
    public class Planner
    {
        public int ID { get; set; }
        public string OpeningSong { get; set; }
        public string SacramentSong { get; set; }
        public string IntermediateSong { get; set; }
        public string ClosingSong { get; set; }
        public DateTime SacramentDate { get; set; }
        public int Conductor { get; set; }
    }
}
