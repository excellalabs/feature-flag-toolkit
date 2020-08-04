using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeatureFlags.Models
{
    public class Variant
    {
        public int Id { get; set; }

        public string Key { get; set; }

        public object Attachment { get; set; }
    }
}
