using Gym.DatabaseAndContext;
using Gym.Exporters.Contracts;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace Gym.Exporters
{
    public class JSONExporter : IExporter
    {
        private string path = "../../ExportedFiles/jsonExports.json";

        public JSONExporter() { }

        public void ExportFile(IDatabase db, string table)
        {
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



        private void GetAtctivites(IDatabase db)
        {
            var activities = db.GetInstance().Activities.ToList();

            var serilizedActivities = JsonConvert.SerializeObject(activities, Formatting.Indented,
                                                                              new JsonSerializerSettings()
                                                                              {
                                                                                  ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                                                                              });

            using (var file = new StreamWriter(this.path))
            {
                file.Write(serilizedActivities);
            }

            Console.WriteLine(serilizedActivities);
        }

        private void GetAthletes(IDatabase db)
        {
            var athletes = db.GetInstance().Athletes.ToList();

            var serilizedAthletes = JsonConvert.SerializeObject(athletes, Formatting.Indented,
                                                                          new JsonSerializerSettings()
                                                                          {
                                                                              ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                                                          });

            using (var file = new StreamWriter(this.path))
            {
                file.Write(serilizedAthletes);
            }

            Console.WriteLine(serilizedAthletes);
        }

        private void GetSpots(IDatabase db)
        {
            var spots = db.GetInstance().Spots.ToList();

            var serilizedSpots = JsonConvert.SerializeObject(spots, Formatting.Indented,
                                                                    new JsonSerializerSettings()
                                                                    {
                                                                        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                                                                    });


            using (var file = new StreamWriter(this.path))
            {
                file.Write(serilizedSpots);
            }

            Console.WriteLine(serilizedSpots);
        }

        private void GetTrainers(IDatabase db)
        {
            var trainers = db.GetInstance().Trainers.ToList();

            var serilizedtTrainers = JsonConvert.SerializeObject(trainers, Formatting.Indented,
                                                                           new JsonSerializerSettings()
                                                                           {
                                                                               ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                                                                           });

            using (var file = new StreamWriter(this.path))
            {
                file.Write(serilizedtTrainers);
            }

            Console.WriteLine(serilizedtTrainers);
        }

        private void GetWorkouts(IDatabase db)
        {
            var workouts = db.GetInstance().Workouts.ToList();

            var serilizedtWorkouts = JsonConvert.SerializeObject(workouts, Formatting.Indented,
                                                                           new JsonSerializerSettings()
                                                                           {
                                                                               ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                                                                           });

            using (var file = new StreamWriter(this.path))
            {
                file.Write(serilizedtWorkouts);
            }

            Console.WriteLine(serilizedtWorkouts);
        }
    }

}
