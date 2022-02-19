using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebServiceMailAPI.Context;

namespace WebServiceMailAPI.Controllers.UiControllers
{
    [Route("/[controller]")]
    public class UiApiController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
