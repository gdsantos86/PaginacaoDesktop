using static PaginacaoDesktop.Pagination.ParametrosPaginacao;

namespace PaginacaoDesktop.Pagination
{
    public class ParametrosPaginacao
    {
        const int maxItensPagina = 10;
        public int NumeroPagina { get; private set; } = 1;
        public int TotalPaginas { get; private set; }
        public int Deslocamento { get; private set; }

        private int _itensPagina = 5;
        public int ItensPagina
        {
            get
            {
                return _itensPagina;
            }
            set
            {
                _itensPagina = (value > maxItensPagina) ? maxItensPagina : value;
            }
        }




        public ParametrosPaginacao(int totalRegistros)
        {
            AtualizaTotalPaginas(totalRegistros);
        }


        private void AtualizaTotalPaginas(int totalRegistros)
        {
            TotalPaginas = (totalRegistros % _itensPagina) > 0 ? (totalRegistros / _itensPagina) + 1 : totalRegistros / _itensPagina;
        }


        private void AtualizaDeslocamento(bool proximo, int numeroPagina,int totalRegistros)
        {
            NumeroPagina = numeroPagina;
            Deslocamento = (NumeroPagina - 1) * _itensPagina;

            if (proximo)
            {
                //NumeroPagina++;
                //Deslocamento = (NumeroPagina - 1) * _itensPagina;
                if (Deslocamento >= totalRegistros)
                {
                    Deslocamento -= _itensPagina;
                    //NumeroPagina = TotalPaginas;
                }
            }
            else
            {
                //NumeroPagina--;
                //Deslocamento = (NumeroPagina - 1) * _itensPagina;
                if (Deslocamento <= 0)
                {
                    Deslocamento = 0;
                    //NumeroPagina = 1;
                }
            }
        }


        public void ConfiguraPaginacao(int itensPorPagina,int totalRegistros, TipoDeslocamento tipoDeslocamento) 
        {
            ItensPagina= itensPorPagina;
            this.AtualizaTotalPaginas(totalRegistros);
            //this.AtualizaDeslocamento(proximo, numeroPagina, totalRegistros);
            this.AtualizaDeslocamento1(tipoDeslocamento, totalRegistros);
        }


        private void AtualizaDeslocamento1(TipoDeslocamento tipoDeslocamento, int totalRegistros)
        {
            if (tipoDeslocamento ==  TipoDeslocamento.PROXIMO)
            {
                NumeroPagina++;
                Deslocamento = (NumeroPagina - 1) * _itensPagina;
                if (Deslocamento >= totalRegistros)
                {
                    Deslocamento -= _itensPagina;
                    NumeroPagina = TotalPaginas;
                }
            }
            else if (tipoDeslocamento == TipoDeslocamento.ANTERIOR)
            {
                NumeroPagina--;
                Deslocamento = (NumeroPagina - 1) * _itensPagina;
                if (Deslocamento <= 0)
                {
                    Deslocamento = 0;
                    NumeroPagina = 1;
                }
            }
            else if (tipoDeslocamento == TipoDeslocamento.PRIMEIRO)
            {
                Deslocamento = 0;
                NumeroPagina = 1;
            }
            else if (tipoDeslocamento == TipoDeslocamento.ULTIMO)
            {
                NumeroPagina = TotalPaginas;
                Deslocamento = (NumeroPagina - 1) * _itensPagina;
            }
        }


        public enum TipoDeslocamento
        {
            ANTERIOR = 1,
            PROXIMO = 2,
            PRIMEIRO = 3,
            ULTIMO = 4
        }



    }
}

