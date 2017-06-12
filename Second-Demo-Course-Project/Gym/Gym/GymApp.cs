using System;

namespace Gym
{
    public class GymApp
    {
        public GymApp()
        {
            this.CommandProcessor = new CommandProcessor();
            this.CRUDCommandProcessor = new CRUDCommandProcessor();
        }

        public CommandProcessor CommandProcessor { get; private set; }
        public CRUDCommandProcessor CRUDCommandProcessor { get; private set; }

        public void Run()
        {
            while (true)
            {
                //Commands List
                Console.WriteLine("-- Welcome to our Dummy App for Workouts --");
                //Export JSON 
                Console.WriteLine("If you want to make Export with JSON type: \"exportJSON _\" as second type name of the table ");
                //Create 
                Console.WriteLine("If you want to sign up  type: \"createProfile\" ");
                Console.WriteLine("If you want to book new Workout type: \"bookWorkout\" ");
                //Delete 
                Console.WriteLine("If you want to cancel your workout type: \"cancelWorkout\" ");
                //Update 
                Console.WriteLine("If you want to change your workout type: \"editWorkout\" ");
                //Read 
                Console.WriteLine("If you want to see your profile details type: \"viewProfile\" ");
                Console.WriteLine("If you want to see your workouts list type: \"viewWorkouts\" ");
                //ReportPDF
                Console.WriteLine("If you want to see all Athletes type: \"reportPDF Athletes\" ");
                //Exit APP 
                Console.WriteLine("If you want to exit App type: exit");
                var command = Console.ReadLine();

                if (command == "exit")
                {
                    Console.WriteLine("We are really sorry that you have to use our very dummy APP! Thank you!");
                    return;
                }
                if (command.Contains("exportJSON") ||
                   command.Contains("reportPDF"))
                {
                    this.CommandProcessor.ProcessCommand(command);
                }
                if (command.Contains("bookWorkout") ||
                   command.Contains("createProfile") ||
                   command.Contains("cancelWorkout") ||
                   command.Contains("editWorkout") ||
                   command.Contains("viewProfile") ||
                   command.Contains("viewWorkouts"))
                {
                    this.CRUDCommandProcessor.ProcessCommand(command);
                }
            }
        }

        
    }
}
