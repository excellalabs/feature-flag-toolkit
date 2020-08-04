using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeatureFlags.Models
{
    public class Segment
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public List<Constraint> Constraints { get; set; }

        public int Rank { get; set; }

        public int RolloutPercent { get; set; }
    }
}
