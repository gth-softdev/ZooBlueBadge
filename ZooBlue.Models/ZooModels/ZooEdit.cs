using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBlue.Models.ZooModels
{
    public class ZooEdit
    {
        [Required]
        public int ZooId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(150, ErrorMessage = "There are too many characters in this field.")]
        public string ZooName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(150, ErrorMessage = "There are too many characters in this field.")]
        public string Location { get; set; }

        public double ZooSize { get; set; }
         
        public bool AZAAccredited { get; set; }

        [Required]
        public double Admission { get; set; }
    }
}
