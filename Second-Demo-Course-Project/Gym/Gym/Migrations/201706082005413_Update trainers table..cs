namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatetrainerstable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WorkoutTrainers", "Workout_Id", "dbo.Workouts");
            DropForeignKey("dbo.WorkoutTrainers", "Trainer_Id", "dbo.Trainers");
            DropIndex("dbo.WorkoutTrainers", new[] { "Workout_Id" });
            DropIndex("dbo.WorkoutTrainers", new[] { "Trainer_Id" });
            AddColumn("dbo.Trainers", "Workout_Id", c => c.Int());
            AddColumn("dbo.Workouts", "Capacity", c => c.Int(nullable: false));
            CreateIndex("dbo.Trainers", "Workout_Id");
            AddForeignKey("dbo.Trainers", "Workout_Id", "dbo.Workouts", "Id");
            DropColumn("dbo.Workouts", "Caapacity");
            DropTable("dbo.WorkoutTrainers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.WorkoutTrainers",
                c => new
                    {
                        Workout_Id = c.Int(nullable: false),
                        Trainer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Workout_Id, t.Trainer_Id });
            
            AddColumn("dbo.Workouts", "Caapacity", c => c.Int(nullable: false));
            DropForeignKey("dbo.Trainers", "Workout_Id", "dbo.Workouts");
            DropIndex("dbo.Trainers", new[] { "Workout_Id" });
            DropColumn("dbo.Workouts", "Capacity");
            DropColumn("dbo.Trainers", "Workout_Id");
            CreateIndex("dbo.WorkoutTrainers", "Trainer_Id");
            CreateIndex("dbo.WorkoutTrainers", "Workout_Id");
            AddForeignKey("dbo.WorkoutTrainers", "Trainer_Id", "dbo.Trainers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WorkoutTrainers", "Workout_Id", "dbo.Workouts", "Id", cascadeDelete: true);
        }
    }
}
