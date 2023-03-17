using System.ComponentModel.DataAnnotations;

namespace IsaacLewisTermProject.Models
{
    public class ItemCommentVM
    {
        public int ItemId { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string CommentText { get; set; }
    }
}
