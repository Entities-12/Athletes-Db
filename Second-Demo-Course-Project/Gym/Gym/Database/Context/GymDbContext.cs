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

        public virtual DbSet<Athlete> Athletes { get; set; }

        public virtual DbSet<Trainer> Trainers { get; set; }

        public virtual DbSet<Spot> Spots { get; set; }

        public virtual DbSet<Workout> Workouts { get; set; }

        public virtual DbSet<Activity> Activities { get; set; }


        //Fluent API
        protected override void OnModelCreating(
            DbModelBuilder modelBuilder)
        {
            //Configure default schema
            modelBuilder.HasDefaultSchema("Gym-Second-Demo");

            //Map entity to table
            modelBuilder.Entity<Athlete>().ToTable("Athletes");
            modelBuilder.Entity<Trainer>().ToTable("Trainers");
            modelBuilder.Entity<Spot>().ToTable("Spots");
            modelBuilder.Entity<Workout>().ToTable("Workouts");
            modelBuilder.Entity<Activity>().ToTable("Activities");

            this.OnWorkoutCreating(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void OnWorkoutCreating(
            DbModelBuilder modelBuilder)
        {
            //primary key
            modelBuilder.Entity<Workout>()
                .HasKey<int>(workout => workout.Id);

            //Properties
            modelBuilder.Entity<Workout>()
                .Property(w => w.Day)
                .IsOptional();
              
        }

    }
}
