using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace BigBirdWebCenter.Areas.HelpPage.Controllers
{
    public class HelloController : ApiController
    {
        public JsonResult<string> Hello()
        {
            return Json("Hello");
        }
    }
}
