using Gym.Context;
using Gym.DatabaseAndContext;
using Gym.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.DbClientOperatior
{
    public class Creator
    {
        public Creator ()  {}

        public void CreateEntity(string tableName)
        {
            switch (tableName)
            {
                case "Athletes":
                    Console.WriteLine("Debugger");
                    var athleteNewEntity = new Athlete();
                    athleteNewEntity.FirstName = "fName";
                    athleteNewEntity.LastName = "lName";
                    athleteNewEntity.Age = 20;

                    var context = new GymDbContext();
                    
                    context.Athletes.Add(athleteNewEntity);
                    context.SaveChanges();
                    Console.WriteLine("You are successfully signed up!Congrats!");
                    
                    break;
                default:
                    Console.WriteLine("The table is NOT FOUND!");
                    return;

            }
        }
    }
}
