using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models
{
    public class Workout
    {
        public Workout() { }

        public int Id { get; set; }

        [Column("Capacity")]
        public int Capacity { get; set; }

        public DateTime StartHour { get; set; }

        public DateTime EndHour { get; set; }

        public virtual ICollection<Trainer> Trainers { get; set; }
    }
}
