using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace HealthyWebApp.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Health()
        {
            return new JsonResult { Data = new { 
                ServiceName = "FX Rate Upload Service",
                Status = "Sick",
                Error = "Database Server is not responding...blah...blah...blah"
            } };
        }

    }
}
