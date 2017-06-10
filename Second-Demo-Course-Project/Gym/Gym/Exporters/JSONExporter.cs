using Gym.DatabaseAndContext;
using Gym.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Exporters
{
    public class JSONExporter
    {
        private string path = "../../ExportedFiles/jsonExports.json";

        public JSONExporter() { }

        public void ExportFile(IDatabase db, string table)
        {
            switch(table.ToLower())
            {
                case "activities":
                       Console.WriteLine(this.GetAtctivites(db));
                    break;
                default:
                    Console.WriteLine("The table is NOT FOUND!");
                    return;
                   
            }
        } 

        private string GetAtctivites(IDatabase db)
        {
            var activities = db.GetInstance().Athletes;

            var serilizedActivities = JsonConvert.SerializeObject(activities);

            using (var file = new StreamWriter(this.path))
            {
                file.Write(serilizedActivities);
            }


            return serilizedActivities;
        }
    }

}
