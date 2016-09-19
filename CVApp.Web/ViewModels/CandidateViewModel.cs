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
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is a required field.")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is a required field.")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string City { get; set; }

        [Required(ErrorMessage = "Accepting agreements is required to fulfill reqruitment process.")]
        public bool HasAcceptedAgreements { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }

        public IEnumerable<Position> Positions { get; set; }

        [Required(ErrorMessage = "Position is a required field.")]
        public long PositionId { get; set; }
    }
}