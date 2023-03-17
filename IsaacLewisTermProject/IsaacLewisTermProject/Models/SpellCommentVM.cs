using System.ComponentModel.DataAnnotations;

namespace IsaacLewisTermProject.Models
{
    public class SpellCommentVM
    {
        public int SpellId { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string CommentText { get; set; }
    }
}
