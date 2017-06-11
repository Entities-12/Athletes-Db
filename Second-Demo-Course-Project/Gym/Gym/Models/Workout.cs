using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gym.Models
{
    public class Workout
    {

        public Workout(){}

        [Key]
        public int Id { get; set; }

        public string WorkoutStart { get; set; }

        public string WorkoutEnd { get; set; }

        public DayOfWeek Day { get; set; }

        //[ForeignKey("Activity")]
        //public int ActivityId { get; set; }
        //[ForeignKey("Trainer")]
        //public int TrainerId { get; set; }
        //[ForeignKey("Spot")]
        //public int SpotId { get; set; }
        //[ForeignKey("Athlete")]
        //public int AthleteId { get; set; }

        
        public virtual Activity Activity { get; set; }
        
        public virtual Trainer Trainer { get; set; }
        
        public virtual Spot Spot { get; set;  }
        
        public virtual Athlete Athlete { get; set; }

    }
}
