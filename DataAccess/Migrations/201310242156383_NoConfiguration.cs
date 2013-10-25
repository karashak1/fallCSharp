namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NoConfiguration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contacts", "KeywordsId", "dbo.Keywords");
            DropForeignKey("dbo.Keywords", "KeywordsId", "dbo.Keywords");
            DropIndex("dbo.Contacts", new[] { "KeywordsId" });
            DropIndex("dbo.Keywords", new[] { "KeywordsId" });
            AddColumn("dbo.Contacts", "Keyword_Id", c => c.Int());
            AddColumn("dbo.Keywords", "Parent_Id", c => c.Int());
            AlterColumn("dbo.Contacts", "FirstName", c => c.String());
            AlterColumn("dbo.Contacts", "LastName", c => c.String());
            AlterColumn("dbo.Contacts", "fbid", c => c.String());
            AlterColumn("dbo.ContactMethods", "Value", c => c.String());
            AlterColumn("dbo.Keywords", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Keywords", "Name", c => c.String());
            CreateIndex("dbo.Contacts", "Keyword_Id");
            CreateIndex("dbo.Keywords", "Parent_Id");
            AddForeignKey("dbo.Contacts", "Keyword_Id", "dbo.Keywords", "Id");
            AddForeignKey("dbo.Keywords", "Parent_Id", "dbo.Keywords", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Keywords", "Parent_Id", "dbo.Keywords");
            DropForeignKey("dbo.Contacts", "Keyword_Id", "dbo.Keywords");
            DropIndex("dbo.Keywords", new[] { "Parent_Id" });
            DropIndex("dbo.Contacts", new[] { "Keyword_Id" });
            AlterColumn("dbo.Keywords", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Keywords", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.ContactMethods", "Value", c => c.String(nullable: false));
            AlterColumn("dbo.Contacts", "fbid", c => c.String(maxLength: 500));
            AlterColumn("dbo.Contacts", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Contacts", "FirstName", c => c.String(nullable: false));
            DropColumn("dbo.Keywords", "Parent_Id");
            DropColumn("dbo.Contacts", "Keyword_Id");
            CreateIndex("dbo.Keywords", "KeywordsId");
            CreateIndex("dbo.Contacts", "KeywordsId");
            AddForeignKey("dbo.Keywords", "KeywordsId", "dbo.Keywords", "Id");
            AddForeignKey("dbo.Contacts", "KeywordsId", "dbo.Keywords", "Id", cascadeDelete: true);
        }
    }
}
