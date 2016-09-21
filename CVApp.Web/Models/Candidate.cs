using System;
using System.ComponentModel.DataAnnotations;

namespace CVApp.Web.Models
{
    public class Candidate : IBaseEntity
    {
        //TODO: Change DataAnnotations into FluentApi
        [Required]
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string City { get; set; }

        [Required]
        public bool HasAcceptedAgreements { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }

        public byte[] ResumeFile { get; set; }

        public Position Position { get; set; }

        [Required]
        public long PositionId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public string UserId { get; set; }

    }
}