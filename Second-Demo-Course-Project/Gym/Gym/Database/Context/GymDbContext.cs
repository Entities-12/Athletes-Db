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

        public virtual  IDbSet<Athlete> Athletes { get; set; }

        public virtual IDbSet<Trainer> Trainers { get; set; }

        public virtual IDbSet<Spot> Spots { get; set; }

        public virtual IDbSet<Workout> Workouts { get; set; }

        public virtual IDbSet<Activity> Activities { get; set; }

    }
}
