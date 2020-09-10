using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBlue.Data;

namespace ZooBlue.Models.ZooModels
{
    public class ZooListItems
    {
        public int ZooId { get; set; }
        public string ZooName { get; set; }
        public string Location { get; set; }
        public double ZooSize { get; set; }
        public bool AZAAccredited { get; set; }
        public double Admission { get; set; }
        public double AverageRating { get; set; }
        public List<AttractionDetail> AttractionsDetails { get; set; }
        public List<Review> AllZooReviews { get; set; }
    }
}
