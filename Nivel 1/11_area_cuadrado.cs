using System;

namespace Ejercicio1
{
    class Cuadrado
    {
        private int lado;

        //Inciacmos con constructor
        public Cuadrado(int lado)
        {
            this.lado = lado;
        }

        //Función para calcular el área
        public int CalcularArea()
        {
            return lado * lado;
        }

        //Ahora con metodo para obetner el lado
        public int ObtenerLado()
        {
            return lado;
        }
    }

    class Pirámide
    {
        public void MostrarAreaCuadrado(int lado)
        {
            Cuadrado cuadrado = new Cuadrado(lado);
            int area = cuadrado.CalcularArea();
            Console.WriteLine($"El área del cuadrado con lado {cuadrado.ObtenerLado()} es: {area}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Pirámide pirámide = new Pirámide();
            pirámide.MostrarAreaCuadrado(85);
            Console.ReadKey();
        }
    }
}
