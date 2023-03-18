using System.ComponentModel.DataAnnotations;

namespace IsaacLewisTermProject.Models
{
    public class Spell : Homebrew
    {
        private List<SpellComment> comments = new();
        public int SpellId { get; set; }
        [Required(ErrorMessage = "Please enter a spell name")]
        [StringLength(255)]
        public string SpellName { get; set; }
        [Required(ErrorMessage = "Please enter a spell school")]
        public string SpellSchool { get; set; }
        [Required(ErrorMessage = "Please enter a spell level")]
        public string SpellLevel { get; set; }
        [Required(ErrorMessage = "Please enter a casting time")]
        public string CastingTime { get; set; }
        [Required(ErrorMessage = "Please enter a range")]
        public string Range { get; set; }
        [Required(ErrorMessage = "Please enter spell components")]
        public string Components { get; set; }
        [Required(ErrorMessage = "Please enter a spell duration")]
        public string Duration { get; set; }
        [Required(ErrorMessage = "Please enter the spell effects")]
        public string Effects { get; set; }
        [Required(ErrorMessage = "Please enter the spell effects at higher levels")]
        public string EffectsAtHigherLevel { get; set; }
        [Required(ErrorMessage = "Please enter the spell lists")]
        public string SpellLists { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/d/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }

        public ICollection<SpellComment> Comments => comments;
    }
}
