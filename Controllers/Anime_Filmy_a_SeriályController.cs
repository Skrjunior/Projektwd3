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

    public class Anime_Filmy_a_SeriályController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;


        public Anime_Filmy_a_SeriályController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Anime_Filmy_a_Seriály
        public async Task<IActionResult> Index()
        {
              return _context.Anime_Filmy_a_Seriály != null ? 
                          View(await _context.Anime_Filmy_a_Seriály.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Anime_Filmy_a_Seriály'  is null.");
        }

        // GET: Anime_Filmy_a_Seriály/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Anime_Filmy_a_Seriály == null)
            {
                return NotFound();
            }

            var anime_Filmy_a_Seriály = await _context.Anime_Filmy_a_Seriály
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anime_Filmy_a_Seriály == null)
            {
                return NotFound();
            }

            return View(anime_Filmy_a_Seriály);
        }

        // GET: Anime_Filmy_a_Seriály/Create
        public IActionResult Create()
        {
            var typy = new List<string> { "Film", "Seriál", "Anime" };
            ViewBag.Typy = new SelectList(typy);
            return View();
        }

        // POST: Anime_Filmy_a_Seriály/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nazov,RokVydania,Zaner,Odkaz,Typ,ObrazokCesta")] Anime_Filmy_a_Seriály anime_Filmy_a_Seriály, IFormFile uploadedFile)
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
                    anime_Filmy_a_Seriály.ObrazokCesta = fileName; // Uloženie cesty k súboru
                }

                _context.Add(anime_Filmy_a_Seriály);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(anime_Filmy_a_Seriály);
        }

        // GET: Anime_Filmy_a_Seriály/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Anime_Filmy_a_Seriály == null)
            {
                return NotFound();
            }

            var anime_Filmy_a_Seriály = await _context.Anime_Filmy_a_Seriály.FindAsync(id);
            if (anime_Filmy_a_Seriály == null)
            {
                return NotFound();
            }

            var typy = new List<string> { "Film", "Seriál", "Anime" };
            ViewBag.Typy = new SelectList(typy);

            return View(anime_Filmy_a_Seriály);
        }
        // POST: Anime_Filmy_a_Seriály/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // POST: Anime_Filmy_a_Seriály/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazov,RokVydania,Zaner,Odkaz,Typ,ObrazokCesta")] Anime_Filmy_a_Seriály anime_Filmy_a_Seriály, IFormFile uploadedFile)
        {
            if (id != anime_Filmy_a_Seriály.Id)
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
                        anime_Filmy_a_Seriály.ObrazokCesta = fileName; // Uloženie cesty k súboru
                    }

                    _context.Update(anime_Filmy_a_Seriály);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Anime_Filmy_a_SeriályExists(anime_Filmy_a_Seriály.Id))
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
            return View(anime_Filmy_a_Seriály);
        }


        // GET: Anime_Filmy_a_Seriály/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Anime_Filmy_a_Seriály == null)
            {
                return NotFound();
            }

            var anime_Filmy_a_Seriály = await _context.Anime_Filmy_a_Seriály
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anime_Filmy_a_Seriály == null)
            {
                return NotFound();
            }

            return View(anime_Filmy_a_Seriály);
        }

        // POST: Anime_Filmy_a_Seriály/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Anime_Filmy_a_Seriály == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Anime_Filmy_a_Seriály'  is null.");
            }
            var anime_Filmy_a_Seriály = await _context.Anime_Filmy_a_Seriály.FindAsync(id);
            if (anime_Filmy_a_Seriály != null)
            {
                _context.Anime_Filmy_a_Seriály.Remove(anime_Filmy_a_Seriály);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Anime_Filmy_a_SeriályExists(int id)
        {
          return (_context.Anime_Filmy_a_Seriály?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
