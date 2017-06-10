namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stringstartandendworkouthour : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Gym-Second-Demo.Workouts", "WorkoutStart", c => c.String());
            AlterColumn("Gym-Second-Demo.Workouts", "WorkoutEnd", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("Gym-Second-Demo.Workouts", "WorkoutEnd", c => c.Int(nullable: false));
            AlterColumn("Gym-Second-Demo.Workouts", "WorkoutStart", c => c.Int(nullable: false));
        }
    }
}
