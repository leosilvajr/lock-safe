using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LockSafe.Domain.Models
{
    public class PasswordAllowance
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Password")] // Define a relação com a tabela Password
        public int PasswordId { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Users")] // Define a relação com a tabela Users
        public int UserId { get; set; }

        [Required]
        public bool IsAdmin { get; set; }

        // Relacionamentos de navegação
        [NotMapped]  // Impede que essas propriedades sejam mapeadas para o banco de dados
        public virtual Password AssociatedPassword { get; set; }

        [NotMapped]  // Impede que essas propriedades sejam mapeadas para o banco de dados
        public virtual Users AssociatedUser { get; set; }
    }
}
