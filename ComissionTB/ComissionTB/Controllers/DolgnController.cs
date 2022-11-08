using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ComissionTB.Data;

namespace ComissionTB.Controllers
{
    public class DolgnController : Controller
    {
        private readonly ComissionDbContext _context;

        public DolgnController(ComissionDbContext context)
        {
            _context = context;
        }

        // GET: Dolgn
        public async Task<IActionResult> Index()
        {
            return View(await _context.dolgn.ToListAsync());
        }

        // GET: Dolgn/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dolgn = await _context.dolgn
                .FirstOrDefaultAsync(m => m.id_dl == id);
            if (dolgn == null)
            {
                return NotFound();
            }

            return View(dolgn);
        }

        // GET: Dolgn/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dolgn/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_dl,dlName")] Dolgn dolgn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dolgn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dolgn);
        }

        // GET: Dolgn/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dolgn = await _context.dolgn.FindAsync(id);
            if (dolgn == null)
            {
                return NotFound();
            }
            return View(dolgn);
        }

        // POST: Dolgn/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_dl,dlName")] Dolgn dolgn)
        {
            if (id != dolgn.id_dl)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dolgn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DolgnExists(dolgn.id_dl))
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
            return View(dolgn);
        }

        // GET: Dolgn/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dolgn = await _context.dolgn
                .FirstOrDefaultAsync(m => m.id_dl == id);
            if (dolgn == null)
            {
                return NotFound();
            }

            return View(dolgn);
        }

        // POST: Dolgn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dolgn = await _context.dolgn.FindAsync(id);
            _context.dolgn.Remove(dolgn);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DolgnExists(int id)
        {
            return _context.dolgn.Any(e => e.id_dl == id);
        }
    }
}
