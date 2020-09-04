using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBlue.Models.AttractionModels
{
    public class AttractionListItems
    {
        [Display(Name = "Attraction Id")]
        public int AttId { get; set; }

        [Display(Name = "Zoo")]
        public int ZooId { get; set; }

        [Display(Name = "Animals")]
        public List<string> Animals { get; set; }
        [Display(Name = "Experinces")]
        public List<string> Experiences { get; set; }

        [Display(Name = "Aquarium")]
        public bool HasAquaticExhibit {get; set;}

        [Display(Name = "Garden")]
        public bool HasGarden { get; set; }

        [Display(Name = "Seasonal Attractions")]
        public List<string> SeasonalAttractions { get; set; }
       
    }
}
