using System;
namespace Ejercicio2
{
    internal class Program
    {

        static void Main(string[] args)                                                              //Función principal
        {
            int[] arr = new int[10];                                                                 //Definimos explícitamente
            int i, s;                                                                                //Declaramos un contador
            string[] rs;                                                                             //Declaramos un arreglo
            char[] sep = new char[] { ' ' };                                                         //Declaramos la separación para unir después al arreglo
            string cad;                                                                              //Declaramos la cadena donde se guardarán los elementos ingresados

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Ingrese hasta 10 múmeros separados por espacios: ");                      //Solicitar al usuario que ingrese 10 dígitos
            Console.ForegroundColor= ConsoleColor.Gray;
            cad = Console.ReadLine();
            rs = cad.Split(sep);                                                                     //Separamos por espacios 
            for (i = 0; i < rs.Length; i++)                                                          //Creamos condicional para colocar cada elemento separado en el arreglo
            {
                arr[i] = Convert.ToInt32(rs[i]);                                                     //Sin antes convertir a entero
            }
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Ingrese el número que desea buscar: ");                                   //Pedimos al usuario que ingrese el número que desea buscar
            Console.ForegroundColor= ConsoleColor.Gray;
            s = Convert.ToInt32(Console.ReadLine());                                                 //Se convierte a entero
            bool Encontrado = true;                                                                  //Creamos una bandera
            for (i = 0; i < rs.Length; i++)                                                          //Creamos bucle para comparar con cada uno de los elementos
            {
                if (arr[i] == s)                                                                     //Creamos condicional por si encuentra coincidencias
                {
                    Encontrado = true;                                                               //Si se lo encuentra, es verdadero
                    break;                                                                           //Así que sale del bloque de código
                }
                else
                    Encontrado = false;                                                              //Si no, se hace falso
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            if (Encontrado)                                                                          //Creamos un condicional
                Console.WriteLine($"Si se ha hallado el número {s} en la posición {i+1}");           //Si es true, imprime junto con la posición del encuentro
            else
                Console.WriteLine("No se encuentra el número en el arreglo...");                     //Si no, imprime un mensaje donde lo especifica

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine("Gracias por usar el programa");                                       //Agradecer para indicar que acabó el programa
            Console.ReadKey();                                                                       //Pausar el programa
        }
    }
}
