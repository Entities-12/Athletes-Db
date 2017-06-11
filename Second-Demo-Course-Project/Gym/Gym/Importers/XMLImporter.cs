using System;
using Gym.DatabaseAndContext;
using Gym.Importers.Contracts;
using System.IO;
using System.Xml.Serialization;
using Gym.Models;
using System.Xml;

namespace Gym.Importers
{
    public class XMLImporter : IImporter
    {
        public XMLImporter () { }

        public void ImportFile(string path, IDatabase db)
        {
            if (db == null || path.Length == 0)
            {
                Console.WriteLine("The past parameters are invalid.");
                return;
            }

            var context = db.GetInstance();

            var serializer = new XmlSerializer(typeof(Athlete));

            using (StreamReader streamReader = new StreamReader(path))
            {
                var athlete = (Athlete)serializer.Deserialize(streamReader);

                context.Athletes.Add(athlete);

                context.SaveChanges();
                
                Console.WriteLine("Successfully Added");
            }
        }
    }
}
