using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LapidaMaker.Data;
using LapidaMaker.Models;

namespace LapidaMaker.Controllers
{
    public class Lapidas2Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Lapidas2Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lapidas2
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lapidas.ToListAsync());
        }

        // GET: Lapidas2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lapida = await _context.Lapidas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lapida == null)
            {
                return NotFound();
            }

            return View(lapida);
        }

        // GET: Lapidas2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lapidas2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Born,Died,Material,Size,Color,Dedication,Price,Remarks,Cellphone,OrdedBy,OrdredOn")] Lapida lapida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lapida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lapida);
        }

        // GET: Lapidas2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lapida = await _context.Lapidas.FindAsync(id);
            if (lapida == null)
            {
                return NotFound();
            }
            return View(lapida);
        }

        // POST: Lapidas2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Born,Died,Material,Size,Color,Dedication,Price,Remarks,Cellphone,OrdedBy,OrdredOn")] Lapida lapida)
        {
            if (id != lapida.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lapida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LapidaExists(lapida.Id))
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
            return View(lapida);
        }

        // GET: Lapidas2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lapida = await _context.Lapidas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lapida == null)
            {
                return NotFound();
            }

            return View(lapida);
        }

        // POST: Lapidas2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lapida = await _context.Lapidas.FindAsync(id);
            if (lapida != null)
            {
                _context.Lapidas.Remove(lapida);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LapidaExists(int id)
        {
            return _context.Lapidas.Any(e => e.Id == id);
        }
    }
}
