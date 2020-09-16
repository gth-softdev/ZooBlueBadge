using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBlue.Data;

namespace ZooBlue.Models
{
   public class AttractionCreate
    {
        [Required]
        [ForeignKey(nameof(Zoo))]
        public int ZooId { get; set; }
   public virtual Zoo Zoo { get; set; }
        [Required]
        public string Animals { get; set; }  
        [Required]
        public string Experiences { get; set; }
        public bool HasAquaticExhibit { get; set; }
        public bool HasGarden { get; set; }
        public string SeasonalAttractions { get; set; }
    }
}
