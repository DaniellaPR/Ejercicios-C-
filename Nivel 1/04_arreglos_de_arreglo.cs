using System;

namespace Clase2ArreglosdeArreglo
{
    internal class Program
    {
        static int[] Fusion(int[] a, int[] b)
        {
            int i, j;
            int[] r = new int[a.Length + b.Length];
            for (i = 0, j = 0; i < a.Length; i++, j++)
                r[j] = a[i];
            for (i = 0; i < b.Length; i++, j++)
                r[j] = b[i];
            return r;
        }
        static int[] IngresarArreglo(int n)
        {
            int i;
            int[] r;
            char[] sep = new char[] {' '};
            string[] rs;
            string cad;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Ingrese los datos del arreglo #{n}, separados por un espacio: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            cad = Console.ReadLine();
            rs = cad.Split( sep );
            r = new int[rs.Length];
            for (i = 0; i < rs.Length; i++)
                r[i] = Convert.ToInt32(rs[i]);
            return r;
        }
        static void VerArreglo(int[] arr)
        {
            int i;
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.Write("Resultado: [ ");
            for (i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine("]");
            Console.BackgroundColor = ConsoleColor.Black;
        }
        static void Main(string[] args)
        {
            int[] a1;
            int[] a2;
            int[] f;
            a1 = IngresarArreglo(1);
            a2 = IngresarArreglo(2);
            f = Fusion(a1, a2);
            VerArreglo(f);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Gracias por usar este programa");
            Console.ReadKey();
        }
    }
}
