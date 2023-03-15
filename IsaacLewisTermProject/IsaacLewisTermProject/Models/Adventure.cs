namespace IsaacLewisTermProject.Models
{
    public class Adventure : Homebrew
    {
        public int AdventureId { get; set; }
        public string AdventureName { get; set; }
        public string AdventureDifficulty { get; set; }
        public string RecommendedLevels { get; set; }
        public string AdventureDescription { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
