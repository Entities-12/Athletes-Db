using Gym.DatabaseAndContext;
using Gym.Exporters;
using Gym.Import;
using Gym.Importers;
using System;

namespace Gym
{
    public class GymApp
    {
        public GymApp(CommandProcessor commandParser)
        {
            this.CommandProcessor = commandParser;
            this.CRUDCommandProcessor = new CRUDCommandProcessor();
        }

        public CommandProcessor CommandProcessor { get; private set; }
        public CRUDCommandProcessor CRUDCommandProcessor { get; private set; }

        public void Run()
        {

            this.DisplayInfo();

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "exit")
                {
                    Console.WriteLine("We are really sorry that you have to use our very dummy APP! Thank you!");
                    return;
                }
                if (command.Contains("exportJSON") ||
                    command.Contains("importJSON") ||
                    command.Contains("importXML") ||
                    command.Contains("getPostgreData") ||
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

        public void DisplayInfo()
        {
            var info = @"
                        -- Welcome to our Dummy App for Workouts --
                        If you want to make Export with JSON type: exportJSON as second type name of the table 
                        If you want to make Import with JSON type: importJSON as second type name of the table
                        If you want to make Export with XML type: exportXML as second type name of the table  
                        If you want to make Import with XML type: importXML as second type name of the table 
                        If you want to sign up  type: createProfile
                        If you want to book new Workout type: bookWorkout
                        If you want to change your workout type: editWorkout
                        If you want to see your profile details type: viewProfile
                        If you want to see your workouts list type: viewWorkouts
                        If you want to see all Athletes type: reportPDF Athletes
                        If you want to exit App type: exit

                        ";

            Console.WriteLine(info);
        }


    }
}
