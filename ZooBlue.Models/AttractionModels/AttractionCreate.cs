using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBlue.Models
{
   public class AttractionCreate
    {
        [Required]
        [Display(Name = "Zoo")]
        public int ZooId { get; set; }
        [Required]
        public string Animals { get; set; }  
        [Required]
        public string Experiences { get; set; }
        public bool HasAquaticExhibit { get; set; }
        public bool HasGarden { get; set; }
        public string SeasonalAttractions { get; set; }
    }
}
