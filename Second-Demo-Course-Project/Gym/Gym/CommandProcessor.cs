using Gym.DatabaseAndContext;
using Gym.Exporters;
using Gym.Import;
using System;
using Gym.Context;
using Gym.Importers;
using Npgsql;
using System.Data;
using Gym.PostgreSQL;

namespace Gym
{
    public class CommandProcessor
    {
        public CommandProcessor()
        {
            this.JSONExporter = new JSONExporter();
            this.JSONImporter = new JSONImporter();
            this.XMLImporter = new XMLImporter();
            this.XMLExprter = new XMLExporter();
            this.PostgreSql = new PostgreSql();
            this.Database = new Database();
        }

        private PostgreSql PostgreSql { get; set; }
        private XMLExporter XMLExprter { get; set; }
        private XMLImporter XMLImporter { get; set; }
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
                case "exportXML":
                    this.XMLExprter.ExportFile(this.Database, tableNameOrPath);
                    break;
                case "getPostgreData":
                    this.PostgreSql.GetData(tableNameOrPath);
                    break;
                case "app":
                    break; 
                default:
                    Console.WriteLine("The command is not found.");
                    break;
            }
        }
    }
}
