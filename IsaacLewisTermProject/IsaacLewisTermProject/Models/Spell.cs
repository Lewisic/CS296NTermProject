namespace IsaacLewisTermProject.Models
{
    public class Spell : Homebrew
    {
        private List<SpellComment> comments = new();
        public int SpellId { get; set; }
        public string SpellName { get; set; }
        public string SpellSchool { get; set; }
        public string SpellLevel { get; set; }
        public string CastingTime { get; set; }
        public string Range { get; set; }
        public string Components { get; set; }
        public string Duration { get; set; }
        public string Effects { get; set; }
        public string EffectsAtHigherLevel { get; set; }
        public string SpellLists { get; set; }
        public DateTime DateAdded { get; set; }

        public ICollection<SpellComment> Comments => comments;
    }
}
