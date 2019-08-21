using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bll.Entity.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public int UserRoleId { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; }

        [Required, MaxLength(150)]
        public string Surname { get; set; }

        [Required, MaxLength(150)]
        public string EmailAddress { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }

        [StringLength(200)]
        public string HashCode { get; set; }

        [DefaultValue(true)]
        public bool IsActive { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        public virtual UserRole UserRole { get; set; }
    }
}
