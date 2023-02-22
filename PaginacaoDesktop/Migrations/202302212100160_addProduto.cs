namespace PaginacaoDesktop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProduto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 80),
                        Preco = c.Decimal(nullable: false, precision: 10, scale: 2),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProdutoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Produto");
        }
    }
}
