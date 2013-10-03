namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Start : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactMethods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(nullable: false),
                        ContactId = c.Int(nullable: false),
                        KeywordID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: false)
                .ForeignKey("dbo.Keywords", t => t.KeywordID, cascadeDelete: false)
                .Index(t => t.ContactId)
                .Index(t => t.KeywordID);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        KeywordsId = c.Int(nullable: false),
                        fbid = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Keywords", t => t.KeywordsId, cascadeDelete: false)
                .Index(t => t.KeywordsId);
            
            CreateTable(
                "dbo.Keywords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        KeywordsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Keywords", t => t.KeywordsId)
                .Index(t => t.KeywordsId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Keywords", new[] { "KeywordsId" });
            DropIndex("dbo.Contacts", new[] { "KeywordsId" });
            DropIndex("dbo.ContactMethods", new[] { "KeywordID" });
            DropIndex("dbo.ContactMethods", new[] { "ContactId" });
            DropForeignKey("dbo.Keywords", "KeywordsId", "dbo.Keywords");
            DropForeignKey("dbo.Contacts", "KeywordsId", "dbo.Keywords");
            DropForeignKey("dbo.ContactMethods", "KeywordID", "dbo.Keywords");
            DropForeignKey("dbo.ContactMethods", "ContactId", "dbo.Contacts");
            DropTable("dbo.Keywords");
            DropTable("dbo.Contacts");
            DropTable("dbo.ContactMethods");
        }
    }
}
