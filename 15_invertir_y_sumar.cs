using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// Invertir y Sumar
/// La función invertir y sumar, parte de un número del que se obtiene otro con el orden de sus dígitos invertido, y suma ambos. Si la suma no es un palíndromo,
/// se repetirá el procedimiento.
/// Por ejemplo, si se empieza con el 195 como número inicial, se obtendrá el palíndormo 9339 después de la cuarta operación:
/// 195 + 591 = 786
/// 786 + 687 = 1473
/// 1473 + 3741 = 5214
/// 5214 + 4125 = 9339 
/// Este método hace que layoría de enteros evolucionen hacia palíndromos en unso pocos pasos. Pero hay excepciones interesantes. El 196 es el primer número para
/// el que no se ha encontrado un palíndromo, aunque no se ha podido demostrar que éste no exista
/// Escribir un programa que con un número inicial como dato devuelva el palíndromo resultante (si es que existe alguno), y el número de iteraciones (sumas)
/// necesarias para llegar a él.
/// Se puede asumir que todos los números que se utilizarán en el programa tienen una solución a la que se llega en menos de 1000 operaciones y ningún
/// palíndomo será mayor que 4,294,967,295. Se debe tomar en cuenta que existen palíndromos de un solo dígito.
/// 
/// Entrada:
/// La primera línea contendrá un entero N (0 < N <= 100) , que indica el núemero de casos de prueba, y las siguientes N líneas constarán cd un único
/// entero P, cuyo palíndromo se debe calcular
/// 
/// Salida:
/// Por cada entero N, se mostrará una línea que indique el número mínimo de iteraciones necesarias para caucluar el palíndromo, un espacio en blando
/// y el propio palíndromo.
/// 
/// Ejemplo de Entrada:
/// 3
/// 195
/// 265
/// 750
/// 
/// Salida:
/// 4 9339
/// 5 45254
/// 3 6666


namespace InvertirYSumar
{
    class Program
    {
        //Devuelve un long invertido al n que recibe como argumento
        public static long Invertir(long n)
        {
            long resultado; //Valor invertido
            String cadInv = ""; //Cad invertida
            String cad = Convert.ToString(n); //Número n visto como string
            for (int i = cad.Length - 1; i >= 0; i--)
                cadInv += Convert.ToString(cad[i]);
            resultado = Convert.ToInt32(cadInv);
            return resultado;
        }

        //Deuvleve true si el argumento es palíndromo
        public static bool EsPalindromo(long n)
        {
            String cad = Convert.ToString(n); //n como cadena
            bool palindromo = true; //Verificará la condición de palíndromo, se asume que es palíndromo al inicio
            int i = 0, j = cad.Length - 1; //Contadores
            while (i < j)
            {
                if (cad[i] != cad[j])
                {
                    palindromo = false;
                    break;
                }
                i++;
                j--;
            }
            return palindromo;
        }

        //Devuelve una línea de la salida solicitada por el ejercicio para un valor entero cualquiera que cumpla con las condiciones inicales
        public static String InvertirSumar(long n)
        {
            String cad = ""; //Cadena resultante
            bool palindromo = EsPalindromo(n); //Verificará que un entero sea palíndromo
            int cont = 0; //Contador de iteraciones
            long suma = n; //Suma de una iteración
            while (!palindromo)
            {
                suma = n + Invertir(n);
                palindromo = EsPalindromo(suma);
                n = suma;
                cont++;
            }
            cad = Convert.ToString(cont) + " " + suma;
            return cad;
        }

        static void Main(string[] args)
        {
            String cad = "-1";
            string resultado;
            while (cad != "0")
            {
                Console.Write("Ingrese un entero positivo (con 0 termina)... ");
                cad = Console.ReadLine();
                if (cad != "0")
                {
                    resultado = InvertirSumar(Convert.ToInt32(cad));
                    Console.WriteLine(resultado);
                }
            }
            Console.Write("Gracias por usar este programa");
            Console.ReadKey();
            //cad = InvertirSumar(195);
            //cad = InvertirSumar(265);
            //cad = InvertirSumar(750);
            //cad = InvertirSumar(5);
            //cad = InvertirSumar(196);
        }
    }
}
