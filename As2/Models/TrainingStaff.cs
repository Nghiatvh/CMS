using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace As2.Models
{
    public class TrainingStaff : Account
    {
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Location { get; set; }
         public ICollection<Categories> Categories { get; set; }
         
    }
}
