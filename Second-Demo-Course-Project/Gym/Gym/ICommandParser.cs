using Gym.DatabaseAndContext;
using Gym.Exporters;
using Gym.Exporters.Contracts;
using Gym.Importers.Contracts;
using Gym.PostgreSQL;

namespace Gym
{
    public interface ICommandParser
    {
        PostgreSql PostgreSql { get; set; }
        IExporter XMLExprter { get; set; }
        IImporter XMLImporter { get; set; }
        IDatabase Database { get; set; }
        IExporter JSONExporter { get; set; }
        IImporter JSONImporter { get; set; }
        PDFReporter PDFReporter { get; set; }

        void ProcessCommand(string command);
    }
}