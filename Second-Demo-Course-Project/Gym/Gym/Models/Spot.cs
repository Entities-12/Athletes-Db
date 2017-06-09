using System;
using System.Collections.Generic;
using Gym.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Gym.Models
{
    public class Spot
    {
        private ICollection<Workout> workouts;

        public Spot()
        {
            this.workouts = new HashSet<Workout>();
        }

        [Key]
        public int Id { get; set; }

        public string Address { get; set; }

        public string ContactNumber { get; set; }

        public SpotCapacity Capacity { get; set; }

        public virtual ICollection<Workout> Workouts
        {
            get { return this.workouts; }
            set { this.workouts = value; }
        }

    }
}
