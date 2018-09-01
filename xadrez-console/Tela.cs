using System;
using tabuleiro;
using xadrez;
using System.Collections.Generic;

namespace xadrez_console
{
    class Tela
    {

        public static void imprimirPartida(PartidaDeXadrez partida)
        {
            ImprimiTabuleiro(partida.tab);
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.turno);
            
            if (!partida.terminada)
            {
                Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);
                if (partida.xeque)
                {
                    Console.WriteLine("Xeque!");
                }
            }
            else
            {
                ConsoleColor original = Console.ForegroundColor;

                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Xeque-Mate!");

                Console.ForegroundColor = original;

                Console.Write("A cor vencedora foi: ");

                if (partida.vencedora == Cor.Branca)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }

                Console.WriteLine(partida.vencedora);

                Console.ForegroundColor = original;
            }
        }

        public static void imprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças Capturadas:");
            Console.Write("Brancas: ");
            imprimirConjunto(partida.PecasCapturadas(Cor.Branca));
            Console.Write("Pretas: ");
            imprimirConjunto(partida.PecasCapturadas(Cor.Preta));
        }

        public static void imprimirConjunto(HashSet<Peca> pecasCapturadas)
        {
            Console.Write("[");
            foreach(Peca p in pecasCapturadas)
            {
                imprimiPeca(p, ", ");
            }
            Console.WriteLine("]");
        }

        public static void ImprimiTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write((8 - i) + " ");
                for (int g = 0; g < tab.colunas; g++)
                {
                    imprimiPeca(tab.peca(i, g), " ");
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
                    imprimiPeca(tab.peca(i, g), " ");
                }
                Console.BackgroundColor = original;
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void imprimiPeca(Peca peca, string complemento)
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
                    Console.Write(peca + complemento);
                    Console.ForegroundColor = aux;
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca + complemento);
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
