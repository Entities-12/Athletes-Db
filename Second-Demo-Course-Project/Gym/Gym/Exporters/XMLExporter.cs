using System;
using Gym.DatabaseAndContext;
using Gym.Exporters.Contracts;
using System.Linq;
using System.Xml.Serialization;
using Gym.Models;
using System.IO;
using System.Xml;
using System.Collections.Generic;

namespace Gym.Exporters
{
    public class XMLExporter : IExporter
    {
        private string path = "../../ExportedFiles/xmlExports.xml";

        public XMLExporter() { }

        public void ExportFile(IDatabase db, string table)
        {
            if (true)
            {
                Console.WriteLine("The xml exporter is not working properly and it will be fixed later.");
                return;
            }

            switch (table.ToLower())
            {
                case "activities":
                    this.GetAtctivites(db);
                    break;
                case "athletes":
                    this.GetAthletes(db);
                    break;
                case "spots":
                    this.GetSpots(db);
                    break;
                case "trainers":
                    this.GetTrainers(db);
                    break;
                case "workouts":
                    this.GetWorkouts(db);
                    break;
                default:
                    Console.WriteLine("The table is NOT FOUND!");
                    return;
            }
        }

        private void GetWorkouts(IDatabase db)
        {
            var wotkouts = db.GetInstance().Workouts.ToList();
            
            var serializer = new XmlSerializer(typeof(Workout));

            using (StreamWriter streamWriter = new StreamWriter(this.path))
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(streamWriter))
                {
                   serializer.Serialize(xmlWriter, wotkouts);

                    Console.WriteLine(streamWriter.ToString());
                } 
            }

        }

        private void GetTrainers(IDatabase db)
        {
            throw new NotImplementedException();
        }

        private void GetSpots(IDatabase db)
        {
            throw new NotImplementedException();
        }

        private void GetAthletes(IDatabase db)
        {
            List<Athlete> athletes = db.GetInstance().Athletes.ToList();

            var serializer = new XmlSerializer(typeof(List<Athlete>));

            using (StreamWriter streamWriter = new StreamWriter(this.path))
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(streamWriter))
                {
                    serializer.Serialize(xmlWriter, athletes);

                    Console.WriteLine(streamWriter.ToString());
                } 
            }
        }

        private void GetAtctivites(IDatabase db)
        {
            throw new NotImplementedException();
        }
    }
}
