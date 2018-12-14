using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace SacrementPlanner.Models
{
    public class Planner
    {
        public int ID { get; set; }
        [Display(Name = "Opening Song")]
        [Required]
        public string OpeningSong { get; set; }
        [Display(Name = "Sacrament Song")]
        [Required]
        public string SacramentSong { get; set; }
        [Display(Name = "Intermediate Song")]
        public string IntermediateSong { get; set; }
        [Display(Name = "Closing Song")]
        [Required]
        public string ClosingSong { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Sacrament Date")]
        public DateTime SacramentDate { get; set; }
        [Required]
        [ForeignKey("Bishopric")]
        [Display(Name = "Bishopric")]
        public int BishopricId { get; set; }

        public Bishopric Bishopric { get; set; }       
    }
}
