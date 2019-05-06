using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DateLocalization
{
    public class JsonRequestCultureProvider : RequestCultureProvider
    {
        public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }
            var header = httpContext.Request.Headers["culture"];
            var culture = header.Count == 0 ? "en-US" : header[0]; // Use the value defined in config files or the default value
            var uiCulture = culture;
            return Task.FromResult(new ProviderCultureResult(culture, uiCulture));
        }
    }
}
