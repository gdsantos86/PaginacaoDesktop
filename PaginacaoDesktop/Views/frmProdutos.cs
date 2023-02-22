using PaginacaoDesktop.Context;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PaginacaoDesktop.Views
{
    public partial class frmProdutos : Form
    {

        int Deslocamento;

        int tamanhoPagina = 5;

        int TotalRegistros;

        int paginaAtual = 1;

        int TotalPaginas;

        public frmProdutos() 
        {
            InitializeComponent();
         
        }



        private void frmProdutos_Load(object sender, EventArgs e)
        {
            using (var ctx = new ProdutoDbContext())
            {
               TotalRegistros = ctx.Produtos.Count();
               var produtos = ctx.Produtos.OrderByDescending(p => p.ProdutoId)
                    .Skip((paginaAtual - 1) * tamanhoPagina)
                    .Take(tamanhoPagina)
                    .ToList();

                dgvProdutos.DataSource = produtos;
            }

            TotalPaginas =  (TotalRegistros % tamanhoPagina) > 0 ? (TotalRegistros / tamanhoPagina) + 1 : TotalRegistros / tamanhoPagina;

            label2.Text = $"Página {paginaAtual} de {TotalPaginas}";
            txtItensPorPagina.Text = tamanhoPagina.ToString();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (txtItensPorPagina.Text == string.Empty || Convert.ToInt32(txtItensPorPagina.Text) == 0)
            {
                MessageBox.Show("O campo Itens por página deve conter um valor diferente de 0.");
                return;
            }

            var tamanhoPaginaAtual = Convert.ToInt32(txtItensPorPagina.Text);

            TotalPaginas = (TotalRegistros % tamanhoPaginaAtual) > 0
                            ? (TotalRegistros / tamanhoPaginaAtual) + 1
                            : TotalRegistros / tamanhoPaginaAtual;


            paginaAtual--;
            Deslocamento = (paginaAtual - 1) * tamanhoPaginaAtual;
            if (Deslocamento <= 0)
            {
                Deslocamento = 0;
                paginaAtual = 1;
            }
     
            using (var ctx = new ProdutoDbContext())
            {
                var produtos = ctx.Produtos.OrderByDescending(p => p.ProdutoId)
                    .Skip(Deslocamento)
                    .Take(tamanhoPaginaAtual)
                    .ToList();

                dgvProdutos.DataSource = produtos;
            }

            label2.Text = $"Página {paginaAtual} de {TotalPaginas}";
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            if (txtItensPorPagina.Text == string.Empty || Convert.ToInt32(txtItensPorPagina.Text) == 0 )
            {
                MessageBox.Show("O campo Itens por página deve conter um valor diferente de 0.");
                return;
            }

            var tamanhoPaginaAtual = Convert.ToInt32(txtItensPorPagina.Text);

            TotalPaginas = (TotalRegistros % tamanhoPaginaAtual) > 0 
                            ? (TotalRegistros / tamanhoPaginaAtual) + 1 
                            : TotalRegistros / tamanhoPaginaAtual;
            
            paginaAtual++;
            Deslocamento = (paginaAtual - 1) * tamanhoPaginaAtual;
            if (Deslocamento >= TotalRegistros)
            {
                Deslocamento -= tamanhoPaginaAtual;
                paginaAtual = TotalPaginas;
            }

            using (var ctx = new ProdutoDbContext())
            {
                var produtos = ctx.Produtos.OrderByDescending(p => p.ProdutoId)
                    .Skip(Deslocamento)
                    .Take(tamanhoPaginaAtual)
                    .ToList();
                dgvProdutos.DataSource = produtos;
            }

            label2.Text = $"Página {paginaAtual} de {TotalPaginas}";

        }

        private void txtItensPorPagina_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
