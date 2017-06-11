using Gym.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Gym.Models
{
    [Serializable, XmlRoot("athlete")]
    public class Athlete : IPerson, IModel
    {
        public Athlete()
        {
            this.Workouts = new HashSet<Workout>();
        }

        [Key]
        public int Id { get; set; }

        [XmlElement("FirstName")]
        public string FirstName { get; set; }

        [XmlElement("LastName")]
        public string LastName { get; set; }

        [XmlElement("Age")]
        public int Age { get; set; }

        [XmlIgnore]
        public Trainer Coach { get; set; }

        [XmlIgnore]
        public virtual ICollection<Workout> Workouts { get; set; }

    }
}
