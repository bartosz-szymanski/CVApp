using CVApp.Web.Models;
using CVApp.Web.Models.Enums;
using PagedList;
using System;
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
            try
            {
                var collection = _context.Candidates.Include(c => c.Position).OrderBy(c => c.Id);

                int pageSize = 5;
                int pageNumber = (page ?? 1);
                return View(collection.ToPagedList(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                var log = new Log(LogCategory.Error, "HomeController/Index", ex.ToString());
                _context.Logs.Add(log);
                _context.SaveChanges();
            }

            return new EmptyResult();
        }


        public ActionResult DownloadFile(long? id)
        {
            try
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
            catch (Exception ex)
            {
                var log = new Log(LogCategory.Error, "HomeController/DownloadFile/" + id, ex.ToString());
                _context.Logs.Add(log);
                _context.SaveChanges();
            }
            return new EmptyResult();
        }

        public ActionResult About()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                var log = new Log(LogCategory.Error, "HomeController/About", ex.ToString());
                _context.Logs.Add(log);
                _context.SaveChanges();
            }
            return new EmptyResult();
        }

        public ActionResult Contact()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                var log = new Log(LogCategory.Error, "HomeController/Contact", ex.ToString());
                _context.Logs.Add(log);
                _context.SaveChanges();
            }
            return new EmptyResult();
        }
    }
}