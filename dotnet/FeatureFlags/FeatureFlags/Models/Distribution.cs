using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeatureFlags.Models
{
    public class Distribution
    {
        public int Id { get; set; }

        public int Percent { get; set; }

        public string VariantKey { get; set; }

        public int VariantId { get; set; }
    }
}
