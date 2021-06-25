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
    public class SamsungsController : Controller
    {
        private readonly sistemDbcontext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public SamsungsController(sistemDbcontext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Samsungs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Samsungs.ToListAsync());
        }
        public async Task<IActionResult> Samsung1()
        {
            return View(await _context.Samsungs.ToListAsync());
        }

        // GET: Samsungs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var samsung = await _context.Samsungs
                .FirstOrDefaultAsync(m => m.SamsungId == id);
            if (samsung == null)
            {
                return NotFound();
            }

            return View(samsung);
        }

        // GET: Samsungs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Samsungs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SamsungId,imageFile,SamsungAciklama,SamsungFiyat")] Samsung samsung)
        {
            if (ModelState.IsValid)
            {


                string wwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(samsung.imageFile.FileName);
                string extention = Path.GetExtension(samsung.imageFile.FileName);
                samsung.imageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
                string path = Path.Combine(wwRootPath + "/image/Samsung/", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await samsung.imageFile.CopyToAsync(fileStream);
                }







                _context.Add(samsung);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(samsung);
        }

        // GET: Samsungs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var samsung = await _context.Samsungs.FindAsync(id);
            if (samsung == null)
            {
                return NotFound();
            }
            return View(samsung);
        }

        // POST: Samsungs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SamsungId,imageName,SamsungAciklama,SamsungFiyat")] Samsung samsung)
        {
            if (id != samsung.SamsungId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(samsung);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SamsungExists(samsung.SamsungId))
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
            return View(samsung);
        }

        // GET: Samsungs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var samsung = await _context.Samsungs
                .FirstOrDefaultAsync(m => m.SamsungId == id);
            if (samsung == null)
            {
                return NotFound();
            }

            return View(samsung);
        }

        // POST: Samsungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var samsung = await _context.Samsungs.FindAsync(id);
            _context.Samsungs.Remove(samsung);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SamsungExists(int id)
        {
            return _context.Samsungs.Any(e => e.SamsungId == id);
        }
    }
}
