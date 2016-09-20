using CVApp.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CVApp.Web.ViewModels
{
    public class CandidateViewModel
    {
        [Required(ErrorMessage = "First name is a required field.")]
        [StringLength(50)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is a required field.")]
        [StringLength(50)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is a required field.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }

        public string City { get; set; }

        [Display(Name = "Terms and Conditions")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "You gotta tick the box, bro!")]
        public bool HasAcceptedAgreements { get; set; }

        [Display(Name = "Resume")]
        [Required(ErrorMessage = "Yours resume is required.")]
        public byte[] ResumeFile { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }

        [Required(ErrorMessage = "Position is a required field.")]
        [Display(Name = "Position")]
        public long PositionId { get; set; }

        public IEnumerable<Position> Positions { get; set; }
    }
}