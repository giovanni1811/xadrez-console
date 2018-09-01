using System.Collections.Generic;
using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada;
        private HashSet<Peca> pecas;
        private HashSet<Peca> pecasCapturadas;
        public bool xeque { get; private set; }
        public Cor vencedora;

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            xeque = false;
            pecas = new HashSet<Peca>();
            pecasCapturadas = new HashSet<Peca>();
            terminada = false;
            colocaPeca();
        }

        public Peca executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retiraPeca(origem);
            p.incrementaQtdMovimentos();
            Peca pecaCapturada = tab.retiraPeca(destino);
            tab.colocaPeca(p, destino);
            if (pecaCapturada != null)
            {
                pecasCapturadas.Add(pecaCapturada);
            }

            return pecaCapturada;
        }

        public void desfazMovimento(Posicao origem , Posicao destino, Peca pecaCapturada)
        {
            Peca p = tab.retiraPeca(destino);
            p.decrementarQtdMovimentos();
            if (pecaCapturada != null)
            {
                tab.colocaPeca(pecaCapturada, destino);
                pecasCapturadas.Remove(pecaCapturada);
            }
            tab.colocaPeca(p, origem);

        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            Peca p = executaMovimento(origem, destino);

            if (estaEmXeque(jogadorAtual))
            {
                desfazMovimento(origem, destino, p);
                throw new TabuleiroException("Você não pode se colocar em xeque!");
            }

            if (estaEmXeque(jogadorAtual))
            {
                xeque = true;
            }
            else
            {
                xeque = false;
            }

            if (testeXequeMate(adversaria(jogadorAtual)))
            {
                terminada = true;
                vencedora = jogadorAtual;
            }
            else
            {
                turno++;
                mudaJogador();
            }
            
        }

        public bool testeXequeMate(Cor cor)
        {
            if (!estaEmXeque(cor))
            {
                return false;
            }

            foreach (Peca x in pecasEmJogo(cor))
            {
                bool[,] mat = x.movimentosPossiveis();
                for (int i = 0; i < tab.linhas; i++)
                {
                    for (int g = 0; g < tab.colunas; g++)
                    {
                        Posicao destino = new Posicao(i, g);
                        Posicao origem = x.pos;
                        if (mat[i, g])
                        {
                            Peca pecaCapturada = executaMovimento(origem, destino);
                            bool testeXeque = estaEmXeque(cor);
                            desfazMovimento(origem, destino, pecaCapturada);

                            if (!testeXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
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
            if (!tab.peca(origem).movimentoPossivel(destino))
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        public void mudaJogador()
        {
            if (jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
        }

        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca p in pecasCapturadas)
            {
                if (p.cor == cor)
                {
                    aux.Add(p);
                }
            }
            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca p in pecas)
            {
                if (p.cor == cor)
                {
                    aux.Add(p);
                }
            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }

        private Cor adversaria(Cor cor)
        {
            if (cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            return Cor.Branca;
        }

        private Peca rei(Cor cor)
        {
            foreach(Peca x in pecasEmJogo(cor))
            {
                if (x is Rei)
                {
                    return x;
                }
            }

            return null;
        }

        public bool estaEmXeque(Cor cor)
        {
            Peca r = rei(cor);
            if (r == null)
            {
                throw new TabuleiroException("Não existe rei da cor " + cor + " no tabuleiro!");
            }
            foreach (Peca x in pecasEmJogo(adversaria(cor)))
            {
                bool[,] mat = x.movimentosPossiveis();

                if (mat[r.pos.linha, r.pos.coluna])
                {
                    return true;
                }
            }
            return false;
        }

        public void colocaNovaPeca(char coluna, int linha, Peca peca)
        {
            tab.colocaPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);
        }

        private void colocaPeca()
        {
            colocaNovaPeca('c', 1, new Torre(Cor.Preta, tab));
            colocaNovaPeca('d', 1, new Rei(Cor.Preta, tab));
            colocaNovaPeca('h', 7, new Torre(Cor.Preta, tab));

            colocaNovaPeca('a', 8, new Rei(Cor.Branca, tab));
            colocaNovaPeca('b', 8, new Torre(Cor.Branca, tab));

        }

    }
}
