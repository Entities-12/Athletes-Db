using Gym.Contracts;
using Gym.DbClientOperatior;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym
{
    public class CRUDCommandProcessor : ICommand
    {
        public CRUDCommandProcessor()
        {
            this.WorkoutsCreator = new WorkoutsCreator();
            this.AthletesCreator = new AthletesCreator();
            this.AthletesReader = new AthletesReader();
            this.WorkoutsRemover = new WorkoutsRemover();
            this.WorkoutsEditor = new WorkoutsEditor();
            this.WorkoutsReader = new WorkoutsReader();
        }

        private WorkoutsCreator WorkoutsCreator { get; set; }
        private AthletesCreator AthletesCreator { get; set; }
        private WorkoutsRemover WorkoutsRemover { get; set; }
        private WorkoutsEditor WorkoutsEditor { get; set; }
        private WorkoutsReader WorkoutsReader { get; set; }
        private AthletesReader AthletesReader { get; set; }

        public void ProcessCommand(string command)
        {
            switch (command)
            {
                //CRUD console commands
                case "bookWorkout":
                    Console.WriteLine(" Should perform create new athlete or workout");
                    this.WorkoutsCreator.OperateEntity();
                    break;
                case "createProfile":
                    Console.WriteLine(" Should perform create new athlete or workout");
                    this.AthletesCreator.OperateEntity();
                    break;
                case "cancelWorkout":
                    Console.WriteLine(" Should perform delete workout by given Id");
                    this.WorkoutsRemover.OperateEntity();
                    break;
                case "editWorkout":
                    Console.WriteLine(" Should perform update workout by given Id");
                    this.WorkoutsEditor.OperateEntity();
                    break;
                case "viewProfile":
                    Console.WriteLine(" Should perform read table for Athlets->AthletId and Workouts->AthletId");
                    this.AthletesReader.OperateEntity();
                    break;
                case "viewWorkouts":
                    Console.WriteLine(" Should perform read table for Athlets->AthletId and Workouts->AthletId");
                    this.WorkoutsReader.OperateEntity();
                    break;
                default:
                    Console.WriteLine(" The command is not found. ");
                    break;
            }
        }
    }
}

