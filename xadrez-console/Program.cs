using System;
using tabuleiro;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Posicao p;
            Tabuleiro tabuleiro;

            p = new Posicao(3, 4);

            tabuleiro = new Tabuleiro(8, 8);

            Console.WriteLine("Posição: " + p);

            Console.ReadLine();

        }
    }
}
