using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LockSafe.Domain.Models
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Garante auto-incremento
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(50)]
        [EmailAddress] // Valida formato de e-mail
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)] // Indica que é uma senha
        public string Password { get; set; }

        public string ProfileImageUrl { get; set; } = string.Empty;
    }
}
