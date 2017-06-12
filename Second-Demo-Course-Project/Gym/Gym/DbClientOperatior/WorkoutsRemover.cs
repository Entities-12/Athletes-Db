using Gym.Context;
using Gym.DbClientOperatior.Contracts;
using Gym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.DbClientOperatior
{
    public class WorkoutsRemover : IDbClientOperatior
    {
        public WorkoutsRemover() { }
        public void OperateEntity()
        {
            
            Workout workoutToDelete;

            Console.WriteLine("Provide workoutId");
            var workoutId = Convert.ToInt32(Console.ReadLine());
                    
            using (var context = new GymDbContext())
            {
                workoutToDelete = context.Workouts.Where(w =>w.Id  == workoutId).FirstOrDefault();

                context.Workouts.Remove(workoutToDelete);

                context.SaveChanges();
                Console.WriteLine("Workout with Id: {0}, was successfully canceled! Have a nice day! ", workoutId);
            }

        }
    }
}

