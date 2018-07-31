using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Tela
    {

        public static void ImprimiTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write((8 - i) + " ");
                for (int g = 0; g < tab.colunas; g++)
                {
                    if (tab.peca(i, g) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        imprimiPeca(tab.peca(i, g));
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void imprimiPeca(Peca peca)
        {
            if (peca.cor == Cor.Branca)
            {
                Console.Write(peca + " ");
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(peca + " ");
                Console.ForegroundColor = aux;
            }
        }

    }
}
