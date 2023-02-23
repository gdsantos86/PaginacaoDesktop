﻿using PaginacaoDesktop.Context;
using PaginacaoDesktop.Pagination;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PaginacaoDesktop.Views
{
    public partial class frmProdutos : Form
    {
        private int _totalRegistros;
        private ParametrosPaginacao _paginacao;



        public frmProdutos() 
        {
            InitializeComponent();
         
        }



        private void frmProdutos_Load(object sender, EventArgs e)
        {
            using (var ctx = new ProdutoDbContext())
            {
                _totalRegistros = ctx.Produtos.Count();
            }

            _paginacao = new ParametrosPaginacao(_totalRegistros);
            ListaProdutosPaginados(_paginacao.Deslocamento, _paginacao.ItensPagina);

            label2.Text = $"Página {_paginacao.NumeroPagina} de {_paginacao.TotalPaginas}";
            txtItensPorPagina.Text = _paginacao.ItensPagina.ToString();
        }


        private void btnAnterior_Click(object sender, EventArgs e)
        {
            RealizaPaginacao(false);
        }


        private void btnProximo_Click(object sender, EventArgs e)
        {
            RealizaPaginacao(true);
        }


        private void txtItensPorPagina_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }


        public void RealizaPaginacao(bool proximo)
        {
            if (txtItensPorPagina.Text == string.Empty || Convert.ToInt32(txtItensPorPagina.Text) == 0)
            {
                MessageBox.Show("O campo Itens por página deve conter um valor diferente de 0.");
                return;
            }

            _paginacao.ConfiguraPaginacao(Convert.ToInt32(txtItensPorPagina.Text), _totalRegistros, proximo);
            ListaProdutosPaginados(_paginacao.Deslocamento, _paginacao.ItensPagina);

            txtItensPorPagina.Text = _paginacao.ItensPagina.ToString(); 
            label2.Text = $"Página {_paginacao.NumeroPagina} de {_paginacao.TotalPaginas}";
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



    }
}
