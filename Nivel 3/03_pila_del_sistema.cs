using System;
using System.Collections.Generic; //Estructuras de un tipo homogéneo
using System.Collections; //Estructuras de tipo abierto

namespace PilasDelSistema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Stack<int> p = new Stack<int>();
            Stack p = new Stack();
            bool booleano;
            char caracter;
            int r;
            p.Push(4);
            p.Push("8");
            p.Push("Papá");
            p.Push('x');
            p.Push(true);
            booleano = (bool)p.Pop();
            caracter = (char)p.Pop();
        }
    }
}
