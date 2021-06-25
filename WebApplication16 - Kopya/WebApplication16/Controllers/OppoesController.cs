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
    public class OppoesController : Controller
    {
        private readonly sistemDbcontext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public OppoesController(sistemDbcontext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Oppoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Oppos.ToListAsync());
        }
        public async Task<IActionResult> Oppo1()
        {
            return View(await _context.Oppos.ToListAsync());
        }
        // GET: Oppoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oppo = await _context.Oppos
                .FirstOrDefaultAsync(m => m.OppoId == id);
            if (oppo == null)
            {
                return NotFound();
            }

            return View(oppo);
        }

        // GET: Oppoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Oppoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OppoId,imageFile,OppoAciklama,Fiyat")] Oppo oppo)
        {
            if (ModelState.IsValid)
            {


                string wwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(oppo.imageFile.FileName);
                string extention = Path.GetExtension(oppo.imageFile.FileName);
                oppo.imageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
                string path = Path.Combine(wwRootPath + "/image/Oppo/", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await oppo.imageFile.CopyToAsync(fileStream);
                }










                _context.Add(oppo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oppo);
        }

        // GET: Oppoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oppo = await _context.Oppos.FindAsync(id);
            if (oppo == null)
            {
                return NotFound();
            }
            return View(oppo);
        }

        // POST: Oppoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OppoId,imageName,OppoAciklama,Fiyat")] Oppo oppo)
        {
            if (id != oppo.OppoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oppo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OppoExists(oppo.OppoId))
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
            return View(oppo);
        }

        // GET: Oppoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oppo = await _context.Oppos
                .FirstOrDefaultAsync(m => m.OppoId == id);
            if (oppo == null)
            {
                return NotFound();
            }

            return View(oppo);
        }

        // POST: Oppoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oppo = await _context.Oppos.FindAsync(id);
            _context.Oppos.Remove(oppo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OppoExists(int id)
        {
            return _context.Oppos.Any(e => e.OppoId == id);
        }
    }
}
