using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace As2.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string NameCourse { get; set; }
        public int CateID { get; set; }
        public Categories Categories { get; set; }
       public ICollection<TraineeCourse>TraineeCourses { get; set; }
        public ICollection<Topic>Topics { get; set; }



    }
}
