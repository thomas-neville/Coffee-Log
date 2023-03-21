using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoffeeLogAppv1.Data;
using CoffeeLogAppv1.Models;

namespace CoffeeLogAppv1.Controllers
{
    public class BrewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BrewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Brews
        public async Task<IActionResult> Index()
        {
              return _context.Brew != null ? 
                          View(await _context.Brew.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Brew'  is null.");
        }

        // GET: Show Search Form
        public async Task<IActionResult> ShowSearchForm()
        {
            // TODO: update return context and problem?
            return _context.Brew != null ?
                        // ShowSearchForm is implied in View method
                        View() :
                        Problem("Entity set 'ApplicationDbContext.Brew'  is null.");
        }

        /*
        // POST: Show Search Results TODO: issue with the ShowSearchResults and SearchCoffeeName context
        public async Task<IActionResult> ShowSearchResults(String(SearchCoffeeName))
        {
            // For search logic, filtering CoffeeNames based on Search entry, using anonymous function
            return View("Index", await _context.Brew.Where(b => b.CoffeeName.Contains(SearchCoffeeName).ToListAsync());
        }
        */

        // GET: Brews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Brew == null)
            {
                return NotFound();
            }

            var brew = await _context.Brew
                .FirstOrDefaultAsync(m => m.Id == id);
            if (brew == null)
            {
                return NotFound();
            }

            return View(brew);
        }

        // GET: Brews/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Brews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CoffeeName,BrewTime,DoseGrams,GrindSetting,WaterTemp,Notes")] Brew brew)
        {
            if (ModelState.IsValid)
            {
                _context.Add(brew);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(brew);
        }

        // GET: Brews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Brew == null)
            {
                return NotFound();
            }

            var brew = await _context.Brew.FindAsync(id);
            if (brew == null)
            {
                return NotFound();
            }
            return View(brew);
        }

        // POST: Brews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CoffeeName,BrewTime,DoseGrams,GrindSetting,WaterTemp,Notes")] Brew brew)
        {
            if (id != brew.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(brew);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrewExists(brew.Id))
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
            return View(brew);
        }

        // GET: Brews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Brew == null)
            {
                return NotFound();
            }

            var brew = await _context.Brew
                .FirstOrDefaultAsync(m => m.Id == id);
            if (brew == null)
            {
                return NotFound();
            }

            return View(brew);
        }

        // POST: Brews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Brew == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Brew'  is null.");
            }
            var brew = await _context.Brew.FindAsync(id);
            if (brew != null)
            {
                _context.Brew.Remove(brew);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BrewExists(int id)
        {
          return (_context.Brew?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
