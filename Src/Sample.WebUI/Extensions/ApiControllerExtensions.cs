using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using Lib.SimpleCqrs.Extended;

namespace Sample.WebUI.Extensions
{
    public static class ApiControllerExtensions
    {
        public static IHttpActionResult CommandResult<T>(this ApiController source, CommandReply<T> reply, Func<Uri> location)
        {
            if (reply.Succeed)
            {
                return new CreatedNegotiatedContentResult<T>(location.Invoke(), reply.Data, source);
            }

            return new NegotiatedContentResult<IEnumerable<Lib.Validation.RuleError>>(
                HttpStatusCode.BadRequest,
                reply.ValidationResult.Errors, 
                source);
        }
    }
}