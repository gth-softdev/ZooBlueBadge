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

        [Required]
        public string ZooName { get; set; }

        [Required]
        public string Location { get; set; }

        public double ZooSize { get; set; }

        public bool AZAAccredited { get; set; }

        [Required]
        public double Admission { get; set; }

        public double AverageRating
        {
            get
            {
                double totalAverageRating = 0;

                foreach (var rating in AllZooReviews)
                {
                    totalAverageRating += rating.Rating;
                }

                return (AllZooReviews.Count > 0) ? Math.Round(totalAverageRating / AllZooReviews.Count) : 0;
            }
        }

        public virtual ICollection<Attraction> Attractions { get; set; } = new List<Attraction>();
        public virtual ICollection<Review> AllZooReviews { get; set; } = new List<Review>();
    }
}
