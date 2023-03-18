using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IsaacLewisTermProject.Models;
using IsaacLewisTermProject.Repos;
using TestDoubles;

namespace IsaacLewisTermProjectTests
{
    public class FakeHomebrewRepository : IHomebrewRepository
    {
        

        private List<Item> items = new List<Item>();
        private List<Adventure> adventures = new List<Adventure>();
        private List<Spell> spells = new List<Spell>();
        private List<Feat> feats= new List<Feat>();
        public IQueryable<Item> Items
        {
            get
            {
                return new InMemoryAsyncQueryable<Item>(items);
            }
        }

        public IQueryable<Adventure> Adventures
        {
            get
            {
                return new InMemoryAsyncQueryable<Adventure>(adventures);
            }
        }

        public IQueryable<Spell> Spells
        {
            get
            {
                return new InMemoryAsyncQueryable<Spell>(spells);
            }
        }

        public IQueryable<Feat> Feats
        {
            get
            {
                return new InMemoryAsyncQueryable<Feat>(feats);
            }
        }

        public Task<int> DeleteAdventureAsync(Adventure adventure)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteFeatsAsync(Feat feat)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteItemAsync(Item item)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteSpellAsync(Spell spell)
        {
            throw new NotImplementedException();
        }

        public Adventure GetAdventureByIdAsync(int id)
        {
            Adventure adventure = adventures.Find(a => a.AdventureId == id);

            return adventure;
        }

        public Feat GetFeatsByIdAsync(int id)
        {
            Feat feat = feats.Find(f => f.FeatId == id);

            return feat;
        }

        public Item GetItemByIdAsync(int id)
        {
            Item item = items.Find(i => i.ItemId == id);

            return item;
        }

        public Spell GetSpellByIdAsync(int id)
        {
            Spell spell = spells.Find(s => s.SpellId == id);

            return spell;
        }

        public async Task<int> StoreAdventureAsync(Adventure model)
        {
            int status = 0;
            if (model != null)
            {
                model.AdventureId = feats.Count + 1;
                adventures.Add(model);
                status = 1;
            }
            return status;
        }

        public async Task<int> StoreFeatsAsync(Feat model)
        {
            int status = 0;
            if (model != null)
            {
                model.FeatId = feats.Count + 1;
                feats.Add(model);
                status = 1;
            }
            return status;
        }

        public async Task<int> StoreItemAsync(Item model)
        {
            int status = 0;
            if (model != null)
            {
                model.ItemId = feats.Count + 1;
                items.Add(model);
                status = 1;
            }
            return status;
        }

        public async Task<int> StoreSpellAsync(Spell model)
        {
            int status = 0;
            if (model != null)
            {
                model.SpellId = feats.Count + 1;
                spells.Add(model);
                status = 1;
            }
            return status;
        }

        public Task UpdateAdventureAsync(Adventure adventure)
        {
            throw new NotImplementedException();
        }

        public Task UpdateFeatsAsync(Feat feat)
        {
            throw new NotImplementedException();
        }

        public Task UpdateItemAsync(Item item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSpellAsync(Spell spell)
        {
            throw new NotImplementedException();
        }

        Task<Adventure> IHomebrewRepository.GetAdventureByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<Feat> IHomebrewRepository.GetFeatsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<Item> IHomebrewRepository.GetItemByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<Spell> IHomebrewRepository.GetSpellByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
