using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8, 8);

            try
            {
                tab.colocaPeca(new Torre(Cor.Amarela, tab), new Posicao(0, 0));
                tab.colocaPeca(new Torre(Cor.Branca, tab), new Posicao(1, 7));
                tab.colocaPeca(new Rei(Cor.Branca, tab), new Posicao(2, 4));
                Tela.ImprimiTabuleiro(tab);
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
            

           

            Console.ReadLine();
        }
    }
}
