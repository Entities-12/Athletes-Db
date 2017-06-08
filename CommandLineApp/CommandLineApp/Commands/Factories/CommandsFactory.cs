using CommandLineApp.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace CommandLineApp.Commands
{
    public class CommandsFactory
    {
        private DbContext database;
        public CommandsFactory()
        {
        }

        public void CreateCommandFromString(string commandName, IList<string> command)
        {
            switch (commandName)
            {
                case "get":
                    var cmd = this.CreateGetCommand(command);

                    cmd.Execute();
                    break;
                default:
                    throw new ArgumentException("Command NOT FOUND");
            }

        }

        public ICommand CreateGetCommand(IList<string> command)
        {
            return new GetCommand(command);
        }

    }
}
