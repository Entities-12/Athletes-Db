using System;
using System.Collections.Generic;

namespace Gym.Models
{
    public class Workout
    {
        public Workout()
        {
            this.Athletes = new HashSet<Athlete>();
        }

        public int Id { get; set; }

        public DateTime StartHour { get; set; }

        public DateTime EndHour { get; set; }

        public DayOfWeek Day { get; set; }

        public Activity SportType { get; set; }

        public virtual ICollection<Athlete> Athletes { get; set; }
    }
}
