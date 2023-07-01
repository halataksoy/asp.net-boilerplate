using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Xelat.Project.Controllers;

namespace Xelat.Project.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : ProjectControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
