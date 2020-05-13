using tabuleiro;
using xadrez;
using System;
using System.Collections.Generic;
namespace xadrez_console
{
    class Tela
    {
        public static void imprimirPartida(PartidaDeXadrez partida)
        {
            imprimirTabuleiro(partida.tab);
            System.Console.WriteLine();
            imprimirPecasCapturadas(partida);
            System.Console.WriteLine();
            System.Console.WriteLine("Turno: " + partida.turno);
            if (!partida.terminada)
            {
                System.Console.WriteLine("Aguardando Jogada: " + partida.jogadorAtual);
                if (partida.xeque)
                {
                    System.Console.WriteLine("XEQUE!");
                }
            }
            else{
                System.Console.WriteLine("XEQUEMATE!");
                System.Console.WriteLine($"Vencedor: {partida.jogadorAtual}");
            }

        }

        public static void imprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            System.Console.WriteLine("Pecas capturadas:");
            System.Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            System.Console.WriteLine();
            System.Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;

        }

        public static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            System.Console.Write("[ ");
            foreach (Peca item in conjunto)
            {
                System.Console.Write(item + " ");
            }
            System.Console.WriteLine(" ]");
        }
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for (int vetor = 0; vetor < tab.linhas; vetor++)
            {
                System.Console.Write(8 - vetor + " ");
                for (int elemento = 0; elemento < tab.colunas; elemento++)
                {
                    imprimirPeca(tab.peca(vetor, elemento));
                }

                System.Console.WriteLine();
            }
            System.Console.WriteLine("  A B C D E F G H");

        }

        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int vetor = 0; vetor < tab.linhas; vetor++)
            {
                System.Console.Write(8 - vetor + " ");
                for (int elemento = 0; elemento < tab.colunas; elemento++)
                {
                    if (posicoesPossiveis[vetor, elemento])
                    {
                        Console.BackgroundColor = fundoAlterado;

                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    imprimirPeca(tab.peca(vetor, elemento));
                    Console.BackgroundColor = fundoOriginal;
                }

                System.Console.WriteLine();
            }
            System.Console.WriteLine("  A B C D E F G H");
            Console.BackgroundColor = fundoOriginal;

        }

        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

        public static void imprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                System.Console.Write("- ");
            }
            else
            {
                if (peca.cor == Cor.Branca)
                {
                    System.Console.Write(peca);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    System.Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                System.Console.Write(" ");
            }
        }
    }
}