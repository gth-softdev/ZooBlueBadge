using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBlue.Models.AttractionModels
{
    public class AttractionEdit
    {
        [Required]
        public int AttId { get; set; }
        [Required]
        [Display(Name = "Zoo")]
        public int ZooId { get; set; }

        public string Animals { get; set; }
        public string Experiences { get; set; }
        public bool HasAquaticExhibit { get; set; }
        public bool HasGarden { get; set; }
        public string SeasonalAttractions {get; set;}
    }
}
