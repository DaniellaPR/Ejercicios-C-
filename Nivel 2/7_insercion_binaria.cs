using System;
//Daniela Pozo
namespace InsercionBinaria
{
    internal class Program
    {
        //FUNCIÓN PARA VER ARREGLO PASO A PASO-------------------------------------
        static void ver(int[] arr, int pos1, int pos2)                     //Argumentos de función: el arreglo, la posición de inicio y la posición actual
        {
            Console.ForegroundColor = ConsoleColor.Gray;                   //Cambio a color base
            Console.Write("{ ");                                           //Llaves de inicio
            for (int i = 0; i < arr.Length; i++)                           //Bucle con iterador hasta tamaño del arreglo
            {
                if (i == pos1 || i == pos2)                                //Si la posición en esa parte del arreglo es igual a alguna que se haya cambiado
                {
                    Console.ForegroundColor = ConsoleColor.Green;          //Se pintará de verde
                } 
                else                                                       //Si no se realizó ningún cambio
                {
                    Console.ForegroundColor = ConsoleColor.Gray;           //Se mantendrá en gris
                }
                Console.Write(arr[i] + " ");                               //Se imprime el elemento según el color escogido
            }
            Console.ForegroundColor = ConsoleColor.Gray;                   //Cambio a color base
            Console.WriteLine("}");                                        //Llaves para finalizar
        }

        //INSERCIÓN BINARIA-------------------------------------------------------
        static void InsercionBinaria(int[] arr)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Inserción Binaria");                        //Nombre del algoritmo de ordenamiento a utilizar
            int i, k, j, inicio, final, medio, l, it = 0;                  //Declaración de variables e iteradores
            for (i = 1; i < arr.Length; i++)                               //Bucle del tamaño del arreglo. Empieza desde el segundo elemento
            {
                it++;                                                      //Se cuenta iteradores
                k = arr[i];                                                //Variable para almacenar el elemento de la posición inicial del arreglo
                inicio = 0;                                                //Inicio para el método de búsqueda
                final = i - 1;                                             //Final para el método de búsqueda
                while (inicio <= final)                                    //Bucle que indicará que concluye si las posiciones de inicio y final son las mismas o inicio mayor al final
                {
                    medio = (inicio + final) / 2;                          //inicia método de búsqueda extrayendo el medio
                    if (k < arr[medio])                                    //Si el elemento de la posición inicial es menor al medio
                        final = medio - 1;                                 //El final baja hasta el medio y se queda con la primera parte del arreglo
                    else                                                   //Si el elemento de la posición inicial es mayor al medio
                        inicio = medio + 1;                                //El inicio sube hasta el medio y se queda con la segunda parte del arreglo
                }
                j = i - 1;                                                 //variable que almacena una posición menos que el de la posición i
                while (j >= inicio)                                        //mientras sea mayor o igual al inicio, es decir que sea superior a 0 (concluirá cuando compare el primer elemento como menor
                {
                    arr[j + 1] = arr[j];                                   //el elemento superior a j, será el primero
                    j = j - 1;                                             //y j será el elemento posterior
                }
                arr[inicio] = k;                                           //se actualiza que el inicio será k, es decir el elemento de la primera posición para comenzar de nuevo
                ver(arr, inicio, i);                                       //Se imprime el paso con la función
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Le tomó " + it + " interaciones.");        //Impresión de iteraciones
            Console.ForegroundColor = ConsoleColor.DarkCyan;  
            Console.Write("Arreglo ordenado: ");                          
            for (l = 0; l < arr.Length; l++)                              //Bucle para impresión del arreglo ordenado
                Console.Write(arr[l] + " ");
            Console.WriteLine();
        }

        //FUNCIÓN PRINCIPAL -------------------------------------------------------
        static void Main(string[] args)
        {
            int i, dato;                                                                             //Declaro variable y contador
            string resp = "s";                                                                       //Se inicia con bandera actualmente con s, para que empiece el bucle
            while (resp == "s")                                                                      //Bucle que no terminará hasta que el usuario ingrese n
            {
                Console.ForegroundColor = ConsoleColor.Green;                                         //Color de impresión de consola
                Console.Write("Ingrese el número de datos del arreglo: ");                           //se pide al usuario que ingerse el número de datos
                Console.ForegroundColor = ConsoleColor.Gray;
                int cant = Convert.ToInt32(Console.ReadLine());
                int[] arreglo = new int[cant];                                                       //Se crea un arreglo con la cantidad de datos que nos a dicho
                for (i = 0; i < arreglo.Length; i++)                                                 //Bucle para ingresar elementos por consola
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Dato #" + (i + 1) + ": ");                                          //En vez de usar comas, imprimo directamente el número de elemento y que lo escriba
                    Console.ForegroundColor = ConsoleColor.Gray;
                    dato = Convert.ToInt32(Console.ReadLine());
                    arreglo[i] = dato;                                                               //Lo añade de una vez en el arreglo en la posición i
                }
                InsercionBinaria(arreglo);                                                           //Se llama a la función para ordenar
                Console.WriteLine();
                Console.ForegroundColor= ConsoleColor.Gray;
                Console.Write("¿Desea ingresar otro arreglo para ser ordenado? (s/n): ");            //Se pregunta si desea volver a escribir otro arreglo
                resp = Console.ReadLine();                                                           //Se lee el mensaje y se confirma con el bucle while
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.Write("Gracias por usar el programa...");                    //Mensaje de finalización en caso de que no haya querido volver a escribir otro arreglo
            Console.ReadKey();
        }
    }
}
