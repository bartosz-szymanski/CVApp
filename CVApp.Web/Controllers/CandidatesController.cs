using CVApp.Web.Models;
using CVApp.Web.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace CVApp.Web.Controllers
{
    public class CandidatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CandidatesController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new CandidateViewModel()
            {
                Positions = _context.Positions.ToList()
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CandidateViewModel viewModel, byte[] upload)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Positions = _context.Positions.ToList();
                return View("Create", viewModel);
            }

            byte[] uploadedFile = new byte[upload.Length];
            using (var fs = new FileStream(string.Empty, FileMode.Append))
            {
                using (var reader = new BinaryReader(fs))
                {
                    uploadedFile = reader.ReadBytes(upload.);
                }
            }

            var gig = new Candidate()
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                EmailAddress = viewModel.EmailAddress,
                PhoneNumber = viewModel.PhoneNumber,
                City = viewModel.City,
                UserId = User.Identity.GetUserId(),
                HasAcceptedAgreements = viewModel.HasAcceptedAgreements,
                PositionId = viewModel.PositionId,
                CreationDate = DateTime.Now,
                ModificationDate = DateTime.Now,
                ResumeFile = uploadedFile
            };
            _context.Candidates.Add(gig);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}