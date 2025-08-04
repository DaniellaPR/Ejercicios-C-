using System;

namespace Clase1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long n, i, a, b, c;
            try
            {
                Console.WriteLine("S E R I E   D E   F I B O N A C C I ");
                Console.WriteLine();
                Console.Write("Cuántos términos desea visualizar?...");
                n = Convert.ToInt32(Console.ReadLine());
                a = b = 1;
                if (n < 1)
                    Console.WriteLine("No se puede generar la serie");
                else if (n == 1)
                    Console.WriteLine("Serie: 1");
                else if (n <= 20)
                {
                    Console.Write($"Serie: {a} {b} ");
                    for (i = 2; i < n; i++)
                    {
                        c = a+b;
                        Console.Write(c + " ");
                        a = b; b = c;
                    }
                }
                else
                    Console.WriteLine("No es posible con números mayores a 20");
            }
            catch
            {
                Console.Write("No se puede generar la serie con esa webada");
            }

            //Final
            Console.WriteLine();
            Console.WriteLine("\nGracias por usar este programa.");
            Console.ReadKey();                                   //Pausa el programa
        }
    }
}
//1. Escribir un programa en C# que pida al usuario un número entero n
// y presente por consola  los n primeros numeros de la serie de fibonacci

//2. Cambiar el programapara que la serie se genere en una funcion que recibe como parametro
//el numero de terminos y retorna uin string conteniendo la serie o el mesaje de error .El programa sigue siendo a prueba de usuarios
