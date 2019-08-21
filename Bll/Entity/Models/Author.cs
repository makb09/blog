using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bll.Entity.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100), Required]
        public string NameSurname { get; set; }

        public string Resume { get; set; }

        [DefaultValue(true)]
        public bool IsActive { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        public ICollection<Article> Article { get; set; }
    }
}
