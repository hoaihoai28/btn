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
    public class CuaHangsController : Controller
    {
        private readonly data_context _context;

        public CuaHangsController(data_context context)
        {
            _context = context;
        }

        // GET: CuaHangs
        public async Task<IActionResult> Index()
        {
              return _context.CuaHangs != null ? 
                          View(await _context.CuaHangs.ToListAsync()) :
                          Problem("Entity set 'data_context.CuaHangs'  is null.");
        }

        // GET: CuaHangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CuaHangs == null)
            {
                return NotFound();
            }

            var cuaHang = await _context.CuaHangs
                .FirstOrDefaultAsync(m => m.id_cuahang == id);
            if (cuaHang == null)
            {
                return NotFound();
            }

            return View(cuaHang);
        }

        // GET: CuaHangs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CuaHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_cuahang,TenCH")] CuaHang cuaHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cuaHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cuaHang);
        }

        // GET: CuaHangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CuaHangs == null)
            {
                return NotFound();
            }

            var cuaHang = await _context.CuaHangs.FindAsync(id);
            if (cuaHang == null)
            {
                return NotFound();
            }
            return View(cuaHang);
        }

        // POST: CuaHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_cuahang,TenCH")] CuaHang cuaHang)
        {
            if (id != cuaHang.id_cuahang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cuaHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CuaHangExists(cuaHang.id_cuahang))
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
            return View(cuaHang);
        }

        // GET: CuaHangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CuaHangs == null)
            {
                return NotFound();
            }

            var cuaHang = await _context.CuaHangs
                .FirstOrDefaultAsync(m => m.id_cuahang == id);
            if (cuaHang == null)
            {
                return NotFound();
            }

            return View(cuaHang);
        }

        // POST: CuaHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CuaHangs == null)
            {
                return Problem("Entity set 'data_context.CuaHangs'  is null.");
            }
            var cuaHang = await _context.CuaHangs.FindAsync(id);
            if (cuaHang != null)
            {
                _context.CuaHangs.Remove(cuaHang);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CuaHangExists(int id)
        {
          return (_context.CuaHangs?.Any(e => e.id_cuahang == id)).GetValueOrDefault();
        }
    }
}
