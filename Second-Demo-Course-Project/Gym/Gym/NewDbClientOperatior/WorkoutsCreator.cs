using Gym.Context;
using Gym.DatabaseAndContext;
using Gym.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.NewDbClientOperatior.Contracts;

namespace Gym.NewDbClientOperatior
{
    public class WorkoutsCreator: IDbClientOperatior
    {
        public WorkoutsCreator ()
        {
            this.workoutNewEntity = new Workout();
        }

        private Workout workoutNewEntity; 

        public void OperateEntity()
        {

                    Console.WriteLine("Pick hour for workout to start");
                    workoutNewEntity.WorkoutStart = Console.ReadLine();
                    Console.WriteLine("Pick hour for workout to end");
                    workoutNewEntity.WorkoutEnd = Console.ReadLine();

                    Console.WriteLine("Pick day for workout from 1 to 7");
                    var day = Console.ReadLine();
                    SetWorkoutDay(workoutNewEntity, day);


                    Console.WriteLine("Type  activity Id");
                    var activityId = Convert.ToInt32(Console.ReadLine());
                    SetActivity(workoutNewEntity, activityId);

                    Console.WriteLine("Type  spot Id");
                    var spotId = Convert.ToInt32(Console.ReadLine());
                    SetSpot(workoutNewEntity, spotId);


                    Console.WriteLine("Type your athlete Id");
                    var athleteId = Convert.ToInt32(Console.ReadLine());
                    SetAthlete(workoutNewEntity, athleteId);

                    Console.WriteLine("Type your trainer Id");
                    var trainerId = Convert.ToInt32(Console.ReadLine());
                    SetTrainer(workoutNewEntity, trainerId);

                    var workoutsContext = new GymDbContext();

                    workoutsContext.Workouts.Add(workoutNewEntity);
                    workoutsContext.SaveChanges();
                    Console.WriteLine("You booked successfully your workout!Enjoy!");
            }

        private void SetAthlete(Workout workout, int id)
        {
            workout.AthleteId = id;
        }
        private void SetActivity(Workout workout, int id)
        {
            workout.ActivityId = id;
        }
        private void SetSpot(Workout workout, int id)
        {
            workout.SpotId = id;
        }

        private void SetTrainer(Workout workout, int id)
        {
            workout.TrainerId = id;
        }
        private void SetWorkoutDay(Workout workout, string day)
        {
            switch (day)
            {
                case "1":
                    var monday = DayOfWeek.Monday;
                    workout.Day = monday;
                    break;
                case "2":
                    var tuesday = DayOfWeek.Tuesday;
                    workout.Day = tuesday;
                    break;
                case "3":
                    var wednesday = DayOfWeek.Wednesday;
                    workout.Day = wednesday;
                    break;
                case "4":
                    var thursday = DayOfWeek.Thursday;
                    workout.Day = thursday;
                    break;
                case "5":
                    var friday = DayOfWeek.Friday;
                    workout.Day = friday;
                    break;
                case "6":
                    var saturday = DayOfWeek.Saturday;
                    workout.Day = saturday;
                    break;
                case "7":
                    var sunday = DayOfWeek.Sunday;
                    workout.Day = sunday;
                    break;
            }
        }
    }
}
       

