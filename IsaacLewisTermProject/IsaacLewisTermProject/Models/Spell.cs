using System.ComponentModel.DataAnnotations;

namespace IsaacLewisTermProject.Models
{
    public class Spell : Homebrew
    {
        private List<SpellComment> comments = new();
        public int SpellId { get; set; }
        [Required]
        [StringLength(255)]
        public string SpellName { get; set; }
        [Required]
        public string SpellSchool { get; set; }
        [Required]
        public string SpellLevel { get; set; }
        [Required]
        public string CastingTime { get; set; }
        [Required]
        public string Range { get; set; }
        [Required]
        public string Components { get; set; }
        [Required]
        public string Duration { get; set; }
        [Required]
        public string Effects { get; set; }
        [Required]
        public string EffectsAtHigherLevel { get; set; }
        [Required]
        public string SpellLists { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/d/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }

        public ICollection<SpellComment> Comments => comments;
    }
}
