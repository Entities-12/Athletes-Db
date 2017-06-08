using CommandLineApp.Commands;
using System;
using System.Data.Entity;
using System.Linq;

namespace CommandLineApp
{
    public class App
    {
        private CommandsFactory commandsFactory;
        private CommandProcessor commandsProcessor;

        public App()
        {
            this.commandsFactory = new CommandsFactory();
            this.commandsProcessor = new CommandProcessor(this.commandsFactory);
        }

        public void Run()
        {
            while (true)
            {
                var command = Console.ReadLine().Split(' ').ToList();

                if (command[0] == "exit")
                {
                    break;
                }

                this.commandsProcessor.ProcessCommand(command);
            }
        }
    }
}
