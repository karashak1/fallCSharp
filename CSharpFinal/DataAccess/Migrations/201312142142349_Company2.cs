namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Company2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AddressID = c.Int(nullable: false),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressID, cascadeDelete: true)
                .Index(t => t.AddressID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Companies", "AddressID", "dbo.Addresses");
            DropIndex("dbo.Companies", new[] { "AddressID" });
            DropTable("dbo.Companies");
        }
    }
}
