using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace As2.Models
{
    public class Trainer : Account
    {
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Education { get; set; }
        public string WorkingPlace { get; set; }
        public ICollection<TrainerTopic>TrainerTopics { get; set; }

    }
}
