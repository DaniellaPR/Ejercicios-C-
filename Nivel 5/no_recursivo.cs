using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozoP_PreordenRecursivo
{
    // PreordenRecursivo
    //1. Crear una pila vacía de tipo Nodo
    //2. Crear un nodo temporal y asignarle el nodo raíz
    //3. Agregar el nodo temporal a la pila
    //4. Mientras la pila no esté vacía
    //    a. Sacar el nodo de arriba de la pila e imprimir
    //    b. Agregar el nodo de la derecha del nodo retirado a la pila
    //    c. Agregar el nodo de la izquierda del nodo retirado a la pila

    public class Arbol
    {
        public Arbol izq, der;
        public int contenido;
        public Arbol(int contenido = 0)
        {
            this.contenido = contenido;
            this.izq = null;
            this.der = null;
        }
        public void Vacio()
        {
            this.izq = null;
            this.der = null;
        }
        //Método para insertar datos en el arbol
        public void Insertar(int contenido)
        {
            //Si el arbol está vacío, se asigna el contenido a la raiz
            //y se crean los hijos izquierdo y derecho como null
            if (this.izq == null && this.der == null && this.contenido == 0)
            {
                this.contenido = contenido;
                return;
            }
            //Si el contenido es menor que el contenido de la raiz
            //se inserta en el subárbol izquierdo
            //Si el contenido es mayor o igual que el contenido de la raiz
            //se inserta en el subárbol derecho

            if (contenido < this.contenido)
            {
                if (izq == null)
                {
                    izq = new Arbol(contenido);
                }
                else
                {
                    izq.Insertar(contenido);
                }
            }
            else
            {
                if (der == null)
                {
                    der = new Arbol(contenido);
                }
                else
                {
                    der.Insertar(contenido);
                }
            }
        }
        // Método para el Preorden NO Recursivo
        //1. Crear una pila vacía de tipo Arbol
        //2. Crear un nodo temporal y asignarle el nodo raíz
        //3. Agregar el nodo temporal a la pila
        //4. Mientras la pila no esté vacía
        //    a. Sacar el nodo de arriba de la pila e imprimir
        //    b. Agregar el nodo de la derecha del nodo retirado a la pila
        //    c. Agregar el nodo de la izquierda del nodo retirado a la pila
        
        //recorrido inorden
        public void InordenNoRecursivo()
        {
            Stack<Arbol> pila = new Stack<Arbol>();
            Arbol temp = this;
            while (temp != null || pila.Count > 0)
            {
                while (temp != null)
                {
                    pila.Push(temp);
                    temp = temp.izq;
                }
                if (pila.Count > 0)
                {
                    temp = pila.Pop();
                    Console.Write(temp.contenido + " ");
                    temp = temp.der;
                }
            }
            Console.WriteLine();
        }
        //recorrido postorden
        public void PostordenNoRecursivo()
        {
            Stack<Arbol> pila = new Stack<Arbol>();
            Arbol temp = this;
            pila.Push(temp);
            while (pila.Count > 0)
            {
                Arbol nodoActual = pila.Pop();
                Console.Write(nodoActual.contenido + " ");
                if (nodoActual.izq != null)
                    pila.Push(nodoActual.izq);
                if (nodoActual.der != null)
                    pila.Push(nodoActual.der);
            }
            Console.WriteLine();
        }
        //recorrido preorden
        public void PreordenNoRecursivo()
        {
            Stack<Arbol> pila = new Stack<Arbol>();
            Arbol temp = this;
            pila.Push(temp);
            while (pila.Count > 0)
            {
                Arbol nodoActual = pila.Pop();
                Console.Write(nodoActual.contenido + " ");
                if (nodoActual.der != null)
                    pila.Push(nodoActual.der);
                if (nodoActual.izq != null)
                    pila.Push(nodoActual.izq);
            }
            Console.WriteLine();
        }
        //Método para imprimir el árbol en preorden
        public void Ver2(string espacio = "", bool nodoDer = true)
        //Segunda versión, con marcos visuales
        {
            string borde = nodoDer ? "└──" : "├──"; //Ascii: └192, ├195, ─196, │179
            if (espacio == "" && nodoDer == true) //Nodo raiz
                Console.Write("   " + contenido);
            else //Cualquier otro nodo
                Console.Write(espacio + borde + contenido);
            espacio += nodoDer ? "   " : "│  ";
            Console.WriteLine();
            if (this.izq != null)
                this.izq.Ver2(espacio, false);
            if (this.der != null)
                this.der.Ver2(espacio, true);
        }
        public void Eliminar()
        {
            contenido = 0;
            izq = der = null;
        }
        public void GenerarRaiz()
        {
            this.Eliminar();
            Console.Write("Ingrese el contenido de la raiz");
            this.contenido = Convert.ToInt32(Console.ReadLine());
            GenerarRec();

        }
        public void GenerarRec()
        //Parte recursiva
        {
            string dato, op;
            //Inserta por la izuierda
            Console.Write($"Nodo {this.contenido}. Tiene hijo por la izquieda (s/n)");
            op = Console.ReadLine().ToLower();
            if (op == "s")
            {
                Console.Write("¿Contenido?...");
                dato = Console.ReadLine();
                this.izq = new Arbol(contenido);
                this.izq.GenerarRec();
            }
            //Inserta por la derecha
            Console.Write($"Nodo {this.contenido}. Tiene hijo por la izquieda (s/n)");
            op = Console.ReadLine().ToLower();
            if (op == "s")
            {
                Console.Write("¿Contenido?...");
                dato = Console.ReadLine();
                this.der = new Arbol(contenido);
                this.der.GenerarRec();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Arbol arbol = new Arbol();
            arbol.Insertar(3);
            arbol.Insertar(8);
            arbol.Insertar(1);
            arbol.Insertar(4);
            arbol.Insertar(7);
            arbol.Insertar(2);
            arbol.Insertar(6);
            arbol.Insertar(9);
            arbol.Ver2();
            arbol.InordenNoRecursivo();
            arbol.PostordenNoRecursivo();
            arbol.PreordenNoRecursivo();
            Console.ReadKey();
        }
    }
}
