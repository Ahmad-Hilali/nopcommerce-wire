using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Shipping;
using Nop.Core.Http.Extensions;
using Nop.Services.Common;
using Nop.Services.Customers;
using Nop.Services.Localization;
using Nop.Services.Orders;
using Nop.Services.Payments;
using Nop.Web.Extensions;
using Nop.Web.Factories;
using Nop.Web.Factories.Mobile;
using Nop.Web.Models.Mobile.Checkout;

namespace Nop.Web.Controllers.Mobile
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        #region Fields
        private readonly AddressSettings _addressSettings;
        private readonly ICheckoutMobFactory _checkoutMobFactory;
        private readonly IAddressService _addressService;
        private readonly ICheckoutModelFactory _checkoutModelFactory;
        private readonly ICustomerService _customerService;
        private readonly IGenericAttributeService _genericAttributeService;
        private readonly ILocalizationService _localizationService;
        private readonly IOrderProcessingService _orderProcessingService;
        private readonly IOrderService _orderService;
        private readonly IPaymentService _paymentService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IStoreContext _storeContext;
        private readonly OrderSettings _orderSettings;
        #endregion
        #region Constructor
        public CheckoutController(
            ICheckoutMobFactory checkoutMobFactory,
        AddressSettings addressSettings,
            IAddressService addressService,
            ICheckoutModelFactory checkoutModelFactory,
            ICustomerService customerService,
            IGenericAttributeService genericAttributeService,
            ILocalizationService localizationService,
            IOrderProcessingService orderProcessingService,
            IOrderService orderService,
            IPaymentService paymentService,
            IShoppingCartService shoppingCartService,
            IStoreContext storeContext,
            OrderSettings orderSettings
            )
        {
            _checkoutMobFactory = checkoutMobFactory;
            _addressSettings = addressSettings;
            _addressService = addressService;
            _checkoutModelFactory = checkoutModelFactory;
            _customerService = customerService;
            _genericAttributeService = genericAttributeService;
            _localizationService = localizationService;
            _orderProcessingService = orderProcessingService;
            _orderService = orderService;
            _paymentService = paymentService;
            _shoppingCartService = shoppingCartService;
            _storeContext = storeContext;
            _orderSettings = orderSettings;
        }
        #endregion
        #region Actions
        [HttpPost]
        [Route("SaveBilling")]
        public IActionResult SaveBilling(BillingInputMobModel model)
        {
            try
            {
                //validation
                if (_orderSettings.CheckoutDisabled)
                    return Ok(new
                    {
                        Success = false,
                        Msg = _localizationService.GetResource("Checkout.Disabled")
                    });
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
                var cart = _shoppingCartService.GetShoppingCart(customer, ShoppingCartType.ShoppingCart, _storeContext.CurrentStore.Id);

                if (!cart.Any())
                    return Ok(new
                    {
                        Success = false,
                        Msg = "Your cart is empty"
                    });


                if (_customerService.IsGuest(customer) && !_orderSettings.AnonymousCheckoutAllowed)
                return Ok(new
                {
                    Success = false,
                    Msg = "Anonymous checkout is not allowed"
                });

                if (model.BillingAddressId > 0)
                {
                    //existing address
                    var address = _customerService.GetCustomerAddress(customer.Id, model.BillingAddressId);
                    if (address == null)
                        return Ok(new
                        {
                            Success = false,
                            Msg = _localizationService.GetResource("Checkout.Address.NotFound")
                        });
                    customer.BillingAddressId = address.Id;
                    customer.ShippingAddressId = address.Id;
                }
                else
                {
                    //new address
                    var newAddress = model.BillingAddress;

                    //try to find an address with the same values (don't duplicate records)
                    var address = _addressService.FindAddress(_customerService.GetAddressesByCustomerId(customer.Id).ToList(),
                        newAddress.FirstName, newAddress.LastName, newAddress.PhoneNumber,
                        newAddress.Email, newAddress.FaxNumber, newAddress.Company,
                        newAddress.Address1, newAddress.Address2, newAddress.City,
                        newAddress.County, newAddress.StateProvinceId, newAddress.ZipPostalCode,
                        newAddress.CountryId, "");

                    if (address == null)
                    {
                        //address is not found. let's create a new one
                        address = newAddress.ToEntity();
                        address.CustomAttributes = "";
                        address.CreatedOnUtc = DateTime.UtcNow;

                        //some validation
                        if (address.CountryId == 0)
                            address.CountryId = null;

                        if (address.StateProvinceId == 0)
                            address.StateProvinceId = null;

                        _addressService.InsertAddress(address);

                        _customerService.InsertCustomerAddress(customer, address);
                    }

                    customer.BillingAddressId = address.Id;
                    customer.ShippingAddressId = address.Id;
                    
                }
                _genericAttributeService.SaveAttribute<ShippingOption>(customer, NopCustomerDefaults.SelectedShippingOptionAttribute, null, _storeContext.CurrentStore.Id);
                _genericAttributeService.SaveAttribute<PickupPoint>(customer, NopCustomerDefaults.SelectedPickupPointAttribute, null, _storeContext.CurrentStore.Id);
                _customerService.UpdateCustomer(customer);
                var shippingMethodModel = _checkoutModelFactory.PrepareShippingMethodModel(cart, _customerService.GetCustomerShippingAddress(customer));
                _genericAttributeService.SaveAttribute(customer,
                NopCustomerDefaults.SelectedShippingOptionAttribute,
                shippingMethodModel.ShippingMethods.First().ShippingOption,
                _storeContext.CurrentStore.Id);

                var filterByCountryId = _customerService.GetCustomerBillingAddress(customer)?.CountryId ?? 0;
                var paymentMethodModel = _checkoutModelFactory.PreparePaymentMethodModel(cart, filterByCountryId);
                _genericAttributeService.SaveAttribute(customer,
                    NopCustomerDefaults.SelectedPaymentMethodAttribute,
                    paymentMethodModel.PaymentMethods[0].PaymentMethodSystemName,
                    _storeContext.CurrentStore.Id);
                return Ok(new
                {
                    Success = true,
                    Msg = ""
                });
            }
            catch (Exception exc)
            {
                return Ok(new
                {
                    Success = false,
                    Msg = exc.Message
                });
            }
        }

        [HttpPost]
        [Route("ConfirmOrder")]
        public virtual IActionResult ConfirmOrder()
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
            //validation
            if (_orderSettings.CheckoutDisabled)
                return RedirectToRoute("ShoppingCart");

            var cart = _shoppingCartService.GetShoppingCart(customer, ShoppingCartType.ShoppingCart, _storeContext.CurrentStore.Id);

            if (!cart.Any())
                return RedirectToRoute("ShoppingCart");

            if (_orderSettings.OnePageCheckoutEnabled)
                return RedirectToRoute("CheckoutOnePage");

            if (_customerService.IsGuest(customer) && !_orderSettings.AnonymousCheckoutAllowed)
                return Challenge();

            //model
            var model = _checkoutModelFactory.PrepareConfirmOrderModel(cart);
            try
            {
                //prevent 2 orders being placed within an X seconds time frame
                if (!IsMinimumOrderPlacementIntervalValid(customer))
                    throw new Exception(_localizationService.GetResource("Checkout.MinOrderPlacementInterval"));

                //place order
                var processPaymentRequest = HttpContext.Session.Get<ProcessPaymentRequest>("OrderPaymentInfo");
                if (processPaymentRequest == null)
                {
                    processPaymentRequest = new ProcessPaymentRequest();
                }
                _paymentService.GenerateOrderGuid(processPaymentRequest);
                processPaymentRequest.StoreId = _storeContext.CurrentStore.Id;
                processPaymentRequest.CustomerId = customer.Id;
                processPaymentRequest.PaymentMethodSystemName = _genericAttributeService.GetAttribute<string>(customer,
                    NopCustomerDefaults.SelectedPaymentMethodAttribute, _storeContext.CurrentStore.Id);
                HttpContext.Session.Set<ProcessPaymentRequest>("OrderPaymentInfo", processPaymentRequest);
                var placeOrderResult = _orderProcessingService.PlaceOrder(processPaymentRequest);
                if (placeOrderResult.Success)
                {
                    HttpContext.Session.Set<ProcessPaymentRequest>("OrderPaymentInfo", null);
                    var postProcessPaymentRequest = new PostProcessPaymentRequest
                    {
                        Order = placeOrderResult.PlacedOrder
                    };
                    _paymentService.PostProcessPayment(postProcessPaymentRequest);
                    return Ok(new
                    {
                        Success = true,
                        Msg = "Successed"
                    });
                }

                foreach (var error in placeOrderResult.Errors)
                    model.Warnings.Add(error);
            }
            catch (Exception exc)
            {
                model.Warnings.Add(exc.Message);
            }

            //If we got this far, something failed, redisplay form
            
            return Ok(new
            {
                Success = false,
                Msg = "",
                Data = model
            });
        }

        [Route("GetValidAddresses")]
        public IActionResult GetValidAddressesByCustomer()
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
            var model = _checkoutMobFactory.GetValidAddressesByCustomerId(customer.Id);
            if(!model.Any())
                return Ok(new
                {
                    Success = false,
                    Msg = "No addresses has found"
                });
            return Ok(new
            {
                Success = true,
                Msg = "",
                Data = model
            });
        }

        [Route("GetInvalidAddresses")]
        public IActionResult GetInvalidAddressesByCustomer()
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
            var model = _checkoutMobFactory.GetInvalidAddressesByCustomerId(customer.Id);
            if (!model.Any())
                return Ok(new
                {
                    Success = false,
                    Msg = "No addresses has found"
                });
            return Ok(new
            {
                Success = true,
                Msg = "",
                Data = model
            });
        }

        [Route("GetBillingAddressModel")]
        public IActionResult GetBillingAddressModel()
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
            var model = _checkoutMobFactory.PrepareAddressMobModel(customer.Id);
            if (model == null)
                return Ok(new
                {
                    Success = false,
                    Msg = "Error in preparing model"
                });
            return Ok(new
            {
                Success = true,
                Msg = "",
                Data = model
            });
        }
        #endregion

        #region Heplers
        protected virtual bool IsMinimumOrderPlacementIntervalValid(Customer customer)
        {
            //prevent 2 orders being placed within an X seconds time frame
            if (_orderSettings.MinimumOrderPlacementInterval == 0)
                return true;

            var lastOrder = _orderService.SearchOrders(storeId: _storeContext.CurrentStore.Id,
                customerId: customer.Id, pageSize: 1)
                .FirstOrDefault();
            if (lastOrder == null)
                return true;

            var interval = DateTime.UtcNow - lastOrder.CreatedOnUtc;
            return interval.TotalSeconds > _orderSettings.MinimumOrderPlacementInterval;
        }
        #endregion
    }
}
