using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Shipping;
using Nop.Core.Domain.Tax;
using Nop.Core.Domain.Vendors;
using Nop.Services.Catalog;
using Nop.Services.Common;
using Nop.Services.Customers;
using Nop.Services.Directory;
using Nop.Services.Helpers;
using Nop.Services.Localization;
using Nop.Services.Orders;
using Nop.Services.Payments;
using Nop.Services.Seo;
using Nop.Services.Shipping;
using Nop.Services.Stores;
using Nop.Services.Vendors;
using Nop.Web.Models.Common;
using Nop.Web.Models.Mobile.Checkout;
using Nop.Web.Models.Mobile.Customer;
using Nop.Web.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nop.Web.Factories.Mobile
{
    public class CustomerMobFactory : ICustomerMobFactory
    {
        #region Fields
        private readonly IShipmentService _shipmentService;
        private readonly IAddressService _addressService;
        private readonly IOrderProcessingService _orderProcessingService;
        private readonly IPriceFormatter _priceFormatter;
        private readonly ICurrencyService _currencyService;
        private readonly AddressSettings _addressSettings;
        private readonly IPaymentService _paymentService;
        //private readonly CaptchaSettings _captchaSettings;
        private readonly CatalogSettings _catalogSettings;
        private readonly IGiftCardService _giftCardService;
        //private readonly CommonSettings _commonSettings;
        private readonly CustomerSettings _customerSettings;
        //private readonly DateTimeSettings _dateTimeSettings;
        private readonly ExternalAuthenticationSettings _externalAuthenticationSettings;
        //private readonly ForumSettings _forumSettings;
        //private readonly GdprSettings _gdprSettings;
        private readonly IAddressModelFactory _addressModelFactory;
        //private readonly IAuthenticationPluginManager _authenticationPluginManager;
        private readonly ICountryService _countryService;
        private readonly ICustomerAttributeParser _customerAttributeParser;
        private readonly ICustomerAttributeService _customerAttributeService;
        private readonly ICustomerService _customerService;
        private readonly IDateTimeHelper _dateTimeHelper;
        private readonly IRewardPointService _rewardPointService;
        private readonly IUrlRecordService _urlRecordService;
        private readonly IVendorService _vendorService;
        private readonly VendorSettings _vendorSettings;
        //private readonly IExternalAuthenticationService _externalAuthenticationService;
        //private readonly IGdprService _gdprService;
        //private readonly IGenericAttributeService _genericAttributeService;
        private readonly ILocalizationService _localizationService;
        private readonly IPaymentPluginManager _paymentPluginManager;
        //private readonly INewsLetterSubscriptionService _newsLetterSubscriptionService;
        private readonly IOrderService _orderService;
        //private readonly IPictureService _pictureService;
        private readonly IProductService _productService;
        private readonly IReturnRequestService _returnRequestService;
        private readonly IStateProvinceService _stateProvinceService;
        private readonly IStoreContext _storeContext;
        private readonly IStoreMappingService _storeMappingService;
        //private readonly IUrlRecordService _urlRecordService;
        private readonly IWorkContext _workContext;
        //private readonly MediaSettings _mediaSettings;
        private readonly OrderSettings _orderSettings;
        private readonly RewardPointsSettings _rewardPointsSettings;
        //private readonly SecuritySettings _securitySettings;
        private readonly TaxSettings _taxSettings;
        //private readonly VendorSettings _vendorSettings;

        #endregion

        #region Ctor

        public CustomerMobFactory(
            IShipmentService shipmentService,
            IPaymentService paymentService,
            IOrderProcessingService orderProcessingService,
            IPriceFormatter priceFormatter,
            ICurrencyService currencyService,
            IAddressService addressService,
            IPaymentPluginManager paymentPluginManager,
            IRewardPointService rewardPointService,
            AddressSettings addressSettings,
            IUrlRecordService urlRecordService,
            IVendorService vendorService,
            VendorSettings vendorSettings,
            //CaptchaSettings captchaSettings,
            CatalogSettings catalogSettings,
            //CommonSettings commonSettings,
            CustomerSettings customerSettings,
            //DateTimeSettings dateTimeSettings,
            ExternalAuthenticationSettings externalAuthenticationSettings,
            //ForumSettings forumSettings,
            //GdprSettings gdprSettings,
            IAddressModelFactory addressModelFactory,
            //IAuthenticationPluginManager authenticationPluginManager,
            ICountryService countryService,
            ICustomerAttributeParser customerAttributeParser,
            ICustomerAttributeService customerAttributeService,
            ICustomerService customerService,
            IDateTimeHelper dateTimeHelper,
            //IExternalAuthenticationService externalAuthenticationService,
            //IGdprService gdprService,
            //IGenericAttributeService genericAttributeService,
            ILocalizationService localizationService,
            //INewsLetterSubscriptionService newsLetterSubscriptionService,
            IOrderService orderService,
            //IPictureService pictureService,
            IProductService productService,
            IReturnRequestService returnRequestService,
            IStateProvinceService stateProvinceService,
            IStoreContext storeContext,
            IGiftCardService giftCardService,
            IStoreMappingService storeMappingService,
            //IUrlRecordService urlRecordService,
            IWorkContext workContext,
            //MediaSettings mediaSettings,
            OrderSettings orderSettings,
            RewardPointsSettings rewardPointsSettings,
            //SecuritySettings securitySettings,
            TaxSettings taxSettings
            //VendorSettings vendorSettings
            )
        {
            _urlRecordService = urlRecordService;
            _paymentService = paymentService;
            _addressService = addressService;
            _shipmentService = shipmentService;
            _paymentPluginManager = paymentPluginManager;
            _orderProcessingService = orderProcessingService;
            _currencyService = currencyService;
            _priceFormatter = priceFormatter;
            _addressSettings = addressSettings;
            _vendorService = vendorService;
            //_captchaSettings = captchaSettings;
            _catalogSettings = catalogSettings;
            //_commonSettings = commonSettings;
            _customerSettings = customerSettings;
            _rewardPointService = rewardPointService;
            _giftCardService = giftCardService;
            _vendorSettings = vendorSettings;
            //_dateTimeSettings = dateTimeSettings;
            //_externalAuthenticationService = externalAuthenticationService;
            _externalAuthenticationSettings = externalAuthenticationSettings;
            //_forumSettings = forumSettings;
            //_gdprSettings = gdprSettings;
            _addressModelFactory = addressModelFactory;
            //_authenticationPluginManager = authenticationPluginManager;
            _countryService = countryService;
            _customerAttributeParser = customerAttributeParser;
            _customerAttributeService = customerAttributeService;
            _customerService = customerService;
            _dateTimeHelper = dateTimeHelper;
            //_gdprService = gdprService;
            //_genericAttributeService = genericAttributeService;
            _localizationService = localizationService;
            //_newsLetterSubscriptionService = newsLetterSubscriptionService;
            _orderService = orderService;
            //_pictureService = pictureService;
            _productService = productService;
            _returnRequestService = returnRequestService;
            _stateProvinceService = stateProvinceService;
            _storeContext = storeContext;
            _storeMappingService = storeMappingService;
            //_urlRecordService = urlRecordService;
            _workContext = workContext;
            //_mediaSettings = mediaSettings;
            _orderSettings = orderSettings;
            _rewardPointsSettings = rewardPointsSettings;
            //_securitySettings = securitySettings;
            _taxSettings = taxSettings;
            //_vendorSettings = vendorSettings;
        }

        #endregion
        public virtual IList<BillingAddressMobModel> PrepareCustomerAddressesModel(Customer customer)
        {
            var billingAddresses = new List<BillingAddressMobModel>();
            var addresses = _customerService.GetAddressesByCustomerId(customer.Id)
                //enabled for the current store
                .Where(a => a.CountryId == null || _storeMappingService.Authorize(_countryService.GetCountryByAddress(a)))
                .ToList();

            var model = new CustomerAddressMobModel();
            foreach (var address in addresses)
            {
                var addressModel = new AddressModel();
                _addressModelFactory.PrepareAddressModel(addressModel,
                    address: address,
                    excludeProperties: false,
                    addressSettings: _addressSettings,
                    loadCountries: () => _countryService.GetAllCountries());
                billingAddresses.Add(new BillingAddressMobModel()
                {
                    Id = addressModel.Id,
                    CountryId = addressModel.CountryId,
                    CountryName = addressModel.CountryName,
                    Address1 = addressModel.Address1,
                    Address2 = addressModel.Address2,
                    Email = addressModel.Email,
                    FirstName = addressModel.FirstName,
                    LastName = addressModel.LastName,
                    City = addressModel.City,
                    FaxNumber = addressModel.FaxNumber,
                    StateProvinceId = addressModel.StateProvinceId,
                    StateProvinceName = addressModel.StateProvinceName,
                    ZipPostalCode = addressModel.ZipPostalCode,
                    PhoneNumber = addressModel.PhoneNumber
                });
            }
            return billingAddresses;
        }

        public virtual CustomerOrderListModel PrepareCustomerOrderListModel(Customer customer)
        {
            var model = new CustomerOrderListModel();
            var orders = _orderService.SearchOrders(storeId: _storeContext.CurrentStore.Id,
                customerId: customer.Id);
            foreach (var order in orders)
            {
                var orderModel = new CustomerOrderListModel.OrderDetailsModel
                {
                    Id = order.Id,
                    CreatedOn = _dateTimeHelper.ConvertToUserTime(order.CreatedOnUtc, DateTimeKind.Utc),
                    OrderStatusEnum = order.OrderStatus,
                    OrderStatus = _localizationService.GetLocalizedEnum(order.OrderStatus),
                    PaymentStatus = _localizationService.GetLocalizedEnum(order.PaymentStatus),
                    ShippingStatus = _localizationService.GetLocalizedEnum(order.ShippingStatus),
                    IsReturnRequestAllowed = _orderProcessingService.IsReturnRequestAllowed(order),
                    CustomOrderNumber = order.CustomOrderNumber
                };
                var orderTotalInCustomerCurrency = _currencyService.ConvertCurrency(order.OrderTotal, order.CurrencyRate);
                orderModel.OrderTotal = _priceFormatter.FormatPrice(orderTotalInCustomerCurrency, true, order.CustomerCurrencyCode, false, _workContext.WorkingLanguage.Id);

                model.Orders.Add(orderModel);
            }

            var recurringPayments = _orderService.SearchRecurringPayments(_storeContext.CurrentStore.Id,
                customer.Id);
            foreach (var recurringPayment in recurringPayments)
            {
                var order = _orderService.GetOrderById(recurringPayment.InitialOrderId);

                var recurringPaymentModel = new CustomerOrderListModel.RecurringOrderModel
                {
                    Id = recurringPayment.Id,
                    StartDate = _dateTimeHelper.ConvertToUserTime(recurringPayment.StartDateUtc, DateTimeKind.Utc).ToString(),
                    CycleInfo = $"{recurringPayment.CycleLength} {_localizationService.GetLocalizedEnum(recurringPayment.CyclePeriod)}",
                    NextPayment = _orderProcessingService.GetNextPaymentDate(recurringPayment) is DateTime nextPaymentDate ? _dateTimeHelper.ConvertToUserTime(nextPaymentDate, DateTimeKind.Utc).ToString() : "",
                    TotalCycles = recurringPayment.TotalCycles,
                    CyclesRemaining = _orderProcessingService.GetCyclesRemaining(recurringPayment),
                    InitialOrderId = order.Id,
                    InitialOrderNumber = order.CustomOrderNumber,
                    CanCancel = _orderProcessingService.CanCancelRecurringPayment(customer, recurringPayment),
                    CanRetryLastPayment = _orderProcessingService.CanRetryLastRecurringPayment(customer, recurringPayment)
                };

                model.RecurringOrders.Add(recurringPaymentModel);
            }

            return model;
        }
        public virtual OrderDetailsModel PrepareOrderDetailsModel(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));
            var model = new OrderDetailsModel
            {
                Id = order.Id,
                CreatedOn = _dateTimeHelper.ConvertToUserTime(order.CreatedOnUtc, DateTimeKind.Utc),
                OrderStatus = _localizationService.GetLocalizedEnum(order.OrderStatus),
                IsReOrderAllowed = _orderSettings.IsReOrderAllowed,
                IsReturnRequestAllowed = _orderProcessingService.IsReturnRequestAllowed(order),
                PdfInvoiceDisabled = false,
                CustomOrderNumber = order.CustomOrderNumber,

                //shipping info
                ShippingStatus = _localizationService.GetLocalizedEnum(order.ShippingStatus)
            };
            if (order.ShippingStatus != ShippingStatus.ShippingNotRequired)
            {
                model.IsShippable = true;
                model.PickupInStore = order.PickupInStore;
                if (!order.PickupInStore)
                {
                    var shippingAddress = _addressService.GetAddressById(order.ShippingAddressId ?? 0);

                    _addressModelFactory.PrepareAddressModel(model.ShippingAddress,
                        address: shippingAddress,
                        excludeProperties: false,
                        addressSettings: _addressSettings);
                }
                else if (order.PickupAddressId.HasValue && _addressService.GetAddressById(order.PickupAddressId.Value) is Address pickupAddress)
                {
                    model.PickupAddress = new AddressModel
                    {
                        Address1 = pickupAddress.Address1,
                        City = pickupAddress.City,
                        County = pickupAddress.County,
                        CountryName = _countryService.GetCountryByAddress(pickupAddress)?.Name ?? string.Empty,
                        ZipPostalCode = pickupAddress.ZipPostalCode
                    };
                }

                model.ShippingMethod = order.ShippingMethod;

                //shipments (only already shipped)
                var shipments = _shipmentService.GetShipmentsByOrderId(order.Id, true).OrderBy(x => x.CreatedOnUtc).ToList();
                foreach (var shipment in shipments)
                {
                    var shipmentModel = new OrderDetailsModel.ShipmentBriefModel
                    {
                        Id = shipment.Id,
                        TrackingNumber = shipment.TrackingNumber,
                    };
                    if (shipment.ShippedDateUtc.HasValue)
                        shipmentModel.ShippedDate = _dateTimeHelper.ConvertToUserTime(shipment.ShippedDateUtc.Value, DateTimeKind.Utc);
                    if (shipment.DeliveryDateUtc.HasValue)
                        shipmentModel.DeliveryDate = _dateTimeHelper.ConvertToUserTime(shipment.DeliveryDateUtc.Value, DateTimeKind.Utc);
                    model.Shipments.Add(shipmentModel);
                }
            }

            var billingAddress = _addressService.GetAddressById(order.BillingAddressId);

            //billing info
            _addressModelFactory.PrepareAddressModel(model.BillingAddress,
                address: billingAddress,
                excludeProperties: false,
                addressSettings: _addressSettings);

            //VAT number
            model.VatNumber = order.VatNumber;

            var languageId = _workContext.WorkingLanguage.Id;

            //payment method
            var customer = _customerService.GetCustomerById(order.CustomerId);
            var paymentMethod = _paymentPluginManager
                .LoadPluginBySystemName(order.PaymentMethodSystemName, customer, order.StoreId);
            model.PaymentMethod = paymentMethod != null ? _localizationService.GetLocalizedFriendlyName(paymentMethod, languageId) : order.PaymentMethodSystemName;
            model.PaymentMethodStatus = _localizationService.GetLocalizedEnum(order.PaymentStatus);
            model.CanRePostProcessPayment = _paymentService.CanRePostProcessPayment(order);
            //custom values
            model.CustomValues = _paymentService.DeserializeCustomValues(order);

            //order subtotal
            if (order.CustomerTaxDisplayType == TaxDisplayType.IncludingTax && !_taxSettings.ForceTaxExclusionFromOrderSubtotal)
            {
                //including tax

                //order subtotal
                var orderSubtotalInclTaxInCustomerCurrency = _currencyService.ConvertCurrency(order.OrderSubtotalInclTax, order.CurrencyRate);
                model.OrderSubtotal = _priceFormatter.FormatPrice(orderSubtotalInclTaxInCustomerCurrency, true, order.CustomerCurrencyCode, languageId, true);
                //discount (applied to order subtotal)
                var orderSubTotalDiscountInclTaxInCustomerCurrency = _currencyService.ConvertCurrency(order.OrderSubTotalDiscountInclTax, order.CurrencyRate);
                if (orderSubTotalDiscountInclTaxInCustomerCurrency > decimal.Zero)
                    model.OrderSubTotalDiscount = _priceFormatter.FormatPrice(-orderSubTotalDiscountInclTaxInCustomerCurrency, true, order.CustomerCurrencyCode, languageId, true);
            }
            else
            {
                //excluding tax

                //order subtotal
                var orderSubtotalExclTaxInCustomerCurrency = _currencyService.ConvertCurrency(order.OrderSubtotalExclTax, order.CurrencyRate);
                model.OrderSubtotal = _priceFormatter.FormatPrice(orderSubtotalExclTaxInCustomerCurrency, true, order.CustomerCurrencyCode, languageId, false);
                //discount (applied to order subtotal)
                var orderSubTotalDiscountExclTaxInCustomerCurrency = _currencyService.ConvertCurrency(order.OrderSubTotalDiscountExclTax, order.CurrencyRate);
                if (orderSubTotalDiscountExclTaxInCustomerCurrency > decimal.Zero)
                    model.OrderSubTotalDiscount = _priceFormatter.FormatPrice(-orderSubTotalDiscountExclTaxInCustomerCurrency, true, order.CustomerCurrencyCode, languageId, false);
            }

            if (order.CustomerTaxDisplayType == TaxDisplayType.IncludingTax)
            {
                //including tax

                //order shipping
                var orderShippingInclTaxInCustomerCurrency = _currencyService.ConvertCurrency(order.OrderShippingInclTax, order.CurrencyRate);
                model.OrderShipping = _priceFormatter.FormatShippingPrice(orderShippingInclTaxInCustomerCurrency, true, order.CustomerCurrencyCode, languageId, true);
                //payment method additional fee
                var paymentMethodAdditionalFeeInclTaxInCustomerCurrency = _currencyService.ConvertCurrency(order.PaymentMethodAdditionalFeeInclTax, order.CurrencyRate);
                if (paymentMethodAdditionalFeeInclTaxInCustomerCurrency > decimal.Zero)
                    model.PaymentMethodAdditionalFee = _priceFormatter.FormatPaymentMethodAdditionalFee(paymentMethodAdditionalFeeInclTaxInCustomerCurrency, true, order.CustomerCurrencyCode, languageId, true);
            }
            else
            {
                //excluding tax

                //order shipping
                var orderShippingExclTaxInCustomerCurrency = _currencyService.ConvertCurrency(order.OrderShippingExclTax, order.CurrencyRate);
                model.OrderShipping = _priceFormatter.FormatShippingPrice(orderShippingExclTaxInCustomerCurrency, true, order.CustomerCurrencyCode, languageId, false);
                //payment method additional fee
                var paymentMethodAdditionalFeeExclTaxInCustomerCurrency = _currencyService.ConvertCurrency(order.PaymentMethodAdditionalFeeExclTax, order.CurrencyRate);
                if (paymentMethodAdditionalFeeExclTaxInCustomerCurrency > decimal.Zero)
                    model.PaymentMethodAdditionalFee = _priceFormatter.FormatPaymentMethodAdditionalFee(paymentMethodAdditionalFeeExclTaxInCustomerCurrency, true, order.CustomerCurrencyCode, languageId, false);
            }

            //tax
            var displayTax = true;
            var displayTaxRates = true;
            if (_taxSettings.HideTaxInOrderSummary && order.CustomerTaxDisplayType == TaxDisplayType.IncludingTax)
            {
                displayTax = false;
                displayTaxRates = false;
            }
            else
            {
                if (order.OrderTax == 0 && _taxSettings.HideZeroTax)
                {
                    displayTax = false;
                    displayTaxRates = false;
                }
                else
                {
                    var taxRates = _orderService.ParseTaxRates(order, order.TaxRates);
                    displayTaxRates = _taxSettings.DisplayTaxRates && taxRates.Any();
                    displayTax = !displayTaxRates;

                    var orderTaxInCustomerCurrency = _currencyService.ConvertCurrency(order.OrderTax, order.CurrencyRate);
                    model.Tax = _priceFormatter.FormatPrice(orderTaxInCustomerCurrency, true, order.CustomerCurrencyCode, false, languageId);

                    foreach (var tr in taxRates)
                    {
                        model.TaxRates.Add(new OrderDetailsModel.TaxRate
                        {
                            Rate = _priceFormatter.FormatTaxRate(tr.Key),
                            Value = _priceFormatter.FormatPrice(_currencyService.ConvertCurrency(tr.Value, order.CurrencyRate), true, order.CustomerCurrencyCode, false, languageId),
                        });
                    }
                }
            }
            model.DisplayTaxRates = displayTaxRates;
            model.DisplayTax = displayTax;
            model.DisplayTaxShippingInfo = _catalogSettings.DisplayTaxShippingInfoOrderDetailsPage;
            model.PricesIncludeTax = order.CustomerTaxDisplayType == TaxDisplayType.IncludingTax;

            //discount (applied to order total)
            var orderDiscountInCustomerCurrency = _currencyService.ConvertCurrency(order.OrderDiscount, order.CurrencyRate);
            if (orderDiscountInCustomerCurrency > decimal.Zero)
                model.OrderTotalDiscount = _priceFormatter.FormatPrice(-orderDiscountInCustomerCurrency, true, order.CustomerCurrencyCode, false, languageId);

            //gift cards
            foreach (var gcuh in _giftCardService.GetGiftCardUsageHistory(order))
            {
                model.GiftCards.Add(new OrderDetailsModel.GiftCard
                {
                    CouponCode = _giftCardService.GetGiftCardById(gcuh.GiftCardId).GiftCardCouponCode,
                    Amount = _priceFormatter.FormatPrice(-(_currencyService.ConvertCurrency(gcuh.UsedValue, order.CurrencyRate)), true, order.CustomerCurrencyCode, false, languageId),
                });
            }

            //reward points           
            if (order.RedeemedRewardPointsEntryId.HasValue && _rewardPointService.GetRewardPointsHistoryEntryById(order.RedeemedRewardPointsEntryId.Value) is RewardPointsHistory redeemedRewardPointsEntry)
            {
                model.RedeemedRewardPoints = -redeemedRewardPointsEntry.Points;
                model.RedeemedRewardPointsAmount = _priceFormatter.FormatPrice(-(_currencyService.ConvertCurrency(redeemedRewardPointsEntry.UsedAmount, order.CurrencyRate)), true, order.CustomerCurrencyCode, false, languageId);
            }

            //total
            var orderTotalInCustomerCurrency = _currencyService.ConvertCurrency(order.OrderTotal, order.CurrencyRate);
            model.OrderTotal = _priceFormatter.FormatPrice(orderTotalInCustomerCurrency, true, order.CustomerCurrencyCode, false, languageId);

            //checkout attributes
            model.CheckoutAttributeInfo = order.CheckoutAttributeDescription;

            //order notes
            foreach (var orderNote in _orderService.GetOrderNotesByOrderId(order.Id, true)
                .OrderByDescending(on => on.CreatedOnUtc)
                .ToList())
            {
                model.OrderNotes.Add(new OrderDetailsModel.OrderNote
                {
                    Id = orderNote.Id,
                    HasDownload = orderNote.DownloadId > 0,
                    Note = _orderService.FormatOrderNoteText(orderNote),
                    CreatedOn = _dateTimeHelper.ConvertToUserTime(orderNote.CreatedOnUtc, DateTimeKind.Utc)
                });
            }

            //purchased products
            model.ShowSku = _catalogSettings.ShowSkuOnProductDetailsPage;
            model.ShowVendorName = _vendorSettings.ShowVendorOnOrderDetailsPage;

            var orderItems = _orderService.GetOrderItems(order.Id);

            foreach (var orderItem in orderItems)
            {
                var product = _productService.GetProductById(orderItem.ProductId);

                var orderItemModel = new OrderDetailsModel.OrderItemModel
                {
                    Id = orderItem.Id,
                    OrderItemGuid = orderItem.OrderItemGuid,
                    Sku = _productService.FormatSku(product, orderItem.AttributesXml),
                    VendorName = _vendorService.GetVendorById(product.VendorId)?.Name ?? string.Empty,
                    ProductId = product.Id,
                    ProductName = _localizationService.GetLocalized(product, x => x.Name),
                    ProductSeName = _urlRecordService.GetSeName(product),
                    Quantity = orderItem.Quantity,
                    AttributeInfo = orderItem.AttributeDescription,
                };
                //rental info
                if (product.IsRental)
                {
                    var rentalStartDate = orderItem.RentalStartDateUtc.HasValue
                        ? _productService.FormatRentalDate(product, orderItem.RentalStartDateUtc.Value) : "";
                    var rentalEndDate = orderItem.RentalEndDateUtc.HasValue
                        ? _productService.FormatRentalDate(product, orderItem.RentalEndDateUtc.Value) : "";
                    orderItemModel.RentalInfo = string.Format(_localizationService.GetResource("Order.Rental.FormattedDate"),
                        rentalStartDate, rentalEndDate);
                }
                model.Items.Add(orderItemModel);

                //unit price, subtotal
                if (order.CustomerTaxDisplayType == TaxDisplayType.IncludingTax)
                {
                    //including tax
                    var unitPriceInclTaxInCustomerCurrency = _currencyService.ConvertCurrency(orderItem.UnitPriceInclTax, order.CurrencyRate);
                    orderItemModel.UnitPrice = _priceFormatter.FormatPrice(unitPriceInclTaxInCustomerCurrency, true, order.CustomerCurrencyCode, languageId, true);

                    var priceInclTaxInCustomerCurrency = _currencyService.ConvertCurrency(orderItem.PriceInclTax, order.CurrencyRate);
                    orderItemModel.SubTotal = _priceFormatter.FormatPrice(priceInclTaxInCustomerCurrency, true, order.CustomerCurrencyCode, languageId, true);
                }
                else
                {
                    //excluding tax
                    var unitPriceExclTaxInCustomerCurrency = _currencyService.ConvertCurrency(orderItem.UnitPriceExclTax, order.CurrencyRate);
                    orderItemModel.UnitPrice = _priceFormatter.FormatPrice(unitPriceExclTaxInCustomerCurrency, true, order.CustomerCurrencyCode, languageId, false);

                    var priceExclTaxInCustomerCurrency = _currencyService.ConvertCurrency(orderItem.PriceExclTax, order.CurrencyRate);
                    orderItemModel.SubTotal = _priceFormatter.FormatPrice(priceExclTaxInCustomerCurrency, true, order.CustomerCurrencyCode, languageId, false);
                }

                //downloadable products
                if (_orderService.IsDownloadAllowed(orderItem))
                    orderItemModel.DownloadId = product.DownloadId;
                if (_orderService.IsLicenseDownloadAllowed(orderItem))
                    orderItemModel.LicenseId = orderItem.LicenseDownloadId ?? 0;
            }

            return model;
        }

    }
}
