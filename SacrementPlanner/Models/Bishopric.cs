using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SacrementPlanner.Models
{
    public class Bishopric
    {
        public int ID { get; set; }
        [Display(Name = "Bishopric")]
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
