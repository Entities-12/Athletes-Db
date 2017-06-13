using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.PostgreSQL
{
    public interface IPostgreSql
    {
        void GetData(string tableName);
    }
}
