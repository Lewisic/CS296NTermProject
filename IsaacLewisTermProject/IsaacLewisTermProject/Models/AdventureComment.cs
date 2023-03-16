namespace IsaacLewisTermProject.Models
{
    public class AdventureComment
    {
        public int AdventureCommentId { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
        public AppUser Commenter { get; set; }

        public int AdventureId { get; set; }
    }
}
