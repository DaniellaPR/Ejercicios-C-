using System;
//Daniela Pozo
//Shaker sort vs Stupid sort
namespace ShakeryStupidSort
{
    internal class Program
    {
        //FUNCIÓN PARA VER Shaker Sort SORT PASO A PASO-------------------------------------
        static void VerSS(int[] arr, int i, int j)                               //Argumentos: el arreglo, las posiciones 
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("{ ");
            for (int o = 0; o < arr.Length; o++)                                 //Bucle del tamaño del arreglo
            {
                if (o == i || o == j)                                            //Si la posición es igual a alguna de las usadas en el paso de la función
                {
                    Console.ForegroundColor = ConsoleColor.Green;                //se resaltan de verde
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;                 //sino se mantendrán del color base, gris
                }
                Console.Write(arr[o] + " ");                                     //Se imprimen los elementos
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("}");
        }

        //SHAKER SORT --------------------------------------------------------------
        static int ShakerSort(int[] arr)                                        //Argumento: el arrelgo
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Shaker Sort");                                   //Nombre del algoritmo
            int i =0, aux, aux2, iteraciones=0, u=0;                                 //Definimos variables
            int f = arr.Length;                                                

            while (i < f)                                                       //Bucle para indicar que acaba cuando la posición del inicio es mayor a la del fin
            {
                for (int x = 0; x < arr.Length - 1; x++)                        //Bucle del tamaño del arrlego
                {
                    iteraciones++;                                              //Se cuentan iteraciones
                    if (arr[x] > arr[x + 1])                                    //Si el arreglo en la posición a analizar es mayor a la siguiente
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("Paso" + (u + 1) + ": ");
                        VerSS(arr, x, x + 1);                                   //Miramos el arreglo antes de que sea cambiado con función
                        aux = arr[x];                                           //Se intercambia con ayuda del auxiliar
                        arr[x] = arr[x + 1];
                        arr[x + 1] = aux;
                        u++;
                    }
                }
                
                for (f = arr.Length - 2; f > 0; f--)                           //Bucle del tamaño del arreglo que lo recorre desde el final
                {
                    iteraciones++;                                             //Se cuentan iteraciones
                    if (arr[f] < arr[f - 1])                                   //Si el arreglo en la posición a analizar es menor a la anterior
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("Paso" + (u + 1) + ": ");
                        VerSS(arr, f, f - 1);                                  //Miramos el arreglo antes de que sea cambiado con función
                        aux2 = arr[f];                                         //Se intercambia con ayuda del auxiliar
                        arr[f] = arr[f - 1];
                        arr[f - 1] = aux2;
                        u++;
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Le tomó {iteraciones} iteraciones.");            //Imprimimos iteraciones
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("Arreglo ordenado: ");                                 //Imprimimos arreglo ordenado
            Console.Write("{ ");
            for (int l = 0; l < arr.Length; l++)
                Console.Write(arr[l] + " ");
            Console.WriteLine("}");
            return iteraciones;
        }
        //FUNCIÓN PARA VER STUPID SORT PASO A PASO-------------------------------------
        static void verS(int[] arr, int pos)                                   //Argumentos solo el arreglo y la posición analizada
        {
            int i;                                                             //Declaramos variables
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("{ ");                                               //LLaves de inicio con cambio de color
            for (i = 0; i < arr.Length - 1; i++)                               //Bucle del tamaño del arreglo
            {
                Console.ForegroundColor = ConsoleColor.Gray;                   //Se reinicia a gris el color base antes de mpezar de nuevo
                if (i == pos || i == pos + 1)                                  //Si la posición es igual a la posición analizada en el paso o la siguiente
                    Console.ForegroundColor = ConsoleColor.Green;              //Cambiará a verde, sino se mantendrá en gris
                Console.Write(arr[i] + ", ");                                  //Se imprimen los elementos
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            if (i == pos || i == pos + 1)                                      //Si la posición es igual a las analizadas
                Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(arr[i]);                                             //Se imprimen en verde
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("}");                                                //Se cierran llaves
            Console.WriteLine();
        }
        
        //STUPID SORT --------------------------------------------------------------

        static int StupidSort(int[] arr)                                       //Argumento: el arreglo
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;                    //Nombre del algoritmo
            Console.WriteLine("Stupid Sort"); 
            int i, aux, it = 0;                                                //Definen variable auxiliar e iteradores
            for (i = 0; i < arr.Length - 1; i++)                               //Bucle de iniciación del tamaño del arrelgo
            {
                it++;                                                          //Se cuentan iteraciones
                if (arr[i] > arr[i + 1])                                       //Si la posición a analizar es mayor a la siguiente
                {
                    aux = arr[i];                                              //Intercambiamos con ayuda del auxiliar
                    arr[i] = arr[i + 1];
                    arr[i + 1] = aux;
                    i = -1;                                                    //El iterador regresa a 0 colocando -1 para que al subir se sume 1
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Paso"+it+": ");                                 //Se  imprime el mensaje de paso
                verS(arr, i);                                                  //Llamamos a la funcion para ver arrelgo
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Le tomó {it} iteraciones.");                   //Imprimimos iteraciones
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("Arreglo ordenado: ");                               //Imprimimos arreglo ordenado
            Console.Write("{ ");
            for (int l = 0; l < arr.Length; l++)
                Console.Write(arr[l]+" ");
            Console.WriteLine("}");
            return it;
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
                    Console.Write("Dato #" + (i + 1) + ": ");                                        //En vez de usar comas, imprimo directamente el número de elemento y que lo escriba
                    Console.ForegroundColor = ConsoleColor.Gray;
                    dato = Convert.ToInt32(Console.ReadLine());
                    arreglo[i] = dato;                                                               //Lo añade de una vez en el arreglo en la posición i
                }
                Console.WriteLine();
                int iteraciones = ShakerSort(arreglo);                                          //Se llama a la función para ordenar
                Console.WriteLine();
                int it = StupidSort(arreglo);                                                   //Se llama a la otra función para ordenar
                Console.WriteLine();
                Console.ForegroundColor= ConsoleColor.Magenta;
                if (it==iteraciones)                                                            //Se crea condicional para evaluar número de iteraciones
                    Console.WriteLine("El número de iteraciones fueron iguales, ambos algoritmos fueron igual de óptimos");
                else if (it<iteraciones)                                                        //Si stupid sort tiene mas iteraciones
                    Console.WriteLine("Stupid sort usó menos pasos que Shaker sort");
                else if (it > iteraciones)                                                      //Si stupid sort tiene menos iteraciones
                    Console.WriteLine("Shaker sort usó menos pasos que Stupid sort");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Stupid Sort: " + it + "       Shaker Sort: " + iteraciones);
                Console.ForegroundColor = ConsoleColor.Gray;
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
