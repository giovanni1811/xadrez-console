using System;
using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada;

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            colocaPeca();
            terminada = false;
        }

        public void executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retiraPeca(origem);
            p.incrementaQtdMovimentos();
            Peca pecaCapturada = tab.retiraPeca(destino);
            tab.colocaPeca(p, destino);
        }

        public void validarPosicaoOrigem(Posicao origem)
        {
            if (tab.peca(origem) == null)
            {
                throw new TabuleiroException("Não existe nenhuma peça nesta posição!");
            }
            if (tab.peca(origem).cor != jogadorAtual)
            {
                throw new TabuleiroException("Essa peça não é sua!");
            }
            if (!tab.peca(origem).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não existem movimentos possíveis para esta peça!");
            }
        }

        public void validarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).podeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            executaMovimento(origem, destino);
            turno++;
            if (jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
        }

        public void colocaPeca()
        {
            tab.colocaPeca(new Torre(Cor.Branca, tab), new PosicaoXadrez('c', 2).toPosicao());
            tab.colocaPeca(new Torre(Cor.Branca, tab), new PosicaoXadrez('d', 2).toPosicao());
            tab.colocaPeca(new Torre(Cor.Branca, tab), new PosicaoXadrez('e', 2).toPosicao());
            tab.colocaPeca(new Torre(Cor.Branca, tab), new PosicaoXadrez('c', 1).toPosicao());
            tab.colocaPeca(new Torre(Cor.Branca, tab), new PosicaoXadrez('e', 1).toPosicao());
            tab.colocaPeca(new Rei(Cor.Branca, tab), new PosicaoXadrez('d', 1).toPosicao());

            tab.colocaPeca(new Torre(Cor.Preta, tab), new PosicaoXadrez('c', 7).toPosicao());
            tab.colocaPeca(new Torre(Cor.Preta, tab), new PosicaoXadrez('d', 7).toPosicao());
            tab.colocaPeca(new Torre(Cor.Preta, tab), new PosicaoXadrez('e', 7).toPosicao());
            tab.colocaPeca(new Torre(Cor.Preta, tab), new PosicaoXadrez('c', 8).toPosicao());
            tab.colocaPeca(new Torre(Cor.Preta, tab), new PosicaoXadrez('e', 8).toPosicao());
            tab.colocaPeca(new Rei(Cor.Preta, tab), new PosicaoXadrez('d', 8).toPosicao());
        }

    }
}
