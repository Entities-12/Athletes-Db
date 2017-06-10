using Gym.DatabaseAndContext;
using Gym.Exporters;
using Gym.Import;
using System;
using Gym.Context;
using Gym.DbClientOperatior;

namespace Gym
{
    public class CommandProcessor
    {
        public CommandProcessor()
        {
            this.JSONExporter = new JSONExporter();
            this.JSONImporter = new JSONImporter();
            this.Database = new Database();
            this.Creator = new Creator();
        }

        private IDatabase Database { get; set; }
        private JSONExporter JSONExporter { get; set; }
        private JSONImporter JSONImporter { get; set; }
        private Creator Creator { get; set; }

        public void ProcessCommand(string command)
        {
            var commandName = command.Split(' ')[0];
            var tableName = command.Split(' ')[1];

            switch (commandName)
            {
                case "exportJSON":
                    this.JSONExporter.ExportFile(this.Database, tableName);
                    break;
                //CRUD console commands
                case "create":
                    Console.WriteLine(" Should perform create new athlete or workout");
                    this.Creator.CreateEntity(tableName);
                    break;
                case "cancel":
                    Console.WriteLine(" Should perform delete workout ");
                    break;
                case "edit":
                    Console.WriteLine(" Should perform update workout ");
                    break;
                case "view":
                    Console.WriteLine(" Should perform read table for Athlets->AthletId and Workouts->AthletId");
                    break;
                default:
                    Console.WriteLine(" The command is not found. ");
                    break;
            }
        }
    }
}
