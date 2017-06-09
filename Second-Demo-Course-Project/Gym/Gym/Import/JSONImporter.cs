using Gym.Models;
using Gym.Models.Contracts;
using Newtonsoft.Json;
using System;
using System.IO;
using Gym.DatabaseAndContext;

namespace Gym.Import
{
    public class JSONImporter
    {
        public JSONImporter() { }
        

        public void ImportJSONFileDataToTheDatabase(string path, IDatabase db)
        {
            if (db == null || path.Length == 0)
            {
                Console.WriteLine("The past parameters are invalid.");
                return;
            }

            using (StreamReader streamReader = new StreamReader(path))
            {
                string jsonData = streamReader.ReadToEnd();
                
                var data = JsonConvert.DeserializeObject<Athlete>(jsonData);

                db.GetInstance().Athletes.Add(data);
            }
        }
    }
}
