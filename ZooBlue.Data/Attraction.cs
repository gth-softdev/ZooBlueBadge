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
        public int AttID { get; set; }
        [Required]
        public List<string> Animals { get; set; }
        [Required]
        public List<string> Experiences { get; set; }
        [Required]
        public bool HasAquaticExhibit { get; set; }
        [Required]
        public bool HasGarden { get; set; }

        public List<string> SeasonalAttractions { get; set; }

        [ForeignKey(nameof(Zoo))]
        public int ZooId { get;}
        public virtual Zoo Zoo { get; set; }
    }
}
