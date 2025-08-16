using System;

namespace ConsoleApp1
{
    class Program
    {
        public int BBinaria(int num, int[] arr)
        {
            int lon = arr.Length;
            int mitad = lon / 2;
            if (num > arr[mitad])
                arr[mitad] = lon;
            if (num < arr[mitad + 1])
                arr[mitad + 1] = lon;
            else
                return mitad;
            for (int i = 0; i<lon; i++)
                Console.Write(arr[i]);
        }
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            
        }
    }
}
