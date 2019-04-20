using BigBird.Models.ProjectModels;
using BigBird.Models.SystemModels;
using BigBirdWebCenter.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace BigBirdWebCenter.Areas.Deployer.Controllers
{
    public class DeployerStatusController : ApiController
    {
        public JsonResult<List<string>> HostList()
        {
            return Json(R.Tx.Hosts);
        }
        public JsonResult<List<ProjectStatusModel>> ProjectStatusList()
        {
            List<ProjectStatusModel> list = new List<ProjectStatusModel>();
            foreach (var item in R.Store.ProjectStatus.ToArray())
            {
                list.Add(item.Value);
            }
            return Json(list);
        }

        public JsonResult<List<SystemStatusModel>> SystemStatusList()
        {
            List<SystemStatusModel> list = new List<SystemStatusModel>();
            foreach (var item in R.Store.SystemStatus.ToArray())
            {
                list.Add(item.Value);
            }
            return Json(list);
        }
    }
}
