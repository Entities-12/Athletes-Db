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

        private ICollection<Workout> workouts;

        public Athlete()
        {
            this.workouts = new HashSet<Workout>();
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
        public virtual ICollection<Workout> Workouts
        {
            get { return this.workouts; }
            set { this.workouts = value; }
        }

    }
}
