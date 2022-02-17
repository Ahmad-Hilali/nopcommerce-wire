using Nop.Web.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nop.Web.Models.Mobile.Account
{
    public partial class RegistrationMobModel : BaseNopModel
    {
        public RegistrationMobModel()
        {
        }

        public string Email { get; set; }
        public string ConfirmEmail { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        //form fields & properties
        public string Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? DateOfBirthDay { get; set; }
        public int? DateOfBirthMonth { get; set; }
        public int? DateOfBirthYear { get; set; }
        public DateTime? ParseDateOfBirth()
        {
            if (!DateOfBirthYear.HasValue || !DateOfBirthMonth.HasValue || !DateOfBirthDay.HasValue)
                return null;

            DateTime? dateOfBirth = null;
            try
            {
                dateOfBirth = new DateTime(DateOfBirthYear.Value, DateOfBirthMonth.Value, DateOfBirthDay.Value);
            }
            catch { }
            return dateOfBirth;
        }

        public string Company { get; set; }

        public string StreetAddress { get; set; }
        public string StreetAddress2 { get; set; }
        public string ZipPostalCode { get; set; }
        public string City { get; set; }
        public string County { get; set; }

        public int CountryId { get; set; }

        public int StateProvinceId { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }

    }
}
