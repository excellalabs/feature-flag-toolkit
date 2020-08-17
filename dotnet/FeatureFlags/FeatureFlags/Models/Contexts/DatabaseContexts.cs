using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeatureFlags.Models.Contexts
{
    public class DatabaseContexts : DbContext
    {
        public DbSet<FeatureFlag> FeatureFlags { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Segment> Segments { get; set; }
        public DbSet<Variant> Variants { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=blogging.db");
    }
}
