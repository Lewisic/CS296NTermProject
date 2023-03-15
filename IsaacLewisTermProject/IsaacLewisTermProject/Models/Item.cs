namespace IsaacLewisTermProject.Models
{
    public class Item : Homebrew
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemRarity { get; set; }
        public string ItemType { get; set; }
        public string ItemEffect { get; set; }
        public bool Attunement { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
