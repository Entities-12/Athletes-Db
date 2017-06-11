using Gym.Context;
using Gym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.DbClientOperatior
{
    public class Remover : IDbClientOperatior
    {
        public Remover() { }
        public void OperateEntity(string tableName)
        {
            switch(tableName)
            {
                case "Workouts":
                    Workout workoutToDelete;

                    Console.WriteLine("Provide workoutId");
                    var workoutId = Convert.ToInt32(Console.ReadLine());
                    
                    using (var context = new GymDbContext())
                    {
                        workoutToDelete = context.Workouts.Where(w =>w.Id  == workoutId).FirstOrDefault<Workout>();
                    }

                    //Create new context for disconnected scenario
                    using (var newContext = new GymDbContext())
                    {
                        newContext.Entry(workoutToDelete).State = System.Data.Entity.EntityState.Deleted;

                        newContext.SaveChanges();
                        Console.WriteLine("Workout with Id: {0}, was successfully canceled! Have a nice day! ", workoutId);
                    }
                    break;

                default:
                    Console.WriteLine("The table is NOT FOUND!");
                    return;
            }

        }
    }
}

