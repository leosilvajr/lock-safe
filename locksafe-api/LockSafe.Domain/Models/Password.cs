using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LockSafe.Domain.Models
{
    public class Password
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Garante auto-incremento
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [MaxLength(1000)] // Limita a descrição (opcional)
        public string Description { get; set; }

        [Url] // Valida que é um URL (opcional)
        public string Reference { get; set; }

        [Required]
        [MaxLength(255)]
        public string Account { get; set; }

        [Required]
        [DataType(DataType.Password)] // Indica que é uma senha
        public string PasswordValue { get; set; }

        [Required]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        public DateTime? ExpirationDate { get; set; } = DateTime.Now.AddYears(1);
    }
}
