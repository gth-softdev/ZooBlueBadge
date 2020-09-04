using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBlue.Data
{
    public class Zoo
    {
        [Key]
        public int ZooId { get; set; }
        public string ZooName { get; set; }
        public string Location { get; set; }
        public int ZooSize { get; set; }
        public bool AZAAccredited { get; set; }
        public double AdmissionCost { get; set; }
        public double AvgRating { get; set; }

        public List<string> Attractions { get; set; }
        public List<int> Reviews { get; set; }


    }
}
