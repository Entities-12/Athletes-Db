namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class props : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Workouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WorkoutStart = c.String(),
                        WorkoutEnd = c.String(),
                        Day = c.Int(nullable: false),
                        ActivityId = c.Int(),
                        TrainerId = c.Int(),
                        SpotId = c.Int(),
                        AthleteId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Activities", t => t.ActivityId)
                .ForeignKey("dbo.Athletes", t => t.AthleteId)
                .ForeignKey("dbo.Trainers", t => t.TrainerId)
                .ForeignKey("dbo.Spots", t => t.SpotId)
                .Index(t => t.ActivityId)
                .Index(t => t.TrainerId)
                .Index(t => t.SpotId)
                .Index(t => t.AthleteId);
            
            CreateTable(
                "dbo.Athletes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Spots",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        ContactNumber = c.String(),
                        Capacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                        SpotID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Spots", t => t.SpotID, cascadeDelete: true)
                .Index(t => t.SpotID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workouts", "SpotId", "dbo.Spots");
            DropForeignKey("dbo.Workouts", "TrainerId", "dbo.Trainers");
            DropForeignKey("dbo.Trainers", "SpotID", "dbo.Spots");
            DropForeignKey("dbo.Workouts", "AthleteId", "dbo.Athletes");
            DropForeignKey("dbo.Workouts", "ActivityId", "dbo.Activities");
            DropIndex("dbo.Trainers", new[] { "SpotID" });
            DropIndex("dbo.Workouts", new[] { "AthleteId" });
            DropIndex("dbo.Workouts", new[] { "SpotId" });
            DropIndex("dbo.Workouts", new[] { "TrainerId" });
            DropIndex("dbo.Workouts", new[] { "ActivityId" });
            DropTable("dbo.Trainers");
            DropTable("dbo.Spots");
            DropTable("dbo.Athletes");
            DropTable("dbo.Workouts");
            DropTable("dbo.Activities");
        }
    }
}
