namespace CommandLineApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Athletes", "CurrentTrainer_Id", "dbo.Trainers");
            DropIndex("dbo.Athletes", new[] { "CurrentTrainer_Id" });
            AlterColumn("dbo.Athletes", "CurrentTrainer_Id", c => c.Int());
            CreateIndex("dbo.Athletes", "CurrentTrainer_Id");
            AddForeignKey("dbo.Athletes", "CurrentTrainer_Id", "dbo.Trainers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Athletes", "CurrentTrainer_Id", "dbo.Trainers");
            DropIndex("dbo.Athletes", new[] { "CurrentTrainer_Id" });
            AlterColumn("dbo.Athletes", "CurrentTrainer_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Athletes", "CurrentTrainer_Id");
            AddForeignKey("dbo.Athletes", "CurrentTrainer_Id", "dbo.Trainers", "Id", cascadeDelete: true);
        }
    }
}
