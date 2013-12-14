namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContactMethods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        value = c.String(),
                        type = c.String(),
                        ContactId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        AddressID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressID, cascadeDelete: true)
                .Index(t => t.AddressID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactMethods", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Contacts", "AddressID", "dbo.Addresses");
            DropIndex("dbo.ContactMethods", new[] { "ContactId" });
            DropIndex("dbo.Contacts", new[] { "AddressID" });
            DropTable("dbo.Contacts");
            DropTable("dbo.ContactMethods");
            DropTable("dbo.Addresses");
        }
    }
}
