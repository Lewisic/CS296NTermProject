using IsaacLewisTermProject.Models;

namespace IsaacLewisTermProject.Repos
{
    public interface IHomebrewRepository
    {
        IQueryable<Item> Items { get; }
        public Task<Item> GetItemByIdAsync(int id);
        public Task<int> StoreItemAsync(Item item);
        public Task UpdateItemAsync(Item item);
        public Task<int> DeleteItemAsync(Item item);

        IQueryable<Adventure> Adventures { get; }
        public Task<Adventure> GetAdventureByIdAsync(int id);
        public Task<int> StoreAdventureAsync(Adventure adventure);
        public Task UpdateAdventureAsync(Adventure adventure);
        public Task<int> DeleteAdventureAsync(Adventure adventure);

        IQueryable<Spell> Spells { get; }
        public Task<Spell> GetSpellByIdAsync(int id);
        public Task<int> StoreSpellAsync(Spell spell);
        public Task UpdateSpellAsync(Spell spell);
        public Task<int> DeleteSpellAsync(Spell spell);

        IQueryable<Feat> Feats { get; }
        public Task<Feat> GetFeatsByIdAsync(int id);
        public Task<int> StoreFeatsAsync(Feat feat);
        public Task UpdateFeatsAsync(Feat feat);
        public Task<int> DeleteFeatsAsync(Feat feat);
    }
}
