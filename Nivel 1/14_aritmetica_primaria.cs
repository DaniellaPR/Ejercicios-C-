using System;
//Solución al ejercicio de Aritmética de Primaria

namespace ConteoArrastres
{
    internal class Program
    {
        static void Main()
        {
            string cad;
            bool salir = false;
            do
            {
                Console.Write("Ingrese las 2 cantidaders a sumar, separadas por un espacio. Con \"0 0\" finaliza... ");
                cad = Console.ReadLine();
                if (cad == "0 0")
                    salir = true;
                else
                    Console.WriteLine(VerificarArrastres(cad));
            } while (!salir);
            Console.WriteLine("Gracias por haber usado este programa");
            Console.ReadKey();
        }
        static string VerificarArrastres(string cantidades)
        {
            int num1, num2; //Los 2 números
            string[] cant = cantidades.Split(new char[] { ' ' });
            string resultado;
            int arrastres;
            num1 = Convert.ToInt32(cant[0]);
            num2 = Convert.ToInt32(cant[1]);
            arrastres = ContarArrastres(num1, num2);
            if (arrastres == 0)
                resultado = "No carry operation.";
            else if (arrastres == 1)
                resultado = "1 carry operation.";
            else
                resultado = arrastres.ToString() + " carry operations.";
            return resultado;
        }
        static int ContarArrastres(int numero1, int numero2)
        {
            int i; //Contador
            int contArrastres = 0; //Contabiliza el número de arrastres
            int arrastre = 0; //Para guardar el arrastre previo

            //Convertir los números a cadenas para obtener su longitud
            string num1 = numero1.ToString();
            string num2 = numero2.ToString();

            //Determinar la longitud del mayor de los dos números
            int maxLong = Math.Max(num1.Length, num2.Length);

            //Crear arreglos para almacenar las cifras
            int[] arr1 = new int[maxLong];
            int[] arr2 = new int[maxLong];

            //Colocar ceros al inicio de la cadena con la menor cantidad
            //Rellenar con ceros a la izquierda manualmente
            while (num1.Length < maxLong)
                num1 = "0" + num1; 
            while (num2.Length < maxLong)
                num2 = "0" + num2;

            //Llenar los arreglos con las cifras de los números de derecha a izquierda
            for (i = maxLong - 1; i >= 0; i--)
            {
                arr1[i] = Convert.ToInt32(num1.Substring(i, 1));
                arr2[i] = Convert.ToInt32(num2.Substring(i, 1));
            }

            //Contar las operaciones de arrastre
            for (i = maxLong - 1; i >= 0; i--)
            {
                int sum = arr1[i] + arr2[i] + arrastre;
                if (sum >= 10)
                {
                    arrastre = 1; //Hay un arrastre
                    contArrastres++;
                }
                else
                    arrastre = 0; //No hay arrastre
            }
            //if (arrastre >= 1) contArrastres++; //Si se quiere contar el arrastre final
            return contArrastres;
        }
    }
}
