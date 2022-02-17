using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nop.Web.Factories;
using Nop.Web.Models.Directory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nop.Web.Controllers.Mobile
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        #region Fields

        private readonly ICountryModelFactory _countryModelFactory;

        #endregion
        #region Ctor

        public CountryController(ICountryModelFactory countryModelFactory)
        {
            _countryModelFactory = countryModelFactory;
        }

        #endregion

        #region States / provinces

        //available even when navigation is not allowed
        //[CheckAccessPublicStore(true)]
        [HttpGet]
        [Route("GetStatesByCountryId")]
        public IEnumerable<StateProvinceModel> GetStatesByCountryId(string countryId, bool addSelectStateItem)
        {
            var model = _countryModelFactory.GetStatesByCountryId(countryId, addSelectStateItem);
            return model;
        }

        #endregion
    }
}
