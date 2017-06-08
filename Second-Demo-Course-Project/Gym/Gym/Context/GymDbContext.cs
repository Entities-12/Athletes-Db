using Gym.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Context
{
    public class GymDbContext : DbContext
    {
        public GymDbContext() 
            : base("Gym-Second-Demo") { }

        public DbSet<Athlete> Athletes { get; set; }

        public DbSet<Trainer> Trainers { get; set; }

        public DbSet<Spot> Spots { get; set; }

        public DbSet<Workout> Workouts { get; set; }

    }
}
