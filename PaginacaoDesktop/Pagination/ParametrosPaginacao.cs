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


        private void AtualizaDeslocamento(bool proximo, int totalRegistros)
        {
            if (proximo)
            {
                NumeroPagina++;
                Deslocamento = (NumeroPagina - 1) * _itensPagina;
                if (Deslocamento >= totalRegistros)
                {
                    Deslocamento -= _itensPagina;
                    NumeroPagina = TotalPaginas;
                }
            }
            else
            {
                NumeroPagina--;
                Deslocamento = (NumeroPagina - 1) * _itensPagina;
                if (Deslocamento <= 0)
                {
                    Deslocamento = 0;
                    NumeroPagina = 1;
                }
            }
        }


        public void ConfiguraPaginacao(int itensPorPagina, int totalRegistros, bool proximo) 
        {
            ItensPagina= itensPorPagina;
            this.AtualizaTotalPaginas(totalRegistros);
            this.AtualizaDeslocamento(proximo, totalRegistros);
        }




    }
}
