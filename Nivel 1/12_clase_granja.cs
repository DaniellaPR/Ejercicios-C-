using System;

namespace Ejercicio2
{
    //Clase llamada granja
    public class Granja
    {
        //Contendrá el nombre de cada animal que se ingrese
        private string Nombre;

        //Constructor para el nombre
        public Granja(string nombre)
        {
            this.Nombre = nombre;
        }

        //Función para ver la impresión de cada animal
        public void Impresión()
        {
            Console.WriteLine("-> " + Nombre);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Crear 5 animales para la granja
            Granja animal1 = new Granja("Gallina");
            Granja animal2 = new Granja("Perro");
            Granja animal3 = new Granja("Cerdo");
            Granja animal4 = new Granja("Vaca");
            Granja animal5 = new Granja("Conejo");

            Console.WriteLine("Los animales de la granja son:");
            //Imprimir la vizualización de cada uno
            animal1.Impresión();
            animal2.Impresión();
            animal3.Impresión();
            animal4.Impresión();
            animal5.Impresión();
            Console.ReadKey(); //No olvidar

        }
    }
}
