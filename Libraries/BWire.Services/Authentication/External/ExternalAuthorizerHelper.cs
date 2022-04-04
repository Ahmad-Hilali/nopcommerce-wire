using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using BWire.Core.Http.Extensions;
using BWire.Core.Infrastructure;

namespace BWire.Services.Authentication.External
{
    /// <summary>
    /// External authorizer helper
    /// </summary>
    public static partial class ExternalAuthorizerHelper
    {
        #region Methods

        /// <summary>
        /// Add error
        /// </summary>
        /// <param name="error">Error</param>
        public static void AddErrorsToDisplay(string error)
        {
            var session = EngineContext.Current.Resolve<IHttpContextAccessor>().HttpContext.Session;
            var errors = session.Get<IList<string>>(NopAuthenticationDefaults.ExternalAuthenticationErrorsSessionKey) ?? new List<string>();
            errors.Add(error);
            session.Set(NopAuthenticationDefaults.ExternalAuthenticationErrorsSessionKey, errors);
        }

        /// <summary>
        /// Retrieve errors to display
        /// </summary>
        /// <returns>Errors</returns>
        public static IList<string> RetrieveErrorsToDisplay()
        {
            var session = EngineContext.Current.Resolve<IHttpContextAccessor>().HttpContext.Session;
            var errors = session.Get<IList<string>>(NopAuthenticationDefaults.ExternalAuthenticationErrorsSessionKey);

            if (errors != null)
                session.Remove(NopAuthenticationDefaults.ExternalAuthenticationErrorsSessionKey);

            return errors;
        }

        #endregion
    }
}