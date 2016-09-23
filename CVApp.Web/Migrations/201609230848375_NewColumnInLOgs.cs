namespace CVApp.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewColumnInLOgs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logs", "Exception", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Logs", "Exception");
        }
    }
}
