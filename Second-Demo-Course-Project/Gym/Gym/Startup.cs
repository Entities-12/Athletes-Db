using Gym.Context;
using Gym.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym
{
    class Startup
    {
        static void Main()
        {
           // If the database isn't created uncomment this.
           /* using (var context = new GymDbContext())
            {
                context.Database.CreateIfNotExists();
            } */

            using (StreamReader streamReader = new StreamReader("../../Data/data.json"))
            {
                string jsonData = streamReader.ReadToEnd();

                Console.WriteLine(jsonData);

                var athlete = JsonConvert.DeserializeObject<Athlete>(jsonData);
                
                Console.WriteLine(athlete.FirstName);

                var context = new GymDbContext();

                context.Athletes.Add(athlete);

                context.SaveChanges();
                
            }
        }
    }
}
