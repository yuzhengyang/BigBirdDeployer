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
        public JsonResult<List<SystemStatusModel>> Get()
        {
            List<SystemStatusModel> list = new List<SystemStatusModel>();
            if (R.Store.SystemStatus.Any())
            {
                for (int i = 0; i < R.Store.SystemStatus.Count; i++)
                {
                    SystemStatusModel status = null;
                    if (R.Store.SystemStatus.TryDequeue(out status))
                    {
                        list.Add(status);
                    }
                }
            }
            return Json(list);
        }
    }
}
