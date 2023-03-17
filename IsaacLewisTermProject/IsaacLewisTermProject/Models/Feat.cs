using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace IsaacLewisTermProject.Models
{
    public class Feat : Homebrew
    {
        private List<FeatComment> comments = new();

        public int FeatId { get; set; }
        [Required]
        [StringLength(255)]
        public string FeatName { get; set;}
        [Required]
        public string FeatEffect { get; set;}
        [DisplayFormat(DataFormatString = "{0:MM/d/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }

        public ICollection<FeatComment> Comments => comments;
    }
}
