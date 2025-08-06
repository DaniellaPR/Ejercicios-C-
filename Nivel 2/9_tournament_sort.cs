using System;

namespace Tarea2_Ejercicio1
{
    internal class Program
    {
        //FUNCIÓN PARA VER RESULTADO POR COLORES ----------------------------------------------------
        static void Resultado(int[] arr)                                                //El argumento será únicamente el arreglo aleatorio
        {
            Console.ForegroundColor = ConsoleColor.Gray;                                //Color base gris
            Console.Write("Resultado: { ");                                             //Imprimir nombre y llaves
            for (int i = 0; i < arr.Length; i++)                                        //Bucle para recorrer todos los elmentos del arreglo
            {
                if (arr[i] == 0)                                                        //Como pusimos de base 0, si son iguales serán del color base
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                else                                                                    //Si son los ganadores se pondrán de color cyan oscuro
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write(arr[i] + " ");                                            //Se imprimen los elemntos dependiendo del color
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("}");                                                         //Se cierra con lalves del color base
            Console.WriteLine();
        }

        //FUNCIÓN PARA VER RONDAS POR COLORES -------------------------------------------------------
        static void Rondas(int[] arr, int ganadorP, int ronda)                          //Iniciamos con 3 argumentos: el arreglo, la posición del ganador y el número de ronda
        {
            int i;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Ronda "+(ronda+1)+": { ");                                   //Mensaje para el número de ronda y llaves de color base

            for (i = 0; i < arr.Length; i++)                                            //Bucle para recorrer elementos del arreglo
            {
                if (i == ganadorP)                                                      //Si resulta la posición del ganador se imprimirá cyan
                    Console.ForegroundColor = ConsoleColor.Cyan;
                else if (arr[i] == 0)                                                   //Si es 0, sera gris oscuro
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                else                                                                    //Para número snormales será el color base
                    Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(arr[i] + " ");                                            //Se imprimen los números
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("}");                                                         //Se cierra con lalves del color base
            Console.WriteLine();
        }

        //TOURNAMENT SORT --------------------------------------------------------------------------
        static void TournamentSort(int[] arr, string orden)                            //Argumentos: arreglo y si es descendente o ascendente
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nTournament Sort\n");                                  //nombre del algoritmo
            int i, it = 0, ronda;                                                      //declaración de variables
            int[] resultado = new int[arr.Length];                                     //creamos arreglo para guardar los ganadores
            for (i = 0; i < resultado.Length; i++)  
                resultado[i] = 0;                                                      //Cada elemento tendrá ceros como base

            for (ronda = 0; ronda < arr.Length; ronda++)                               //Bucle para especificar las rondas dependiendo de la extensión del arreglo
            {
                int ganadorP = -1;                                                     //Declaramos variable para guardar posici+on del ganador
                int ganador = 0;                                                       //Variable para guardar el ganador
                bool primero = false;                                                  //Un booleano para indicarnos si es el primero analizado
                int comp = 0;                                                          //variable para contar cuantas comparaciones hace por ronda :)

                for (i = 0; i < arr.Length; i++)                                       //Se inicia con bucle para recorrer elementos del arreglo
                {
                    if (arr[i] != 0)                                                   //Si no son la casilla base (0)  
                    {
                        comp++;                                                        //Se comienzan a contar comparaciones por pareja
                        if (primero==false)                                            //Si es el primer valor no cero
                        {
                            ganador = arr[i];                                          //Se lo toma como ganador
                            ganadorP = i;                                              //Se guarda su posción en la variable creada
                            primero = true;
                        }
                        else                                                           //Si no es el primero
                        {
                            if (orden == "ascendente" && arr[i] < ganador)             //Dependiendo si es ascendente y es MENOR al ganador anterior
                            {
                                ganador = arr[i];                                      //Se guarda como ganador en esa ronda
                                ganadorP = i;
                            }
                            else if (orden == "descendente" && arr[i] > ganador)       //Si resulta descendente y es MAYOR al ganador anterior
                            {
                                ganador = arr[i];                                      //Queda como ganador en esa ronda
                                ganadorP = i;
                            }
                        }
                    }
                }
                it += comp;
                if (ganadorP != -1)                                                   //Si la posición ha cambiado, es decir hubo ganador
                {
                    Rondas(arr, ganadorP, ronda);                                     //se usa función para ver las rondas con argumentos el arreglo, la posición del ganador y el número de ronda que toca

                    resultado[ronda] = ganador;                                       //Si el rrelgo en esa posición es el ganador 
                    arr[ganadorP] = 0;                                                //La posición resultaria 0 como casilla base
                     
                    Resultado(resultado);                                             //Se imprime el arreglo resultante ordenado de poco en poco
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Comparaciones en esta ronda: " + comp);            //Se imprimen compracaciones por cada ronda
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Arreglo ordenado: ");                                      //Al salir del bucle se imprime el arreglo finalmente ordenado
            Console.ForegroundColor = ConsoleColor.Red;
            for (i = 0; i < resultado.Length; i++)
                Console.Write(resultado[i] + " ");                                    //Elemento por elemento
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Le tomó " + it+ " iteraciones.");                      //Y el número de iteraciones
        }
        //FUNCIÓN PRINCIPAL PARA ALGORITMO DE ORDENAMIENTO -----------------------------------------
        static void Main(string[] args)
        {
            int i;
            Random rand = new Random();                                                //Comando para usar random
            int cant = rand.Next(5, 16);                                               //Variable para extensión del arrelgo usando rand.Next
            int[] arreglo = new int[cant];                                             //Creación del arreglo en base a esa canidad de elementos propuesta

            for (i = 0; i < cant; i++)                                                 //Llenamos el arreglo con datos desde -100 a 100
                arreglo[i] = rand.Next(-100, 101);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Arreglo con datos aleatorios: ");                           //Mnesaje para imprimir arreglo aleatorio
            Console.ForegroundColor = ConsoleColor.Gray;
            for (i = 0; i < arreglo.Length; i++)                                       //Impresión de elementos del arreglo
                Console.Write(arreglo[i] + " ");

            Console.WriteLine();
            Console.ForegroundColor= ConsoleColor.DarkGreen;
            Console.Write("Orden del arreglo (ascendente/descendente): ");             //Preguntamos por el orden que desea
            Console.ForegroundColor = ConsoleColor.Gray;
            string orden = Console.ReadLine().ToLower();
            TournamentSort(arreglo, orden);                                            //Usamos función con argumentos: arreglo y forma de ordenar
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Gracias por usar el programa...");
            Console.ReadKey();
        }
    }
}
