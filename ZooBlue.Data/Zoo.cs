using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBlue.Data
{
    public class Zoo
    {

        public int ZooId { get; set; }
        public string ZooName { get; set; }
        public string Location { get; set; }
        public double ZooSize { get; set; }
        public bool AZAAccredited { get; set; }
        public double Admission { get; set; }
        public Review AverageRating { get; }
        public List<Attraction> Attractions { get; }
        public List<Review> Reviews { get; }

    }
}
