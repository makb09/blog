using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bll.Entity.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public int ArticleId { get; set; }

        public int UserId { get; set; }

        public CommentStatus CommentStatus { get; set; }

        [Required, MaxLength(500)]
        public string Content { get; set; }

        public DateTime InsertDate { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        public virtual Article Article { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

    }

    public enum CommentStatus
    {
        WaitingforApproval,
        Approved,
        Rejected
    }
}
