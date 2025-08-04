using System;
using System.Collections.Generic;

namespace Clase4NovelaHerencia
{
    internal class Libro
    {
        private string autor;
        private string titulo;
        private float precio;


        public Libro(string aut, string tit, float pre)
        {
            autor = aut;
            titulo = tit;
            precio = pre;
        }
        public Libro(float precio)
        {
            this.autor = "Sin autor";
            this.titulo = "Sin titulo";
            this.precio = precio;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Libro l1;
            Libro l2 = new Libro();
            Libro l3 = new Libro(12);
            l1 = new Libro("Ken Follet", "Lazy caida de los gigantes", 45);
        }
    }
}
