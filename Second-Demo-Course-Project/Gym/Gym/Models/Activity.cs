using Gym.Models.Contracts;
using Gym.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Gym.Models
{
    public class Activity : IModel
    {
        public Activity() { }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public Category Category { get; set; }
    }
}
