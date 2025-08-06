using System;

//Daniela Pozo
namespace Tarea2_Ejercicio2
{
    class Program
    {
        // FUNCIÓN PARA IMPRIMIR PASOS CON COLORES --------------------------------
        static void ImprimirPasos(int[] arr, int i, int j)
        {
            Console.ForegroundColor =ConsoleColor.Gray;
            Console.Write("{ ");
            for (int o = 0; o < arr.Length; o++)
            {
                if (o==i || o==j)
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(arr[o] + " ");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("}");
        }

        // FUNCIÓN DE FUSIÓN (MERGE) ----------------------------------------------
        static int Fusion(int[] arr1, int[] arr2, int[] arr)
        {
            int i=0, j=0, k=0;
            int iteraciones = 0;

            while (i < arr1.Length || j < arr2.Length)
            {
                if (i == arr1.Length)
                    arr[k++] = arr2[j++];
                else if (j == arr2.Length)
                    arr[k++] = arr1[i++];
                else if (arr1[i] >= arr2[j])  //Orden descendente
                {
                    ImprimirPasos(arr1, i, j);
                    arr[k++] = arr1[i++];
                }
                else
                {
                    ImprimirPasos(arr1, i, j);
                    arr[k++] = arr2[j++];
                }
                iteraciones++;
            }

            Console.WriteLine($"Iteraciones de fusión: {iteraciones}");
            return iteraciones;
        }

        //FUNCIÓN MERGE SORT ----------------------------------------------------
        static void MergeSort(int[] arr, string orden)
        {
            

            if (arr.Length <= 1) return;
            int[] arr1, arr2;
            if (arr.Length % 2 == 0)
            {
                arr1 = new int[arr.Length / 2];
                arr2 = new int[arr.Length / 2];
            }
            else
            {
                arr1 = new int[arr.Length / 2];
                arr2 = new int[arr.Length / 2 + 1];
            }

            //Llenar los subarreglos
            for (int i = 0; i < arr.Length / 2; i++)
                arr1[i] = arr[i];
            for (int i = arr.Length / 2; i < arr.Length; i++)
                arr2[i - arr.Length / 2] = arr[i];

            //Llamadas recursivas
            MergeSort(arr1, orden);
            MergeSort(arr2, orden);

            //Fusión
            int it = Fusion(arr1, arr2, arr);

            //Mensaje final de iteraciones
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Le tomó " + it + " iteraciones.");

            //Imprimir arreglo ordenado
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Arreglo ordenado: ");
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }

        // FUNCIÓN PRINCIPAL (Merge Sort) -----------------------------------
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("--- Bienvenido al programa de Merge Sort ---");

            string otroArr = "s";
            while (otroArr == "s")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nIngrese la cantidad de datos que tendrá el arreglo: ");
                Console.ForegroundColor = ConsoleColor.Gray;
                int cant = Convert.ToInt32(Console.ReadLine());

                int[] arreglo = new int[cant];
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Ingrese los elementos del arreglo: ");
                Console.ForegroundColor = ConsoleColor.Gray;

                for (int i = 0; i < cant; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Dato " + (i + 1) + ": ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    arreglo[i] = Convert.ToInt32(Console.ReadLine());
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nOrden del arreglo (ascendente/descendente): ");
                string orden = Console.ReadLine();

                //Llamamos a MergeSort
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nMerge Sort\n");
                MergeSort((int[])arreglo.Clone(), orden); //Usamos clon para no afectar el original si se reimprime

                Console.Write("\n¿Desea ingresar un arreglo nuevo? (s/n)... ");
                otroArr = Console.ReadLine();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nGracias por usar el programa...\n");
            Console.ReadKey();
        }
    }
}
