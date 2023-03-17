using IsaacLewisTermProject.Models;
using IsaacLewisTermProject.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IsaacLewisTermProject.Controllers
{
    public class HomebrewController : Controller
    {
        IHomebrewRepository repo;
        UserManager<AppUser> userManager;
        public HomebrewController(IHomebrewRepository r, UserManager<AppUser> userMngr)
        {
            repo = r;
            userManager = userMngr;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Item
        public async Task<IActionResult> Item(string itemName, string userName)
        {
            List<Item> items;

            if (itemName != null)
            {
                items = await (from r in repo.Items where r.ItemName == itemName select r).ToListAsync<Item>();
            }
            else if (userName != null)
            {
                items = await (from r in repo.Items where r.User.UserName== userName select r).ToListAsync<Item>();
            }
            else
            {
                items = repo.Items.ToList<Item>();
            }
            return View(items);
        }

        [Authorize]
        public IActionResult ItemAdd() { return View(); }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ItemAdd(Item item)
        {
            if (ModelState.IsValid)
            {
                if (userManager != null)
                {
                    item.User = await userManager.GetUserAsync(User);
                    item.User.Name = item.User.UserName;
                }

                if (await repo.StoreItemAsync(item) > 0)
                {
                    return RedirectToAction("Item", new { itemId = item.ItemId });
                }
            }
            return View();
        }

        [Authorize]
        public IActionResult ItemComment(int itemID)
        {
            var commentVM = new ItemCommentVM { ItemId = itemID };
            return View(commentVM);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ItemComment(ItemCommentVM commentVM)
        {
            if (ModelState.IsValid)
            {
                var comment = new ItemComment { CommentText = commentVM.CommentText };

                if (userManager != null)
                {
                    comment.Commenter = await userManager.GetUserAsync(User);
                    comment.Commenter.Name = comment.Commenter.UserName;
                    comment.CommentDate = DateTime.Now;
                }

                var item = await repo.GetItemByIdAsync(commentVM.ItemId);

                item.Comments.Add(comment);
                await repo.UpdateItemAsync(item);
                return RedirectToAction("Item", new { userName = item.User });
            }
            return View(commentVM);
        }
        #endregion

        #region Adventure
        public async Task<IActionResult> Adventure(string adventureName, string userName)
        {
            List<Adventure> adventures;

            if (adventureName != null)
            {
                adventures = await (from r in repo.Adventures where r.AdventureName == adventureName select r).ToListAsync<Adventure>();
            }
            else if (userName != null)
            {
                adventures = await (from r in repo.Adventures where r.User.UserName == userName select r).ToListAsync<Adventure>();
            }
            else
            {
                adventures = repo.Adventures.ToList<Adventure>();
            }
            return View(adventures);
        }

        [Authorize]
        public IActionResult AdventureAdd() { return View(); }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AdventureAdd(Adventure adventure)
        {
            if (ModelState.IsValid)
            {
                if (userManager != null)
                {
                    adventure.User = await userManager.GetUserAsync(User);
                    adventure.User.Name = adventure.User.UserName;
                }

                if (await repo.StoreAdventureAsync(adventure) > 0)
                {
                    return RedirectToAction("Adventure", new { adventureId = adventure.AdventureId });
                }
            }
            return View();
        }

        [Authorize]
        public IActionResult AdventureComment(int adventureId)
        {
            var commentVM = new AdventureCommentVM { AdventureId = adventureId };
            return View(commentVM);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AdventureComment(AdventureCommentVM commentVM)
        {
            if (ModelState.IsValid)
            {
                var comment = new AdventureComment { CommentText = commentVM.CommentText };

                if (userManager != null)
                {
                    comment.Commenter = await userManager.GetUserAsync(User);
                    comment.Commenter.Name = comment.Commenter.UserName;
                    comment.CommentDate = DateTime.Now;
                }

                var adventure = await repo.GetAdventureByIdAsync(commentVM.AdventureId);

                adventure.Comments.Add(comment);
                await repo.UpdateAdventureAsync(adventure);
                return RedirectToAction("Adventure", new { userName = adventure.User });
            }
            return View(commentVM);
        }
        #endregion

        #region Spell
        public async Task<IActionResult> Spell(string spellName, string userName)
        {
            List<Spell> spells;

            if (spellName != null)
            {
                spells = await (from r in repo.Spells where r.SpellName == spellName select r).ToListAsync<Spell>();
            }
            else if (userName != null)
            {
                spells = await (from r in repo.Spells where r.User.UserName == userName select r).ToListAsync<Spell>();
            }
            else
            {
                spells = repo.Spells.ToList<Spell>();
            }
            return View(spells);
        }

        [Authorize]
        public IActionResult SpellAdd() { return View(); }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SpellAdd(Spell spell)
        {
            if (ModelState.IsValid)
            {
                if (userManager != null)
                {
                    spell.User = await userManager.GetUserAsync(User);
                    spell.User.Name = spell.User.UserName;
                }

                if (await repo.StoreSpellAsync(spell) > 0)
                {
                    return RedirectToAction("Spell", new { spellId = spell.SpellId });
                }
            }
            return View();
        }

        [Authorize]
        public IActionResult SpellComment(int spellId)
        {
            var commentVM = new SpellCommentVM { SpellId = spellId };
            return View(commentVM);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SpellComment(SpellCommentVM commentVM)
        {
            if (ModelState.IsValid)
            {
                var comment = new SpellComment { CommentText = commentVM.CommentText };

                if (userManager != null)
                {
                    comment.Commenter = await userManager.GetUserAsync(User);
                    comment.Commenter.Name = comment.Commenter.UserName;
                    comment.CommentDate = DateTime.Now;
                }

                var spell = await repo.GetSpellByIdAsync(commentVM.SpellId);

                spell.Comments.Add(comment);
                await repo.UpdateSpellAsync(spell);
                return RedirectToAction("Spell", new { userName = spell.User });
            }
            return View(commentVM);
        }
        #endregion

        #region Feat
        public async Task<IActionResult> Feat(string featName, string userName)
        {
            List<Feat> feats;

            if (featName != null)
            {
                feats = await (from r in repo.Feats where r.FeatName == featName select r).ToListAsync<Feat>();
            }
            else if (userName != null)
            {
                feats = await (from r in repo.Feats where r.User.UserName == userName select r).ToListAsync<Feat>();
            }
            else
            {
                feats = repo.Feats.ToList<Feat>();
            }
            return View(feats);
        }

        [Authorize]
        public IActionResult FeatAdd() { return View(); }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> FeatAdd(Feat feat)
        {
            if (ModelState.IsValid)
            {
                if (userManager != null)
                {
                    feat.User = await userManager.GetUserAsync(User);
                    feat.User.Name = feat.User.UserName;
                }

                if (await repo.StoreFeatsAsync(feat) > 0)
                {
                    return RedirectToAction("Feat", new { featId = feat.FeatId });
                }
            }
            return View();
        }

        [Authorize]
        public IActionResult FeatComment(int featid)
        {
            var commentVM = new FeatCommentVM { FeatId = featid };
            return View(commentVM);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> FeatComment(FeatCommentVM commentVM)
        {
            if (ModelState.IsValid)
            {
                var comment = new FeatComment { CommentText = commentVM.CommentText };

                if (userManager != null)
                {
                    comment.Commenter = await userManager.GetUserAsync(User);
                    comment.Commenter.Name = comment.Commenter.UserName;
                    comment.CommentDate = DateTime.Now;
                }

                var feat = await repo.GetFeatsByIdAsync(commentVM.FeatId);

                feat.Comments.Add(comment);
                await repo.UpdateFeatsAsync(feat);
                return RedirectToAction("Feat", new { userName = feat.User });
            }
            return View(commentVM);
        }
        #endregion
    }
}
