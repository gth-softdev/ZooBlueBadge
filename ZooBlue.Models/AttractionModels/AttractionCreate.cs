using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBlue.Models
{
    class AttractionCreate
    {
        [Required]
        [Display(Name = "Zoo")]
        public int ZooId { get; set; }
        [Required]
        public List<string> Animals { get; set; }  
        [Required]
        public List<string> Experiences { get; set; }
        public bool HasAquaticExhibit { get; set; }
        public bool HasGarden { get; set; }
        public List<string> SeasonalAttractions { get; set; }
    }
}
