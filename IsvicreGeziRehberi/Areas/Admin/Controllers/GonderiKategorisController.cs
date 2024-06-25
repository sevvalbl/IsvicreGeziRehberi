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
    public class GonderiKategorisController : Controller
    {
        private readonly DatabaseContext _context;

        public GonderiKategorisController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Admin/GonderiKategoris
        public async Task<IActionResult> Index()
        {
            return View(await _context.GonderiKategoris.ToListAsync());
        }

        // GET: Admin/GonderiKategoris/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gonderiKategori = await _context.GonderiKategoris
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gonderiKategori == null)
            {
                return NotFound();
            }

            return View(gonderiKategori);
        }

        // GET: Admin/GonderiKategoris/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/GonderiKategoris/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KategoriAdi")] GonderiKategori gonderiKategori)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gonderiKategori);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gonderiKategori);
        }

        // GET: Admin/GonderiKategoris/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gonderiKategori = await _context.GonderiKategoris.FindAsync(id);
            if (gonderiKategori == null)
            {
                return NotFound();
            }
            return View(gonderiKategori);
        }

        // POST: Admin/GonderiKategoris/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KategoriAdi")] GonderiKategori gonderiKategori)
        {
            if (id != gonderiKategori.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gonderiKategori);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GonderiKategoriExists(gonderiKategori.Id))
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
            return View(gonderiKategori);
        }

        // GET: Admin/GonderiKategoris/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gonderiKategori = await _context.GonderiKategoris
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gonderiKategori == null)
            {
                return NotFound();
            }

            return View(gonderiKategori);
        }

        // POST: Admin/GonderiKategoris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gonderiKategori = await _context.GonderiKategoris.FindAsync(id);
            if (gonderiKategori != null)
            {
                _context.GonderiKategoris.Remove(gonderiKategori);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GonderiKategoriExists(int id)
        {
            return _context.GonderiKategoris.Any(e => e.Id == id);
        }
    }
}
