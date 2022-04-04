﻿using System;
using System.Text;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using BWire.Core.Domain.Security;
using BWire.Core.Infrastructure;

namespace BWire.Web.Framework.Security.Honeypot
{
    /// <summary>
    /// HTML extensions
    /// </summary>
    public static class HtmlExtensions
    {
        /// <summary>
        /// Generate honeypot input
        /// </summary>
        /// <param name="helper">HTML helper</param>
        /// <returns>Result</returns>
        public static IHtmlContent GenerateHoneypotInput(this IHtmlHelper helper)
        {
            var sb = new StringBuilder();

            sb.AppendFormat("<div style=\"display:none;\">");
            sb.Append(Environment.NewLine);

            var securitySettings = EngineContext.Current.Resolve<SecuritySettings>();
            sb.AppendFormat("<input id=\"{0}\" name=\"{0}\" type=\"text\">", securitySettings.HoneypotInputName);

            sb.Append(Environment.NewLine);
            sb.Append("</div>");

            return new HtmlString(sb.ToString());
        }
    }
}