using BigBird.Models.ProjectModels;
using BigBirdWebCenter.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace BigBirdWebCenter.Areas.Project.Controllers
{
    public class ProjectStatusController : ApiController
    {
        public JsonResult<List<ProjectStatusModel>> List()
        {
            List<ProjectStatusModel> list = new List<ProjectStatusModel>();
            foreach(var item in R.Store.ProjectStatus)
            {
                list.Add(item.Value);
            }
            return Json(list);
        }
    }
}
