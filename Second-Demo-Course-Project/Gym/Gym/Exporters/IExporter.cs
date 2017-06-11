using Gym.DatabaseAndContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Exporters
{
    public interface IExporter
    {
         void ExportFile(IDatabase db, string table);
    }
}
