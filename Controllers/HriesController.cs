using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjektWD3.Data;
using ProjektWD3.Models;

namespace ProjektWD3.Controllers
{
    public class HriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;


        public HriesController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Hries
        public async Task<IActionResult> Index()
        {
              return _context.Hry != null ? 
                          View(await _context.Hry.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Hry'  is null.");
        }

        // GET: Hries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hry == null)
            {
                return NotFound();
            }

            var hry = await _context.Hry
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hry == null)
            {
                return NotFound();
            }

            return View(hry);
        }

        // GET: Hries/Create
        public IActionResult Create()
        {
           
            var platformy = new List<string> { "PC", "PlayStation", "Xbox" };
            ViewBag.Platformy = new SelectList(platformy);
            return View();

        }
        // POST: Hries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nazov,RokVydania,Odkaz,Zaner,Platforma,ObrazokCesta")] Hry hry, IFormFile uploadedFile)
        {
            if (ModelState.IsValid)
            {
                if (uploadedFile != null && uploadedFile.Length > 0)
                {
                    var fileName = Path.GetFileName(uploadedFile.FileName);
                    var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await uploadedFile.CopyToAsync(stream);
                    }
                    hry.ObrazokCesta = fileName; // Uloženie cesty k súboru
                }

                _context.Add(hry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hry);
        }


        // GET: Hries/Edit/5
        public async Task<IActionResult> Edit(int? id)
{
    if (id == null || _context.Hry == null)
    {
        return NotFound();
    }

    var hry = await _context.Hry.FindAsync(id);
    if (hry == null)
    {
        return NotFound();
    }

    var platformy = new List<string> { "PC", "PlayStation", "Xbox" };
    ViewBag.Platformy = new SelectList(platformy, hry.Platforma);
    return View(hry);
     }

        // POST: Hries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazov,RokVydania,Odkaz,Zaner,Platforma,ObrazokCesta")] Hry hry, IFormFile uploadedFile)
        {
            if (id != hry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (uploadedFile != null && uploadedFile.Length > 0)
                    {
                        var fileName = Path.GetFileName(uploadedFile.FileName);
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await uploadedFile.CopyToAsync(stream);
                        }

                        hry.ObrazokCesta = fileName; // Aktualizácia cesty k súboru
                    }

                    _context.Update(hry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HryExists(hry.Id))
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
            return View(hry);
        }

        // GET: Hries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hry == null)
            {
                return NotFound();
            }

            var hry = await _context.Hry
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hry == null)
            {
                return NotFound();
            }

            return View(hry);
        }

        // POST: Hries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hry == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Hry'  is null.");
            }
            var hry = await _context.Hry.FindAsync(id);
            if (hry != null)
            {
                _context.Hry.Remove(hry);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HryExists(int id)
        {
          return (_context.Hry?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
