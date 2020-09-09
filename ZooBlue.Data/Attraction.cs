using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBlue.Data
{
   public class Attraction
    {
        [Key]
        public int AttId { get; set; }
        [Required]
        public string Animals { get; set; }
        [Required]
        public string Experiences { get; set; }
        [Required]
        public bool HasAquaticExhibit { get; set; }
        [Required]
        public bool HasGarden { get; set; }

        public string SeasonalAttractions { get; set; }

        [ForeignKey(nameof(Zoo))]
        public int ZooId { get; set; }
        public virtual Zoo Zoo { get; set; }
    }
}
