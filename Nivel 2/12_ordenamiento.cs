using System;
//Daniela Pozo
//todo menos quick sort
namespace Tarea2_Ejercicio2
{
    class Program
    {
        //FUNCIÓN PARA IMPRIMIR PASOS CON COLORES --------------------------------
        static void ImprimirPasos(int[] arr, int i, int j)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("{ ");
            for (int o = 0; o < arr.Length; o++)
            {
                if (o == i || o == j)
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(arr[o] + " ");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("}");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Arreglo ordenado: ");                                      //Al salir del bucle se imprime el arreglo finalmente ordenado
            for (i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
        }

        //FUNCIÓN DE FUSIÓN (MERGE) ----------------------------------------------
        static int Fusion(int[] arr1, int[] arr2, int[] arr)
        {
            int i = 0, j = 0, k = 0;
            int iteraciones = 0;
            int it = 0;

            // Mientras haya elementos en ambos arreglos
            while (i < arr1.Length || j < arr2.Length)
            {
                if (i == arr1.Length)
                    arr[k++] = arr2[j++];
                else if (j == arr2.Length)
                    arr[k++] = arr1[i++];
                else if (arr1[i] >= arr2[j])  // Cambiado a comparación descendente
                {
                    ImprimirPasos(arr1, i, j); // Muestra el paso actual
                    arr[k++] = arr1[i++];
                }
                else
                {
                    ImprimirPasos(arr1, i, j); // Muestra el paso actual
                    arr[k++] = arr2[j++];
                }
                iteraciones++;
                it++;
            }
            Console.WriteLine($"Iteraciones de fusión: {iteraciones}");
            return it;
        }

        //FUNCIÓN MERGE SORT ----------------------------------------------------
        static void MergeSort(int[] arr, string orden)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nMerge Sort\n");
            int i, it;
            int[] arr1, arr2;
            if (arr.Length > 1)
            {
                if (arr.Length % 2 == 0)
                {
                    arr1 = new int[arr.Length / 2];
                    arr2 = new int[arr.Length / 2];
                }
                else
                {
                    arr1 = new int[arr.Length / 2];
                    arr2 = new int[arr.Length / 2 + 1];
                }

                for (i = 0; i < arr.Length / 2; i++)
                    arr1[i] = arr[i];
                for (i = arr.Length / 2; i < arr.Length; i++)
                    arr2[i - arr.Length / 2] = arr[i];

                MergeSort(arr1, orden);
                MergeSort(arr2, orden);

                
                it = Fusion(arr1, arr2, arr);
                for (i=0; i < arr1.Length; i++)
                {
                    if (arr[i] < arr[i+1])
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nLe tomó " + it + " iteraciones.");
                }
            }
        }
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
            Console.Write("Ronda " + (ronda + 1) + ": { ");                                   //Mensaje para el número de ronda y llaves de color base

            for (i = 0; i < arr.Length; i++)                                            //Bucle para recorrer elementos del arreglo
            {
                if (i == ganadorP)                                                      //Si resulta la posición del ganador se imprimirá cyan
                    Console.ForegroundColor = ConsoleColor.Red;
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
                        if (primero == false)                                            //Si es el primer valor no cero
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
                            else if (orden != "ascendente" && arr[i] > ganador)       //Si resulta descendente y es MAYOR al ganador anterior
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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nLe tomó " + it + " iteraciones.");                      //Y el número de iteraciones
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Arreglo ordenado: ");                                      //Al salir del bucle se imprime el arreglo finalmente ordenado
            for (i = 0; i < resultado.Length; i++)
                Console.Write(resultado[i] + " ");                                    //Elemento por elemento
        }
        //FUNCIÓN PARA VER Shaker Sort PASO A PASO-------------------------------------
        static void VerSS(int[] arr, int i)                               //Argumentos: el arreglo, las posiciones 
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("{ ");
            for (int o = 0; o < arr.Length; o++)                                 //Bucle del tamaño del arreglo
            {
                if (o == i || o == i-1)                                            //Si la posición es igual a alguna de las usadas en el paso de la función
                    Console.ForegroundColor = ConsoleColor.Green;                //se resaltan de verde
                else
                    Console.ForegroundColor = ConsoleColor.Gray;                 //sino se mantendrán del color base, gris
                Console.Write(arr[o] + " ");                                     //Se imprimen los elementos
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("}");
        }

        //SHAKER SORT --------------------------------------------------------------
        static void ShakerSort(int[] arr, string orden)                         //Argumento: el arreglo y la preferencia de orden
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Shaker Sort");                                   //Nombre del algoritmo
            int i = 0, aux, aux2, iteraciones = 0, x, y;
            int f = arr.Length;

            while (i < f)                                                       //Bucle para indicar que acaba cuando la posición del inicio es mayor a la del fin
            {
                for (x = 0; x < arr.Length - 1; x++)                        //Bucle del tamaño del arrlego
                {
                                                                  //Se cuentan iteraciones
                    if ((orden == "ascendente" && arr[x] > arr[x + 1]) || (orden != "ascendente" && arr[x] < arr[x + 1])) //Condición según el orden
                    {
                        iteraciones++;
                        VerSS(arr, x);                                         //Miramos el arreglo antes de que sea cambiado con función
                        aux = arr[x];                                           //Se intercambia con ayuda del auxiliar
                        arr[x] = arr[x + 1];
                        arr[x + 1] = aux;
                    }
                }
                f--;
                for (y=f; y > i; y--)                           //Bucle del tamaño del arreglo que lo recorre desde el final
                {
                                                                //Se cuentan iteraciones
                    if ((orden == "ascendente" && arr[y] < arr[y - 1]) || (orden != "ascendente" && arr[y] > arr[y - 1])) //Condición según el orden
                    {
                        iteraciones++;
                        VerSS(arr, y);                                  //Miramos el arreglo antes de que sea cambiado con función
                        aux2 = arr[y];                                         //Se intercambia con ayuda del auxiliar
                        arr[y] = arr[y - 1];
                        arr[y - 1] = aux2;
                    }
                }
                i++;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Le tomó {iteraciones} iteraciones.");            //Imprimimos iteraciones
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("Arreglo ordenado: ");                                 //Imprimimos arreglo ordenado
            for (int l = 0; l < arr.Length; l++)
                Console.Write(arr[l] + " ");
        }
        //FUNCIÓN PARA VER ARREGLO PASO A PASO-------------------------------------
        static void ver(int[] arr, int pos1, int pos2)                     //Argumentos de función: el arreglo, la posición de inicio y la posición actual
        {
            Console.ForegroundColor = ConsoleColor.Gray;                   //Cambio a color base
            Console.Write("{ ");                                           //Llaves de inicio
            for (int i = 0; i < arr.Length; i++)                           //Bucle con iterador hasta tamaño del arreglo
            {
                if (i == pos1 || i == pos2)                                //Si la posición en esa parte del arreglo es igual a alguna que se haya cambiado
                    Console.ForegroundColor = ConsoleColor.Green;          //Se pintará de verde
                else                                                       //Si no se realizó ningún cambio
                    Console.ForegroundColor = ConsoleColor.Gray;           //Se mantendrá en gris
                Console.Write(arr[i] + " ");                               //Se imprime el elemento según el color escogido
            }
            Console.ForegroundColor = ConsoleColor.Gray;                   //Cambio a color base
            Console.WriteLine("}");                                        //Llaves para finalizar
        }

        //INCERSIÓN BINARIA-------------------------------------------------------
        static void InsercionBinaria(int[] arr, string orden)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Inserción Binaria");                        //Nombre del algoritmo de ordenamiento a utilizar
            int i, k, j, inicio, final, medio, l, it = 0;                  //Declaración de variables e iteradores
            for (i = 1; i < arr.Length; i++)                               //Bucle del tamaño del arreglo. Empieza desde el segundo elemento
            {
                it++;                                                      //Se cuenta iteradores
                k = arr[i];                                                //Variable para almacenar el elemento de la posición inicial del arreglo
                inicio = 0;                                                //Inicio para el método de búsqueda
                final = i-1;                                             //Final para el método de búsqueda
                while (inicio <= final)                                    //Bucle que indicará que concluye si las posiciones de inicio y final son las mismas o inicio mayor al final
                {
                    medio = (inicio + final) / 2;                          //inicia método de búsqueda extrayendo el medio
                    if ((orden == "ascendente" && k < arr[medio]) || (orden != "ascendente" && k > arr[medio]))  //Condición de comparación basada en el orden elegido
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
            Console.WriteLine("Le tomó " + it + " iteraciones.");          //Impresión de iteraciones
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("Arreglo ordenado: ");
            for (l = 0; l < arr.Length; l++)                               //Bucle para impresión del arreglo ordenado
                Console.Write(arr[l] + " ");
            Console.WriteLine();
        }
        //FUNCIÓN PARA VER ARREGLO PASO A PASO-------------------------------------
        static void ver(int[] anterior, int[] actual)                    // Inicia con argumentos de la lista anterior y la actual para encontrar diferencia
        {
            Console.ForegroundColor = ConsoleColor.Gray;                 //Color por definición será gris
            Console.Write("{ ");                                         //Primera llave que contendra los números del arreglo
            for (int i = 0; i < anterior.Length; i++)                    //Bucle de la longitud del arreglo
            {
                if (anterior[i] != actual[i])                           //Condicional para los números que sean diferentes de la lista actual
                {
                    Console.ForegroundColor = ConsoleColor.Red;         //cambia el colore
                    Console.Write(actual[i] + " ");                     //se imprimirán de rojo
                }
                else                                                    //Para números sin cambios
                {
                    Console.ForegroundColor = ConsoleColor.Gray;        //Se cambia al color por definición, gris
                    Console.Write(actual[i] + " ");                   //Se imprimen esos números
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;                //Se vuelve a cambiar a gris por si el color queda en rojo
            Console.Write("}");                                         //Se cierra con llaves
            Console.WriteLine();
        }

        //SELECCIÓN DIRECTA-------------------------------------------------------
        static void SeleccionDirecta(int[] arr, string orden)            //Único argumento: el arreglo y el orden
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Selección Directa");                      //Nombre del tipo de ordenamiento

            int it = 0;                                                  //Definición de contador de iteraciones
            int[] actual = new int[arr.Length];                          //Definicion de lista actual para la función de mostrar el arreglo con colores
            for (int i = 0; i < arr.Length; i++)                         //Se copia el arreglo base en el actual
                actual[i] = arr[i];

            for (int i = 0; i < arr.Length - 1; i++)                     //Bucle para empezar ordenamiento del tamaño del arreglo
            {
                it++;                                                    //Se cuentan las iteraciones
                ver(actual, arr);                                   //Primera comparación antes del cambio (no tendría que verse ningún color cambiado)
                for (int l = 0; l < actual.Length; l++)                  //Se cambia el actual como anterior
                    actual[l] = arr[l];

                int y = i;                                               //Como parte del ordenamiento, se copia i, la posición, en una variable nueva
                for (int j = i + 1; j < arr.Length; j++)                 //Bucle que empieza 1 posición después que i, del tamaño del arreglo
                {
                    if ((orden == "ascendente" && arr[j] < arr[y]) || (orden != "ascendente" && arr[j] > arr[y])) //Condición basada en el orden
                        y = j;                                           //Se iguala a la posición posterior
                }

                int x = arr[y];                                          //Se crea variable auxiliar para guardar esta posición y
                arr[y] = arr[i];                                         //Se iguala y a la posición i anterior
                arr[i] = x;                                              //Se iguala i a la auxiliar
            }

            Console.ForegroundColor = ConsoleColor.Yellow;               //Imprime con colorcitos el número de iteraciones
            Console.WriteLine("Le tomó " + it + " iteraciones.");
            Console.ForegroundColor = ConsoleColor.DarkCyan;             //Cambia de color para imprimir elementos del arreglo
            for (int k = 0; k < arr.Length; k++)
                Console.Write(arr[k] + " ");                             //Datos del arreglo en bucle
            Console.WriteLine();
        }
        //FUNCIÓN PARA VER Stupid Sort PASO A PASO-------------------------------------
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
        static void StupidSort(int[] arr, string orden)                        //Argumento: el arreglo y la preferencia de orden
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;                    //Nombre del algoritmo
            Console.WriteLine("Stupid Sort");
            int i, aux, it = 0;                                                //Definen variable auxiliar e iteradores
            for (i = 0; i < arr.Length - 1; i++)                               //Bucle de iniciación del tamaño del arrelgo
            {
                it++;                                                          //Se cuentan iteraciones
                if ((orden == "ascendente" && arr[i] > arr[i + 1]) || (orden != "ascendente" && arr[i] < arr[i + 1])) //Condición según el orden
                {
                    aux = arr[i];                                              //Intercambiamos con ayuda del auxiliar
                    arr[i] = arr[i + 1];
                    arr[i + 1] = aux;
                    i = -1;                                                    //El iterador regresa a 0 colocando -1 para que al subir se sume 1
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Paso" + it + ": ");                              //Se  imprime el mensaje de paso
                verS(arr, i);                                                  //Llamamos a la funcion para ver arreglo
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Le tomó {it} iteraciones.");                   //Imprimimos iteraciones
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("Arreglo ordenado: ");                               //Imprimimos arreglo ordenado
            for (int l = 0; l < arr.Length; l++)
                Console.Write(arr[l] + " ");
        }
        //FUNCIÓN PRINCIPAL DE ALGORITMOS DE ORDENAMIENTO ---------------------------------------------------------------------------------------------------------------------------------
        static void Main(string[] args)
        {
            int i, dato;                                                                                //Declaraci+on de variable y datos a ingresar por consola
            string otroArr = "s";                                                                       //Bandera para añadir un nuevo arreglo
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("--- Bienvenido al programa de algoritmos de ordenamiento ---");          //Nombre de bienvenida
            while (otroArr == "s")                                                                      //Bucle que seguirá hasta que se ponga algo diferente de s, si no desea otro arreglo a ingresar
            {
                string otroAlg = "s";                                                                   //Bandera para usar otro algoritmo deordenamiento
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nIngrese la cantidad de datos que tendrá el arreglo: ");                //Ingresar cantidad de datos
                Console.ForegroundColor = ConsoleColor.Gray;
                int cant = Convert.ToInt32(Console.ReadLine());                                         //Leemos y convertimos
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Ingrese los elementos del arreglo: ");                               //Mensaje de ingreso de datos
                Console.ForegroundColor = ConsoleColor.Gray;
                int[] arreglo = new int[cant];                                                          //Se cera arreglo con la cantidad que puso antes
                int[] copia = new int[arreglo.Length];                                                  //Una copia para poder ser usada varias veces el mismo arreglo
                for (i = 0; i < arreglo.Length; i++)                                                    //Bucle para recorrer posiciones del arrgelo
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Dato " + (i + 1) + ": ");                                            //Ingresa datos no por comas, ni hasta que el quiera, sino 1 por 1 como persona normal y encima enumerados
                    Console.ForegroundColor = ConsoleColor.Gray;
                    dato = Convert.ToInt32(Console.ReadLine());
                    arreglo[i] = dato;                                                                  //Se guardan los dato sen el arreglo
                    copia[i] = dato;                                                                    //Se hace copia del arreglo por la razón de antes
                }
                while (otroAlg == "s")                                                                  //Bucle por si desea usar otro método de ordenamiento para el mismo arreglo
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n-- Algoritmos de ordenamiento --");                            //Nombre bonito
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\n  1. Stupid Sort\n  2. Selección Directa\n  3. Incersión Binaria\n  4. Shaker Sort\n  5. Tournament Sort\n  6. Merge Sort"); //Opciones pq no me se el switch
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\nNúmero del algoritmo que desee utilizar... ");                    //Se pide el número que desee
                    int num = Convert.ToInt32(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\nOrden del arreglo (ascendente/descendente): ");                   //Y el orden
                    string orden = Console.ReadLine();                                                 //Se guarda el rorden escogido en la variable orden
                    if (num == 1)                                                                      //Según el número se usa la función correspondiente
                        StupidSort(arreglo, orden);
                    else if (num == 2)
                        SeleccionDirecta(arreglo, orden);
                    else if (num == 3)
                        InsercionBinaria(arreglo, orden);
                    else if (num == 4)
                        ShakerSort(arreglo, orden);
                    else if (num == 5)
                        TournamentSort(arreglo, orden);
                    else if (num == 6)
                        MergeSort(arreglo, orden);
                    else                                                                              //Si no es ninguna se invalida y se pregunta de nuevo por el algoritmo de ordenamiento
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Opción numérica inválida");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\n¿Desea imprimir el arreglo en otro algoritmo de ordenamiento? (s/n)... "); //Al final se pregunta si desea imprimir en otro algoritmo
                    otroAlg = Console.ReadLine();
                    for (int l = 0; l < copia.Length; l++)                                            //por si acaso se hace copia del arreglo anterior para su reuso
                        arreglo[l] = copia[l];
                }
                Console.Write("\n¿Desea ingresar un arreglo nuevo? (s/n)... ");                       //Se pregunta si desea ingresar nuevo arreglo
                otroArr = Console.ReadLine();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nGracias por usar el programa...");                                       //Hasta que ponga culaquier cosa diferente y se acaba el programa con mensaje
            Console.ReadKey();
        }
    }
}
