//Suma con recursividad
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozoP_SumaRecursivaDigitos
{
    internal class Program
    {
        //Suma recursiva función
        public static int SumaRecursiva(int n)      //Función de suma recursiva
        {
            if (n==0)                               //Caso base si es igual a 0, es decir no hau más dígitos
                return 0;                           //Devuelve 0
            return n % 10 + SumaRecursiva(n / 10);  //Suma el último dígito y llama a la función con el número sin el último dígito
        }
        //Función principal
        static void Main(string[] args)
        {
            Console.Write("Introduce un número: ");
            int numero = Convert.ToInt32(Console.ReadLine()); //Lee el número introducido por el usuario
            int resultado = SumaRecursiva(numero);            //Llama a la función de suma recursiva
            Console.WriteLine("La suma de los dígitos de: "+numero+" es: "+resultado);  //Muestra el resultado
            Console.WriteLine("Gracias por usar este programa..."); //Mensaje final
            Console.ReadKey();
        }
    }
}

//Fibonacci
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozoP_FibonacciRecursivo
{
    internal class Program
    {
        //Fibonacci recursivo realizado en clase
        public static int FibonacciRecursivo(int n)          //Función de fibonacci recursivo
        {
            if (n <= 1)                                      //Caso base
                return n;                                    //Retorna el valor de 1 o 0 en caso de que n sea 0 o 1
            else if (n== 0)
                return n;
            else                                             //Caso recursivo
                return FibonacciRecursivo(n - 1) + FibonacciRecursivo(n - 2); //Llama a la función recursivamente con valor de n menos 1 + llamada a la función de n menos 2
        }
        //Función principal
        static void Main(string[] args)
        {
            Console.Write("Ingrese el número de la serie Fibonacci: ");
            int n = Convert.ToInt32(Console.ReadLine());      //Pide el número de la serie Fibonacci
            Console.WriteLine("El número Fibonacci en la posición "+n+" es: "+FibonacciRecursivo(n)); //Llama a la función FibonacciRecursivo con el número que ingresó el usuari o y lo imprime
            Console.WriteLine("Gracias por usar el programa..."); //Imprime mensaje final
            Console.ReadKey();
        }
    }
}

//Factorial
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozoP_FactorialRecursivo
{
    internal class Program
    {
        //Clase de factorial recursivo creada en clase
        public static long FR(long n)  //Clase de factorial rcursivo creada en clase
        {
            if (n == 0)                //Bucle condicional si llega a caso base
                return 1;              //donde retorna 1
            else                       //si no se cumple el caso base
                return n * FR(n - 1);  //llama a la funcion FR de nuevo con el número menos 1
        }
        //Clase principal
        static void Main(string[] args)
        {
            Console.WriteLine("-- Factorial Recursivo --");       
            Console.WriteLine("Ingrese un número entero positivo:");  //Ingreso del número con usuario
            long n = Convert.ToInt64(Console.ReadLine());             //Lee el número ingresado
            long resultado = FR(n);                                   //Llama a la función FR con el número ingresado
            Console.WriteLine("El factorial de "+n+" es: " + resultado);
            Console.WriteLine("Gracias por usar este programa...");   //Mensaje de salida
            Console.ReadKey();
        }
    }
}
