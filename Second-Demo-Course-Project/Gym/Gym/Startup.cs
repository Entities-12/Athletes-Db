using Gym.Context;
using Gym.DatabaseAndContext;
using Gym.Exporters;
using Gym.Exporters.Contracts;
using Gym.Import;
using Gym.Importers;
using Gym.Importers.Contracts;
using Gym.Models;
using Gym.PostgreSQL;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Gym
{
    class Startup
    {
        static void Main()
        {
            IDatabase database = new Database();
            IExporter xmlExporter = new XMLExporter();
            IExporter jsonExporter = new JSONExporter();
            IImporter xmlImport = new XMLImporter();
            IImporter jsonImport = new JSONImporter();

            var commandParser = new CommandProcessor(database, xmlExporter, jsonExporter, xmlImport, jsonImport);

            var app = new GymApp(commandParser);

            app.Run();
            
        }
    }
}
