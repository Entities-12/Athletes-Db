using CommandLineApp.Models.Contracts;
using System;
using System.ComponentModel.DataAnnotations;

namespace CommandLineApp.Models
{
    public class Trainer : Person
    {
        public Trainer(int id, string FirstName, string LastName): base(id, FirstName, LastName) { }
       // public Trainer(): base() { }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20), MinLength(3)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20), MinLength(3)]
        public string LastName { get; set; }
        

        public void Sm()
        {
            throw new NotImplementedException();
        }
    }
}
