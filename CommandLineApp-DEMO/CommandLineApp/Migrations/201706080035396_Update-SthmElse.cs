namespace CommandLineApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSthmElse : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Athletes", "CurrentTrainer_Id", "dbo.Trainers");
            DropIndex("dbo.Athletes", new[] { "CurrentTrainer_Id" });
            RenameColumn(table: "dbo.Trainers", name: "CurrentCompany_Id", newName: "Company_Id");
            RenameIndex(table: "dbo.Trainers", name: "IX_CurrentCompany_Id", newName: "IX_Company_Id");
            DropColumn("dbo.Athletes", "CurrentTrainer_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Athletes", "CurrentTrainer_Id", c => c.Int());
            RenameIndex(table: "dbo.Trainers", name: "IX_Company_Id", newName: "IX_CurrentCompany_Id");
            RenameColumn(table: "dbo.Trainers", name: "Company_Id", newName: "CurrentCompany_Id");
            CreateIndex("dbo.Athletes", "CurrentTrainer_Id");
            AddForeignKey("dbo.Athletes", "CurrentTrainer_Id", "dbo.Trainers", "Id");
        }
    }
}
