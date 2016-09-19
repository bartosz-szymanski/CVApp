using CVApp.Web.Models;

namespace CVApp.Web.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<CVApp.Web.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CVApp.Web.Models.ApplicationDbContext";
        }

        protected override void Seed(CVApp.Web.Models.ApplicationDbContext context)
        {

            context.Positions.AddOrUpdate(
              p => p.Name,
              new Position { Name = "Junior Software Developer" },
              new Position { Name = "Medium Software Developer" },
              new Position { Name = "Senior Software Developer" },
              new Position { Name = "Junior Quality  Assurance" },
              new Position { Name = "Medium Quality  Assurance" },
              new Position { Name = "Senior Quality  Assurance" },
              new Position { Name = "Scrum Master" },
              new Position { Name = "Business Analytic" },
              new Position { Name = "Project Manager" }
            );

        }
    }
}
