using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBlue.Models
{
    public class ReviewDetail
    {
        public int ReviewId { get; set; }
        public string ReviewText { get; set; }
        public int Rating { get; set; }
        public int ZooId { get; set; }

        [Display(Name = "Created")]
        public DateTime VisitDate { get; set; }
    }
}
