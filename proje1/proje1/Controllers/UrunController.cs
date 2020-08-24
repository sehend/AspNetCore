using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proje1.Models.Entity;
namespace proje1.Models.Entity
{
    public class UrunController : Controller
    {

        MvcDbStokEntities db = new MvcDbStokEntities();

        // GET: Urun
        public ActionResult Index()
        {
            var degerler = db.TBLURUNLER.ToList();



            return View(degerler);
        }

        [HttpGet]

        public ActionResult YeniUrun()
        {
            /**************************************************************************/

            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()

                                         select new SelectListItem
                                         {
                                             Text=i.KATEGORIAD,
                                             Value=i.KATEGORIID.ToString()

                                         }).ToList();
            ViewBag.dgr = degerler;

            return View();
        }

        [HttpPost]

        public ActionResult YeniUrun(TBLURUNLER p1)
        {
            var ktg = db.TBLKATEGORILER.Where(m => m.KATEGORIID == p1.TBLKATEGORILER.KATEGORIID).FirstOrDefault();

            p1.TBLKATEGORILER = ktg;

            db.TBLURUNLER.Add(p1);

            db.SaveChanges();


            return RedirectToAction("Index","Urun");
        }


        public ActionResult Sil(int id)
        {


            var kategori = db.TBLURUNLER.Find(id);

            db.TBLURUNLER.Remove(kategori);

            db.SaveChanges();


            return RedirectToAction("Index", "Urun");
        }

        public ActionResult UrunGetir(int id)
        {

            var ktgr = db.TBLURUNLER.Find(id);

            return View("UrunGetir", ktgr);



        }



        public ActionResult Guncelle(TBLURUNLER p1)
        {

            var ktg = db.TBLURUNLER.Find(p1.URUNID);

            ktg.URUNAD = p1.URUNAD;

            ktg.URUNKATEGORI = p1.URUNKATEGORI;

            ktg.FİYAT = p1.FİYAT;

            db.SaveChanges();

            return RedirectToAction("Index", "Urun");



        }
    }
}