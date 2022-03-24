using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;


namespace DevIO.Data.Context
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options)
        {
                
        }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);

            //desabilitar cascade delete(impede que uma classe que esta sendo representada por uma tabela no banco, ao excluir, leve os filhos junto.

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            base.OnModelCreating(modelBuilder);
            

            //Caso esqueça não entre como nvarcharmax

            //        foreach (var property in modelBuilder.Model.GetEntityTypes()
            //            .SelectMany(e => e.GetProperties()
            //                .Where(p => p.ClrType == typeof(string))))
            //            property.Relational().ColumnType = "varchar(100)";

        }


    }
}
