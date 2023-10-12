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
    public class PhanQuyensController : Controller
    {
        private readonly data_context _context;

        public PhanQuyensController(data_context context)
        {
            _context = context;
        }

        // GET: PhanQuyens
        public async Task<IActionResult> Index()
        {
            var data_context = _context.PhanQuyens.Include(p => p.CuaHang).Include(p => p.NamThang).Include(p => p.NhanVien).Include(p => p.SanPham);
            return View(await data_context.ToListAsync());
        }

        // GET: PhanQuyens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PhanQuyens == null)
            {
                return NotFound();
            }

            var phanQuyen = await _context.PhanQuyens
                .Include(p => p.CuaHang)
                .Include(p => p.NamThang)
                .Include(p => p.NhanVien)
                .Include(p => p.SanPham)
                .FirstOrDefaultAsync(m => m.id_phanquyen == id);
            if (phanQuyen == null)
            {
                return NotFound();
            }

            return View(phanQuyen);
        }

        // GET: PhanQuyens/Create
        public IActionResult Create()
        {
            ViewData["id_cuahang"] = new SelectList(_context.CuaHangs, "id_cuahang", "id_cuahang");
            ViewData["id_namthang"] = new SelectList(_context.NamThangs, "id_namthang", "id_namthang");
            ViewData["id_nhanvien"] = new SelectList(_context.NhanViens, "id_nhanvien", "id_nhanvien");
            ViewData["id_sanpham"] = new SelectList(_context.SanPhams, "id_sanpham", "id_sanpham");
            return View();
        }

        // POST: PhanQuyens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_phanquyen,id_nhanvien,id_cuahang,id_sanpham,id_namthang")] PhanQuyen phanQuyen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phanQuyen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_cuahang"] = new SelectList(_context.CuaHangs, "id_cuahang", "id_cuahang", phanQuyen.id_cuahang);
            ViewData["id_namthang"] = new SelectList(_context.NamThangs, "id_namthang", "id_namthang", phanQuyen.id_namthang);
            ViewData["id_nhanvien"] = new SelectList(_context.NhanViens, "id_nhanvien", "id_nhanvien", phanQuyen.id_nhanvien);
            ViewData["id_sanpham"] = new SelectList(_context.SanPhams, "id_sanpham", "id_sanpham", phanQuyen.id_sanpham);
            return View(phanQuyen);
        }

        // GET: PhanQuyens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PhanQuyens == null)
            {
                return NotFound();
            }

            var phanQuyen = await _context.PhanQuyens.FindAsync(id);
            if (phanQuyen == null)
            {
                return NotFound();
            }
            ViewData["id_cuahang"] = new SelectList(_context.CuaHangs, "id_cuahang", "id_cuahang", phanQuyen.id_cuahang);
            ViewData["id_namthang"] = new SelectList(_context.NamThangs, "id_namthang", "id_namthang", phanQuyen.id_namthang);
            ViewData["id_nhanvien"] = new SelectList(_context.NhanViens, "id_nhanvien", "id_nhanvien", phanQuyen.id_nhanvien);
            ViewData["id_sanpham"] = new SelectList(_context.SanPhams, "id_sanpham", "id_sanpham", phanQuyen.id_sanpham);
            return View(phanQuyen);
        }

        // POST: PhanQuyens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_phanquyen,id_nhanvien,id_cuahang,id_sanpham,id_namthang")] PhanQuyen phanQuyen)
        {
            if (id != phanQuyen.id_phanquyen)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phanQuyen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhanQuyenExists(phanQuyen.id_phanquyen))
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
            ViewData["id_cuahang"] = new SelectList(_context.CuaHangs, "id_cuahang", "id_cuahang", phanQuyen.id_cuahang);
            ViewData["id_namthang"] = new SelectList(_context.NamThangs, "id_namthang", "id_namthang", phanQuyen.id_namthang);
            ViewData["id_nhanvien"] = new SelectList(_context.NhanViens, "id_nhanvien", "id_nhanvien", phanQuyen.id_nhanvien);
            ViewData["id_sanpham"] = new SelectList(_context.SanPhams, "id_sanpham", "id_sanpham", phanQuyen.id_sanpham);
            return View(phanQuyen);
        }

        // GET: PhanQuyens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PhanQuyens == null)
            {
                return NotFound();
            }

            var phanQuyen = await _context.PhanQuyens
                .Include(p => p.CuaHang)
                .Include(p => p.NamThang)
                .Include(p => p.NhanVien)
                .Include(p => p.SanPham)
                .FirstOrDefaultAsync(m => m.id_phanquyen == id);
            if (phanQuyen == null)
            {
                return NotFound();
            }

            return View(phanQuyen);
        }

        // POST: PhanQuyens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PhanQuyens == null)
            {
                return Problem("Entity set 'data_context.PhanQuyens'  is null.");
            }
            var phanQuyen = await _context.PhanQuyens.FindAsync(id);
            if (phanQuyen != null)
            {
                _context.PhanQuyens.Remove(phanQuyen);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhanQuyenExists(int id)
        {
          return (_context.PhanQuyens?.Any(e => e.id_phanquyen == id)).GetValueOrDefault();
        }
    }
}
