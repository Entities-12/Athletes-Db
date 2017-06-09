namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updates : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Trainers", "Workout_Id", "dbo.Workouts");
            DropForeignKey("dbo.Workouts", "Athlete_Id", "dbo.Athletes");
            DropIndex("dbo.Trainers", new[] { "Workout_Id" });
            DropIndex("dbo.Workouts", new[] { "Athlete_Id" });
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category = c.Int(nullable: false),
                        Spot_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Spots", t => t.Spot_Id)
                .Index(t => t.Spot_Id);
            
            CreateTable(
                "dbo.WorkoutAthletes",
                c => new
                    {
                        Workout_Id = c.Int(nullable: false),
                        Athlete_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Workout_Id, t.Athlete_Id })
                .ForeignKey("dbo.Workouts", t => t.Workout_Id, cascadeDelete: true)
                .ForeignKey("dbo.Athletes", t => t.Athlete_Id, cascadeDelete: true)
                .Index(t => t.Workout_Id)
                .Index(t => t.Athlete_Id);
            
            AddColumn("dbo.Trainers", "Activity_Id", c => c.Int());
            AddColumn("dbo.Spots", "Capacity", c => c.Int(nullable: false));
            AddColumn("dbo.Workouts", "Day", c => c.Int(nullable: false));
            AddColumn("dbo.Workouts", "SportType_Id", c => c.Int());
            CreateIndex("dbo.Trainers", "Activity_Id");
            CreateIndex("dbo.Workouts", "SportType_Id");
            AddForeignKey("dbo.Trainers", "Activity_Id", "dbo.Activities", "Id");
            AddForeignKey("dbo.Workouts", "SportType_Id", "dbo.Activities", "Id");
            DropColumn("dbo.Trainers", "Workout_Id");
            DropColumn("dbo.Workouts", "Capacity");
            DropColumn("dbo.Workouts", "Athlete_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workouts", "Athlete_Id", c => c.Int());
            AddColumn("dbo.Workouts", "Capacity", c => c.Int(nullable: false));
            AddColumn("dbo.Trainers", "Workout_Id", c => c.Int());
            DropForeignKey("dbo.Workouts", "SportType_Id", "dbo.Activities");
            DropForeignKey("dbo.WorkoutAthletes", "Athlete_Id", "dbo.Athletes");
            DropForeignKey("dbo.WorkoutAthletes", "Workout_Id", "dbo.Workouts");
            DropForeignKey("dbo.Activities", "Spot_Id", "dbo.Spots");
            DropForeignKey("dbo.Trainers", "Activity_Id", "dbo.Activities");
            DropIndex("dbo.WorkoutAthletes", new[] { "Athlete_Id" });
            DropIndex("dbo.WorkoutAthletes", new[] { "Workout_Id" });
            DropIndex("dbo.Workouts", new[] { "SportType_Id" });
            DropIndex("dbo.Trainers", new[] { "Activity_Id" });
            DropIndex("dbo.Activities", new[] { "Spot_Id" });
            DropColumn("dbo.Workouts", "SportType_Id");
            DropColumn("dbo.Workouts", "Day");
            DropColumn("dbo.Spots", "Capacity");
            DropColumn("dbo.Trainers", "Activity_Id");
            DropTable("dbo.WorkoutAthletes");
            DropTable("dbo.Activities");
            CreateIndex("dbo.Workouts", "Athlete_Id");
            CreateIndex("dbo.Trainers", "Workout_Id");
            AddForeignKey("dbo.Workouts", "Athlete_Id", "dbo.Athletes", "Id");
            AddForeignKey("dbo.Trainers", "Workout_Id", "dbo.Workouts", "Id");
        }
    }
}
