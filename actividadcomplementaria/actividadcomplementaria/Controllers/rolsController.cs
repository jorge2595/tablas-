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
    public class rolsController : Controller
    {
        private readonly actividadcomplementariaContext _context;

        public rolsController(actividadcomplementariaContext context)
        {
            _context = context;
        }

        // GET: rols
        public async Task<IActionResult> Index()
        {
            return View(await _context.rol.ToListAsync());
        }

        // GET: rols/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rol = await _context.rol
                .SingleOrDefaultAsync(m => m.ID_rol == id);
            if (rol == null)
            {
                return NotFound();
            }

            return View(rol);
        }

        // GET: rols/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: rols/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_rol,nombre_rol,descripcion")] rol rol)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rol);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rol);
        }

        // GET: rols/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rol = await _context.rol.SingleOrDefaultAsync(m => m.ID_rol == id);
            if (rol == null)
            {
                return NotFound();
            }
            return View(rol);
        }

        // POST: rols/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_rol,nombre_rol,descripcion")] rol rol)
        {
            if (id != rol.ID_rol)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rol);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!rolExists(rol.ID_rol))
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
            return View(rol);
        }

        // GET: rols/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rol = await _context.rol
                .SingleOrDefaultAsync(m => m.ID_rol == id);
            if (rol == null)
            {
                return NotFound();
            }

            return View(rol);
        }

        // POST: rols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rol = await _context.rol.SingleOrDefaultAsync(m => m.ID_rol == id);
            _context.rol.Remove(rol);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool rolExists(int id)
        {
            return _context.rol.Any(e => e.ID_rol == id);
        }
    }
}
