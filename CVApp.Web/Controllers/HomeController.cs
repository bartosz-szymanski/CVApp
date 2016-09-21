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

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(collection.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}