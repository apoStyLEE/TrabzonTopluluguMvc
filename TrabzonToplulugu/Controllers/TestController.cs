using System.Web.Mvc;

namespace TrabzonToplulugu.Controllers
{
    public class TestController : ApiBaseController
    {
        public ActionResult Index()
        {
            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}