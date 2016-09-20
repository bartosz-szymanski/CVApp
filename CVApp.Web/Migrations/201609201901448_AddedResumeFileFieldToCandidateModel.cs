namespace CVApp.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedResumeFileFieldToCandidateModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidates", "ResumeFile", c => c.Binary(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Candidates", "ResumeFile");
        }
    }
}
