using Surplus.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Surplus.Controllers
{
    public class ValidateFixedAssetController : ApiController
    {
        [ValidateModel]
        [HttpGet]
        public IHttpActionResult Index(int id)
        {
            return Ok();
        }
    }
}
