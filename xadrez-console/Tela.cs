﻿using System;
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
                    imprimiPeca(tab.peca(i, g));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void ImprimiTabuleiro(Tabuleiro tab, bool[,] mat)
        {
            ConsoleColor original = Console.BackgroundColor;
            ConsoleColor alterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write((8 - i) + " ");
                for (int g = 0; g < tab.colunas; g++)
                {   
                    if (mat[i, g])
                    {
                        Console.BackgroundColor = alterado;
                    }
                    else
                    {
                        Console.BackgroundColor = original;
                    }
                    imprimiPeca(tab.peca(i, g));
                }
                Console.BackgroundColor = original;
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void imprimiPeca(Peca peca)
        {

            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.cor == Cor.Branca)
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(peca + " ");
                    Console.ForegroundColor = aux;
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca + " ");
                    Console.ForegroundColor = aux;
                }
            }

            
        }

        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();

            int linha = int.Parse(s[1] + " ");
            char coluna = s[0];

            return new PosicaoXadrez(coluna, linha);
        }

    }
}
