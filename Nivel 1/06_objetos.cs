using System;
using System.Security.Cryptography.X509Certificates;

namespace Clase4Objetos
{
    internal class Libro
    {
        public string autor; //accesible desde cualquier lugar
        private string titulo; //Accesible desde la misma clase
        protected float precio; //Accesible desde ñas misma clase o clases hijas (derivadas)
        internal int anioPub; //Accesible desde l msimo proyecto
        int numPag; //

        public void FuncionClase()
        {
            Libro l3 = new Libro();
            l3.autor = "Dan Brown";
            l3.titulo = "Fortaleza Digital";
            l3.precio = 35;
            l3.anioPub = 1998;
            l3.numPag = 650;
        }
    }
    internal class Novela :Libro
    {
        public void FuncionFueraClase()
        {
            Novela n1=new Novela();
            n1.autor = "Richard Assimov";
            n1.anioPub = 1950;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Libro l1 = new Libro();
            Libro l2 = new Libro();
            l1.autor = "Ken Follet";
            l1.anioPub = 1989;
            l1.FuncionClase();
        }
    }
}
