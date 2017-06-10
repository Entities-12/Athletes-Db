using System;
using System.Collections.Generic;
using Gym.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Gym.Models
{
    public class Spot
    {
        private ICollection<Workout> workouts;
        private ICollection<Trainer> trainers;
      //  private ICollection<Activity> activities;

        public Spot()
        {
            this.workouts = new HashSet<Workout>();
            this.trainers = new HashSet<Trainer>();
          //  this.activities = new HashSet<Activity>();
        }

        [Key]
        public int Id { get; set; }

        public string Address { get; set; }

        public string ContactNumber { get; set; }

        public SpotCapacity Capacity { get; set; }

        public virtual ICollection<Trainer> Trainers
        {
            get { return this.trainers; }
            set { this.trainers = value; }
            
        }

        public virtual ICollection<Workout> Workouts
        {
            get { return this.workouts; }
            set { this.workouts = value; }
        }

        //public virtual ICollection<Activity> Activities
        //{
        //    get { return this.activities; }
        //    set { this.activities = value; }
       // }
    }
}
