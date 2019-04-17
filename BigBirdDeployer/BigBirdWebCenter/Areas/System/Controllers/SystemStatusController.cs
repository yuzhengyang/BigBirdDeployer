using BigBird.Models.SystemModels;
using BigBirdWebCenter.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace BigBirdWebCenter.Areas.System.Controllers
{
    public class SystemStatusController : ApiController
    {
        public JsonResult<List<SystemStatusModel>> List()
        {
            List<SystemStatusModel> list = new List<SystemStatusModel>();
            foreach (var item in R.Store.SystemStatus)
            {
                list.Add(item.Value);
            }
            return Json(list);
        }
    }
}
