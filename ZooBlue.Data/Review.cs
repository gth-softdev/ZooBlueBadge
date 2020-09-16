using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBlue.Data
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public int Rating { get; set; }
        public string ReviewText { get; set; }
        public DateTime VisitDate { get; set; }


        [ForeignKey(nameof(Zoo))]
        public int ZooId { get; set; }
        public virtual Zoo Zoo { get; set; }


        public bool IsRecommended { get; set; }



    }
}
