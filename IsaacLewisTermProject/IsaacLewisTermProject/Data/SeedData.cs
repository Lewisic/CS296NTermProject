﻿using IsaacLewisTermProject.Models;
using Microsoft.AspNetCore.Identity;

namespace IsaacLewisTermProject.Data
{
    public class SeedData
    {
        public static void Seed(ApplicationDbContext context, IServiceProvider provider)
        {
            var userManager = provider.GetRequiredService<UserManager<AppUser>>();
            const string PASSWORD = "Secret!1";


            if (!context.Items.Any())
            {
                AppUser isaac = new AppUser { UserName = "IsaacLewis" };
                isaac.Name = isaac.UserName;
                var result = userManager.CreateAsync(isaac, PASSWORD);
                AppUser jack = new AppUser { UserName = "Jack" };
                jack.Name = jack.UserName;
                result = userManager.CreateAsync(jack, PASSWORD);
                context.SaveChanges();

                Item item = new Item
                {
                    ItemName = "Ring of Invisibility",
                    ItemRarity = "Rare",
                    ItemType = "Wondrous Item",
                    Attunement = true,
                    ItemEffect = "Grants invisibility once per day. totally a unique new item for this game.",
                    User = isaac,
                    DateAdded = DateTime.Now

                };
                context.Items.Add(item);

                item = new Item
                {
                    ItemName = "Ring of Fire Resistance",
                    ItemRarity = "Rare",
                    ItemType = "Wondrous Item",
                    Attunement = false,
                    ItemEffect = "Grants Fire Resistance to the wearer.",
                    User = jack,
                    DateAdded = DateTime.Now

                };
                context.Items.Add(item);

                context.SaveChanges();

            }

            if (!context.Adventures.Any())
            {
                AppUser john = new AppUser { UserName = "John" };
                john.Name = john.UserName;
                var result = userManager.CreateAsync(john, PASSWORD);
                context.SaveChanges();

                Adventure adventure = new Adventure
                {
                    AdventureName = "Journey to Dun Morough",
                    AdventureDifficulty = "Easy",
                    RecommendedLevels = "1-3",
                    AdventureDescription = "You are a group of young dwarven adventurers going on a journey.",
                    DateAdded = DateTime.Now,
                    User = john
                };
                context.Adventures.Add(adventure);
                context.SaveChanges();
            }

            if (!context.Spells.Any())
            {
                AppUser jake = new AppUser { UserName = "Jake" };
                jake.Name = jake.UserName;
                var result = userManager.CreateAsync(jake, PASSWORD);
                context.SaveChanges();

                Spell spell = new Spell
                {
                    SpellName = "Dragon Breath",
                    SpellSchool = "Evocation",
                    SpellLevel = "2",
                    CastingTime = "1 action",
                    Range = "20 ft cone",
                    Components = "V, S",
                    Duration = "Instant",
                    Effects = "Deal 4d6 fire damage in a 20 ft cone.",
                    EffectsAtHigherLevel = "Add 2d6 fire damage for every level past second.",
                    SpellLists = "Wizard, Sorcerer",
                    User = jake,
                    DateAdded = DateTime.Now,
                };
                context.Spells.Add(spell);
                context.SaveChanges();
            }

            if (!context.Feats.Any())
            {
                AppUser peyton = new AppUser { UserName = "Peyton" };
                peyton.Name = peyton.UserName;
                var result = userManager.CreateAsync(peyton, PASSWORD);
                context.SaveChanges();

                Feat feat = new Feat
                {
                    FeatName = "Fire Master.",
                    FeatEffect = "Add 2d6 damage to any fire spell you cast.",
                    User = peyton,
                    DateAdded = DateTime.Now,
                };
                context.Feats.Add(feat);
                context.SaveChanges();
            }
        }
    }
}
