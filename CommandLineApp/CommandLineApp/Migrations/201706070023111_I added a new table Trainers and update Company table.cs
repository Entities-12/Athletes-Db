namespace CommandLineApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IaddedanewtableTrainersandupdateCompanytable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        CurrentCompany_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CurrentCompany_Id)
                .Index(t => t.CurrentCompany_Id);
            
            AddColumn("dbo.Athletes", "CurrentTrainer_Id", c => c.Int());
            CreateIndex("dbo.Athletes", "CurrentTrainer_Id");
            AddForeignKey("dbo.Athletes", "CurrentTrainer_Id", "dbo.Trainers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Athletes", "CurrentTrainer_Id", "dbo.Trainers");
            DropForeignKey("dbo.Trainers", "CurrentCompany_Id", "dbo.Companies");
            DropIndex("dbo.Trainers", new[] { "CurrentCompany_Id" });
            DropIndex("dbo.Athletes", new[] { "CurrentTrainer_Id" });
            DropColumn("dbo.Athletes", "CurrentTrainer_Id");
            DropTable("dbo.Trainers");
        }
    }
}
