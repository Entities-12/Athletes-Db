using Gym.Models.Contracts;
using Gym.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gym.Models
{
    public class Activity : IModel
    {
        private ICollection<Workout> workouts;
        //private ICollection<Spot> spots;

        public Activity()
        {
            this.workouts = new HashSet<Workout>();
            //this.spots = new HashSet<Spot>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public CategoryType Category { get; set; }

        public virtual ICollection<Workout> Workouts
        {
            get { return this.workouts; }
            set { this.workouts = value; }
        }
        //public virtual ICollection<Spot> Spots
        //{
        //    get { return this.spots; }
        //    set { this.spots = value; }
        //}
    }
}
