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
            if(true)
            {
                Console.WriteLine("The xml importer is not ready yet.");
                return;
            }

            if (db == null || path.Length == 0)
            {
                Console.WriteLine("The past parameters are invalid.");
                return;
            }

            var serializer = new XmlSerializer(typeof(Athlete));
            var doc = new XmlDocument();

            doc.Load(path);

            var xmlReader = XmlReader.Create(path);

            Athlete athlete = (Athlete)serializer.Deserialize(xmlReader);

            Console.WriteLine(athlete.Age);


            
        }
    }
}
