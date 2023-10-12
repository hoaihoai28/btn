using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Baitap1.Models;
using Baitap1.data;

namespace Baitap1.Controllers
{
    public class NamThangsController : Controller
    {
        private readonly data_context _context;

        public NamThangsController(data_context context)
        {
            _context = context;
        }

        // GET: NamThangs
        public async Task<IActionResult> Index()
        {
              return _context.NamThangs != null ? 
                          View(await _context.NamThangs.ToListAsync()) :
                          Problem("Entity set 'data_context.NamThangs'  is null.");
        }

        // GET: NamThangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NamThangs == null)
            {
                return NotFound();
            }

            var namThang = await _context.NamThangs
                .FirstOrDefaultAsync(m => m.id_namthang == id);
            if (namThang == null)
            {
                return NotFound();
            }

            return View(namThang);
        }

        // GET: NamThangs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NamThangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_namthang,NLHD")] NamThang namThang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(namThang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(namThang);
        }

        // GET: NamThangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NamThangs == null)
            {
                return NotFound();
            }

            var namThang = await _context.NamThangs.FindAsync(id);
            if (namThang == null)
            {
                return NotFound();
            }
            return View(namThang);
        }

        // POST: NamThangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_namthang,NLHD")] NamThang namThang)
        {
            if (id != namThang.id_namthang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(namThang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NamThangExists(namThang.id_namthang))
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
            return View(namThang);
        }

        // GET: NamThangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NamThangs == null)
            {
                return NotFound();
            }

            var namThang = await _context.NamThangs
                .FirstOrDefaultAsync(m => m.id_namthang == id);
            if (namThang == null)
            {
                return NotFound();
            }

            return View(namThang);
        }

        // POST: NamThangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NamThangs == null)
            {
                return Problem("Entity set 'data_context.NamThangs'  is null.");
            }
            var namThang = await _context.NamThangs.FindAsync(id);
            if (namThang != null)
            {
                _context.NamThangs.Remove(namThang);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NamThangExists(int id)
        {
          return (_context.NamThangs?.Any(e => e.id_namthang == id)).GetValueOrDefault();
        }
    }
}
