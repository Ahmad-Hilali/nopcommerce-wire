using Nop.Core;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Directory;
using Nop.Services.Common;
using Nop.Services.Customers;
using Nop.Services.Directory;
using Nop.Services.Stores;
using Nop.Web.Models.Common;
using Nop.Web.Models.Mobile.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nop.Web.Factories.Mobile
{
    public class CheckoutMobFactory : ICheckoutMobFactory
    {

        private readonly ICustomerService _customerService;
        private readonly AddressSettings _addressSettings;
        private readonly CommonSettings _commonSettings;
        private readonly IAddressModelFactory _addressModelFactory;
        private readonly IAddressService _addressService;
        private readonly ICountryService _countryService;
        private readonly IStoreMappingService _storeMappingService;
        private readonly IWorkContext _workContext;
        public CheckoutMobFactory(ICustomerService customerService,
        AddressSettings addressSettings,
        CommonSettings commonSettings,
        IAddressModelFactory addressModelFactory,
        IAddressService addressService,
        ICountryService countryService,
        IStoreMappingService storeMappingService,
        IWorkContext workContext)
        {
            _customerService = customerService;
            _addressSettings = addressSettings;
            _commonSettings = commonSettings;
            _addressModelFactory = addressModelFactory;
            _addressService = addressService;
            _countryService = countryService;
            _storeMappingService = storeMappingService;
            _workContext = workContext;
        }
        public IList<BillingAddressMobModel> GetValidAddressesByCustomerId(int customerId)
        {
            var billingAddresses = new List<BillingAddressMobModel>();
            var customer = _customerService.GetCustomerById(customerId);
            if (customer != null)
            {
                var addresses = _customerService.GetAddressesByCustomerId(customer.Id)
                   .Where(a => _countryService.GetCountryByAddress(a) is Country country &&
                       (//published
                       country.Published &&
                       //allow billing
                       country.AllowsBilling &&
                       //enabled for the current store
                       _storeMappingService.Authorize(country)))
                   .ToList();
                foreach (var address in addresses)
                {
                    var addressModel = new AddressModel();
                    _addressModelFactory.PrepareAddressModel(addressModel,
                        address: address,
                        excludeProperties: false,
                        addressSettings: _addressSettings);

                    if (_addressService.IsAddressValid(address))
                    {
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
                }
            }
            return billingAddresses;
                
        }

        public IList<BillingAddressMobModel> GetInvalidAddressesByCustomerId(int customerId)
        {
            var billingAddresses = new List<BillingAddressMobModel>();
            var customer = _customerService.GetCustomerById(customerId);
            if (customer == null)
            {
                var addresses = _customerService.GetAddressesByCustomerId(customer.Id)
                   .Where(a => _countryService.GetCountryByAddress(a) is Country country &&
                       (//published
                       country.Published &&
                       //allow billing
                       country.AllowsBilling &&
                       //enabled for the current store
                       _storeMappingService.Authorize(country)))
                   .ToList();
                foreach (var address in addresses)
                {
                    var addressModel = new AddressModel();
                    _addressModelFactory.PrepareAddressModel(addressModel,
                        address: address,
                        excludeProperties: false,
                        addressSettings: _addressSettings);

                    if (!_addressService.IsAddressValid(address))
                    {
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
                }
            }
            return billingAddresses;

        }

        public BillingAddressMobModel PrepareAddressMobModel(int customerId)
        {
            var billingAddress = new BillingAddressMobModel();
            var customer = _customerService.GetCustomerById(customerId);
            if (customer != null)
            {
                var addressModel = new AddressModel();
                _addressModelFactory.PrepareAddressModel(addressModel,
                address: null,
                excludeProperties: false,
                addressSettings: _addressSettings,
                loadCountries: () => _countryService.GetAllCountriesForBilling(_workContext.WorkingLanguage.Id),
                prePopulateWithCustomerFields: true,
                customer: customer,
                overrideAttributesXml: "");
                billingAddress = new BillingAddressMobModel()
                {
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
                    PhoneNumber = addressModel.PhoneNumber,
                    AvailableCountries = addressModel.AvailableCountries,
                    AvailableStates = addressModel.AvailableStates
                };
            }
            return billingAddress;
        }
    }
}
