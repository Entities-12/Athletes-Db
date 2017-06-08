using CommandLineApp.Models.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CommandLineApp.Models
{
    public class Company: IModel
    {
        public Company() { }

        public int Id { get; set; }

        [Required]
        [MaxLength(20), MinLength(3)]
        public string CompanyName { get; set; }

        [Required]
        [MaxLength(20), MinLength(3)]
        public string Address { get; set; }

        [Required]
        [MaxLength(20), MinLength(3)]
        public string CompanyNumber { get; set; }

        public virtual ICollection<Trainer> Trainers { get; set; }

        public void Sm()
        {
            throw new NotImplementedException();
        }
    }
}
