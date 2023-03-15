using IsaacLewisTermProject.Data;
using IsaacLewisTermProject.Models;
using Microsoft.EntityFrameworkCore;

namespace IsaacLewisTermProject.Repos
{
    public class HomebrewRepository : IHomebrewRepository
    {
        private ApplicationDbContext context;

        public HomebrewRepository(ApplicationDbContext c) 
        { 
            context = c;
        }
        #region Items
        public IQueryable<Item> Items
        {
            get
            {
                return context.Items.Include(item => item.User)
                                    .Include(item => item.Comments)
                                    .ThenInclude(comment => comment.Commenter);
            }
        }

        public async Task<Item?> GetItemByIdAsync(int id)
        {
            return await Items.Where(i => i.ItemId == id).FirstOrDefaultAsync();
        }

        public async Task<int> StoreItemAsync(Item item)
        {
            item.DateAdded = DateTime.Now;
            context.Items.Add(item);
            return await context.SaveChangesAsync();
        }

        public async Task UpdateItemAsync(Item item)
        {
            context.Items.Update(item);
            await context.SaveChangesAsync();
        }

        public async Task<int> DeleteItemAsync(Item item)
        {
            var theItem = await context.Items.FindAsync(item.ItemId);
            context.Items.Remove(theItem);
            return await context.SaveChangesAsync();
        }

        #endregion
        #region Adventures
        public IQueryable<Adventure> Adventures
        {
            get
            {
                return context.Adventures.Include(adventure => adventure.User)
                                    .Include(adventure => adventure.Comments)
                                    .ThenInclude(comment => comment.Commenter);
            }
        }

        public async Task<Adventure?> GetAdventureByIdAsync(int id)
        {
            return await Adventures.Where(a => a.AdventureId == id).FirstOrDefaultAsync();
        }

        public async Task<int> StoreAdventureAsync(Adventure adventure)
        {
            adventure.DateAdded = DateTime.Now;
            context.Adventures.Add(adventure);
            return await context.SaveChangesAsync();
        }

        public async Task UpdateAdventureAsync(Adventure adventure)
        {
            context.Adventures.Update(adventure);
            await context.SaveChangesAsync();
        }

        public async Task<int> DeleteAdventureAsync(Adventure adventure)
        {
            var theAdventure = await context.Adventures.FindAsync(adventure.AdventureId);
            context.Adventures.Remove(theAdventure);
            return await context.SaveChangesAsync();
        }

        #endregion
        #region Spells
        public IQueryable<Spell> Spells
        {
            get
            {
                return context.Spells.Include(spell => spell.User)
                                    .Include(spell => spell.Comments)
                                    .ThenInclude(comment => comment.Commenter);
            }
        }

        public async Task<Spell?> GetSpellByIdAsync(int id)
        {
            return await Spells.Where(s => s.SpellId == id).FirstOrDefaultAsync();
        }

        public async Task<int> StoreSpellAsync(Spell spell)
        {
            spell.DateAdded = DateTime.Now;
            context.Spells.Add(spell);
            return await context.SaveChangesAsync();
        }

        public async Task UpdateSpellAsync(Spell spell)
        {
            context.Spells.Update(spell);
            await context.SaveChangesAsync();
        }

        public async Task<int> DeleteSpellAsync(Spell spell)
        {
            var theSpell = await context.Spells.FindAsync(spell.SpellId);
            context.Spells.Remove(spell);
            return await context.SaveChangesAsync();
        }

        #endregion
        #region Feats
        public IQueryable<Feat> Feats
        {
            get
            {
                return context.Feats.Include(feat => feat.User)
                                    .Include(feat => feat.Comments)
                                    .ThenInclude(comment => comment.Commenter);
            }
        }

        public async Task<Feat?> GetFeatsByIdAsync(int id)
        {
            return await Feats.Where(f => f.FeatId == id).FirstOrDefaultAsync();
        }

        public async Task<int> StoreFeatsAsync(Feat feat)
        {
            feat.DateAdded = DateTime.Now;
            context.Feats.Add(feat);
            return await context.SaveChangesAsync();
        }

        public async Task UpdateFeatsAsync(Feat feat)
        {
            context.Feats.Update(feat);
            await context.SaveChangesAsync();
        }

        public async Task<int> DeleteFeatsAsync(Feat feat)
        {
            var theFeat = await context.Feats.FindAsync(feat.FeatId);
            context.Feats.Remove(feat);
            return await context.SaveChangesAsync();
        }

        #endregion
    }
}
