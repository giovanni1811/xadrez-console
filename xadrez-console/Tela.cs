using System;
using tabuleiro;

namespace xadrez_console
{
    class Tela
    {

        public static void ImprimiTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.linhas; i++)
            {
                for (int g = 0; g < tab.colunas; g++)
                {
                    if (tab.peca(i, g) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(tab.peca(i, g) + " ");
                    }
                }
                Console.WriteLine();
            }
        }

    }
}
