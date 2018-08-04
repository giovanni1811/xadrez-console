using tabuleiro;

namespace xadrez
{
    class Torre : Peca
    {
        public Torre(Cor cor, Tabuleiro tab) : base(cor, tab)
        {
        }

        public override string ToString()
        {
            return "T";
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

            // acima
            p.DefinirValores(pos.linha - 1, pos.coluna);
            while (tab.validaPos(p) && podeMover(p))
            {
                mat[p.linha, p.coluna] = true;
                if (tab.peca(p) != null && tab.peca(p).cor != cor)
                {
                    break;
                }
                p.linha = p.linha - 1;
            }

            // direita
            p.DefinirValores(pos.linha, pos.coluna + 1);
            while (tab.validaPos(p) && podeMover(p))
            {
                mat[p.linha, p.coluna] = true;
                if (tab.peca(p) != null && tab.peca(p).cor != cor)
                {
                    break;
                }
                p.coluna = p.coluna + 1;
            }

            // esquerda 
            p.DefinirValores(pos.linha, pos.coluna - 1);
            while (tab.validaPos(p) && podeMover(p))
            {
                mat[p.linha, p.coluna] = true;
                if (tab.peca(p) != null && tab.peca(p).cor != cor)
                {
                    break;
                }
                p.coluna = p.coluna - 1;
            }


            // baixo
            p.DefinirValores(pos.linha + 1, pos.coluna);
            while (tab.validaPos(p) && podeMover(p))
            {
                mat[p.linha, p.coluna] = true;
                if (tab.peca(p) != null && tab.peca(p).cor != cor)
                {
                    break;
                }
                p.linha = p.linha + 1;
            }

            return mat;
        }  

    }
}
