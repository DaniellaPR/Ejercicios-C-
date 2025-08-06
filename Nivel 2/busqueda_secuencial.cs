using System;

namespace PozoPaula_A
{
    internal class Program
    {
        static void BuscarNum(int[] arreglo, int numeroBuscado)
        {
            bool buscar = true;                                                  //definimos un booleano para indicar si se encontró o no
            int i;
            for (i =0; i < arreglo.Length; i++)                                  //Iniciamos con un bucle for desde 0 al largo del arreglo
            {
                if (arreglo[i] == numeroBuscado)                                 //Si el arreglo en esa posición es igual al numero buscado
                {
                    Console.WriteLine(numeroBuscado + " se encontró en la posición " + (i+1)); //Imprimiremos la posición encontrada
                    buscar = false;                                              //Buscar será falso
                }
            }
            if (buscar)                                                          //Si buscar sigue verdadero
                Console.WriteLine("El número no existe en el arreglo");          //Significará que no se encontró el número buscado
        }
        static void Main(string[] args)
        {
            //1. Emoezaremos con preguntar al usuario cuantos datos tendrá el arreglo en el que se buscará
            Console.WriteLine("Ingrese cuántos datos tendrá el arreglo: ");       //Por consola se preugnta
            int datos = Convert.ToInt32(Console.ReadLine());                      //Se almacenará en la variable "datos"
            int[] numeros = new int[datos];                                       //Se crea el arreglo con la cantidad de datos que indicó

            //2. Datos ingresados por consola
            Console.WriteLine("Ingrese los datos del arreglo: ");                 //Se pregunta al usuario los elementos del arreglo 1 por 1
            int i;
            for (i=0; i <datos; i++)                                              //Para ello usamos un bucle for hasta el número de datos
            {
                Console.Write("Número " + (i+1) + ": ");                          //Indicamos el orden que tendrán los números
                int n = Convert.ToInt32(Console.ReadLine());                      //Almacenamos en n
                numeros[i] = n;                                                 //Y los agregamos al arreglo
            }

            //3. Pedir el número a buscar y usar función
            Console.WriteLine("Ingrese el número que desea buscar en el arreglo: "); //Pedir al usuario que ingrese el que desea buscar
            int numeroBuscado = Convert.ToInt32(Console.ReadLine());                 //Guardarlo en numeroBuscado
            BuscarNum(numeros, numeroBuscado);                                       //Usar función para buscar

            Console.ReadKey();
        }
    }
}
