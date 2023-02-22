using PaginacaoDesktop.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace PaginacaoDesktop.Context
{
    public class ProdutoDbContext : DbContext
    {

        public ProdutoDbContext(): base("ProdutoDBConnectionString")
        {
            Database.SetInitializer(new ProdutoDBInitializer());
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Produto>()
                        .Property(p => p.Preco)
                        .HasPrecision(10, 2);
        }


        public DbSet<Produto> Produtos { get; set; }

    }
}
