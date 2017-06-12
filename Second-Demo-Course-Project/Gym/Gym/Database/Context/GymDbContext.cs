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

        public DbSet<Activity> Activities { get; set; }

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
            modelBuilder.Entity<Workout>()
                .Property(w => w.WorkoutStart)
                .IsOptional();
            modelBuilder.Entity<Workout>()
                .Property(w => w.WorkoutEnd)
                .IsOptional();
            modelBuilder.Entity<Workout>()
                .Property(w => w.TrainerId)
                .IsOptional();
            modelBuilder.Entity<Workout>()
               .Property(w => w.AthleteId)
               .IsOptional();
            modelBuilder.Entity<Workout>()
               .Property(w => w.SpotId)
               .IsOptional();
            modelBuilder.Entity<Workout>()
               .Property(w => w.ActivityId)
               .IsOptional();

        }

    }
}
