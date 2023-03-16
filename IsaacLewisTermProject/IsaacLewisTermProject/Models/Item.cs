using System.Xml.Linq;

namespace IsaacLewisTermProject.Models
{
    public class Item : Homebrew
    {
        private List<ItemComment> comments = new();

        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemRarity { get; set; }
        public string ItemType { get; set; }
        public string ItemEffect { get; set; }
        public bool Attunement { get; set; }
        public DateTime DateAdded { get; set; }

        public ICollection<ItemComment> Comments => comments;
    }
}
