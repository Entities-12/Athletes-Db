using Gym.DatabaseAndContext;
using Gym.Exporters;
using Gym.Import;
using System;
using Gym.Context;
using Gym.Importers;
using Npgsql;
using System.Data;
using Gym.PostgreSQL;
using Gym.Exporters.Contracts;
using Gym.Importers.Contracts;

namespace Gym
{
    public class CommandProcessor : ICommandParser
    {
        public CommandProcessor(IDatabase database, IExporter xmlExporter, IExporter jsonExporter,
                                 IImporter xmlImporter, IImporter jsonImporter)
        {
            this.JSONExporter = jsonExporter;
            this.JSONImporter = jsonImporter;
            this.XMLImporter = xmlImporter;
            this.XMLExprter = xmlExporter;
            this.PostgreSql = new PostgreSql();
            this.Database = database;
            this.PDFReporter = new PDFReporter();
        }

        public PostgreSql PostgreSql { get; set; }
        public IExporter XMLExprter { get; set; }
        public IImporter XMLImporter { get; set; }
        public IDatabase Database { get; set; }
        public IExporter JSONExporter { get; set; }
        public IImporter JSONImporter { get; set; }
        public PDFReporter PDFReporter { get; set; }

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
                case "reportPDF":
                    this.PDFReporter.ReportFile();
                    break;
                default:
                    Console.WriteLine("The command is not found.");
                    break;
            }
        }
    }
}
