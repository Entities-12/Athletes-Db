namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetimetoint : DbMigration
    {
        public override void Up()
        {
            AddColumn("Gym-Second-Demo.Workouts", "WorkoutStart", c => c.Int(nullable: false));
            AddColumn("Gym-Second-Demo.Workouts", "WorkoutEnd", c => c.Int(nullable: false));
            DropColumn("Gym-Second-Demo.Workouts", "StartHour");
            DropColumn("Gym-Second-Demo.Workouts", "EndHour");
        }
        
        public override void Down()
        {
            AddColumn("Gym-Second-Demo.Workouts", "EndHour", c => c.DateTime(nullable: false));
            AddColumn("Gym-Second-Demo.Workouts", "StartHour", c => c.DateTime(nullable: false));
            DropColumn("Gym-Second-Demo.Workouts", "WorkoutEnd");
            DropColumn("Gym-Second-Demo.Workouts", "WorkoutStart");
        }
    }
}
