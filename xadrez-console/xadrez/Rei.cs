using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        
        public Rei(Cor cor, Tabuleiro tab) : base(cor, tab)
        {
        }

        public override string ToString()
        {
            return "R";
        }

        private bool podeMover(Posicao pos)
        {
            Peca peca = tab.peca(pos);
            return peca == null || peca.cor != cor;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao p = new Posicao(0, 0);

            // testando acima
            p.DefinirValores(pos.linha - 1, pos.coluna);
            if (tab.validaPos(p) && podeMover(p))
            {
                mat[p.linha, p.coluna] = true;
            }

            // testando noroeste
            p.DefinirValores(pos.linha - 1, pos.coluna - 1);
            if (tab.validaPos(p) && podeMover(p))
            {
                mat[p.linha, p.coluna] = true;
            }

            // testando nordeste
            p.DefinirValores(pos.linha - 1, pos.coluna + 1);
            if (tab.validaPos(p) && podeMover(p))
            {
                mat[p.linha, p.coluna] = true;
            }

            // testando esquerda
            p.DefinirValores(pos.linha, pos.coluna - 1);
            if (tab.validaPos(p) && podeMover(p))
            {
                mat[p.linha, p.coluna] = true;
            }

            // testando direita
            p.DefinirValores(pos.linha, pos.coluna + 1);
            if (tab.validaPos(p) && podeMover(p))
            {
                mat[p.linha, p.coluna] = true;
            }

            // testando baixo
            p.DefinirValores(pos.linha + 1, pos.coluna);
            if (tab.validaPos(p) && podeMover(p))
            {
                mat[p.linha, p.coluna] = true;
            }

            // testando sudeste
            p.DefinirValores(pos.linha + 1, pos.coluna + 1);
            if (tab.validaPos(p) && podeMover(p))
            {
                mat[p.linha, p.coluna] = true;
            }

            // testando sudoeste
            p.DefinirValores(pos.linha + 1, pos.coluna - 1);
            if (tab.validaPos(p) && podeMover(p))
            {
                mat[p.linha, p.coluna] = true;
            }

            return mat;
        }

    }
}
