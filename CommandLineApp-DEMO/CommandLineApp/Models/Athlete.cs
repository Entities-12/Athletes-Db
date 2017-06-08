using CommandLineApp.Models.Contracts;
using System;
using System.ComponentModel.DataAnnotations;

namespace CommandLineApp.Models
{
    public class Athlete : Person
    {
        public Athlete(int id, string FirstName, string LastName): base(id, FirstName, LastName) {}

       // public Athlete() : base() { }

        public int Id { get; set; }

        [Required]
        [MaxLength(20), MinLength(3)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20), MinLength(3)]
        public string LastName { get; set; }

       

        public void Sm() { }
    }
}
