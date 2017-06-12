using Gym.Context;
using Gym.NewDbClientOperatior.Contracts;
using Gym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.NewDbClientOperatior
{
    public class WorkoutsEditor : IDbClientOperatior
    {
        public void OperateEntity()
        {
            Workout workoutToEdit;
            Console.WriteLine("Provide workoutId");
            var workoutId = Convert.ToInt32(Console.ReadLine());
            using (var context = new GymDbContext())
            {
                workoutToEdit = context.Workouts.Where(w => w.Id == workoutId).FirstOrDefault();
            }

            if (workoutToEdit != null)
            {

                Console.WriteLine("Pick new hour for start of the workout");
                workoutToEdit.WorkoutStart = Console.ReadLine();
                Console.WriteLine("Pick new hour for end of the workout");
                workoutToEdit.WorkoutEnd = Console.ReadLine();

            }

            using (var dbCtx = new GymDbContext())
            {

                dbCtx.Entry(workoutToEdit).State = System.Data.Entity.EntityState.Modified;

                dbCtx.SaveChanges();
                Console.WriteLine("Changes are saved!");
            }
        }
    }
 }

