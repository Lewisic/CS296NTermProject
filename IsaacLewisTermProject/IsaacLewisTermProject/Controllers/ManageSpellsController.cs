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
    public class ManageSpellsController : Controller
    {
        UserManager<AppUser> userManager;

        IHomebrewRepository _context;

        public ManageSpellsController(IHomebrewRepository repo, UserManager<AppUser> userMngr)
        {
            _context = repo;
            userManager = userMngr;
        }

        // GET: ManageSpells
        public async Task<IActionResult> Index()
        {
              return _context.Spells != null ? 
                          View(await _context.Spells.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Spells'  is null.");
        }

        // GET: ManageSpells/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Spells == null)
            {
                return NotFound();
            }

            var spell = await _context.Spells
                .FirstOrDefaultAsync(m => m.SpellId == id);
            if (spell == null)
            {
                return NotFound();
            }

            return View(spell);
        }

        // GET: ManageSpells/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ManageSpells/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpellId,SpellName,SpellSchool,SpellLevel,CastingTime,Range,Components,Duration,Effects,EffectsAtHigherLevel,SpellLists,DateAdded")] Spell spell)
        {
            if (ModelState.IsValid)
            {
                await _context.StoreSpellAsync(spell);

                return RedirectToAction(nameof(Index));
            }
            return View(spell);
        }

        // GET: ManageSpells/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _context.Spells == null)
            {
                return NotFound();
            }

            var spell = await _context.GetSpellByIdAsync(id);
            if (spell == null)
            {
                return NotFound();
            }
            return View(spell);
        }

        // POST: ManageSpells/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SpellId,SpellName,SpellSchool,SpellLevel,CastingTime,Range,Components,Duration,Effects,EffectsAtHigherLevel,SpellLists,DateAdded")] Spell spell)
        {
            if (id != spell.SpellId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.UpdateSpellAsync(spell);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpellExists(spell.SpellId))
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
            return View(spell);
        }

        // GET: ManageSpells/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Spells == null)
            {
                return NotFound();
            }

            var spell = await _context.Spells
                .FirstOrDefaultAsync(m => m.SpellId == id);
            if (spell == null)
            {
                return NotFound();
            }

            return View(spell);
        }

        // POST: ManageSpells/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Spells == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Spells'  is null.");
            }
            var spell = await _context.GetSpellByIdAsync(id);
            if (spell != null)
            {
                await _context.DeleteSpellAsync(spell);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool SpellExists(int id)
        {
          return (_context.Spells?.Any(e => e.SpellId == id)).GetValueOrDefault();
        }
    }
}
