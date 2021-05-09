using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace As2.Models
{
    public class TraineeCourse
    {
        public int TraineeID { get; set; }
        public int CourseID { get; set; }
        public Course Course { get; set; }
        public Trainee Trainee { get; set; }
        
    }
}
