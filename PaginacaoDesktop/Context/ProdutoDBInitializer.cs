using PaginacaoDesktop.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;


namespace PaginacaoDesktop.Context
{
    public class ProdutoDBInitializer : DropCreateDatabaseAlways<ProdutoDbContext>
    {
        protected override void Seed(ProdutoDbContext context)
        {
            IList<Produto> produtos = new List<Produto>
            {
                new Produto() { Nome = "Produto 1", Preco = 8.55m, DataCadastro = DateTime.Now },
                new Produto() { Nome = "Produto 2", Preco = 10.98m, DataCadastro = DateTime.Now },
                new Produto() { Nome = "Produto 3", Preco = 100.50m, DataCadastro = DateTime.Now },
                new Produto() { Nome = "Produto 4", Preco = 25.98m, DataCadastro = DateTime.Now },
                new Produto() { Nome = "Produto 5", Preco = 3.99m, DataCadastro = DateTime.Now },
                new Produto() { Nome = "Produto 6", Preco = 225.00m, DataCadastro = DateTime.Now },
                new Produto() { Nome = "Produto 7", Preco = 10.98m, DataCadastro = DateTime.Now },
                new Produto() { Nome = "Produto 8", Preco = 42.90m, DataCadastro = DateTime.Now },
                new Produto() { Nome = "Produto 9", Preco = 10.98m, DataCadastro = DateTime.Now },
                new Produto() { Nome = "Produto 10", Preco = 342.90m, DataCadastro = DateTime.Now },
                new Produto() { Nome = "Produto 11", Preco = 342.90m, DataCadastro = DateTime.Now },
                new Produto() { Nome = "Produto 12", Preco = 342.90m, DataCadastro = DateTime.Now },
                new Produto() { Nome = "Produto 13", Preco = 342.90m, DataCadastro = DateTime.Now },
                new Produto() { Nome = "Produto 14", Preco = 342.90m, DataCadastro = DateTime.Now },
                new Produto() { Nome = "Produto 15", Preco = 342.90m, DataCadastro = DateTime.Now },
                new Produto() { Nome = "Produto 16", Preco = 342.90m, DataCadastro = DateTime.Now }
            };

            context.Produtos.AddRange(produtos);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
