
using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace Arbol_Binario
{
    class Nodo
    {
        private string contenido; //contenido de cada nodo
        private Nodo izq, der; //referencia a los hijos
        public Nodo(string contenido = null) // el arbol estara vacio cuando exista un unico nodo cuyo contenido sea null
        {
            this.contenido = contenido;
            this.izq = this.der = null;
        }
        public void Eliminar() //deja el arbol vacio
        {
            contenido = null;
            izq = der = null;
        }
        public void DatosPrueba()
        {
            Nodo p;
            this.Eliminar();
            this.contenido = "A";
            this.izq = new Nodo("B");
            this.der = new Nodo("E");
            // this.izq.izq = new Nodo("C");
            p = this.izq;
            p.izq = new Nodo("C");
            p.der = new Nodo("D");
            p = this.der;
            p.der = new Nodo("F");
            p = p.der;
            p.izq = new Nodo("G");
            p.der = new Nodo("H");
        }
        public void Preorden() //indica si el arbol esta vacio o presenta por pantalla el recorrido en preorden
        {
            if (Vacio())
            {
                Console.WriteLine("Arbol vacio");
            }
            else
            {
                PreordenRec();
            }
            Console.WriteLine();
        }
        public void Inorden() //indica si el arbol esta vacio o presenta por pantalla el recorrido en inorden
        {
            if (Vacio())
            {
                Console.WriteLine("Arbol vacio");
            }
            else
            {
                InordenRec();
            }
            Console.WriteLine();
        }
        public void Postorden() //indica si el arbol esta vacio o presenta por pantalla el recorrido en postorden
        {
            if (Vacio())
            {
                Console.WriteLine("Arbol vacio");
            }
            else
            {
                PostordenRec();
            }
            Console.WriteLine();
        }
        public void PreordenRec() //indica si el arbol esta vacio o presenta por pantalla el recorrido en preorden de forma recursiva
        {
            Console.Write(this.contenido + " ");
            if (this.izq != null)
            {
                this.izq.PreordenRec();
            }
            if (this.der != null)
            {
                this.der.PreordenRec();
            }

        }
        public void InordenRec() //indica si el arbol esta vacio o presenta por pantalla el recorrido en Inorden de forma recursiva
        {
            if (this.izq != null)
            {
                this.izq.InordenRec();
            }
            Console.Write(this.contenido + " ");
            if (this.der != null)
            {
                this.der.InordenRec();
            }

        }
        public void PostordenRec() //indica si el arbol esta vacio o presenta por pantalla el recorrido en Postorden de forma recursiva
        {
            if (this.izq != null)
            {
                this.izq.PostordenRec();
            }
            if (this.der != null)
            {
                this.der.PostordenRec();
            }
            Console.Write(this.contenido + " ");
        }
        public bool Vacio()
        {
            bool resp = false;
            if (this.contenido == null && this.izq == null && this.der == null)
            {
                resp = true;
            }
            return resp;
        }
        public void Generar()
        {
            //parte recurisiva del  siguiente
            string dato, op;
            //se opera por la izquierda
            Console.Write("Nodo " + this.contenido + " tiene hijo izquierdo?: ");
            op = Console.ReadLine().ToLower();
            if (op == "s")
            {
                Console.Write("Contenido: ");
                dato = Console.ReadLine();
                this.izq = new Nodo(dato);
                this.izq.Generar();
            }
            //se opera por la derecha
            Console.Write("Nodo " + this.contenido + " tiene hijo derecho?: ");
            op = Console.ReadLine().ToLower();
            if (op == "s")
            {
                Console.Write("Contenido: ");
                dato = Console.ReadLine();
                this.der = new Nodo(dato);
                this.der.Generar();
            }
        }
        public void GenerarRaiz()
        {
            //Permite ingesar arbol dsde consola
            this.Eliminar();
            Console.WriteLine("Raíz: ");
            this.contenido = Console.ReadLine();
            Generar();
        }

        public void Anchura()
        {
            //Presenta recorrido en anchura
            Queue<Nodo> cola = new Queue<Nodo>();
            Nodo p = this; //rferencia raiz
            cola.Enqueue(p);
            while (cola.Count >= 1)
            {
                p = cola.Dequeue();
                if (p.izq != null)
                    cola.Enqueue(p.izq);
                if (p.der != null)
                    cola.Enqueue(p.der);
                Console.Write(p.contenido + " ");
                
            }
            Console.WriteLine();
        }
        
        //Ver arbol este si
        public void Ver1(string espacio="")
        {
            Console.WriteLine(espacio+contenido);
            espacio += "\t";
            if (this.izq != null)
            {
                this.izq.Ver1(espacio);
            }
            if (this.der != null)
            {
                this.der.Ver1(espacio);
            }
        }
        
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            Nodo arbol = new Nodo(); //creacion del arbol
            arbol.Anchura();
            //arbol.GenerarRaiz();
            arbol.DatosPrueba();
            arbol.Preorden();
            Console.WriteLine("Ver Árbol");
            arbol.Ver1();
            Console.ReadKey();
        }
    }
}
