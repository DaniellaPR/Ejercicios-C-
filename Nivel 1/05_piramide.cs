using System;

namespace Clase3Piramide
{
    internal class Program
    {
        static int[][] GenerarPiramide(int altura)
        {
            int[][] piramide = new int[altura][];
            int contador = 1;
            for (int i = 0; i < altura; i++)
                piramide[i] = new int[altura - i];
            for (int col = 0; col < altura; col++)
            {
                for (int fila = 0; fila < altura - col; fila++)
                {
                    piramide[fila][col] = contador; 
                    contador++; 
                }
            }
            return piramide;
        }

        static void Ver(int[][] piramide)
        {
            for (int i = 0; i < piramide.Length; i++)
            {
                for (int j = 0; j < piramide[i].Length; j++)
                    Console.Write(piramide[i][j] + "  "); //tabulaciones
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Ingrese la altura de la pirámide: ");
            int altura = Convert.ToInt32(Console.ReadLine());
            int[][] arrf = GenerarPiramide(altura);
            Ver(arrf);
            Console.WriteLine("Gracias por usar este programa");
            Console.ReadKey();
        }
    }
}
