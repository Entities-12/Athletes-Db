using Gym.Context;
using Gym.DatabaseAndContext;
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
            /*using (var context = new GymDbContext())
            {
                context.Database.CreateIfNotExists();
            }*/

            IDatabase db = new Database();
            var jsonImporter = new JSONImporter();

            jsonImporter.ImportJSONFileDataToTheDatabase("../../Data/data.json", db);
        }
    }
}
