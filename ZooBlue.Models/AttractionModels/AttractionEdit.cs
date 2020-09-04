using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBlue.Models.AttractionModels
{
    class AttractionEdit
    {
        [Required]
        public int AttId { get; set; }
        [Required]
        [Display(Name = "Zoo")]
        public int ZooId { get; set; }

        public List<string> Animals { get; set; }
        public List<string> Experiences { get; set; }
        public bool HasAquaticExhibit { get; set; }
        public bool HasGarden { get; set; }
        public List<string> SeasonalAttractions {get; set;}
    }
}
