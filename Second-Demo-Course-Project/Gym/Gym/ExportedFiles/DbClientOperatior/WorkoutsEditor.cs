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

                var trainer = new Trainer();
                workoutToEdit.Trainer = trainer;

                var spot = new Spot();
                workoutToEdit.Spot = spot;

                var activity = new Activity();
                workoutToEdit.Trainer = trainer;
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

