using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace As2.Models
{
    public class Topic
    {
        public int ID { get; set; }
        public string NameTopic { get; set; }
        public int CourseID { get; set; }
        public Course Course { get; set; }
        public ICollection<TrainerTopic>TrainerTopics { get; set; }

    }
}
