using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.Common;
using Nop.Services.Common;
using Nop.Services.Customers;
using Nop.Services.Directory;
using Nop.Services.Orders;
using Nop.Web.Extensions;
using Nop.Web.Factories;
using Nop.Web.Factories.Mobile;
using Nop.Web.Models.Mobile.Checkout;

namespace Nop.Web.Controllers.Mobile
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        #region Fields

        private readonly AddressSettings _addressSettings;
        //private readonly CaptchaSettings _captchaSettings;
        //private readonly CustomerSettings _customerSettings;
        //private readonly DateTimeSettings _dateTimeSettings;
        //private readonly IDownloadService _downloadService;
        //private readonly ForumSettings _forumSettings;
        //private readonly GdprSettings _gdprSettings;
        //private readonly IAddressAttributeParser _addressAttributeParser;
        private readonly IAddressService _addressService;
        //private readonly IAuthenticationService _authenticationService;
        private readonly ICountryService _countryService;
        //private readonly ICurrencyService _currencyService;
        //private readonly ICustomerActivityService _customerActivityService;
        //private readonly ICustomerAttributeParser _customerAttributeParser;
        //private readonly ICustomerAttributeService _customerAttributeService;
        private readonly ICustomerMobFactory _customerModelFactory;
        //private readonly ICustomerRegistrationService _customerRegistrationService;
        private readonly ICustomerService _customerService;
        //private readonly IEventPublisher _eventPublisher;
        //private readonly IExportManager _exportManager;
        //private readonly IExternalAuthenticationService _externalAuthenticationService;
        //private readonly IGdprService _gdprService;
        //private readonly IGenericAttributeService _genericAttributeService;
        //private readonly IGiftCardService _giftCardService;
        //private readonly ILocalizationService _localizationService;
        //private readonly ILogger _logger;
        //private readonly INewsLetterSubscriptionService _newsLetterSubscriptionService;
        private readonly IOrderService _orderService;
        //private readonly IPictureService _pictureService;
        //private readonly IPriceFormatter _priceFormatter;
        //private readonly IProductService _productService;
        //private readonly IShoppingCartService _shoppingCartService;
        //private readonly IStateProvinceService _stateProvinceService;
        //private readonly IStoreContext _storeContext;
        //private readonly ITaxService _taxService;
        //private readonly IWebHelper _webHelper;
        //private readonly IWorkContext _workContext;
        //private readonly IWorkflowMessageService _workflowMessageService;
        //private readonly LocalizationSettings _localizationSettings;
        //private readonly MediaSettings _mediaSettings;
        //private readonly StoreInformationSettings _storeInformationSettings;
        //private readonly TaxSettings _taxSettings;

        #endregion

        #region Ctor

        public CustomerController(
            AddressSettings addressSettings,
            //CaptchaSettings captchaSettings,
            //CustomerSettings customerSettings,
            //DateTimeSettings dateTimeSettings,
            //IDownloadService downloadService,
            //ForumSettings forumSettings,
            //GdprSettings gdprSettings,
            //IAddressAttributeParser addressAttributeParser,
            IAddressService addressService,
            //IAuthenticationService authenticationService,
            ICountryService countryService,
            //ICurrencyService currencyService,
            //ICustomerActivityService customerActivityService,
            //ICustomerAttributeParser customerAttributeParser,
            //ICustomerAttributeService customerAttributeService,
            ICustomerMobFactory customerModelFactory,
            //ICustomerRegistrationService customerRegistrationService,
            ICustomerService customerService,
            //IEventPublisher eventPublisher,
            //IExportManager exportManager,
            //IExternalAuthenticationService externalAuthenticationService,
            //IGdprService gdprService,
            //IGenericAttributeService genericAttributeService,
            //IGiftCardService giftCardService,
            //ILocalizationService localizationService,
            //ILogger logger,
            //INewsLetterSubscriptionService newsLetterSubscriptionService,
            IOrderService orderService
            //IPictureService pictureService,
            //IPriceFormatter priceFormatter,
            //IProductService productService,
            //IShoppingCartService shoppingCartService,
            //IStateProvinceService stateProvinceService,
            //IStoreContext storeContext,
            //ITaxService taxService,
            //IWebHelper webHelper,
            //IWorkContext workContext,
            //IWorkflowMessageService workflowMessageService,
            //LocalizationSettings localizationSettings,
            //MediaSettings mediaSettings,
            //StoreInformationSettings storeInformationSettings,
            //TaxSettings taxSettings
            )
        {
            _addressSettings = addressSettings;
            //_captchaSettings = captchaSettings;
            //_customerSettings = customerSettings;
            //_dateTimeSettings = dateTimeSettings;
            //_downloadService = downloadService;
            //_forumSettings = forumSettings;
            //_gdprSettings = gdprSettings;
            //_addressAttributeParser = addressAttributeParser;
            _addressService = addressService;
            //_authenticationService = authenticationService;
            _countryService = countryService;
            //_currencyService = currencyService;
            //_customerActivityService = customerActivityService;
            //_customerAttributeParser = customerAttributeParser;
            //_customerAttributeService = customerAttributeService;
            _customerModelFactory = customerModelFactory;
            //_customerRegistrationService = customerRegistrationService;
            _customerService = customerService;
            //_eventPublisher = eventPublisher;
            //_exportManager = exportManager;
            //_externalAuthenticationService = externalAuthenticationService;
            //_gdprService = gdprService;
            //_genericAttributeService = genericAttributeService;
            //_giftCardService = giftCardService;
            //_localizationService = localizationService;
            //_logger = logger;
            //_newsLetterSubscriptionService = newsLetterSubscriptionService;
            _orderService = orderService;
            //_pictureService = pictureService;
            //_priceFormatter = priceFormatter;
            //_productService = productService;
            //_shoppingCartService = shoppingCartService;
            //_stateProvinceService = stateProvinceService;
            //_storeContext = storeContext;
            //_taxService = taxService;
            //_webHelper = webHelper;
            //_workContext = workContext;
            //_workflowMessageService = workflowMessageService;
            //_localizationSettings = localizationSettings;
            //_mediaSettings = mediaSettings;
            //_storeInformationSettings = storeInformationSettings;
            //_taxSettings = taxSettings;
        }

        #endregion
        #region My account / Addresses

        [Route("Addresses")]
        public IActionResult Addresses()
        {
            Request.Headers.TryGetValue("token", out var token);
            if (string.IsNullOrEmpty(token))
                return Ok(new
                {
                    Success = false,
                    Msg = "Token is missed"
                });
            Guid guid = Guid.Parse(token);
            var customer = _customerService.GetCustomerByGuid(guid);
            if (customer == null)
                return Ok(new
                {
                    Success = false,
                    Msg = "Customer not found"
                });

            var model = _customerModelFactory.PrepareCustomerAddressesModel(customer);
            return Ok(new
            {
                Success = true,
                Msg = "",
                Data = model
            });
        }

        [HttpPost]
        [Route("AddressAdd")]
        public IActionResult AddressAdd(BillingInputMobModel model)
        {
            Request.Headers.TryGetValue("token", out var token);
            if (string.IsNullOrEmpty(token))
                return Ok(new
                {
                    Success = false,
                    Msg = "Token is missed"
                });
            Guid guid = Guid.Parse(token);
            var customer = _customerService.GetCustomerByGuid(guid);
            if (customer == null)
                return Ok(new
                {
                    Success = false,
                    Msg = "Customer not found"
                });

            if (ModelState.IsValid)
            {
                var address = model.BillingAddress.ToEntity();
                address.CreatedOnUtc = DateTime.UtcNow;
                //some validation
                if (address.CountryId == 0)
                    address.CountryId = null;
                if (address.StateProvinceId == 0)
                    address.StateProvinceId = null;


                _addressService.InsertAddress(address);

                _customerService.InsertCustomerAddress(customer, address);

                return Ok(new
                {
                    Success = true,
                    Msg = ""
                });
            }

            //If we got this far, something failed, redisplay form
            return Ok(new
            {
                Success = false,
                Msg = "Model is not valid"
            });
        }

        [HttpPost]
        [Route("AddressEdit")]
        public IActionResult AddressEdit(BillingInputMobModel model)
        {
            Request.Headers.TryGetValue("token", out var token);
            if (string.IsNullOrEmpty(token))
                return Ok(new
                {
                    Success = false,
                    Msg = "Token is missed"
                });
            Guid guid = Guid.Parse(token);
            var customer = _customerService.GetCustomerByGuid(guid);
            if (customer == null)
                return Ok(new
                {
                    Success = false,
                    Msg = "Customer not found"
                });
            //find address (ensure that it belongs to the current customer)
            var address = _customerService.GetCustomerAddress(customer.Id, model.BillingAddressId);
            if (address == null)
                //address is not found
                return Ok(new
                {
                    Success = false,
                    Msg = "Address Not Found"
                });

            if (ModelState.IsValid)
            {
                address = model.BillingAddress.ToEntity(address);
                _addressService.UpdateAddress(address);

                return Ok(new
                {
                    Success = true,
                    Msg = ""
                });
            }

            //If we got this far, something failed, redisplay form
            return Ok(new
            {
                Success = false,
                Msg = "Model is not valid"
            });
        }
        [HttpDelete]
        [Route("AddressDelete")]
        public IActionResult AddressDelete(int addressId)
        {
            Request.Headers.TryGetValue("token", out var token);
            if (string.IsNullOrEmpty(token))
                return Ok(new
                {
                    Success = false,
                    Msg = "Token is missed"
                });
            Guid guid = Guid.Parse(token);
            var customer = _customerService.GetCustomerByGuid(guid);
            if (customer == null)
                return Ok(new
                {
                    Success = false,
                    Msg = "Customer not found"
                });
            //find address (ensure that it belongs to the current customer)
            var address = _customerService.GetCustomerAddress(customer.Id, addressId);
            if (address != null)
            {
                _customerService.RemoveCustomerAddress(customer, address);
                _customerService.UpdateCustomer(customer);
                //now delete the address record
                _addressService.DeleteAddress(address);
                return Ok(new
                {
                    Success = true,
                    Msg = ""
                });
            }

            return Ok(new
            {
                Success = false,
                Msg = "Address Not Found"
            });
        }

        #endregion
        [Route("Orders")]
        public IActionResult CustomerOrders()
        {
            Request.Headers.TryGetValue("token", out var token);
            if (string.IsNullOrEmpty(token))
                return Ok(new
                {
                    Success = false,
                    Msg = "Token is missed"
                });
            Guid guid = Guid.Parse(token);
            var customer = _customerService.GetCustomerByGuid(guid);
            if (customer == null)
                return Ok(new
                {
                    Success = false,
                    Msg = "Customer not found"
                });

            var model = _customerModelFactory.PrepareCustomerOrderListModel(customer);
            return Ok(new
            {
                Success = true,
                Msg = "",
                Data = model
            });
        }
        [Route("OrderDetails")]
        public virtual IActionResult Details(int orderId)
        {
            var order = _orderService.GetOrderById(orderId);
            Request.Headers.TryGetValue("token", out var token);
            if (string.IsNullOrEmpty(token))
                return Ok(new
                {
                    Success = false,
                    Msg = "Token is missed"
                });
            Guid guid = Guid.Parse(token);
            var customer = _customerService.GetCustomerByGuid(guid);
            if (customer == null)
                return Ok(new
                {
                    Success = false,
                    Msg = "Customer not found"
                });
            if (order == null)
                return Ok(new
                {
                    Success = false,
                    Msg = "Order not found"
                });
            var model = _customerModelFactory.PrepareOrderDetailsModel(order);
            return Ok(new
            {
                Success = true,
                Msg = "",
                Data = model
            });
        }
    }
}
