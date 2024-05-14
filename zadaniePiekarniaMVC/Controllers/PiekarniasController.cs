using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using zadaniePiekarniaMVC.Data;
using zadaniePiekarniaMVC.Models;

namespace zadaniePiekarniaMVC.Controllers
{
    public class PiekarniasController : Controller
    {
        private readonly zadaniePiekarniaMVCContext _context;

        public PiekarniasController(zadaniePiekarniaMVCContext context)
        {
            _context = context;
        }

        // GET: Piekarnias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Piekarnia.ToListAsync());
        }

        // GET: Piekarnias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piekarnia = await _context.Piekarnia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (piekarnia == null)
            {
                return NotFound();
            }

            return View(piekarnia);
        }

        // GET: Piekarnias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Piekarnias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nazwa,Rodzaj,Cena")] Piekarnia piekarnia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(piekarnia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(piekarnia);
        }

        // GET: Piekarnias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piekarnia = await _context.Piekarnia.FindAsync(id);
            if (piekarnia == null)
            {
                return NotFound();
            }
            return View(piekarnia);
        }

        // POST: Piekarnias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa,Rodzaj,Cena")] Piekarnia piekarnia)
        {
            if (id != piekarnia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(piekarnia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PiekarniaExists(piekarnia.Id))
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
            return View(piekarnia);
        }

        // GET: Piekarnias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piekarnia = await _context.Piekarnia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (piekarnia == null)
            {
                return NotFound();
            }

            return View(piekarnia);
        }

        // POST: Piekarnias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var piekarnia = await _context.Piekarnia.FindAsync(id);
            if (piekarnia != null)
            {
                _context.Piekarnia.Remove(piekarnia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PiekarniaExists(int id)
        {
            return _context.Piekarnia.Any(e => e.Id == id);
        }
    }
}
