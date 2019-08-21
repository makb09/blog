using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bll.Entity.Models
{
    public class UserRole
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Role { get; set; }

        [Required, MaxLength(50)]
        public string Code { get; set; }

        public ICollection<User> User { get; set; }
    }
}
