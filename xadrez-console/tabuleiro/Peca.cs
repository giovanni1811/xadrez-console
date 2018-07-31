using System;

namespace tabuleiro
{
    class Peca
    {
        public Posicao pos { get; set; }
        public Cor cor { get; protected set; }
        public int qtdMovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; }


        public Peca(Posicao pos, Cor cor)
        {
            this.pos = pos;
            this.cor = cor;
            this.qtdMovimentos = 0;
        }
    }
}
