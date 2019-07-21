using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Models
{
    public class FinalProjectContext : DbContext
    {
        public FinalProjectContext (DbContextOptions<FinalProjectContext> options)
            : base(options)
        {
        }

        public DbSet<FinalProject.Models.Exotic> Exotic { get; set; }

        public DbSet<FinalProject.Models.Muscle> Muscle { get; set; }

        public DbSet<FinalProject.Models.Tuner> Tuner { get; set; }
    }
}
