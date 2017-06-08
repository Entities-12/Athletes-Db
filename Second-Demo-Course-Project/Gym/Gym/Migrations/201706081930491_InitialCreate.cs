namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Athletes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                        Coach_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trainers", t => t.Coach_Id)
                .Index(t => t.Coach_Id);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                        Place_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Spots", t => t.Place_Id)
                .Index(t => t.Place_Id);
            
            CreateTable(
                "dbo.Spots",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        ContactNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Workouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Caapacity = c.Int(nullable: false),
                        StartHour = c.DateTime(nullable: false),
                        EndHour = c.DateTime(nullable: false),
                        Athlete_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Athletes", t => t.Athlete_Id)
                .Index(t => t.Athlete_Id);
            
            CreateTable(
                "dbo.WorkoutTrainers",
                c => new
                    {
                        Workout_Id = c.Int(nullable: false),
                        Trainer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Workout_Id, t.Trainer_Id })
                .ForeignKey("dbo.Workouts", t => t.Workout_Id, cascadeDelete: true)
                .ForeignKey("dbo.Trainers", t => t.Trainer_Id, cascadeDelete: true)
                .Index(t => t.Workout_Id)
                .Index(t => t.Trainer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workouts", "Athlete_Id", "dbo.Athletes");
            DropForeignKey("dbo.Athletes", "Coach_Id", "dbo.Trainers");
            DropForeignKey("dbo.WorkoutTrainers", "Trainer_Id", "dbo.Trainers");
            DropForeignKey("dbo.WorkoutTrainers", "Workout_Id", "dbo.Workouts");
            DropForeignKey("dbo.Trainers", "Place_Id", "dbo.Spots");
            DropIndex("dbo.WorkoutTrainers", new[] { "Trainer_Id" });
            DropIndex("dbo.WorkoutTrainers", new[] { "Workout_Id" });
            DropIndex("dbo.Workouts", new[] { "Athlete_Id" });
            DropIndex("dbo.Trainers", new[] { "Place_Id" });
            DropIndex("dbo.Athletes", new[] { "Coach_Id" });
            DropTable("dbo.WorkoutTrainers");
            DropTable("dbo.Workouts");
            DropTable("dbo.Spots");
            DropTable("dbo.Trainers");
            DropTable("dbo.Athletes");
        }
    }
}
