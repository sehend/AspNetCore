using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proje1.Models.Entity;

namespace proje1.Controllers
{
    public class KategoriController : Controller
    {

        MvcDbStokEntities db = new MvcDbStokEntities();


        // GET: Kategori
        public ActionResult Index()
        {
            var degerler = db.TBLKATEGORILER.ToList();
            return View(degerler);
        }


        [HttpGet]

        public ActionResult YeniKategori()
        {
            

          

            return View();
        }


        [HttpPost]

        public ActionResult YeniKategori(TBLKATEGORILER p1)
        {
            if (!ModelState.IsValid) /*Eger Dogrulanma İşlemi Yapılmadı İse*/
            {
                return View("YeniKategori");
            }

            db.TBLKATEGORILER.Add(p1);

            db.SaveChanges();

            return RedirectToAction("Index", "Kategori");
        }

        public ActionResult Sil(int id)
        {

            var kategori = db.TBLKATEGORILER.Find(id);

            db.TBLKATEGORILER.Remove(kategori);

            db.SaveChanges();


            return RedirectToAction("Index", "Kategori");
        }

        public ActionResult KategoriGetir(int id)
        {

            var ktgr = db.TBLKATEGORILER.Find(id);

            return View("kategoriGetir",ktgr);
                
                
                
        }
         
       

        public ActionResult Guncelle(TBLKATEGORILER p1)
        {

            var ktg = db.TBLKATEGORILER.Find(p1.KATEGORIID);

            ktg.KATEGORIAD = p1.KATEGORIAD;

            db.SaveChanges();

            return RedirectToAction("Index","Kategori");



        }




    }
}