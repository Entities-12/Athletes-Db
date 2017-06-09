using Gym.Context;
using Gym.DatabaseAndContext;
using Gym.Exporters;
using Gym.Import;
using Gym.Models;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Gym
{
    class Startup
    {
        static void Main()
        {

            // For creating the database.
            /*    using (var context = new GymDbContext())
                {
                    context.Database.CreateIfNotExists();
                }*/


            var app = new GymApp();

            app.Run();
            
        }
    }
}
