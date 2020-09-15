using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBlue.Models
{
    public class ReviewListItem
    {
        public int ReviewId { get; set; }
        public string ReviewText { get; set; }


        [Display(Name = "Created")]
        public DateTime VisitDate { get; set; }
    
    }
}
