using Gym.DatabaseAndContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Importers.Contracts
{
    public interface IImporter
    {
        void ImportFile(string path, IDatabase db);
    }
}
