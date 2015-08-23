using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Surplus.Controllers
{
    public class CasController : Controller
    {
        [AllowAnonymous]
        public ActionResult Logout()
        {
            DotNetCasClient.CasAuthentication.SingleSignOut();
            return RedirectToAction("Create", "SurplusRequests");
        }
    }
}