using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeatureFlags.Models
{
    public class Constraint
    {
        public int Id { get; set; }

        public string Property { get; set; }

        public string Operator { get; set; }

        public string Value { get; set; }
    }
}
