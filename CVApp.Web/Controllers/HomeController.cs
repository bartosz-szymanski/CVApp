using CVApp.Web.Models;
using PagedList;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace CVApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index(int? page)
        {
            var collection = _context.Candidates.Include(c => c.Position).OrderBy(c => c.Id);

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(collection.ToPagedList(pageNumber, pageSize));
        }


        public ActionResult DownloadFile(long? id)
        {
            if (!id.HasValue)
                return new EmptyResult();
            var candidate = _context.Candidates.SingleOrDefault(c => c.Id == id.Value);

            if (candidate == null)
                return new EmptyResult();

            var fileContents = candidate.ResumeFile;
            var fileName = $"{candidate.FirstName}{candidate.LastName}{".pdf"}";
            Response.AddHeader("Content-Disposition", $"attachment; filename={fileName}");
            return File(fileContents, "application/octet-stream");

        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}