using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Localization;
using Nop.Services.Authentication;
using Nop.Services.Common;
using Nop.Services.Customers;
using Nop.Services.Events;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Orders;
using Nop.Web.Factories;
using Nop.Web.Models.Customer;
using Nop.Web.Models.Mobile.Account;

namespace Nop.Web.Controllers.Mobile
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        #region Fields

        private readonly CustomerSettings _customerSettings;
        private readonly IAuthenticationService _authenticationService;
        private readonly ICustomerActivityService _customerActivityService;
        private readonly ICustomerRegistrationService _customerRegistrationService;
        private readonly ICustomerService _customerService;
        private readonly IEventPublisher _eventPublisher;
        private readonly ILocalizationService _localizationService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IWorkContext _workContext;
        private readonly ICustomerModelFactory _customerModelFactory;
        private readonly IStoreContext _storeContext;
        private readonly IGenericAttributeService _genericAttributeService;
        private readonly IAddressService _addressService;
        private readonly IWorkflowMessageService _workflowMessageService;
        private readonly LocalizationSettings _localizationSettings;

        #endregion
        public AccountController(CustomerSettings customerSettings,
        IAuthenticationService authenticationService,
        ICustomerActivityService customerActivityService,
        ICustomerRegistrationService customerRegistrationService,
        ICustomerService customerService,
        IEventPublisher eventPublisher,
        ILocalizationService localizationService,
        IShoppingCartService shoppingCartService,
        IWorkContext workContext,
        IStoreContext storeContext,
        IAddressService addressService,
        ICustomerModelFactory customerModelFactory,
        IGenericAttributeService genericAttributeService,
        IWorkflowMessageService workflowMessageService,
        LocalizationSettings localizationSettings)
        {
            _customerSettings = customerSettings;
            _authenticationService = authenticationService;
            _customerActivityService = customerActivityService;
            _customerRegistrationService = customerRegistrationService;
            _customerService = customerService;
            _eventPublisher = eventPublisher;
            _localizationService = localizationService;
            _shoppingCartService = shoppingCartService;
            _workContext = workContext;
            _customerModelFactory = customerModelFactory;
            _storeContext = storeContext;
            _genericAttributeService = genericAttributeService;
            _addressService = addressService;
            _localizationSettings = localizationSettings;
            _workflowMessageService = workflowMessageService;
        }

        [HttpPost]
        [Route("Login")]
        //[ValidateCaptcha]
        //available even when a store is closed
        //[CheckAccessClosedStore(true)]
        //available even when navigation is not allowed
        //[CheckAccessPublicStore(true)]
        public IActionResult Login(LoginMobModel model)
        {
            ////validate CAPTCHA
            //if (_captchaSettings.Enabled && _captchaSettings.ShowOnLoginPage && !captchaValid)
            //{
            //    return Content(_localizationService.GetResource("Common.WrongCaptchaMessage"));
            //}

            if (ModelState.IsValid)
            {
                if (_customerSettings.UsernamesEnabled && model.Username != null)
                {
                    model.Username = model.Username.Trim();
                }
                var loginResult = _customerRegistrationService.ValidateCustomer(_customerSettings.UsernamesEnabled ? model.Username : model.Email, model.Password);
                switch (loginResult)
                {
                    case CustomerLoginResults.Successful:
                        {
                            var customer = _customerSettings.UsernamesEnabled
                                ? _customerService.GetCustomerByUsername(model.Username)
                                : _customerService.GetCustomerByEmail(model.Email);

                            //migrate shopping cart
                            _shoppingCartService.MigrateShoppingCart(_workContext.CurrentCustomer, customer, true);

                            //sign in new customer
                            _authenticationService.SignIn(customer, model.RememberMe);

                            //raise event       
                            _eventPublisher.Publish(new CustomerLoggedinEvent(customer));

                            //activity log
                            _customerActivityService.InsertActivity(customer, "PublicStore.Login",
                                _localizationService.GetResource("ActivityLog.PublicStore.Login"), customer);


                            return Ok(customer.CustomerGuid.ToString());
                        }
                    case CustomerLoginResults.CustomerNotExist:
                        return Content(_localizationService.GetResource("Account.Login.WrongCredentials.CustomerNotExist"));
                        
                    case CustomerLoginResults.Deleted:
                        return Content(_localizationService.GetResource("Account.Login.WrongCredentials.Deleted"));
                        
                    case CustomerLoginResults.NotActive:
                        return Content(_localizationService.GetResource("Account.Login.WrongCredentials.NotActive"));
                        
                    case CustomerLoginResults.NotRegistered:
                        return Content(_localizationService.GetResource("Account.Login.WrongCredentials.NotRegistered"));
                        
                    case CustomerLoginResults.LockedOut:
                        return Content(_localizationService.GetResource("Account.Login.WrongCredentials.LockedOut"));
                        
                    case CustomerLoginResults.WrongPassword:
                    default:
                        return Content(_localizationService.GetResource("Account.Login.WrongCredentials"));
                        
                }
            }

            //If we got this far, something failed, redisplay form
            
            return NoContent();
        }
        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegistrationMobModel model)
        {
            Request.Headers.TryGetValue("token", out var token);
            if (!string.IsNullOrEmpty(token))
                return NoContent();
            _workContext.CurrentCustomer = _customerService.InsertGuestCustomer();
            var customer = _workContext.CurrentCustomer;
            if (ModelState.IsValid)
            {
                if (_customerSettings.UsernamesEnabled && model.Username != null)
                {
                    model.Username = model.Username.Trim();
                }

                var isApproved = _customerSettings.UserRegistrationType == UserRegistrationType.Standard;
                var registrationRequest = new CustomerRegistrationRequest(customer,
                    model.Email,
                    _customerSettings.UsernamesEnabled ? model.Username : model.Email,
                    model.Password,
                    _customerSettings.DefaultPasswordFormat,
                    _storeContext.CurrentStore.Id,
                    isApproved);
                var registrationResult = _customerRegistrationService.RegisterCustomer(registrationRequest);
                if (registrationResult.Success)
                {
                    //form fields
                    if (_customerSettings.GenderEnabled)
                        _genericAttributeService.SaveAttribute(customer, NopCustomerDefaults.GenderAttribute, model.Gender);
                    if (_customerSettings.FirstNameEnabled)
                        _genericAttributeService.SaveAttribute(customer, NopCustomerDefaults.FirstNameAttribute, model.FirstName);
                    if (_customerSettings.LastNameEnabled)
                        _genericAttributeService.SaveAttribute(customer, NopCustomerDefaults.LastNameAttribute, model.LastName);
                    if (_customerSettings.DateOfBirthEnabled)
                    {
                        var dateOfBirth = model.ParseDateOfBirth();
                        _genericAttributeService.SaveAttribute(customer, NopCustomerDefaults.DateOfBirthAttribute, dateOfBirth);
                    }
                    if (_customerSettings.CompanyEnabled)
                        _genericAttributeService.SaveAttribute(customer, NopCustomerDefaults.CompanyAttribute, model.Company);
                    if (_customerSettings.StreetAddressEnabled)
                        _genericAttributeService.SaveAttribute(customer, NopCustomerDefaults.StreetAddressAttribute, model.StreetAddress);
                    if (_customerSettings.StreetAddress2Enabled)
                        _genericAttributeService.SaveAttribute(customer, NopCustomerDefaults.StreetAddress2Attribute, model.StreetAddress2);
                    if (_customerSettings.ZipPostalCodeEnabled)
                        _genericAttributeService.SaveAttribute(customer, NopCustomerDefaults.ZipPostalCodeAttribute, model.ZipPostalCode);
                    if (_customerSettings.CityEnabled)
                        _genericAttributeService.SaveAttribute(customer, NopCustomerDefaults.CityAttribute, model.City);
                    if (_customerSettings.CountyEnabled)
                        _genericAttributeService.SaveAttribute(customer, NopCustomerDefaults.CountyAttribute, model.County);
                    if (_customerSettings.CountryEnabled)
                        _genericAttributeService.SaveAttribute(customer, NopCustomerDefaults.CountryIdAttribute, model.CountryId);
                    if (_customerSettings.CountryEnabled && _customerSettings.StateProvinceEnabled)
                        _genericAttributeService.SaveAttribute(customer, NopCustomerDefaults.StateProvinceIdAttribute,
                            model.StateProvinceId);
                    if (_customerSettings.PhoneEnabled)
                        _genericAttributeService.SaveAttribute(customer, NopCustomerDefaults.PhoneAttribute, model.Phone);
                    if (_customerSettings.FaxEnabled)
                        _genericAttributeService.SaveAttribute(customer, NopCustomerDefaults.FaxAttribute, model.Fax);

                    
                    //login customer now
                    if (isApproved)
                        _authenticationService.SignIn(customer, true);

                    //insert default address (if possible)
                    var defaultAddress = new Address
                    {
                        FirstName = _genericAttributeService.GetAttribute<string>(customer, NopCustomerDefaults.FirstNameAttribute),
                        LastName = _genericAttributeService.GetAttribute<string>(customer, NopCustomerDefaults.LastNameAttribute),
                        Email = customer.Email,
                        Company = _genericAttributeService.GetAttribute<string>(customer, NopCustomerDefaults.CompanyAttribute),
                        CountryId = _genericAttributeService.GetAttribute<int>(customer, NopCustomerDefaults.CountryIdAttribute) > 0
                            ? (int?)_genericAttributeService.GetAttribute<int>(customer, NopCustomerDefaults.CountryIdAttribute)
                            : null,
                        StateProvinceId = _genericAttributeService.GetAttribute<int>(customer, NopCustomerDefaults.StateProvinceIdAttribute) > 0
                            ? (int?)_genericAttributeService.GetAttribute<int>(customer, NopCustomerDefaults.StateProvinceIdAttribute)
                            : null,
                        County = _genericAttributeService.GetAttribute<string>(customer, NopCustomerDefaults.CountyAttribute),
                        City = _genericAttributeService.GetAttribute<string>(customer, NopCustomerDefaults.CityAttribute),
                        Address1 = _genericAttributeService.GetAttribute<string>(customer, NopCustomerDefaults.StreetAddressAttribute),
                        Address2 = _genericAttributeService.GetAttribute<string>(customer, NopCustomerDefaults.StreetAddress2Attribute),
                        ZipPostalCode = _genericAttributeService.GetAttribute<string>(customer, NopCustomerDefaults.ZipPostalCodeAttribute),
                        PhoneNumber = _genericAttributeService.GetAttribute<string>(customer, NopCustomerDefaults.PhoneAttribute),
                        FaxNumber = _genericAttributeService.GetAttribute<string>(customer, NopCustomerDefaults.FaxAttribute),
                        CreatedOnUtc = customer.CreatedOnUtc
                    };
                    if (_addressService.IsAddressValid(defaultAddress))
                    {
                        //some validation
                        if (defaultAddress.CountryId == 0)
                            defaultAddress.CountryId = null;
                        if (defaultAddress.StateProvinceId == 0)
                            defaultAddress.StateProvinceId = null;
                        //set default address
                        //customer.Addresses.Add(defaultAddress);

                        _addressService.InsertAddress(defaultAddress);

                        _customerService.InsertCustomerAddress(customer, defaultAddress);

                        customer.BillingAddressId = defaultAddress.Id;
                        customer.ShippingAddressId = defaultAddress.Id;

                        _customerService.UpdateCustomer(customer);
                    }

                    //notifications
                    if (_customerSettings.NotifyNewCustomerRegistration)
                        _workflowMessageService.SendCustomerRegisteredNotificationMessage(customer,
                            _localizationSettings.DefaultAdminLanguageId);

                    //raise event       
                    _eventPublisher.Publish(new CustomerRegisteredEvent(customer));

                    switch (_customerSettings.UserRegistrationType)
                    {
                        case UserRegistrationType.EmailValidation:
                            {
                                //email validation message
                                _genericAttributeService.SaveAttribute(customer, NopCustomerDefaults.AccountActivationTokenAttribute, Guid.NewGuid().ToString());
                                _workflowMessageService.SendCustomerEmailValidationMessage(customer, _workContext.WorkingLanguage.Id);

                                //result
                                return Ok(customer.CustomerGuid);
                            }
                        case UserRegistrationType.AdminApproval:
                            {
                                return Ok(customer.CustomerGuid);
                            }
                        case UserRegistrationType.Standard:
                            {
                                //send customer welcome message
                                _workflowMessageService.SendCustomerWelcomeMessage(customer, _workContext.WorkingLanguage.Id);

                                //raise event       
                                _eventPublisher.Publish(new CustomerActivatedEvent(customer));

                                return Ok(customer.CustomerGuid);
                            }
                        default:
                            {
                                return RedirectToRoute("Homepage");
                            }
                    }
                }

                //errors

                return Ok(new { Errors = registrationResult.Errors, Count = registrationResult.Errors.Count });
            }

            //If we got this far, something failed, redisplay form
            return Forbid();
        }

        [HttpGet]
        [Route("Logout")]
        public IActionResult Logout()
        {
            Request.Headers.TryGetValue("token", out var token);
            if (string.IsNullOrEmpty(token))
                return NoContent();
            Guid guid = Guid.Parse(token);
            var customer = _customerService.GetCustomerByGuid(guid);
            if (customer == null)
                return NotFound();
            //activity log
            _customerActivityService.InsertActivity(customer, "PublicStore.Logout",
                _localizationService.GetResource("ActivityLog.PublicStore.Logout"), customer);

            //standard logout 
            _authenticationService.SignOut();

            //raise logged out event       
            _eventPublisher.Publish(new CustomerLoggedOutEvent(customer));


            return Ok();
        }

        [HttpGet]
        [Route("Info")]
        public virtual IActionResult Info()
        {
            Request.Headers.TryGetValue("token", out var token);
            if (string.IsNullOrEmpty(token))
                return NoContent();
            Guid guid = Guid.Parse(token);
            var customer = _customerService.GetCustomerByGuid(guid);
            if (customer == null)
                return NotFound();
            var model = new CustomerInfoModel();
            model = _customerModelFactory.PrepareCustomerInfoModel(model, customer, false);

            return Ok(model);
        }
    }
}
