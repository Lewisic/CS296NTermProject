namespace IsaacLewisTermProject.Models
{
    public class FeatComment
    {
        public int FeatCommentId { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
        public AppUser Commenter { get; set; }

        public int FeatId { get; set; }
    }
}
