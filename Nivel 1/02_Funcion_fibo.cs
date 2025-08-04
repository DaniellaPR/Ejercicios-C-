using System;

namespace Clase2FuncionFibo
{
    internal class Program
    {
        static string GenerarFuncion(long n)
        {
            string resultado = " ";
            long i, a, b, c;
            Console.WriteLine();
            try
            {
                a = b = 1;
                if (n < 1)
                    resultado = "No se puede generar la serie...";
                else if (n == 1)
                    resultado = "Serie: 1";
                else if (n <= 20)
                {
                    resultado = $"Serie: {a} {b} ";
                    for (i = 2; i < n; i++)
                    {
                        c = a + b;
                        resultado += c + " ";
                        a = b; b = c;
                    }
                }
                else
                    resultado = "No se puede con mayores a 20";
            }
            catch
            {
                resultado = "No se puede generar con esa webada";
            }
            return resultado;
        }

        static void Main(string[] args)
        {
            long n;
            string res;
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  S E R I E   D E   F I B O N A C C I  ");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Cuántos números desea ver: ");
            Console.ForegroundColor= ConsoleColor.Gray;
            n = Convert.ToInt64(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Green;
            res = GenerarFuncion(n);
            Console.WriteLine(res);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Gracias por usarme");
            Console.ReadKey();
        }
    }
}
