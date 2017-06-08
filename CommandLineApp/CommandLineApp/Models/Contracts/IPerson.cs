using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLineApp.Models.Contracts
{
    public interface IPerson
    {
         int Id { get; set; }
        
         string FirstName { get; set; }

         string LastName { get; set; }

    }
}
