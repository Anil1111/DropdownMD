using DropdownMD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DropdownMD.Controllers
{
    public class HomeController : Controller
    {
       private DBContext db = new DBContext();
        public ActionResult Index()
        {
            ViewBag.CountryList = new SelectList(db.Countries, "CountryId", "Name");
            return View();
        }

        public JsonResult BindState(int CountryId)
        {
            //var stateList = from x in db.States where x.CountryId == CountryId select x;
            var stateList = db.States.Where(s=>s.CountryId == CountryId).ToList();
            return Json(new SelectList(stateList, "StateId", "Name"), JsonRequestBehavior.AllowGet);
        }

        public JsonResult BindCity(int CountryId, int StateId)
        {
            //var citylist = from x in db.Cities where x.CountryId == CountryId && x.StateId == StateId select x;
            var citylist = db.Cities.Where(c=>c.CountryId == CountryId && c.StateId == StateId).ToList();
            return Json(new SelectList(citylist, "CityId", "Name"), JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}