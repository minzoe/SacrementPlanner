using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SacrementPlanner.Models
{
    public class BulletinContext : DbContext
    {
        public BulletinContext (DbContextOptions<BulletinContext> options)
            : base(options)
        {
        }

        public DbSet<Planner> Planner { get; set; }
        public DbSet<Bishopric> Bishoprics { get; set; }
        public DbSet<Speakers> Speakers { get; set; }
    }
}
