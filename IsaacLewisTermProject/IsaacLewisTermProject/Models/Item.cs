using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace IsaacLewisTermProject.Models
{
    public class Item : Homebrew
    {
        private List<ItemComment> comments = new();

        public int ItemId { get; set; }
        [Required(ErrorMessage = "Please enter a item name")]
        [StringLength(255)]
        public string ItemName { get; set; }
        [Required(ErrorMessage = "Please enter the item rarity")]
        public string ItemRarity { get; set; }
        [Required(ErrorMessage = "Please enter the item type")]
        public string ItemType { get; set; }
        [Required(ErrorMessage = "Please enter the item effect")]
        public string ItemEffect { get; set; }
        public bool Attunement { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/d/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }

        public ICollection<ItemComment> Comments => comments;
    }
}
