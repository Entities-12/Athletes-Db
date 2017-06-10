using Gym.Context;
using Gym.DatabaseAndContext;
using Gym.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.DbClientOperatior
{
    public class Creator
    {
        public Creator ()  {}

        public void CreateEntity(string tableName)
        {
            switch (tableName)
            {
                case "Athletes":

                    var athleteNewEntity = new Athlete();

                    Console.WriteLine("Provide Firs Name");
                    athleteNewEntity.FirstName = Console.ReadLine();
                    Console.WriteLine("Provide Last Name");
                    athleteNewEntity.LastName = Console.ReadLine();
                    Console.WriteLine("Provide Age");
                    athleteNewEntity.Age = Convert.ToInt32(Console.ReadLine());

                    var athleteContext = new GymDbContext();

                    athleteContext.Athletes.Add(athleteNewEntity);
                    athleteContext.SaveChanges();
                    Console.WriteLine("You are successfully signed up!Congrats!");
                    break;

                case "Workouts":

                    var workoutNewEntity = new Workout();

                    Console.WriteLine("Pick hour for workout to start");
                    workoutNewEntity.WorkoutStart = Console.ReadLine();
                    Console.WriteLine("Pick hour for workout to end");
                    workoutNewEntity.WorkoutEnd = Console.ReadLine();

                    Console.WriteLine("Pick day for workout from 1 to 7");
                    var day = Console.ReadLine();
                    switch (day)
                    { 
                        case "1":
                            var monday = DayOfWeek.Monday;
                            workoutNewEntity.Day = monday;
                            break;
                        case "2":
                            var tuesday = DayOfWeek.Tuesday;
                            workoutNewEntity.Day = tuesday;
                            break;
                        case "3":
                            var wednesday = DayOfWeek.Wednesday;
                            workoutNewEntity.Day = wednesday;
                            break;
                        case "4":
                            var thursday = DayOfWeek.Thursday;
                            workoutNewEntity.Day = thursday;
                            break;
                        case "5":
                            var friday = DayOfWeek.Friday;
                            workoutNewEntity.Day = friday;
                            break;
                        case "6":
                            var saturday = DayOfWeek.Saturday;
                            workoutNewEntity.Day = saturday;
                            break;
                        case "7":
                            var sunday = DayOfWeek.Sunday;
                            workoutNewEntity.Day = sunday;
                            break;
                    }
                    
                    var workoutsContext = new GymDbContext();

                    workoutsContext.Workouts.Add(workoutNewEntity);
                    workoutsContext.SaveChanges();
                    Console.WriteLine("You booked successfully your workout!Enjoy!");
                    break;
                default:
                    Console.WriteLine("The table is NOT FOUND!");
                    return;

            }
        }
    }
}
