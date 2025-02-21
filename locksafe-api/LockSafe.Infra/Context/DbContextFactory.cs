using LockSafe.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace LockSafe.Infra.Factories
{
    public class LockSafeContextFactory : IDesignTimeDbContextFactory<LockSafeContext>
    {
        public LockSafeContext CreateDbContext(string[] args)
        {
            // Obter o caminho do appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Configurar a string de conexão
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Configurar o DbContextOptions
            var optionsBuilder = new DbContextOptionsBuilder<LockSafeContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new LockSafeContext(optionsBuilder.Options);
        }
    }

    /* Dificuldade para executar os comandos para criar as tabelas no banco de dados com o Entity Framework Core
     * 
     * Comando executado no PowerShell na raiz da Solução para criar as tabelas
     *    dotnet ef migrations add InitialCreate --project C:\Git\LockSafe.API\LockSafe.Infra\LockSafe.Infra.csproj --startup-project C:\Git\LockSafe.API\LockSafe.API\LockSafe.API.csproj --output-dir Migrations

     * Comando executado no POwerShell na raiz da Solução para atualizar as tabelas
     *    dotnet ef database update --project C:\Git\LockSafe.API\LockSafe.Infra\LockSafe.Infra.csproj --startup-project C:\Git\LockSafe.API\LockSafe.API\LockSafe.API.csproj
     * 
     * Precisei instaslar o EntityFrameworkCore.Design no projeto LockSafe.API
     */


    /*
     Para realiZar Update na Tabela no Banco de Dados apos alteração no Model
     dotnet ef migrations add AjusteTabelaPasswordAllowance2 --project C:\Git\LockSafe.API\LockSafe.Infra\LockSafe.Infra.csproj --startup-project C:\Git\LockSafe.API\LockSafe.API\LockSafe.API.csproj

     dotnet ef database update --project C:\Git\LockSafe.API\LockSafe.Infra\LockSafe.Infra.csproj --startup-project C:\Git\LockSafe.API\LockSafe.API\LockSafe.API.csproj

     */
}
