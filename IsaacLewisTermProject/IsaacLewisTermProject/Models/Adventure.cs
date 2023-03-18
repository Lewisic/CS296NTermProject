using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace IsaacLewisTermProject.Models
{
    public class Adventure : Homebrew
    {
        private List<AdventureComment> comments = new();

        public int AdventureId { get; set; }
        [Required(ErrorMessage = "Please enter a adventure name")]
        [StringLength(255)]
        public string AdventureName { get; set; }
        [Required(ErrorMessage = "Please enter the adventure difficulty")]
        public string AdventureDifficulty { get; set; }
        [Required(ErrorMessage = "Please enter the recommended levels")]
        public string RecommendedLevels { get; set; }
        [Required(ErrorMessage = "Please enter the adventure description")]
        public string AdventureDescription { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/d/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }

        public ICollection<AdventureComment> Comments => comments;
    }
}
