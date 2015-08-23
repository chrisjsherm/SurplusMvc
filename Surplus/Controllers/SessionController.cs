using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Surplus.Controllers
{
    public class SessionController : ApiController
    {
        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage Index()
        {
            return Request.CreateResponse(HttpStatusCode.NoContent, "application/json");
        }
    }
}
