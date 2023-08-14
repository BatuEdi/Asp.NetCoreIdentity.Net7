using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreIdentityApp.Repository.PermissionsRoot;

namespace AspNetCoreIdentityApp.Web.Controllers
{
    public class OrderController : Controller
    {

        [Authorize(Policy ="")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
