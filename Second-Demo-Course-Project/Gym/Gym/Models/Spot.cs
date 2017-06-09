using System;
using System.Collections.Generic;
using Gym.Models.Enums;

namespace Gym.Models
{
    public class Spot
    {
        public Spot()
        {
            this.Activities = new HashSet<Activity>();
        }

        public int Id { get; set; }

        public string Address { get; set; }

        public string ContactNumber { get; set; }

        public SpotCapacity Capacity { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }

    }
}
