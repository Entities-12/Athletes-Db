using Gym.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gym.Models
{
    public class Workout : IModel
    {
        public Workout()
        {
            this.Athletes = new HashSet<Athlete>();
        }

        [Key]
        public int Id { get; set; }

        public DateTime StartHour { get; set; }

        public DateTime EndHour { get; set; }

        public DayOfWeek Day { get; set; }

        public Activity SportType { get; set; }

        public virtual ICollection<Athlete> Athletes { get; set; }
    }
}
