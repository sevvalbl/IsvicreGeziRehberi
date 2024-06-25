using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IsvicreGeziRehberi.Model;

namespace IsvicreGeziRehberi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GonderisController : Controller
    {
        private readonly DatabaseContext _context;

        public GonderisController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Admin/Gonderis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gonderis.ToListAsync());
        }

        // GET: Admin/Gonderis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gonderi = await _context.Gonderis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gonderi == null)
            {
                return NotFound();
            }

            return View(gonderi);
        }

        // GET: Admin/Gonderis/Create
        public IActionResult Create()
        {
            ViewData["KategoriID"] = new SelectList(_context.GonderiKategoris, "Id", "KategoriAdi");
            return View();
        }

        // POST: Admin/Gonderis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Gonderi gonderi, IFormFile? Fotograf)
        {
            if (ModelState.IsValid)
            {
                if (Fotograf is not null)
                {
                    string folder = Directory.GetCurrentDirectory() + "/wwwroot/images/" + Fotograf.FileName;
                    using var stream = new FileStream(folder, FileMode.Create);
                    Fotograf.CopyTo(stream);
                    gonderi.Fotograf = Fotograf.FileName;
                }
                ViewData["CategoryID"] = new SelectList(_context.GonderiKategoris, "Id", "KategoriAdi", gonderi.KategoriID);
                _context.Add(gonderi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(gonderi);
        }

        // GET: Admin/Gonderis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gonderi = await _context.Gonderis.FindAsync(id);
            if (gonderi == null)
            {
                return NotFound();
            }
            return View(gonderi);
        }

        // POST: Admin/Gonderis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Baslik,Icerik,Fotograf,AktiflikDurumu,OlusturanKullanici,KategoriID,OlusturmaTarihi")] Gonderi gonderi)
        {
            if (id != gonderi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gonderi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GonderiExists(gonderi.Id))
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
            return View(gonderi);
        }

        // GET: Admin/Gonderis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gonderi = await _context.Gonderis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gonderi == null)
            {
                return NotFound();
            }

            return View(gonderi);
        }

        // POST: Admin/Gonderis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gonderi = await _context.Gonderis.FindAsync(id);
            if (gonderi != null)
            {
                _context.Gonderis.Remove(gonderi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GonderiExists(int id)
        {
            return _context.Gonderis.Any(e => e.Id == id);
        }
    }
}
