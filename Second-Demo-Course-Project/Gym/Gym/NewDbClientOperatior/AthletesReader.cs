using Gym.Context;
using Gym.NewDbClientOperatior.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.NewDbClientOperatior
{
    public class AthletesReader : IDbClientOperatior
    {
        public AthletesReader() { }

        public void OperateEntity()
        {
            Console.WriteLine("Provide your Id");
            var athlethId = Convert.ToInt32(Console.ReadLine());

            using (var context = new GymDbContext())
            {
                var athletes = context.Athletes.ToList();
                athletes.Where(a => a.Id == athlethId).FirstOrDefault();
                var id = athletes[0].Id;
                var name = athletes[0].FirstName +" "+ athletes[0].LastName;
                var age = athletes[0].Age;
                Console.WriteLine("Id: {0} \nName: {1} \nAge: {2}", id, name, age);
            }
        }
    }
}
