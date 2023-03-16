using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace IsaacLewisTermProject.Models
{
    public class Feat : Homebrew
    {
        private List<FeatComment> comments = new();

        public int FeatId { get; set; }
        public string FeatName { get; set;}
        public string FeatEffect { get; set;}
        public DateTime DateAdded { get; set; }

        public ICollection<FeatComment> Comments => comments;
    }
}
