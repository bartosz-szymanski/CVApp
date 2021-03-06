﻿using CVApp.Web.Helpers;
using CVApp.Web.Models;
using CVApp.Web.Models.Enums;
using CVApp.Web.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
        public ActionResult Create(CandidateViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    viewModel.Positions = _context.Positions.ToList();
                    return View("Create", viewModel);
                }


                var candidate = new Candidate()
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
                    ModificationDate = DateTime.Now
                };

                candidate.SetContentOfFile(viewModel.ResumeFile);

                _context.Candidates.Add(candidate);
                _context.SaveChanges();

                SendMailToCandidate(candidate);

                return RedirectToAction("Index", "Home");

            }
            catch (Exception ex)
            {
                var log = new Log(LogCategory.Error, "HomeController/DownloadFile/" + nameof(viewModel), ex.ToString());
                _context.Logs.Add(log);
                _context.SaveChanges();
            }
            return new EmptyResult();
        }

        private void SendMailToCandidate(Candidate candidate)
        {
            try
            {
                MailMessage message = new MailMessage("CVAppBaybe@hotmail.com", candidate.EmailAddress, Resource.CompanyNameGoesHere, Resource.ApplicationAddedToDatabase);
                NetworkCredential netCred = new NetworkCredential("CVAppBaybe@hotmail.com", "TesT1279"); //TODO: Move to config file.
                SmtpClient client = new SmtpClient("smtp.live.com", 587);
                message.Body = Resource.ApplicationAddedToDatabase;
                message.Subject = Resource.CompanyNameGoesHere;
                client.EnableSsl = true;
                client.Credentials = netCred;
                client.Send(message);
            }
            catch (Exception ex)
            {
                var log = new Log(LogCategory.Error, "HomeController/SendMailToCandidate", ex.ToString());
                _context.Logs.Add(log);
                _context.SaveChanges();
            }

        }
    }
}