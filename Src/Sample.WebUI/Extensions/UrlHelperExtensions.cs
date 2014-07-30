using System;
using System.Security.Policy;
using System.Web.Http.Routing;
using Sample.Core.Extensions;

namespace Sample.WebUI.Extensions
{
    public static class UrlHelperExtensions
    {
        public static Uri BookDetails(this UrlHelper url, long id)
        {
            return new Uri(url.Link("GetBookById", new { id }));
        }
    }
}