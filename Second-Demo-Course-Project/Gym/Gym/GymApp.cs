using System;

namespace Gym
{
    public class GymApp
    {
        public GymApp()
        {
            this.CommandProcessor = new CommandProcessor();
        }

        public CommandProcessor CommandProcessor { get; private set; }

        public void Run()
        {
            while (true)
            {
                var command = Console.ReadLine();

                if (command == "exit")
                {
                    return;
                }

                this.CommandProcessor.ProcessCommand(command);

            }
        }
    }
}
