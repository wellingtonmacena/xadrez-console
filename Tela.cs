using tabuleiro;
using xadrez;
using System;
namespace xadrez_console
{
    class Tela
    {
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
                    else{
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