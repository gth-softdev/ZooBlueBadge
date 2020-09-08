using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public double AverageRating
        {
            get
            {
                double totalAverageRating = 0;

                foreach (var rating in Reviews)
                {
                    totalAverageRating += rating.Rating;
                }

                return (Reviews.Count > 0) ? totalAverageRating / Reviews.Count : 0;
            }
        }
        public virtual List<Review> Reviews { get; set; } = new List<Review>();
        public List<Attraction> Attractions { get; set; }
        public List<Review> AllZooReviews { get; set; }
    }
}
