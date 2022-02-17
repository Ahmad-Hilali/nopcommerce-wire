using Nop.Web.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nop.Web.Models.Mobile.Account
{
    public partial class LoginMobModel : BaseNopModel
    {
        public string Email { get; set; }

        //public UserRegistrationType RegistrationType { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}
