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
    public class AthletesCreator : IDbClientOperatior
    {
        public AthletesCreator() { }

        public void OperateEntity()
        {
            var athleteNewEntity = new Athlete();

            Console.WriteLine("Provide Firs Name");
            athleteNewEntity.FirstName = Console.ReadLine();
            Console.WriteLine("Provide Last Name");
            athleteNewEntity.LastName = Console.ReadLine();
            Console.WriteLine("Provide Age");
            athleteNewEntity.Age = Convert.ToInt32(Console.ReadLine());


            var athleteContext = new GymDbContext();

            athleteContext.Athletes.Add(athleteNewEntity);
            athleteContext.SaveChanges();
            Console.WriteLine("You are successfully signed up!Congrats!");
        }
    }
}
