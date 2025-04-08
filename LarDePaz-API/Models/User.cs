using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LarDePaz_API.Models
{
    public class User : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;


        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; } = null!;
    }
}
