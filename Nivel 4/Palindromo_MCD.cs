//Palíndromo
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozoP_PalindromoRecursivo
{
    internal class Program
    {
        //Usando el c[odigo de invertir trabajado en clase:
        public static string Invertir(string s, int indice)
        {
            if (indice < 0)               //Caso base, si el índice es menor que 0
                return "";                //se detiene la recursión
            else                          //Caso recursivo, se llama a la función
                return s[indice] + Invertir(s, indice - 1); //devuelve el carácter en la posición índice y llama a la función nuevamente con el índice decrementado
        }
        //Función para verificar el palíndromo
        public static bool VerificarPalindromo(string original)
        {
   
            string invertido = Invertir(original, original.Length - 1); //llamada a la función de invertir
            if (invertido == original)
                return true;                        //Comparamos si es igual es verdadero
            else
                return false;                       //sino devolver[a falso
        }
        //Funcion principal
        static void Main(string[] args)
        {
            Console.Write("Ingrese una cadena de texto sin espacios ni caracteres especiales: ");            //Se piden datos de ingreso
            string original = Console.ReadLine();                                                            //Se guardan los datos en la variable original
            if (VerificarPalindromo(original))                                                               //llamada a la función de verificar palíndromo
                Console.WriteLine("Es un palíndromo");
            else
                Console.WriteLine("No es un palíndromo");                                                    //se imprime el resultado
            Console.WriteLine("Graias por usar este programa...");                                           //Mensaje final
            Console.ReadKey();
        }
    }
}

//MCD
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozoP_MCD_Recursivo
{
    internal class Program
    {
        //Máximo común divisor recursivo
        public static int MCD(int a, int b)
        {
            if (b == 0)               //El caso base sería cuando b es 0, cuando cualquier número se lo divide entre 0 es el mismo valor, tal como está en el documento del deber
                return a;             // por lo que se detiene la recursión devolviendo a
            else                      //El caso recursivo hace una llamada intercambiando los valores de a y b
                return MCD(b, a % b); // Donde a se convierte en b y b es el residuo de la división entre a y b
            //si un número se divisor común  de a y btambién es de b,del residuo entre a y b
            ////y permite reducir el problema sin ocupar tanta memoria y de manera más +optima
        }
        //Función principal
        static void Main(string[] args)
        {
            Console.WriteLine("Máximo común divisor recursivo");  //Nombre
            Console.Write("Ingrese el primer número: ");          //Ingreso de valores por el usuario
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese el segundo número: ");
            int b = Convert.ToInt32(Console.ReadLine());          //Guarda los valores ingresados por el usuario en las variables a y b
            int resultado = MCD(a, b);                            //Llamada a la función MCD
            Console.WriteLine("El máximo común divisor de "+a +" y "+b+ "es: "+resultado); //Imprime resultados
            Console.WriteLine("Gracias por usar este programa :)...");
            Console.ReadKey();
        }
    }
}
