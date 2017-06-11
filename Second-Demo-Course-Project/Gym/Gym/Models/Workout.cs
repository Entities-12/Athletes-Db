using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        //Foreign keys
         // public int TrainerID { get; set; }

        //   public int ActivityID { get; set; }

        //   public int SpotID { get; set; }

        //   public int AthleteID { get; set; }

        //WorkoutName
        public virtual Activity Activity { get; set; }

        public virtual Trainer Trainer { get; set; }

        public virtual Spot Spot { get; set;  }

        public virtual Athlete Athlete { get; set; }

    }
}
