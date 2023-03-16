using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IsaacLewisTermProject.Data;
using IsaacLewisTermProject.Models;
using IsaacLewisTermProject.Repos;
using Microsoft.AspNetCore.Identity;

namespace IsaacLewisTermProject.Controllers
{
    public class ManageAdventuresController : Controller
    {
        UserManager<AppUser> userManager;

        IHomebrewRepository _context;

        public ManageAdventuresController(IHomebrewRepository repo, UserManager<AppUser> userMngr)
        {
            _context = repo;
            userManager = userMngr;
        }


        // GET: ManageAdventures
        public async Task<IActionResult> Index()
        {
              return _context.Adventures != null ? 
                          View(await _context.Adventures.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Adventures'  is null.");
        }

        // GET: ManageAdventures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Adventures == null)
            {
                return NotFound();
            }

            var adventure = await _context.Adventures
                .FirstOrDefaultAsync(m => m.AdventureId == id);
            if (adventure == null)
            {
                return NotFound();
            }

            return View(adventure);
        }

        // GET: ManageAdventures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ManageAdventures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdventureId,AdventureName,AdventureDifficulty,RecommendedLevels,AdventureDescription,DateAdded")] Adventure adventure)
        {
            if (ModelState.IsValid)
            {
                if (userManager != null)
                {
                    adventure.User = await userManager.GetUserAsync(User);
                    adventure.User.Name = adventure.User.UserName;
                }
                await _context.StoreAdventureAsync(adventure);
                return RedirectToAction(nameof(Index));
            }
            return View(adventure);
        }

        // GET: ManageAdventures/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _context.Adventures == null)
            {
                return NotFound();
            }

            var adventure = await _context.GetAdventureByIdAsync(id);
            if (adventure == null)
            {
                return NotFound();
            }
            return View(adventure);
        }

        // POST: ManageAdventures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdventureId,AdventureName,AdventureDifficulty,RecommendedLevels,AdventureDescription,DateAdded")] Adventure adventure)
        {
            if (id != adventure.AdventureId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.UpdateAdventureAsync(adventure);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdventureExists(adventure.AdventureId))
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
            return View(adventure);
        }

        // GET: ManageAdventures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Adventures == null)
            {
                return NotFound();
            }

            var adventure = await _context.Adventures
                .FirstOrDefaultAsync(m => m.AdventureId == id);
            if (adventure == null)
            {
                return NotFound();
            }

            return View(adventure);
        }

        // POST: ManageAdventures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Adventures == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Adventures'  is null.");
            }
            var adventure = await _context.GetAdventureByIdAsync(id);
            if (adventure != null)
            {
                await _context.DeleteAdventureAsync(adventure);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool AdventureExists(int id)
        {
          return (_context.Adventures?.Any(e => e.AdventureId == id)).GetValueOrDefault();
        }
    }
}
