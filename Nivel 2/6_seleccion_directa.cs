using System;
//Daniela Pozo
namespace SeleccionDirecta
{
    internal class Program
    {
        //FUNCIÓN PARA VER ARREGLO PASO A PASO-------------------------------------
        static void ver(int[] anterior, int[] actual)                    //Inicia con argumentos de la lista anterior y la actual para encontrar diferencia
        {
            Console.ForegroundColor = ConsoleColor.Gray;                 //Color por definición será gris
            Console.Write("{ ");                                         //Primera llave que contendra los números del arreglo
            for (int i = 0; i < anterior.Length; i++)                    //Bucle de la longitud del arreglo
            {
                if (anterior[i] != actual[i])                           //Condicional para los números que sean diferentes de la lista actual
                {
                    Console.ForegroundColor = ConsoleColor.Red;         //cambia el colore
                    Console.Write(actual[i] + " ");                     //se ijmprimiran de rojo
                }
                else                                                    //Para números sin cambios
                {
                    Console.ForegroundColor = ConsoleColor.Gray;        //Se cambia al color por definición, gris
                    Console.Write(anterior[i] + " ");                   //Se imprimen esos números
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;                //Se vuelve a cambiar a gris por si el color queda en rojo
            Console.Write("}");                                         //Se cierra con llaves
            Console.WriteLine();
        }

        //SELECCIÓN DIRECTA-------------------------------------------------------
        static void SeleccionDirecta(int[] arr)                        //Único argumento: el arreglo
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Selección Directa");                    //Nombre del tipo de ordenamiento

            int it = 0;                                                //Definición de contador de iteraciones
            int[] actual = new int[arr.Length];                        //Definicion de lista actual para la función de mostrar el arreglo con colores
            for (int i = 0; i < arr.Length; i++)                       //Se copia el arreglo base en el actual
                actual[i] = arr[i];
            int[] anterior = new int[arr.Length];                      //Definicion de lista actual para la función de mostrar el arreglo con colores
            for (int i = 0; i < arr.Length; i++)                       //Se copia el arreglo base como el anterior
                anterior[i] = arr[i];

            for (int i = 0; i < arr.Length - 1; i++)                   //Bucle para empezar ordenamiento del tamaño del arreglo
            {
                it++;                                                  //Se cuentan las iteraciones
                ver(anterior, actual);                                 //Primera comparación antes del cambio (no tendría que verse ningún color cambiado)
                for (int l = 0; l < actual.Length; l++)                //Se cambia el actual como anterior
                    anterior[l] = actual[l];

                int y = i;                                             //Como parte del ordenamiento, se copia i, la posición, en una variable nueva
                for (int j = i + 1; j < arr.Length; j++)               //Bucle que empieza 1 posición despues que i, del tamaño del arreglo
                {
                    if (arr[j] < arr[y])                               //Si esta posición resulta menos que la variable nueva con i
                        y = j;                                         //Se iguala a la posición posterior
                }

                int x = arr[y];                                        //Se crea variable auxiliar para guardar esta posición y
                arr[y] = arr[i];                                       //se iguala y a la posicón i anterior
                arr[i] = x;                                            //Se iguala i a la auxiliar
                for (int l = 0; l < actual.Length; l++)                //Por último realizo una copia del arreglo al actual para la función de ver arreglo con colores
                    actual[l] = arr[l];
            }

            Console.ForegroundColor = ConsoleColor.Yellow;             //Imprime con colorcitos el número de iteraciones
            Console.WriteLine("Le tomó " + it + " iteraciones.");
            Console.ForegroundColor = ConsoleColor.DarkCyan;           //Cambia de color para imprimir elementos del arreglo
            for (int k = 0; k < arr.Length; k++)
                Console.Write(arr[k] + " ");                           //Datos del arreglo en bucle
            Console.WriteLine();
        }

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
                SeleccionDirecta(arreglo);                                                           //Se llama a la función para ordenar
                Console.WriteLine();
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
