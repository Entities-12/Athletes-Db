using Gym.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models
{
    public class Trainer : IPerson, IModel
    {
        public Trainer() { }

        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public Spot Place { get; set; }

        public Activity Activity { get; set; }
        
    }
}
