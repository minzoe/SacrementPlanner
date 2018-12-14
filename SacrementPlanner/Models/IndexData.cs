using System;
using System.Collections.Generic;
using SacrementPlanner.Models;

namespace SacrementPlanner.ViewModels
{
    public class IndexData
    {
        public IEnumerable<Planner> Planners { get; set; }
        public IEnumerable<Speakers> Speakers { get; set; }
    }
}
