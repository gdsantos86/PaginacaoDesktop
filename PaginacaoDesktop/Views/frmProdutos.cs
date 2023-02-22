using PaginacaoDesktop.Context;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PaginacaoDesktop.Views
{
    public partial class frmProdutos : Form
    {
        private int _deslocamento;
        private int _tamanhoPagina = 5;
        private int _maxTamanhoPagina = 10;
        private int _totalRegistros;
        private int _paginaAtual = 1;
        private int _totalPaginas;



        public frmProdutos() 
        {
            InitializeComponent();
         
        }



        private void frmProdutos_Load(object sender, EventArgs e)
        {
            using (var ctx = new ProdutoDbContext())
            {
               _totalRegistros = ctx.Produtos.Count();
               var produtos = ctx.Produtos.OrderByDescending(p => p.ProdutoId)
                    .Skip((_paginaAtual - 1) * _tamanhoPagina)
                    .Take(_tamanhoPagina)
                    .ToList();

                dgvProdutos.DataSource = produtos;
            }

            _totalPaginas =  (_totalRegistros % _tamanhoPagina) > 0 
                             ? (_totalRegistros / _tamanhoPagina) + 1  
                             : _totalRegistros / _tamanhoPagina;

            label2.Text = $"Página {_paginaAtual} de {_totalPaginas}";
            txtItensPorPagina.Text = _tamanhoPagina.ToString();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (txtItensPorPagina.Text == string.Empty || Convert.ToInt32(txtItensPorPagina.Text) == 0)
            {
                MessageBox.Show("O campo Itens por página deve conter um valor diferente de 0.");
                return;
            }

            int itens = Convert.ToInt32(txtItensPorPagina.Text);
            ConfiguraPaginacao(itens, _maxTamanhoPagina, _totalRegistros, false);

            ListaProdutosPaginados(_deslocamento, _tamanhoPagina);

            label2.Text = $"Página {_paginaAtual} de {_totalPaginas}";
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            if (txtItensPorPagina.Text == string.Empty || Convert.ToInt32(txtItensPorPagina.Text) == 0 )
            {
                MessageBox.Show("O campo Itens por página deve conter um valor diferente de 0.");
                return;
            }

            int itens = Convert.ToInt32(txtItensPorPagina.Text);
            ConfiguraPaginacao(itens, _maxTamanhoPagina, _totalRegistros, true);

            ListaProdutosPaginados(_deslocamento, _tamanhoPagina);

            label2.Text = $"Página {_paginaAtual} de {_totalPaginas}";
        }


        private void txtItensPorPagina_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }


        public void ListaProdutosPaginados(int deslocamento, int tamanhoPagina)
        {
            using (var ctx = new ProdutoDbContext())
            {
                var produtos = ctx.Produtos.OrderByDescending(p => p.ProdutoId)
                    .Skip(deslocamento)
                    .Take(tamanhoPagina)
                    .ToList();
                dgvProdutos.DataSource = produtos;
            }
        }


        public void ConfiguraPaginacao(int itensPorPagina, int maxTamanhoPagina, int totalRegistros, bool proximo)
        {
            _tamanhoPagina = _tamanhoPagina > maxTamanhoPagina
                     ? maxTamanhoPagina
                     : itensPorPagina;

            _totalPaginas = (totalRegistros % _tamanhoPagina) > 0
                            ? (totalRegistros / _tamanhoPagina) + 1
                            : totalRegistros / _tamanhoPagina;

            if (proximo)
            {
                _paginaAtual++;
                _deslocamento = (_paginaAtual - 1) * _tamanhoPagina;
                if (_deslocamento >= _totalRegistros)
                {
                    _deslocamento -= _tamanhoPagina;
                    _paginaAtual = _totalPaginas;
                }
            }
            else
            {
                _paginaAtual--;
                _deslocamento = (_paginaAtual - 1) * _tamanhoPagina;
                if (_deslocamento <= 0)
                {
                    _deslocamento = 0;
                    _paginaAtual = 1;
                }
            }
        }



    }
}
