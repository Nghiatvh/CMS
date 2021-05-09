using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace As2.Models
{
    public class TrainerTopic
    {
        public int TrainerID
        {
            get; set;
        }
        public int TopicID
        { get; set;
            
    }
    public Trainer Trainer { get; set; }
    public Topic Topic { get; set; }
}
}
