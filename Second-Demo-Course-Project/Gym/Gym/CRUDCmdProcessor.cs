using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.NewDbClientOperatior;

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
                    this.WorkoutsCreator.OperateEntity();
                    break;
                case "createProfile":
                    this.AthletesCreator.OperateEntity();
                    break;
                case "cancelWorkout":
                    this.WorkoutsRemover.OperateEntity();
                    break;
                case "editWorkout":
                    this.WorkoutsEditor.OperateEntity();
                    break;
                case "viewProfile":
                    this.AthletesReader.OperateEntity();
                    break;
                case "viewWorkouts":
                    this.WorkoutsReader.OperateEntity();
                    break;
                default:
                    Console.WriteLine(" The command is not found. ");
                    break;
            }
        }
    }
}

