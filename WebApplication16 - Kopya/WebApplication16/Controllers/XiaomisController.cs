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
    public class XiaomisController : Controller
    {
        private readonly sistemDbcontext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public XiaomisController(sistemDbcontext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Xiaomis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Xiaomis.ToListAsync());
        }
        public async Task<IActionResult> Xiaomis1()
        {
            return View(await _context.Xiaomis.ToListAsync());
        }

        // GET: Xiaomis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var xiaomi = await _context.Xiaomis
                .FirstOrDefaultAsync(m => m.XiaomiId == id);
            if (xiaomi == null)
            {
                return NotFound();
            }

            return View(xiaomi);
        }

        // GET: Xiaomis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Xiaomis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("XiaomiId,imageFile,XiaomiAciklama,Fiyat")] Xiaomi xiaomi)
        {
            if (ModelState.IsValid)
            {


                string wwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(xiaomi.imageFile.FileName);
                string extention = Path.GetExtension(xiaomi.imageFile.FileName);
                xiaomi.imageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
                string path = Path.Combine(wwRootPath + "/image/Xiaomi/", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await xiaomi.imageFile.CopyToAsync(fileStream);
                }






                _context.Add(xiaomi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(xiaomi);
        }

        // GET: Xiaomis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var xiaomi = await _context.Xiaomis.FindAsync(id);
            if (xiaomi == null)
            {
                return NotFound();
            }
            return View(xiaomi);
        }

        // POST: Xiaomis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("XiaomiId,imageName,XiaomiAciklama,Fiyat")] Xiaomi xiaomi)
        {
            if (id != xiaomi.XiaomiId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(xiaomi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!XiaomiExists(xiaomi.XiaomiId))
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
            return View(xiaomi);
        }

        // GET: Xiaomis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var xiaomi = await _context.Xiaomis
                .FirstOrDefaultAsync(m => m.XiaomiId == id);
            if (xiaomi == null)
            {
                return NotFound();
            }

            return View(xiaomi);
        }

        // POST: Xiaomis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var xiaomi = await _context.Xiaomis.FindAsync(id);
            _context.Xiaomis.Remove(xiaomi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool XiaomiExists(int id)
        {
            return _context.Xiaomis.Any(e => e.XiaomiId == id);
        }
    }
}
