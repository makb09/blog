using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bll.Entity.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        public int ArticleCategoryId { get; set; }

        public int AuthorId { get; set; }

        [StringLength(100), Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        [DefaultValue(true)]
        public bool IsActive { get; set; }

        public DateTime? UpdateDate { get; set; }

        public DateTime InsertDate { get; set; }

        [ForeignKey("ArticleCategoryId")]
        public ArticleCategory ArticleCategory { get; set; }

        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; }

        public ICollection<Comment> Comment { get; set; }
    }
}
