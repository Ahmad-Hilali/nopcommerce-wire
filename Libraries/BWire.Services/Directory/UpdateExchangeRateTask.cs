using System;
using BWire.Core.Domain.Directory;
using BWire.Services.Tasks;

namespace BWire.Services.Directory
{
    /// <summary>
    /// Represents a task for updating exchange rates
    /// </summary>
    public partial class UpdateExchangeRateTask : IScheduleTask
    {
        #region Fields

        private readonly CurrencySettings _currencySettings;
        private readonly ICurrencyService _currencyService;

        #endregion

        #region Ctor

        public UpdateExchangeRateTask(CurrencySettings currencySettings,
            ICurrencyService currencyService)
        {
            _currencySettings = currencySettings;
            _currencyService = currencyService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Executes a task
        /// </summary>
        public void Execute()
        {
            if (!_currencySettings.AutoUpdateEnabled)
                return;

            var exchangeRates = _currencyService.GetCurrencyLiveRates();
            foreach (var exchageRate in exchangeRates)
            {
                var currency = _currencyService.GetCurrencyByCode(exchageRate.CurrencyCode);
                if (currency == null)
                    continue;

                currency.Rate = exchageRate.Rate;
                currency.UpdatedOnUtc = DateTime.UtcNow;
                _currencyService.UpdateCurrency(currency);
            }
        }

        #endregion
    }
}