using Gym.Context;
using Gym.NewDbClientOperatior.Contracts;
using Gym.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Gym.NewDbClientOperatior
{
    public class WorkoutsReader : IDbClientOperatior
    {
        public void OperateEntity()
        {
            using (var context = new GymDbContext())
            {
                var workouts = context.Workouts.ToList();
                workouts.ForEach(w => Console.WriteLine(" WorkoutId: " + w.Id + "\n ActivityId: " + w.ActivityId + "\n SpotId:  " + w.SpotId + "\n TrainerId: " + w.TrainerId + "\n WorkoutStart: " + w.WorkoutStart + "\n WorkoutEnd: " + w.WorkoutEnd + "\n Day: " + w.Day));
                Console.WriteLine(workouts.Count);
            }
        }
    }
}
