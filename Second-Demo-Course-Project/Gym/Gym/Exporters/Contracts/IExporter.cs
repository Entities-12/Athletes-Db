using Gym.DatabaseAndContext;

namespace Gym.Exporters.Contracts
{
    public interface IExporter
    {
        void ExportFile(IDatabase db, string table);
    }
}
