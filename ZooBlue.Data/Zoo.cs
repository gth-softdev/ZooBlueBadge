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
        public Review AverageRating { get; }
        public List<Attraction> Attractions { get; }
        public List<Review> Reviews { get; }

    }
}
