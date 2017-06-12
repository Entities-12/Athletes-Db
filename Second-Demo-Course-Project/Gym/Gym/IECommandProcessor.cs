using Gym.DatabaseAndContext;
using Gym.Exporters;
using Gym.Import;
using System;
using Gym.Context;
using Gym.DbClientOperatior;
using Gym.Contracts;

namespace Gym
{
    public class IECommandProcessor : ICommand
    {
        public IECommandProcessor()
        {
            this.JSONExporter = new JSONExporter();
            this.JSONImporter = new JSONImporter();
            this.Database = new Database();
            this.PDFReporter = new PDFReporter();
        }

        private IDatabase Database { get; set; }
        private JSONExporter JSONExporter { get; set; }
        private JSONImporter JSONImporter { get; set; }
        private PDFReporter PDFReporter { get; set; }


        public void ProcessCommand(string command)
        {
            var commandName = command.Split(' ')[0];
            var tableName = command.Split(' ')[1];

            switch (commandName)
            {
                case "exportJSON":
                    this.JSONExporter.ExportFile(this.Database, tableName);
                    break;
                case "reportPDF":
                    this.PDFReporter.ReportFile(tableName);
                    break;                
                default:
                    Console.WriteLine(" The command is not found. ");
                    break;
            }
        }
    }
}
