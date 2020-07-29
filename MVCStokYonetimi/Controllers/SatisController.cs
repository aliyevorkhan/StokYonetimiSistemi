using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStokYonetimi.Models.Entity;

namespace MVCStokYonetimi.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        MvcDbStokEntities db = new MvcDbStokEntities(); 
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            //List<SelectListItem> urunler = (from i in db.TBL_URUNLER.ToList()
            //                                 select new SelectListItem
            //                                 {
            //                                     Text = i.URUNAD,
            //                                     Value = i.URUNID.ToString()
            //                                 }).ToList();
            //ViewBag.urun = urunler;
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(TBL_SATISLAR p1)
        {
            //var satis = db.TBL_URUNLER.Where(m => m.URUNID == p1.TBL_URUNLER.URUNID).FirstOrDefault();
            //p1.TBL_URUNLER = satis;
            db.TBL_SATISLAR.Add(p1);
            db.SaveChanges();
            return View("Index");
        }

    }
}