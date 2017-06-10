namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrainersforeignkeypropertySpotIDadded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Trainers", "Place_Id", "dbo.Spots");
            DropIndex("dbo.Trainers", new[] { "Place_Id" });
            RenameColumn(table: "dbo.Trainers", name: "Place_Id", newName: "SpotID");
            AlterColumn("dbo.Trainers", "SpotID", c => c.Int(nullable: false));
            CreateIndex("dbo.Trainers", "SpotID");
            AddForeignKey("dbo.Trainers", "SpotID", "dbo.Spots", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trainers", "SpotID", "dbo.Spots");
            DropIndex("dbo.Trainers", new[] { "SpotID" });
            AlterColumn("dbo.Trainers", "SpotID", c => c.Int());
            RenameColumn(table: "dbo.Trainers", name: "SpotID", newName: "Place_Id");
            CreateIndex("dbo.Trainers", "Place_Id");
            AddForeignKey("dbo.Trainers", "Place_Id", "dbo.Spots", "Id");
        }
    }
}
