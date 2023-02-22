using System;
using System.ComponentModel.DataAnnotations;

namespace PaginacaoDesktop.Entities
{
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required]
        [StringLength(80)]
        public string Nome { get; set; }

        [Required]
        public decimal Preco { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}
