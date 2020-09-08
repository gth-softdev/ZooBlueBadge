using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBlue.Models
{
    public class AttractionDetail
    {
        [Display(Name = "Zoo")]
        public string ZooName { get; set; }
        public int ZooId {get; set;}
        public int Attid { get; set; }
        public List<string> Animals { get; set; }
        public List<string> Experiences { get; set; }
        public bool HassAquaticExhibit { get; set; }
        public bool HasGarden { get; set; }
        public List<string> SeasonalAttractions { get; set; }
    }
}
