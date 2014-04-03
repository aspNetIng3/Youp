namespace Youpe.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserProfile", "Gender", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserProfile", "Gender", c => c.Int(nullable: false));
        }
    }
}
