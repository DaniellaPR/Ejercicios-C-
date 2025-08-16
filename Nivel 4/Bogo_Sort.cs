using System;

namespace HernandezPozo
{
    class Program
    {
        static bool VerificarOrden(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                    return false;
            }
            return true;
        }

        static void ReorganizarAleatorio(int[] arr)
        {
            Random r = new Random();
            for (int i = arr.Length - 1; i > 0; i--)
            {
                int j = r.Next(i + 1);
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        static int[] Ordenar(int[] arr, bool imprimir)
        {
            int contador = 0;
            while (!VerificarOrden(arr))
            {
                contador++;
                ReorganizarAleatorio(arr);
                if (imprimir)
                    Console.WriteLine(string.Join(" ", arr));
            }
            Console.WriteLine($"\nPara ordenar {arr.Length} datos se necesitaron {contador} reorganizaciones aleatorias.");
            return arr;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese los números separados por espacios:");
            string cadena = Console.ReadLine();

            string[] partes = cadena.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] arreglo = new int[partes.Length];
            for (int i = 0; i < partes.Length; i++)
                arreglo[i] = Convert.ToInt32(partes[i]);

            Console.WriteLine("Desea imprimir los arreglos intermedios? (s/n)");
            string opcion = Console.ReadLine();
            bool imprimir = opcion.ToLower() == "s";

            arreglo = Ordenar(arreglo, imprimir);

            Console.WriteLine("El arreglo final es:");
            Console.WriteLine(string.Join(" ", arreglo));
            Console.ReadKey();
        }
    }
}
