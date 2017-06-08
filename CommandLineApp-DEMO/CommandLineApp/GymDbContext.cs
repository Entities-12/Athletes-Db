using CommandLineApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLineApp
{
    public class GymDbContext : DbContext
    {
        public GymDbContext()
            :base("Gym-CourseProject")
        {

        }

        public virtual IDbSet<Athlete> Athletes { get; set; }

        public virtual IDbSet<Company> Companies { get; set; }

        public virtual IDbSet<Trainer> Trainers { get; set; }
    }
}
