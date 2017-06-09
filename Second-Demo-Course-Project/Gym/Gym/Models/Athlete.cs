using Gym.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models
{
    public class Athlete : IPerson
    {
        public Athlete()
        {
            this.Workouts = new HashSet<Workout>();
        }


        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public Trainer Coach { get; set; }

        public virtual ICollection<Workout> Workouts { get; set; }

    }
}
