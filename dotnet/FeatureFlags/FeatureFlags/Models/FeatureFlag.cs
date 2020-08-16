using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeatureFlags.Models
{
    public class FeatureFlag
    {
        public int Id { get; set; }

        public string Key { get; set; }

        public string Description { get; set; }

        public bool Enabled { get; set; }

        public List<Tag> Tags { get; set; }

        public List<Segment> Segments { get; set; }

        public List<Variant> Variants { get; set; }

        public bool DataRecordsEnabled { get; set; }

        public string EntityType { get; set; }

        public string Notes { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }
}
}
