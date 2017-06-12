namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class keysofworkouts : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "Gym-Second-Demo.Workouts", name: "Athlete_Id", newName: "AthleteId");
            RenameColumn(table: "Gym-Second-Demo.Workouts", name: "Spot_Id", newName: "SpotId");
            RenameColumn(table: "Gym-Second-Demo.Workouts", name: "Trainer_Id", newName: "TrainerId");
            RenameIndex(table: "Gym-Second-Demo.Workouts", name: "IX_Trainer_Id", newName: "IX_TrainerId");
            RenameIndex(table: "Gym-Second-Demo.Workouts", name: "IX_Spot_Id", newName: "IX_SpotId");
            RenameIndex(table: "Gym-Second-Demo.Workouts", name: "IX_Athlete_Id", newName: "IX_AthleteId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "Gym-Second-Demo.Workouts", name: "IX_AthleteId", newName: "IX_Athlete_Id");
            RenameIndex(table: "Gym-Second-Demo.Workouts", name: "IX_SpotId", newName: "IX_Spot_Id");
            RenameIndex(table: "Gym-Second-Demo.Workouts", name: "IX_TrainerId", newName: "IX_Trainer_Id");
            RenameColumn(table: "Gym-Second-Demo.Workouts", name: "TrainerId", newName: "Trainer_Id");
            RenameColumn(table: "Gym-Second-Demo.Workouts", name: "SpotId", newName: "Spot_Id");
            RenameColumn(table: "Gym-Second-Demo.Workouts", name: "AthleteId", newName: "Athlete_Id");
        }
    }
}
