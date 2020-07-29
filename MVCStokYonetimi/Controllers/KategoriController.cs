using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStokYonetimi.Models.Entity;


namespace MVCStokYonetimi.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index(int sayfa = 1)
        {
            var degerler = db.TBL_KATEGORILER.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKategori(TBL_KATEGORILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.TBL_KATEGORILER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var ktgr = db.TBL_KATEGORILER.Find(id);
            db.TBL_KATEGORILER.Remove(ktgr);
            db.SaveChanges();
            return RedirectToAction("Index"); 
        }

        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TBL_KATEGORILER.Find(id);
            return View("KategoriGetir", ktgr);
        }

        public  ActionResult Guncelle(TBL_KATEGORILER p1)
        {
            var ktgr = db.TBL_KATEGORILER.Find(p1.KATEGORIID);
            ktgr.KATEGORIAD = p1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}