using System;
//Daniela Pozo

namespace ShellSort
{
    internal class Program
    {
        static void Ver(int[] arreglo, int i, int gap)
        {
            bool intercambio = false;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("{ ");
            for (int j = 0; j < arreglo.Length; j++)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                if (i == j)
                {
                    intercambio = true;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else if (j == i + gap)
                {
                    intercambio = true;
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.Write(arreglo[j] + " ");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            if (intercambio)
            {
                Console.WriteLine("}   gap = " + gap + ", Se intercamia el cyan con el verde");

            }
            else
            {
                Console.WriteLine("}   gap = " + gap + ", Se disminuye el gap");
            }
        }
        static int[] ShellSort(int[] arreglo)
        {
            int gap = Convert.ToInt32(arreglo.Length / 2), auxiliar, a = 0;
            bool SinIntercambio = true;
            while (SinIntercambio && gap != 0)
            {
                for (int i = 0; i + gap < arreglo.Length; i++)
                {
                    if (arreglo[i] > arreglo[gap + i])
                    {
                        auxiliar = arreglo[i];
                        arreglo[i] = arreglo[gap + i];
                        arreglo[gap + i] = auxiliar;
                        SinIntercambio = false;
                        a = i;
                        Ver(arreglo, i, gap);
                    }
                }
                if (SinIntercambio)
                {
                    Console.Write("{ ");
                    for (int i = 0; i < arreglo.Length; i++)
                    {
                        Console.Write(arreglo[i] + " ");
                    }
                    Console.Write("}  ");
                    if (gap - 1 != 0)
                    {
                        Console.Write(" gap = " + gap + ", La gap se disminuye");
                        Console.WriteLine();
                    }
                    if (gap - 1 == 0)
                        Console.Write(" gap = 1, Arreglo final");

                    gap--;
                }

                SinIntercambio = true;
            }

            return arreglo;
        }
        static int[] Agrandar(int[] arreglo)
        {
            int[] nuevo = new int[arreglo.Length + 1];
            for (int i = 0; i < arreglo.Length; i++)
            {
                nuevo[i] = arreglo[i];
            }
            return nuevo;
        }
        static int[] GenerarArreglo()
        {
            int[] arreglo = new int[0];
            string ingresado = "0";
            int i = 0, numero;

            while (ingresado != "")
            {
                Console.WriteLine($"Ingrese el valor entero numero {i + 1}: ");
                ingresado = Console.ReadLine();
                try
                {
                    numero = Convert.ToInt32(ingresado);
                    arreglo = Agrandar(arreglo);
                    arreglo[i] = numero;
                    i++;
                }
                catch
                {
                    Console.WriteLine("");
                }

            }
            return arreglo;
        }
        static void Main(string[] args)
        {
            //int[] arreglo;                 
            //arreglo = GenerarArreglo();
            //int[] arreglo = { 9, 6, 3, 2, 1, 6, 9, 1, 4, 5 };
            int[] arreglo = { 9, 8, 7, 6, 9, 8, 7, 6, 2, 3, -4, -1, 0 };
            Console.Write("{ ");
            for (int i = 0; i < arreglo.Length; i++)
            {
                Console.Write(arreglo[i] + " ");
            }
            Console.WriteLine("}   gap = " + arreglo.Length / 2 + ", Arreglo original");

            arreglo = ShellSort(arreglo);
            Console.ReadKey();
        }
    }
}
