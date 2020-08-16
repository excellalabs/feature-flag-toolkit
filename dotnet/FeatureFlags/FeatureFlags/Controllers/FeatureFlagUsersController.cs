using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FeatureFlags.Models;
using FeatureFlags.Models.Contexts;

namespace FeatureFlags.Controllers
{
    public class FeatureFlagUsersController : Controller
    {
        private readonly DatabaseContexts _context;

        public FeatureFlagUsersController(IDatabaseContexts context)
        {
            _context = (DatabaseContexts)context;
        }

        // GET: FeatureFlagUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.FeatureFlagUsers.ToListAsync());
        }

        // GET: FeatureFlagUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var featureFlagUser = await _context.FeatureFlagUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (featureFlagUser == null)
            {
                return NotFound();
            }

            return View(featureFlagUser);
        }

        // GET: FeatureFlagUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FeatureFlagUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName")] FeatureFlagUser featureFlagUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(featureFlagUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(featureFlagUser);
        }

        // GET: FeatureFlagUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var featureFlagUser = await _context.FeatureFlagUsers.FindAsync(id);
            if (featureFlagUser == null)
            {
                return NotFound();
            }
            return View(featureFlagUser);
        }

        // POST: FeatureFlagUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName")] FeatureFlagUser featureFlagUser)
        {
            if (id != featureFlagUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(featureFlagUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeatureFlagUserExists(featureFlagUser.Id))
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
            return View(featureFlagUser);
        }

        // GET: FeatureFlagUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var featureFlagUser = await _context.FeatureFlagUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (featureFlagUser == null)
            {
                return NotFound();
            }

            return View(featureFlagUser);
        }

        // POST: FeatureFlagUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var featureFlagUser = await _context.FeatureFlagUsers.FindAsync(id);
            _context.FeatureFlagUsers.Remove(featureFlagUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeatureFlagUserExists(int id)
        {
            return _context.FeatureFlagUsers.Any(e => e.Id == id);
        }
    }
}
