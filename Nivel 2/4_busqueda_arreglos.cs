using System;

namespace PozoPaula_B_
{
    internal class Program
    {
        static void Busqueda(int[] arr1, int[] arr2)    //FUNCIÓN DE BÚSQUEDA DE ELEMENTOS DEL ARREGLO 1 EN EL ARREGLO 2
        {
            int i, j;                                  //Definimos contadores
            for (i=0; i < arr1.Length;i++)             //Bucle por cada elemento del primer arreglo
            {
                for (j=0;j<arr2.Length;j++)            //Busque en cada elemento del segundo arreglo
                {
                    if (arr1[i] == arr2[j])            //Si el elemento del arr1 es igual a uno del segundo, imprimirá un mensaje 
                        Console.WriteLine("El elemento " + arr1[i] + " del arreglo 1, con posición " + (i+1) + " se encuentra en la posición " + (j+1) + " del segundo arreglo");
                }
            }

        }
        static void Main(string[] args)    //FUNCIÓN PRINCIPAL
        {
            int i, dato;                                                                          //Definimos y contador variable
            Console.Write("Escriba de cuantos términos el primer arreglo: ");                     //Pedimos cuantos términos del primer arreglo
            int cant1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Escriba de cuántos términos el segundo arreglo: ");                    //Pedimos cuantos términos del segundo arreglo
            int cant2 = Convert.ToInt32(Console.ReadLine());

            int[] arr1 = new int[cant1];         //Creamos arreglo con cantidad de datos que ingresó
            int[] arr2 = new int[cant2];         //Creamos arreglo 2 con cantidad de datos que ingresó

            Console.WriteLine("Ingrese datos del arreglo 1 (no repetidos):");
            for (i=0; i < arr1.Length; i++)                                                       //Bucle por cada elementos del arreglo 1
            {
                Console.Write("Dato " + (i + 1)+": ");                                            //Preguntamos por cada dato
                dato = Convert.ToInt32(Console.ReadLine());
                arr1[i] = dato;                                                                   //Guardamos dato en posición i
            }

            Console.WriteLine("Ingrese datos del arreglo 2 (pueden haber repetidos):");
            for (i = 0; i < arr2.Length; i++)                                                     //Bucle por cada elementos del arreglo 2
            {
                Console.Write("Dato " + (i + 1) + ": ");                                          //Preguntamos por cada dato
                dato = Convert.ToInt32(Console.ReadLine());
                arr2[i] = dato;                                                                   //Guardamos dato en posición i
            }

            Console.WriteLine();
            Busqueda(arr1, arr2);                                                                 //Usamos función para buscar elementos del arreglo 1 en arreglo 2
            Console.ReadKey();
        }
    }
}
