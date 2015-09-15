using System.Web.Mvc;

namespace MvcTest.Controllers
{
    public class DefaultController : Controller
    {
        //
        // GET: /Default/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Default/TestAjax

        public ActionResult TestAjax()
        {
            return Json(new
            {
                Name = "Событие работает", 
                GetParam = Request.QueryString["a"], 
                PostParam = Request.Form["b"]
            });
        }
    }
}
