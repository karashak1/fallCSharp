namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Start1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Keywords", "Id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Keywords", "Id", c => c.Int(nullable: false, identity: true));
        }
    }
}
