﻿using Gym.Models.Contracts;
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
        private ICollection<Workout> workouts;

        public Trainer()
        {
            this.workouts = new HashSet<Workout>();
        }

        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        //Foreign key
        public int SpotID { get; set; }

        public virtual Spot Place { get; set; }

        public virtual ICollection<Workout> Workouts
        {
            get { return this.workouts; }
            set { this.workouts = value; }
        }
    }
}
