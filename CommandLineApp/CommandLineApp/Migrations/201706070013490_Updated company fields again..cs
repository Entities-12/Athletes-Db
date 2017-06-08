namespace CommandLineApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatedcompanyfieldsagain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        Address = c.String(),
                        CompanyNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Companies");
        }
    }
}
