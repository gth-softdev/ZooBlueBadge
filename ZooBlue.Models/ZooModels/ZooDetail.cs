using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBlue.Models.ZooModels
{
    public class ZooDetail
    {
        public int ZooId { get; set; }
        public string ZooName { get; set; }
        public string Location { get; set; }
        public double ZooSize { get; set; }
        public bool AZAAccredited { get; set; }
        public double Admission { get; set; }
    }
}
