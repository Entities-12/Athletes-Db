using System;
using Gym.Context;

namespace Gym.DatabaseAndContext
{
    public class Database : IDatabase
    {
        public Database() { }

        public GymDbContext GetInstance()
        {
            return new GymDbContext();
        }
    }
}
