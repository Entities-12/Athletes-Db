namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.Activities", newSchema: "Gym-Second-Demo");
            MoveTable(name: "dbo.Workouts", newSchema: "Gym-Second-Demo");
            MoveTable(name: "dbo.Athletes", newSchema: "Gym-Second-Demo");
            MoveTable(name: "dbo.Spots", newSchema: "Gym-Second-Demo");
            MoveTable(name: "dbo.Trainers", newSchema: "Gym-Second-Demo");
            MoveTable(name: "dbo.AthleteWorkouts", newSchema: "Gym-Second-Demo");
            AlterColumn("Gym-Second-Demo.Workouts", "Day", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("Gym-Second-Demo.Workouts", "Day", c => c.Int(nullable: false));
            MoveTable(name: "Gym-Second-Demo.AthleteWorkouts", newSchema: "dbo");
            MoveTable(name: "Gym-Second-Demo.Trainers", newSchema: "dbo");
            MoveTable(name: "Gym-Second-Demo.Spots", newSchema: "dbo");
            MoveTable(name: "Gym-Second-Demo.Athletes", newSchema: "dbo");
            MoveTable(name: "Gym-Second-Demo.Workouts", newSchema: "dbo");
            MoveTable(name: "Gym-Second-Demo.Activities", newSchema: "dbo");
        }
    }
}
