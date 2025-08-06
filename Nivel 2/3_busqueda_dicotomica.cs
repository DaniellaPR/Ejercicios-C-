using System;

namespace PozoPaula_A_
{
    internal class Program
    {
        //Implementación búsqueda dicotómica en arreglo con impresión a colores :D

        static void Busqueda(int[] arreglo, int numero) //FUNCIÓN DE BÚSQUEDA
        {
            int inicio=0;                                          //Variable de inicio
            int final = arreglo.Length - 1;                        //Variable para el final
            int solucion=-1;
            int it = 0;                                            //Cpntador de iteraciones
            while (inicio <= final)                                //Bucle que acabará cuando haya buscado en todo el arreglo
            {
                it++;                                              //Iteraciones del bucle while
                int medio = (final + inicio) / 2;                  //Variable de la mitad del arreglo

                //Impresión con colores (al inicio para que se imprima todo el arreglo primero):

                int y, u;                                          //Contadores para for
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("{" + " ");                          //Imprimimos las llaves primero solas
                for (y = inicio; y < medio; y++)                   //Bucle for desde el incio al medio
                    Console.Write(arreglo[y]+" ");                 //Imprimimos todos los elementos que hay más " ", para que se coloque a lado la siguiente línea
                Console.Write("}");                                //La otra llave

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" "+arreglo[medio] +" ");            //Imprimimos " ", antes y después para que se vea centrado entre los 2 conjuntos

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("{"+" ");                            //Imprimimos la primera llave sola
                for (u = (medio+1); u <= final; u++)               //Bucle for desde el medio al final
                    Console.Write(arreglo[u]+" ");                 //Imprimimos todos los elementos que hay más " ", para que se coloque a lado la siguiente línea
                Console.Write("}");                                //Última llave
                Console.WriteLine();

                //Busqueda binaria

                if (arreglo[medio] == numero)                      //Si al comparar el elemento buscado es el del medio
                {
                    solucion = medio;                              //La solución es el medio
                    break;                                         //Ya no necesita buscar más
                }
                else if (numero < arreglo[medio])                  //Si el número que busca es menor al que encontró dentro del arreglo
                    final = medio - 1;                             //El final se convertirá en 1 menos que el medio, para que solo entre al primer conjunto de menores
                else                                               //Si el número resulta mayor
                    inicio = medio + 1;                            //El inicio se moverá al del medio más 1, obteniendo solo el segundo conjunto

            }

            if (solucion != -1)                                    //Como al inicio pusimos solución = -1, si se cambió imprimrá:
            {
                Console.WriteLine();
                Console.ForegroundColor= ConsoleColor.Gray;
                Console.WriteLine("Encontrado: " + numero);                 //El número que encontró
                Console.WriteLine("Posición: " + (solucion+1));             //La posci´´on donde lo encontró
                Console.WriteLine("Iteraciones: " + it);                    //Y el número de iteraciones
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Gracias por usar el programa");
            }
            else                                                  //Si no se cambió de menos 1, significa que el número no existe
            {
                Console.WriteLine();
                Console.ForegroundColor= ConsoleColor.DarkRed;
                Console.WriteLine("-Número no encontrado-");                 //mensaje de que el número no existe
                Console.WriteLine("Dato no existe...");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Gracias por usar el programa");
            }
        }
        static int[] Ordenar(int[] arr) //FUNCIÓN PARA ORDENAR POR MÉTODO BURBUJA
        {
            int mayor;                           //Definimos variable "mayor"
            int i, j;                            //Contadores
            for (i= 0; i < arr.Length;i++)       //Bucle for hasta el largo del arreglo
            {
                for (j=0;j<arr.Length-1;j++)     //Bucle for hasta donde va a ordenar (-1del arreglo)
                { 
                    if (arr[j] > arr[j+1])       //Si resulta mayor que el siguiente, se intercambian:
                    { 
                        mayor = arr[j];          //El actual será la posición del mayor
                        arr[j] = arr[j+1];       //La posición actual será el siguiente
                        arr[j+1] = mayor;        //El siguiente será el mayor
                    }
                }
            }
            return arr;                          //Devolveremos el arreglo ordenado
        }
        static void Main(string[] args)  //FUNCIÓN PRINCIPAL
        {
            //Iniciamos preguntando cuántos datos tendrá el arreglo

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("¿Cuántos datos tendrá el arreglo?... ");
            Console.ForegroundColor = ConsoleColor.Gray;
            int cant = Convert.ToInt32(Console.ReadLine());            //Los guardamos en "cant"
            int i;                                                     //Definimos contador
            string[] rs;                                               //Definimos lista para caracteres separados
            string cadena;                                             //Definimos la variable donde ingresará la cadena
            char[] sep = new char[] { ',' };                           //Definimos caracter de separación, coma en este caso
            int[] arr=new int[cant];                                   //Definimois el arreglo con los datos de "cant"

            //Ahora preguntamos por los datos que tendrá y los guardamos

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Ingrese los datos del arreglo separados por comas: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            cadena = Console.ReadLine();                               //Los guardaoms en la variable cadena
            rs = cadena.Split( sep );                                  //Guardamos en "rs" separando por comas
            for (i = 0; i < rs.Length; i++)                            //Iniciamos un bucle donde se guardarán en el arreglo
                arr[i] = Convert.ToInt32(rs[i]);                       //Los guardamos convirtiéndolos a enteros

            //Ordenamos el arreglo con función

            int k;                                                     //Definimos un contador
            int[] ordenado = Ordenar(arr);                             //Guardamos el arreglo rodenado usando función
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Usaremos el arreglo ordenado: ");           //Escribimos mensaje para enviar ordenado
            Console.ForegroundColor = ConsoleColor.Gray;
            for (k = 0; k < arr.Length; k++)                           //Bucle del tamaño del arreglo para imprimir datos
            {
                if (k==arr.Length-1)                                   //Para imprimir por separado y que se entienda
                    Console.Write(ordenado[k]);                        //Si es el último elemento, no va a haber espacio
                else
                    Console.Write(ordenado[k] + " ");                  //Si no lo es, va a haber espacio
            }

            //Ahora pediremos número a buscar

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.Write("Número buscado: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            //Por último, usamos función de búsqueda, que ya incorporará colores

            Busqueda(ordenado, num);

            Console.ReadKey();
        }
    }
}
