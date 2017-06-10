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
            

        }
    }
}
