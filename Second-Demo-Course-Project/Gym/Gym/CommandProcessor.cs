using Gym.DatabaseAndContext;
using Gym.Exporters;
using Gym.Import;
using System;
using Gym.Context;
using Gym.Importers;

namespace Gym
{
    public class CommandProcessor
    {
        public CommandProcessor()
        {
            this.JSONExporter = new JSONExporter();
            this.JSONImporter = new JSONImporter();
            this.XMLImporter = new XMLImporter();
            this.Database = new Database();
        }

        public XMLImporter XMLImporter { get; private set; }
        private IDatabase Database { get; set; }
        private JSONExporter JSONExporter { get; set; }
        private JSONImporter JSONImporter { get; set; }
        public void ProcessCommand(string command)
        {
            var commandName = command.Split(' ')[0];
            var tableNameOrPath = command.Split(' ')[1];
            
           
            switch (commandName)
            {
                case "exportJSON":
                    this.JSONExporter.ExportFile(this.Database, tableNameOrPath);
                    break;
                case "importJSON":
                    this.JSONImporter.ImportFile(tableNameOrPath, this.Database);
                    break;
                case "importXML":
                    this.XMLImporter.ImportFile(tableNameOrPath, this.Database);
                    break;
                default:
                    Console.WriteLine("The command is not found.");
                    break;
            }
        }
    }
}
