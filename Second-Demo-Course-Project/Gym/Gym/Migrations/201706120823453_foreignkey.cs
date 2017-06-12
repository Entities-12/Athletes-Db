namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignkey : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "Gym-Second-Demo.Workouts", name: "Activity_Id", newName: "ActivityId");
            RenameIndex(table: "Gym-Second-Demo.Workouts", name: "IX_Activity_Id", newName: "IX_ActivityId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "Gym-Second-Demo.Workouts", name: "IX_ActivityId", newName: "IX_Activity_Id");
            RenameColumn(table: "Gym-Second-Demo.Workouts", name: "ActivityId", newName: "Activity_Id");
        }
    }
}
