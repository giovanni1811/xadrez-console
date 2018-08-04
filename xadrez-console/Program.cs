﻿using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.terminada)
                {
                    try{
                        Console.Clear();

                        Tela.ImprimiTabuleiro(partida.tab);

                        Console.WriteLine();
                        Console.WriteLine("Turno: " + partida.turno);
                        Console.WriteLine("Aguardando jogada da: " + partida.jogadorAtual);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();

                        partida.validarPosicaoOrigem(origem);

                        bool[,] posPossiveis = partida.tab.peca(origem).movimentosPossiveis();

                        Console.Clear();

                        Tela.ImprimiTabuleiro(partida.tab, posPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();

                        partida.validarPosicaoDestino(origem ,destino);

                        partida.realizaJogada(origem, destino);
                    }
                    catch(TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
