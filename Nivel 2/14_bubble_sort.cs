using System;

class ordenar
{
    static void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        int iterations = 0; //Contador de iteraciones

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                iterations++; //Incrementar por cada comparación
                //Intercambiar si el elemento actual es mayor que el siguiente
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }

        Console.WriteLine($"Arreglo ordenado (Bubble Sort): {string.Join(", ", arr)}");
        Console.WriteLine($"Número de iteraciones: {iterations}");
    }

    static void Main(string[] args)
    {
        int[] arr = { 123, -56, 87, 234, 45, 98, 12, 567, 321, 111 };
        BubbleSort(arr);
        Console.ReadKey();
    }
}
