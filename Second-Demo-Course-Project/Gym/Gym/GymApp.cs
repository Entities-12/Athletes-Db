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

                if (command == "app --info")
                {
                    this.Info();
                }

                if (command == "exit")
                {
                    return;
                }

                this.CommandProcessor.ProcessCommand(command);
            }
        }

        public void Info()
        {
            Console.WriteLine(@"
                        -- exportJSON tableName
                        -- importJSON filePath
                        -- importXML filePath
                        -- getPostgreData tableName
                                ");
        }
    }
}
