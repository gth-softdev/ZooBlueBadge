using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBlue.Data;

namespace ZooBlue.Models.ReviewModels
{
    public class ReviewEdit
    {
        [Required]
        public int ReviewId { get; set; }

        public string ReviewText { get; set; }
        public int Rating { get; set; }
        public bool IsRecommended { get; set; }

        [Required]
        [ForeignKey(nameof(Zoo))]
        public int ZooId { get; set; }
        public virtual Zoo Zoo { get; set; }
        //public ApplicationUser Author { get; set; }


    }
}
