namespace IsaacLewisTermProject.Models
{
    public class Homebrew
    {
        private List<Comment> comments = new();
        public AppUser? User { get; set; }
        public ICollection<Comment> Comments => comments;
    }
}
