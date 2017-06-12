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
                athletes.ForEach(a => Console.WriteLine(" YourId: " + a.Id + "\n Frst Name: "+ a.FirstName + "\n Last Name: " + a.LastName  + "\n Age: " + a.Age));
                Console.WriteLine(athletes);
            }
        }
    }
}
