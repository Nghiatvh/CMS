using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace As2.Models
{
    public class Trainee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Education { get; set; }
        public ICollection<TraineeCourse>TraineeCourses { get; set; }

    }
}
