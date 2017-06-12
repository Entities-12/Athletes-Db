using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Contracts
{
    public interface ICommand
    {
        void ProcessCommand(string command);
    }
}
