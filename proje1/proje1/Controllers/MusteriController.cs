using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proje1.Models.Entity;
namespace proje1.Controllers
{
    public class MusteriController : Controller
    {

        MvcDbStokEntities db = new MvcDbStokEntities();

        // GET: Musteri
        public ActionResult Index(string p)
        {
            var degerler = from d in db.TBLMUSTERILER select d;

            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.MUSTERIAD.Contains(p));
            }

            //var deger = db.TBLMUSTERILER.ToList();


            return View(degerler.ToList());
        }
        
        [HttpGet]

        public ActionResult YeniMusteri()
        {

           


            return View();
        }

        [HttpPost]

        public ActionResult YeniMusteri(TBLMUSTERILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }

            db.TBLMUSTERILER.Add(p1);

            db.SaveChanges();


            return RedirectToAction("Index","Musteri");
        }

        public ActionResult Sil(int id)
        {

            var musteribul = db.TBLMUSTERILER.Find(id);

            db.TBLMUSTERILER.Remove(musteribul);

            db.SaveChanges();


            return RedirectToAction("Index", "Musteri");
        }

        public ActionResult MusteriGetir(int id)
        {
           var mus = db.TBLMUSTERILER.Find(id);

            return View("MusteriGetir", mus);

        }


        public ActionResult Guncelle(TBLMUSTERILER p1)
        {
            var mus = db.TBLMUSTERILER.Find(p1.MUSTERIID);

            mus.MUSTERIAD = p1.MUSTERIAD;

            mus.MUSTERISOYAD = p1.MUSTERISOYAD;

            db.SaveChanges();



            return RedirectToAction("Index");

        }





    }
}