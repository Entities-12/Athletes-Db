namespace CommandLineApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Iaddedrequirementsforthetables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Athletes", "CurrentTrainer_Id", "dbo.Trainers");
            DropIndex("dbo.Athletes", new[] { "CurrentTrainer_Id" });
            AlterColumn("dbo.Athletes", "FirstName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Athletes", "LastName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Athletes", "CurrentTrainer_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Trainers", "FirstName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Trainers", "LastName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Companies", "CompanyName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Companies", "Address", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Companies", "CompanyNumber", c => c.String(nullable: false, maxLength: 20));
            CreateIndex("dbo.Athletes", "CurrentTrainer_Id");
            AddForeignKey("dbo.Athletes", "CurrentTrainer_Id", "dbo.Trainers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Athletes", "CurrentTrainer_Id", "dbo.Trainers");
            DropIndex("dbo.Athletes", new[] { "CurrentTrainer_Id" });
            AlterColumn("dbo.Companies", "CompanyNumber", c => c.String());
            AlterColumn("dbo.Companies", "Address", c => c.String());
            AlterColumn("dbo.Companies", "CompanyName", c => c.String());
            AlterColumn("dbo.Trainers", "LastName", c => c.String());
            AlterColumn("dbo.Trainers", "FirstName", c => c.String());
            AlterColumn("dbo.Athletes", "CurrentTrainer_Id", c => c.Int());
            AlterColumn("dbo.Athletes", "LastName", c => c.String());
            AlterColumn("dbo.Athletes", "FirstName", c => c.String());
            CreateIndex("dbo.Athletes", "CurrentTrainer_Id");
            AddForeignKey("dbo.Athletes", "CurrentTrainer_Id", "dbo.Trainers", "Id");
        }
    }
}
