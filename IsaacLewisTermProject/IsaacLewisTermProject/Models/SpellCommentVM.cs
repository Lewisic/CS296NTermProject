using System.ComponentModel.DataAnnotations;

namespace IsaacLewisTermProject.Models
{
    public class SpellCommentVM
    {
        public int SpellId { get; set; }
        [Required(ErrorMessage = "Please enter a comment")]
        [StringLength(255, MinimumLength = 3)]
        public string CommentText { get; set; }
    }
}
