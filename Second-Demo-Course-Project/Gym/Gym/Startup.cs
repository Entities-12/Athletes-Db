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
            //  var app = new GymApp();

            //  app.Run();

            // Create new athlete object
            var newAthlete = new Athlete();
            newAthlete.FirstName = "Pesho";
            newAthlete.LastName = "Peshev";
            newAthlete.Age = 25;
            var dateTime = new DateTime(2017, 02, 02, 16, 00, 00);
            newAthlete.Workouts.Add(new Workout {
                StartHour = dateTime,
                EndHour = dateTime,
                Day = DayOfWeek.Friday,
              //  ActivityId,
              //  TrainerId,
              //  SpotId,
              //  AthleteId
            });

            using (var context = new GymDbContext())
            {
                
                
                // Mark the object for inserting
                context.Athletes.Add(newAthlete);
                context.SaveChanges();
                Console.WriteLine("Done");

            }

        }
    }
}
