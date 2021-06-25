using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication16;
using WebApplication16.Models;

namespace WebApplication16.Controllers
{
    public class MudursController : Controller
    {
        private readonly sistemDbcontext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public MudursController(sistemDbcontext context,IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Mudurs
        public async Task<IActionResult> Index()
        {
            var sistemDbcontext = _context.Mudurs.Include(m => m.Urun);
            return View(await sistemDbcontext.ToListAsync());
        }

        // GET: Mudurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mudur = await _context.Mudurs
                .Include(m => m.Urun)
                .FirstOrDefaultAsync(m => m.MudurId == id);
            if (mudur == null)
            {
                return NotFound();
            }

            return View(mudur);
        }

        // GET: Mudurs/Create
        public IActionResult Create()
        {
            ViewData["UrunId"] = new SelectList(_context.Urunlers, "UrunId", "UrunId");
            return View();
        }

        // POST: Mudurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MudurId,imageFile,MudurAd,MudurSoyad,MudurEmail,MudurAdres,PersonelTc,UrunId")] Mudur mudur)
        {
            if (ModelState.IsValid)
            {


                string wwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(mudur.imageFile.FileName);
                string extention = Path.GetExtension(mudur.imageFile.FileName);
               mudur.imageName= fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
                string path = Path.Combine(wwRootPath + "/image/Admin/", fileName);

                using(var fileStream=new FileStream(path, FileMode.Create))
                {
                    await mudur.imageFile.CopyToAsync(fileStream);
                }










                _context.Add(mudur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UrunId"] = new SelectList(_context.Urunlers, "UrunId", "UrunId", mudur.UrunId);
            return View(mudur);
        }

        // GET: Mudurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mudur = await _context.Mudurs.FindAsync(id);
            if (mudur == null)
            {
                return NotFound();
            }
            ViewData["UrunId"] = new SelectList(_context.Urunlers, "UrunId", "UrunId", mudur.UrunId);
            return View(mudur);
        }

        // POST: Mudurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MudurId,imageName,MudurAd,MudurSoyad,MudurEmail,MudurAdres,PersonelTc,UrunId")] Mudur mudur)
        {
            if (id != mudur.MudurId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mudur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MudurExists(mudur.MudurId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UrunId"] = new SelectList(_context.Urunlers, "UrunId", "UrunId", mudur.UrunId);
            return View(mudur);
        }

        // GET: Mudurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mudur = await _context.Mudurs
                .Include(m => m.Urun)
                .FirstOrDefaultAsync(m => m.MudurId == id);
            if (mudur == null)
            {
                return NotFound();
            }

            return View(mudur);
        }

        // POST: Mudurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mudur = await _context.Mudurs.FindAsync(id);
            _context.Mudurs.Remove(mudur);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MudurExists(int id)
        {
            return _context.Mudurs.Any(e => e.MudurId == id);
        }
    }
}
