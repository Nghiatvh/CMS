using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace As2.Models
{
    public class Categories
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public TrainingStaff TrainingStaff { get; set; }
        public ICollection<Course> Courses { get; set; }

    }
}
