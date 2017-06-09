namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Trainers", "Activity_Id", "dbo.Activities");
            DropForeignKey("dbo.Activities", "Spot_Id", "dbo.Spots");
            DropForeignKey("dbo.Athletes", "Coach_Id", "dbo.Trainers");
            DropIndex("dbo.Activities", new[] { "Spot_Id" });
            DropIndex("dbo.Athletes", new[] { "Coach_Id" });
            DropIndex("dbo.Trainers", new[] { "Activity_Id" });
            RenameColumn(table: "dbo.Workouts", name: "SportType_Id", newName: "WorkoutName_Id");
            RenameIndex(table: "dbo.Workouts", name: "IX_SportType_Id", newName: "IX_WorkoutName_Id");
            AddColumn("dbo.Workouts", "Spot_Id", c => c.Int());
            AddColumn("dbo.Workouts", "Trainer_Id", c => c.Int());
            CreateIndex("dbo.Workouts", "Spot_Id");
            CreateIndex("dbo.Workouts", "Trainer_Id");
            AddForeignKey("dbo.Workouts", "Spot_Id", "dbo.Spots", "Id");
            AddForeignKey("dbo.Workouts", "Trainer_Id", "dbo.Trainers", "Id");
            DropColumn("dbo.Activities", "Spot_Id");
            DropColumn("dbo.Athletes", "Coach_Id");
            DropColumn("dbo.Trainers", "Activity_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trainers", "Activity_Id", c => c.Int());
            AddColumn("dbo.Athletes", "Coach_Id", c => c.Int());
            AddColumn("dbo.Activities", "Spot_Id", c => c.Int());
            DropForeignKey("dbo.Workouts", "Trainer_Id", "dbo.Trainers");
            DropForeignKey("dbo.Workouts", "Spot_Id", "dbo.Spots");
            DropIndex("dbo.Workouts", new[] { "Trainer_Id" });
            DropIndex("dbo.Workouts", new[] { "Spot_Id" });
            DropColumn("dbo.Workouts", "Trainer_Id");
            DropColumn("dbo.Workouts", "Spot_Id");
            RenameIndex(table: "dbo.Workouts", name: "IX_WorkoutName_Id", newName: "IX_SportType_Id");
            RenameColumn(table: "dbo.Workouts", name: "WorkoutName_Id", newName: "SportType_Id");
            CreateIndex("dbo.Trainers", "Activity_Id");
            CreateIndex("dbo.Athletes", "Coach_Id");
            CreateIndex("dbo.Activities", "Spot_Id");
            AddForeignKey("dbo.Athletes", "Coach_Id", "dbo.Trainers", "Id");
            AddForeignKey("dbo.Activities", "Spot_Id", "dbo.Spots", "Id");
            AddForeignKey("dbo.Trainers", "Activity_Id", "dbo.Activities", "Id");
        }
    }
}
