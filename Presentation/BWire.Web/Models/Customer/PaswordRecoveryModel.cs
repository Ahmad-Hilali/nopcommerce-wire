using System.ComponentModel.DataAnnotations;
using BWire.Web.Framework.Mvc.ModelBinding;
using BWire.Web.Framework.Models;

namespace BWire.Web.Models.Customer
{
    public partial class PasswordRecoveryModel : BaseNopModel
    {
        [DataType(DataType.EmailAddress)]
        [NopResourceDisplayName("Account.PasswordRecovery.Email")]
        public string Email { get; set; }

        public string Result { get; set; }

        public bool DisplayCaptcha { get; set; }
    }
}