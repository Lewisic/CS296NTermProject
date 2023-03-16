using IsaacLewisTermProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IsaacLewisTermProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Item>  Items { get; set; }
        public DbSet<Adventure> Adventures { get; set; }
        public DbSet<Spell> Spells { get; set; }
        public DbSet<Feat> Feats { get; set; }
        public DbSet<ItemComment> IComments { get; set; }
        public DbSet<AdventureComment> AComments { get; set; }
        public DbSet<SpellComment> SComments { get; set; }
        public DbSet<FeatComment> FComments { get; set; }

    }
}
