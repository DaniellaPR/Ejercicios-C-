using System;

namespace Colores
{
    internal class Program
    {
        static void ver(int[] arr, int pos)
        {
            int i;
            Console.Write("{ ");
            for (i= 0; i < arr.Length-1;i++)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                if (i==pos || i == pos+1)
                    Console.ForegroundColor= ConsoleColor.Green;
                Console.Write(arr[i] + ", ");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            if (i == pos || i == pos + 1)
                Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(arr[i]);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("}");
            Console.WriteLine();
        }
        static int[] StupidSort(int[] arr, bool dev =false)
        {
            int i, aux, it=0;
            for (i= 0; i < arr.Length-1;i++)
            {
                if (arr[i] > arr[i+1])
                {
                    it++;
                    aux = arr[i];
                    arr[i] = arr[i+1];
                    arr[i+1] = aux;
                    if (dev) ver(arr, i);
                    i = -1;
                }
            }
            Console.WriteLine(it);
            if (dev) ver(arr, -2);
            return arr;
        }
        static void Main(string[] args)
        {
            int[] arr = { 7, 4, 6, 2, 5 };
            arr = StupidSort(arr, true);
            Console.ReadKey();
        }
    }
}
