using Gym.Models.Enums;

namespace Gym.Models
{
    public class Activity
    {
        public Activity() { }

        public int Id { get; set; }

        public string Name { get; set; }

        public Category Category { get; set; }
    }
}
