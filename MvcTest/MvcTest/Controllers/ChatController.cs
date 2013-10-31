using System.Web.Mvc;

namespace MvcTest.Controllers
{
    public class ChatController : Controller
    {
        //
        // GET: /Chat/
        public ActionResult Index()
        {
            return View();
        }
	}
}