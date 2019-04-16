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
            if (R.Store.ProjectStatus.Any())
            {
                for (int i = 0; i < R.Store.ProjectStatus.Count; i++)
                {
                    ProjectStatusModel status = null;
                    if (R.Store.ProjectStatus.TryDequeue(out status))
                    {
                        list.Add(status);
                    }
                }
            }
            return Json(list);
        }
    }
}
