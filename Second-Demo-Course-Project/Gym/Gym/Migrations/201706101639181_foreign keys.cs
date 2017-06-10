namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignkeys : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.WorkoutAthletes", newName: "AthleteWorkouts");
            RenameColumn(table: "dbo.Workouts", name: "WorkoutName_Id", newName: "Activity_Id");
            RenameIndex(table: "dbo.Workouts", name: "IX_WorkoutName_Id", newName: "IX_Activity_Id");
            DropPrimaryKey("dbo.AthleteWorkouts");
            AddPrimaryKey("dbo.AthleteWorkouts", new[] { "Athlete_Id", "Workout_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.AthleteWorkouts");
            AddPrimaryKey("dbo.AthleteWorkouts", new[] { "Workout_Id", "Athlete_Id" });
            RenameIndex(table: "dbo.Workouts", name: "IX_Activity_Id", newName: "IX_WorkoutName_Id");
            RenameColumn(table: "dbo.Workouts", name: "Activity_Id", newName: "WorkoutName_Id");
            RenameTable(name: "dbo.AthleteWorkouts", newName: "WorkoutAthletes");
        }
    }
}
