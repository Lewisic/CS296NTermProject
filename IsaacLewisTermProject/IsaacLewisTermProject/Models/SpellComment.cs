namespace IsaacLewisTermProject.Models
{
    public class SpellComment
    {
        public int SpellCommentId { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
        public AppUser Commenter { get; set; }

        public int SpellId { get; set; }
    }
}
