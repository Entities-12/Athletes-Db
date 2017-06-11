namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class workoutsAthleterenamed : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "Gym-Second-Demo.Workouts", name: "Athletes_Id", newName: "Athlete_Id");
            RenameIndex(table: "Gym-Second-Demo.Workouts", name: "IX_Athletes_Id", newName: "IX_Athlete_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "Gym-Second-Demo.Workouts", name: "IX_Athlete_Id", newName: "IX_Athletes_Id");
            RenameColumn(table: "Gym-Second-Demo.Workouts", name: "Athlete_Id", newName: "Athletes_Id");
        }
    }
}
