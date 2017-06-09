using Gym.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Gym.Models
{
    public class Activity
    {
        public Activity() { }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public Category Category { get; set; }
    }
}
