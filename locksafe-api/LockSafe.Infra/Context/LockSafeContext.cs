using LockSafe.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LockSafe.Infra.Context
{
    public class LockSafeContext : DbContext
    {
        public LockSafeContext(DbContextOptions<LockSafeContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }
        public DbSet<Password> Passwords { get; set; }
        public DbSet<PasswordAllowance> PasswordAllowances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar chave composta na tabela PasswordAllowance
            modelBuilder.Entity<PasswordAllowance>()
                .HasKey(pa => new { pa.UserId, pa.PasswordId }); // Chave composta

            // Configurar relacionamento entre Users e PasswordAllowance
            modelBuilder.Entity<PasswordAllowance>()
                .HasOne<Users>() // Relacionamento com Users
                .WithMany() // Sem navegação reversa
                .HasForeignKey(pa => pa.UserId) // FK para UserId
                .OnDelete(DeleteBehavior.Restrict); // Restringir exclusão em cascata

            // Configurar relacionamento entre Passwords e PasswordAllowance
            modelBuilder.Entity<PasswordAllowance>()
                .HasOne<Password>() // Relacionamento com Passwords
                .WithMany() // Sem navegação reversa
                .HasForeignKey(pa => pa.PasswordId) // FK para PasswordId
                .OnDelete(DeleteBehavior.Restrict); // Restringir exclusão em cascata

            // Ignorar as propriedades 'AssociatedPassword' e 'AssociatedUser' no modelo (não mapeadas)
            modelBuilder.Entity<PasswordAllowance>()
                .Ignore(pa => pa.AssociatedPassword)
                .Ignore(pa => pa.AssociatedUser);

            // Configuração de limites e validações adicionais para Users
            modelBuilder.Entity<Users>()
                .Property(u => u.FullName)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<Users>()
                .Property(u => u.UserName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Users>()
                .Property(u => u.Email)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Users>()
                .Property(u => u.Password)
                .IsRequired();

            // Configuração de limites para Password
            modelBuilder.Entity<Password>()
                .Property(p => p.Title)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Password>()
                .Property(p => p.Account)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Password>()
                .Property(p => p.CreationDate)
                .HasDefaultValueSql("GETDATE()"); // Valor padrão como data atual

            modelBuilder.Entity<Password>()
                .Property(p => p.ExpirationDate)
                .HasDefaultValueSql("DATEADD(YEAR, 1, GETDATE())"); // Expiração padrão de 1 ano

            // Chamando o método base para finalizar a configuração
            base.OnModelCreating(modelBuilder);
        }
    }
}
