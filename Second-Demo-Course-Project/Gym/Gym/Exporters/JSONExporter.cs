using Gym.DatabaseAndContext;
using Gym.Models;
using Gym.Models.Contracts;
using Microsoft.EntityFrameworkCore;
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
            var activities = db.GetInstance().Activities;

            var serilizedActivities = JsonConvert.SerializeObject(activities);

            using (var file = new StreamWriter(this.path))
            {
                file.Write(serilizedActivities);
            }

            Console.WriteLine(serilizedActivities);
        }

        private void GetAthletes(IDatabase db)
        {
            var athletes = db.GetInstance().Athletes.ToList();

            var serilizedAthletes = JsonConvert.SerializeObject(athletes);

            using (var file = new StreamWriter(this.path))
            {
                file.Write(serilizedAthletes);
            }

            Console.WriteLine(serilizedAthletes);
        }

        private void GetSpots(IDatabase db)
        {
            var spots = db.GetInstance().Spots;

            var serilizedSpots = JsonConvert.SerializeObject(spots);

            using (var file = new StreamWriter(this.path))
            {
                file.Write(serilizedSpots);
            }

            Console.WriteLine(serilizedSpots);
        }

        private void GetTrainers(IDatabase db)
        {
            var trainers = db.GetInstance().Trainers;

            var serilizedtTrainers = JsonConvert.SerializeObject(trainers);

            using (var file = new StreamWriter(this.path))
            {
                file.Write(serilizedtTrainers);
            }

            Console.WriteLine(serilizedtTrainers);
        }

        private void GetWorkouts(IDatabase db)
        {
            var workouts = db.GetInstance().Workouts;

            var serilizedtWorkouts = JsonConvert.SerializeObject(workouts);

            using (var file = new StreamWriter(this.path))
            {
                file.Write(serilizedtWorkouts);
            }

            Console.WriteLine(serilizedtWorkouts);
        }
    }

}
