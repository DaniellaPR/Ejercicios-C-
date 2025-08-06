using System;

namespace QuickSort
{
    internal class Program
    {
        //Función para mostrar el arreglo con colores
        static void VerPasos(int[] arreglo, int izq, int der, int pivoteValor)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("{ ");
            for (int i = 0; i < arreglo.Length; i++)
            {
                if (arreglo[i] == pivoteValor && izq <= i && i <= der)          //Si es el valor pivote y está en el rango actual
                    Console.ForegroundColor = ConsoleColor.Red;                 //Lo mostramos en rojo
                else if (i == izq || i == der)
                    Console.ForegroundColor = ConsoleColor.Yellow;              //Amarillo para los extremos del rango
                else
                    Console.ForegroundColor = ConsoleColor.Gray;                //Gris para el resto

                Console.Write(arreglo[i] + " ");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("}");
        }

        //Función principal del Quick Sort
        static void QuickSort(int[] arreglo, int izq, int der)
        {
            if (izq >= der) return;                                             //Caso base: rango inválido

            int i = izq;                                                        //Puntero izquierdo
            int j = der;                                                        //Puntero derecho
            int pivote = arreglo[(izq + der) / 2];                              //Valor pivote (no índice)

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Particionando desde {izq} hasta {der}, pivote: {pivote}");
            VerPasos(arreglo, i, j, pivote);                                    //Mostramos estado inicial

            while (i <= j)
            {
                while (arreglo[i] < pivote) i++;                                //Avanzamos mientras sea menor
                while (arreglo[j] > pivote) j--;                                //Retrocedemos mientras sea mayor

                if (i <= j)
                {
                    int temp = arreglo[i];                                      //Intercambiamos
                    arreglo[i] = arreglo[j];
                    arreglo[j] = temp;

                    i++;                                                        //Movemos punteros
                    j--;

                    VerPasos(arreglo, i, j, pivote);                            //Mostramos tras intercambio
                }
            }

            //Llamadas recursivas
            if (izq < j) QuickSort(arreglo, izq, j);                            //Izquierda
            if (i < der) QuickSort(arreglo, i, der);                            //Derecha
        }

        //Función principal del programa
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese los números separados por espacio:");
            string entrada = Console.ReadLine();                                //Leemos entrada

            if (string.IsNullOrWhiteSpace(entrada))                             //Validamos entrada vacía
            {
                Console.WriteLine("Entrada vacía.");
                return;
            }

            string[] partes = entrada.Split(' '); //Evita espacios extra
            int[] arreglo = new int[partes.Length];

            for (int i = 0; i < partes.Length; i++)
            {
                if (!int.TryParse(partes[i], out arreglo[i]))                   //Validamos números
                {
                    Console.WriteLine($"'{partes[i]}' no es un número válido.");
                    return;
                }
            }

            Console.WriteLine("\n=== Pasos del ordenamiento ===\n");
            QuickSort(arreglo, 0, arreglo.Length - 1);

            Console.WriteLine("\n=== Arreglo ordenado ===");
            Console.ForegroundColor = ConsoleColor.Blue;
            foreach (int num in arreglo)
                Console.Write(num + " ");
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("\nGracias por usar el programa...");
            Console.ReadKey();
        }
    }
}
