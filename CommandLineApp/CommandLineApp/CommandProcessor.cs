using CommandLineApp.Commands;
using System;
using System.Collections.Generic;

namespace CommandLineApp
{
    public class CommandProcessor
    {
        public CommandProcessor(CommandsFactory factory)
        {
            this.Factory = factory;
        }

        public CommandsFactory Factory { get; private set; }

        public void ProcessCommand(IList<string> command)
        {
            var commandName = command[0];
             
            if (string.IsNullOrWhiteSpace(commandName))
            {
                Console.WriteLine("You can't pass a empty command.");
                return;
            }


            this.Factory.CreateCommandFromString(commandName, command);

        }
    }
}
