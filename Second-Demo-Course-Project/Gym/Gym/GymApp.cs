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
                //Commands List
                Console.WriteLine("-- Welcome to our Dummy App for Workouts --");
                //Export JSON 
                Console.WriteLine("If you want to make Export with JSON type: exportJSON and as second type name of the table");
                //Create 
                Console.WriteLine("If you want to sign up  type: create Athletes");
                Console.WriteLine("If you want to book new Workout type: create Workouts");
                //Delete 
                Console.WriteLine("If you want to cancel your workout type: cancel Workouts");
                //Update 
                Console.WriteLine("If you want to change your workout type: edit Workouts");
                //Read 
                Console.WriteLine("If you want to see your profile details type: view Athletes");
                Console.WriteLine("If you want to see your workouts list type: view Workouts");
                //Exit APP 
                Console.WriteLine("If you want to exit App type: exit");
                var command = Console.ReadLine();

                if (command == "exit")
                {
                    Console.WriteLine("We are really sorry that you have to use are very dummy APP! Thank you! ");
                    return;
                }

                this.CommandProcessor.ProcessCommand(command);

            }
        }
    }
}
