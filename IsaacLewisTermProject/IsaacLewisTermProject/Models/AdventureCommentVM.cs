using System.ComponentModel.DataAnnotations;

namespace IsaacLewisTermProject.Models
{
    public class AdventureCommentVM
    {
        public int AdventureId { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string CommentText { get; set; }
    }
}
