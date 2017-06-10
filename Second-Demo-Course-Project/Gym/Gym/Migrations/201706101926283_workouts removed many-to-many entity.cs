namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class workoutsremovedmanytomanyentity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Gym-Second-Demo.AthleteWorkouts", "Athlete_Id", "Gym-Second-Demo.Athletes");
            DropForeignKey("Gym-Second-Demo.AthleteWorkouts", "Workout_Id", "Gym-Second-Demo.Workouts");
            DropIndex("Gym-Second-Demo.AthleteWorkouts", new[] { "Athlete_Id" });
            DropIndex("Gym-Second-Demo.AthleteWorkouts", new[] { "Workout_Id" });
            AddColumn("Gym-Second-Demo.Workouts", "Athletes_Id", c => c.Int());
            CreateIndex("Gym-Second-Demo.Workouts", "Athletes_Id");
            AddForeignKey("Gym-Second-Demo.Workouts", "Athletes_Id", "Gym-Second-Demo.Athletes", "Id");
            DropTable("Gym-Second-Demo.AthleteWorkouts");
        }
        
        public override void Down()
        {
            CreateTable(
                "Gym-Second-Demo.AthleteWorkouts",
                c => new
                    {
                        Athlete_Id = c.Int(nullable: false),
                        Workout_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Athlete_Id, t.Workout_Id });
            
            DropForeignKey("Gym-Second-Demo.Workouts", "Athletes_Id", "Gym-Second-Demo.Athletes");
            DropIndex("Gym-Second-Demo.Workouts", new[] { "Athletes_Id" });
            DropColumn("Gym-Second-Demo.Workouts", "Athletes_Id");
            CreateIndex("Gym-Second-Demo.AthleteWorkouts", "Workout_Id");
            CreateIndex("Gym-Second-Demo.AthleteWorkouts", "Athlete_Id");
            AddForeignKey("Gym-Second-Demo.AthleteWorkouts", "Workout_Id", "Gym-Second-Demo.Workouts", "Id", cascadeDelete: true);
            AddForeignKey("Gym-Second-Demo.AthleteWorkouts", "Athlete_Id", "Gym-Second-Demo.Athletes", "Id", cascadeDelete: true);
        }
    }
}
