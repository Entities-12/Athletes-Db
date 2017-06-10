using Gym.Context;
using Gym.DatabaseAndContext;
using Gym.Exporters;
using Gym.Import;
using Gym.Models;
using Gym.Models.Enums;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace Gym
{
    class Startup
    {
        static void Main()
        {
            // For creating the database.
            using (var context = new GymDbContext())
                {
                    context.Database.CreateIfNotExists();
                }
              var app = new GymApp();

              app.Run();

            ////Create new activity object
            //var activity = new Activity();
            //activity.Name = "Kangoo";
            //activity.Category = CategoryType.heavy;

            ////create new spot object
            //var spot = new Spot();
            //spot.Address = "Some address";
            //spot.Capacity = SpotCapacity.small;
            //spot.ContactNumber = "0894 123456";

            ////Create new trainer object
            //var trainer = new Trainer();
            //trainer.FirstName = "Gosho";
            //trainer.LastName = "Goshev";
            //trainer.Age = 28;


            //// Create new athlete object
            //var athlete = new Athlete();
            //athlete.FirstName = "Pesho";
            //athlete.LastName = "Peshev";
            //athlete.Age = 25;
            //athlete.Workouts.Add(new Workout {
            //    WorkoutStart = "3",
            //    WorkoutEnd = "4",
            //    Day = DayOfWeek.Friday,
            //    Activity = activity,
            //    Trainer = trainer,
            //    Spot = spot

            //});
            
            

            //using (var context = new GymDbContext())
            //{


            //    // Mark the object for inserting
            //    context.Spots.Add(spot);
            //    context.Trainers.Add(trainer);
            //    context.Activities.Add(activity);
            //    context.Athletes.Add(athlete);
            //    context.SaveChanges();
            //    Console.WriteLine("Added new Athlete");
            //    Console.WriteLine("Added new Activity");
            //    Console.WriteLine("Added new Trainer");
            //    Console.WriteLine("Added new Spot");

            //}

        }
    }
}
