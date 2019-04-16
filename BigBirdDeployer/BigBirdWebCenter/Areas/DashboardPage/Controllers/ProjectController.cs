using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace BigBirdWebCenter.Areas.DashboardPage.Controllers
{
    public class ProjectController : ApiController
    {
        public JsonResult<string> Hello()
        {
            return Json("Hello");
        }
        public JsonResult<string> Xaaa()
        {
            return Json("Xaaa");
        }
    }
}
