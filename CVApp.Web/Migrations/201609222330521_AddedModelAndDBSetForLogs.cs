namespace CVApp.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedModelAndDBSetForLogs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Category = c.Int(nullable: false),
                        Details = c.String(),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModificationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Logs");
        }
    }
}
