using System.ComponentModel.DataAnnotations;

namespace IsaacLewisTermProject.Models
{
    public class AdventureComment
    {
        public int AdventureCommentId { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string CommentText { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/d/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime CommentDate { get; set; }
        public AppUser Commenter { get; set; }

        public int AdventureId { get; set; }
    }
}
