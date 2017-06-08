using CommandLineApp.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLineApp.Models
{
    public class Person : IPerson
    {
        public Person (int id, string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Id = id;
        }

        public Person() { }

        public string FirstName { get; set; }
        

        public int Id { get; set; }

        public string LastName { get; set; }
    }
}
