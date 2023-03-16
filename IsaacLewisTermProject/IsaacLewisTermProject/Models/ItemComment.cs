namespace IsaacLewisTermProject.Models
{
    public class ItemComment
    {
        public int ItemCommentId { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
        public AppUser Commenter { get; set; }

        public int ItemId { get; set; }
    }
}
