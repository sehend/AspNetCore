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
    public class ApplesController : Controller
    {
        private readonly sistemDbcontext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ApplesController(sistemDbcontext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Apples
        public async Task<IActionResult> Index()
        {
            return View(await _context.Apples.ToListAsync());
        }
        public async Task<IActionResult> Apple1()
        {
            return View(await _context.Apples.ToListAsync());
        }
        // GET: Apples/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apple = await _context.Apples
                .FirstOrDefaultAsync(m => m.AppleId == id);
            if (apple == null)
            {
                return NotFound();
            }

            return View(apple);
        }

        // GET: Apples/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Apples/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppleId,imageFile,AppleAciklama,Fiyat")] Apple apple)
        {
            if (ModelState.IsValid)
            {



                string wwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(apple.imageFile.FileName);
                string extention = Path.GetExtension(apple.imageFile.FileName);
                apple.imageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
                string path = Path.Combine(wwRootPath + "/image/Apple/", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await apple.imageFile.CopyToAsync(fileStream);
                }










                _context.Add(apple);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(apple);
        }

        // GET: Apples/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apple = await _context.Apples.FindAsync(id);
            if (apple == null)
            {
                return NotFound();
            }
            return View(apple);
        }

        // POST: Apples/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppleId,imageName,AppleAciklama,Fiyat")] Apple apple)
        {
            if (id != apple.AppleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apple);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppleExists(apple.AppleId))
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
            return View(apple);
        }

        // GET: Apples/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apple = await _context.Apples
                .FirstOrDefaultAsync(m => m.AppleId == id);
            if (apple == null)
            {
                return NotFound();
            }

            return View(apple);
        }

        // POST: Apples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apple = await _context.Apples.FindAsync(id);
            _context.Apples.Remove(apple);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppleExists(int id)
        {
            return _context.Apples.Any(e => e.AppleId == id);
        }
    }
}
