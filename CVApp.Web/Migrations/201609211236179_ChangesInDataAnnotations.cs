namespace CVApp.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesInDataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Candidates", "ResumeFile", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Candidates", "ResumeFile", c => c.Binary(nullable: false));
        }
    }
}
