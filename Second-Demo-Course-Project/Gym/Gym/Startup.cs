using Gym.Context;
using Gym.DatabaseAndContext;
using Gym.Exporters;
using Gym.Import;
using Gym.Models;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Gym
{
    class Startup
    {
        static void Main()
        {
            var app = new GymApp();

            app.Run();
            
        }
    }
}
