namespace CVApp.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelBuilder : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Candidates", "CreationDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Candidates", "ModificationDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Positions", "CreationDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Positions", "ModificationDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime());
            AlterColumn("dbo.Positions", "ModificationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Positions", "CreationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Candidates", "ModificationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Candidates", "CreationDate", c => c.DateTime(nullable: false));
        }
    }
}
