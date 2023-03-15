using MessagePack;
using System.ComponentModel.DataAnnotations;

namespace IsaacLewisTermProject.Models
{
    public class Feat : Homebrew
    {
        
        public int FeatId { get; set; }
        public string FeatName { get; set;}
        public string FeatEffect { get; set;}
        public DateTime DateAdded { get; set; }
    }
}
