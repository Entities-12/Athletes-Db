using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gym.Models
{
    public class Workout
    {
        private ICollection<Athlete> athletes;

        public Workout()
        {
            this.athletes = new HashSet<Athlete>();
        }

        [Key]
        public int Id { get; set; }

        public DateTime StartHour { get; set; }

        public DateTime EndHour { get; set; }

        public DayOfWeek Day { get; set; }

        public Activity WorkoutName { get; set; }

        public Trainer Trainer { get; set;  }

        public virtual ICollection<Athlete> Athletes
        {
          get { return this.athletes; }
          set { this.athletes = value; }
        }
    }
}
