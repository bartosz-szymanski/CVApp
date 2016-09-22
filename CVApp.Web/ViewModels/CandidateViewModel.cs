using CVApp.Web.Helpers;
using CVApp.Web.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CVApp.Web.ViewModels
{
    public class CandidateViewModel
    {

        [Required(ErrorMessageResourceName = nameof(Resource.FirstNameRequired), ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = nameof(Resource.FirstName), ResourceType = typeof(Resource))]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceName = nameof(Resource.LastNameRequired), ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = nameof(Resource.LastName), ResourceType = typeof(Resource))]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessageResourceName = nameof(Resource.EmailAddressRequired), ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = nameof(Resource.EmailAddress), ResourceType = typeof(Resource))]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }


        [Required(ErrorMessageResourceName = nameof(Resource.PhoneNumberRequired), ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = nameof(Resource.PhoneNumber), ResourceType = typeof(Resource))]
        public string PhoneNumber { get; set; }

        public string City { get; set; }

        [MustBeTrue(ErrorMessageResourceName = nameof(Resource.TermsAndConditionsRequired), ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = nameof(Resource.TermsAndConditions), ResourceType = typeof(Resource))]
        public bool HasAcceptedAgreements { get; set; }

        //[Required(ErrorMessageResourceName = nameof(Resource.ResumeRequired), ErrorMessageResourceType = typeof(Resource))]
        //[Display(Name = nameof(Resource.Resume), ResourceType = typeof(Resource))]
        //public byte[] ResumeFile { get; set; }

        [Required(ErrorMessageResourceName = nameof(Resource.PositionRequired), ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = nameof(Resource.Position), ResourceType = typeof(Resource))]
        public long PositionId { get; set; }

        public IEnumerable<Position> Positions { get; set; }
    }
}