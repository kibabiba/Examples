using System;
using System.Linq;
using System.Web.Mvc;
using MvcTest.Models.Databases;

namespace MvcTest.Controllers
{
    public class HolidaysController : Controller
    {
        private readonly Duris4eDbEntities _db = new Duris4eDbEntities();

        //
        // GET: /Holidays/

        public ActionResult Index()
        {
            return View(_db.holidays.ToList());
        }
 
        //
        // GET: /Holidays/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Holidays/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(holidays holidays)
        {
            if (ModelState.IsValid)
            {
                _db.holidays.Add(holidays);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(holidays);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}