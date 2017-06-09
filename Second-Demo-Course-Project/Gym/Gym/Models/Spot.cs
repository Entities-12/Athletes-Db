using System;
using System.Collections.Generic;
using Gym.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Gym.Models
{
    public class Spot
    {
        public Spot()
        {
            this.Activities = new HashSet<Activity>();
        }

        [Key]
        public int Id { get; set; }

        public string Address { get; set; }

        public string ContactNumber { get; set; }

        public SpotCapacity Capacity { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }

    }
}
