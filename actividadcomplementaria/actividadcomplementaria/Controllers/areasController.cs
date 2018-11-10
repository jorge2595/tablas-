using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using actividadcomplementaria.Models;

namespace actividadcomplementaria.Controllers
{
    public class areasController : Controller
    {
        private readonly actividadcomplementariaContext _context;

        public areasController(actividadcomplementariaContext context)
        {
            _context = context;
        }

        // GET: areas
        public async Task<IActionResult> Index()
        {
            return View(await _context.area.ToListAsync());
        }

        // GET: areas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var area = await _context.area
                .SingleOrDefaultAsync(m => m.ID_area == id);
            if (area == null)
            {
                return NotFound();
            }

            return View(area);
        }

        // GET: areas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: areas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_area,Nombre_area")] area area)
        {
            if (ModelState.IsValid)
            {
                _context.Add(area);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(area);
        }

        // GET: areas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var area = await _context.area.SingleOrDefaultAsync(m => m.ID_area == id);
            if (area == null)
            {
                return NotFound();
            }
            return View(area);
        }

        // POST: areas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID_area,Nombre_area")] area area)
        {
            if (id != area.ID_area)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(area);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!areaExists(area.ID_area))
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
            return View(area);
        }

        // GET: areas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var area = await _context.area
                .SingleOrDefaultAsync(m => m.ID_area == id);
            if (area == null)
            {
                return NotFound();
            }

            return View(area);
        }

        // POST: areas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var area = await _context.area.SingleOrDefaultAsync(m => m.ID_area == id);
            _context.area.Remove(area);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool areaExists(string id)
        {
            return _context.area.Any(e => e.ID_area == id);
        }
    }
}
