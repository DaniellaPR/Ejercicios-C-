using System;

namespace PozoPaula_B
{
    internal class Program
    {
        static int Busqueda(string principal, string aBuscar)
        {
            //Empezamos con un booleano para indicar si se encontró o no
            int i, j;
            bool buscar;
            //Ya que la cadena puede ser de más de 2 caracteres
            //Usamos Length para calcular una longitud hasta
            //donde podría contenerse la cadena a buscar
            //dentro del bucle for
            for (i=0; i <principal.Length-aBuscar.Length; i++)
            {
                buscar = true;                            //booleano verdadero para buscar hasta encontrar
                for (j=0;j<aBuscar.Length;j++)            //Un segundo bucle for para la cadena a buscar
                {
                    if (principal[i + j] != aBuscar[j])   //Si es diferente la cadena que se encontró a la que buscamos
                    {
                        buscar = false;                   //Entonces se hace falso
                        break;                            //Sale del bucle para no seguir buscando
                    }
                }
                if (buscar)                               //Si encuentra el que buscó
                    return i;                             //devolverá la posición
            }
            return -1;                                    //si no, la posición tomará el valor de -1
        }
        static void Main(string[] args)
        {
                     //Pedimos ingresar cadena principal
            Console.Write("Ingrese una cadena o frase: ");
            string principal = Console.ReadLine();

                     //Pedimos ingresar cadena a buscar
            Console.Write("Ingrese que cadena desea buscar: ");
            string cadena = Console.ReadLine();

                     //Usamos la función para buscar la posición
            int posicion = Busqueda(principal, cadena);


            //Por último, si se encontró enviaremos un mensaje con la posición
            if (posicion != -1)
                Console.WriteLine("La cadena se encontró en la posición: " + posicion);
            //Caso contrario, gracias a -1, podemos escribir un mensaje que indique que no se encontró
            else
                Console.WriteLine("No se encontró la cadena dentro de la frase");

            Console.ReadKey();
        }
    }
}
