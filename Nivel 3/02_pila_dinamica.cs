using System;
namespace PilaDinamica
{
    class Nodo
    {
        private int elemento; //Valor que se almacena en el nodo
        private Nodo siguiente; //Referencia al siguiente nodo
        public Nodo() //Inicia una pila vacía
        {
            this.elemento = -1;
            this.siguiente = null;
        }
        public Nodo(int dato) //Inicia un nodo con un valor inicial
        {
            this.elemento = dato;
            this.siguiente = null;
        }
        public bool Vacia() //Devuelve true si la pila está vacía
        {
            bool resultado = false;
            if (this.elemento == -1 && this.siguiente == null)
                resultado = true;
            return resultado;
        }
        public void Push(int dato) //Inserta dato al final de la pila
        {
            Nodo nuevo, p;
            if (this.Vacia()) //Se inserta el primer nodo
            { 
                nuevo = new Nodo(dato);
                this.siguiente = nuevo; //Se junta el nodo raíz con el nuevo
            }
            else //Para el segundo nodo o superior
            {
                p = this;
                while (p.siguiente != null)
                    p = p.siguiente;
                nuevo = new Nodo(dato);
                p.siguiente = nuevo; //Se junta último nodo con el nuevo
            }
        }
        public int Pop()
        //Elimina y devuelve el último elemento de la pila
        //Si la pila está vacía devuelve -1
        {
            int resultado = -1;
            Nodo p = this, q = this; //p y q inician apuntando al inicio de la pila
            if (!this.Vacia()) //Solo se puede hacer un Pop si la pila tiene datos
            {
                while (p.siguiente != null) //p avanza hasta el último nodo
                    p = p.siguiente;
                while (q.siguiente != p) //q avanza hasta un nodo antes de p
                    q = q.siguiente;
                q.siguiente = null; //Se desconecta el último nodo de la pila
                resultado = p.elemento;
            }
            return resultado;
        }
        public void Ver() //Permite ver por consola la pila o indica si está vacía
        {
            Nodo p = this.siguiente; //p inicia apuntando al segundo nodo
            if (this.Vacia())
                Console.WriteLine("Pila vacía");
            else
            {
                Console.Write("Pila: ");
                while (p != null) //Avanza hasta la flecha del último nodo
                {
                    Console.Write(p.elemento + " ");
                    p = p.siguiente;
                }
                Console.WriteLine();
            }
        }
        public int Contar() //Devuelve el número de elementos de la pila.
        {
            int total = 0;
            Nodo p = this.siguiente;
            if (!this.Vacia())
            {
                while (p != null)
                {
                    total++; //Sumar uno 
                    p = p.siguiente; //Pasar a la siguiente posición
                }
            }
            return total;
        }

        public int Peek()
        //Devuelve el próximo elemento que saldrá de la pila, pero no lo saca de la pila.
        //Si la pila está vacía devuelve -1
        {
            int resultado = -1;
            Nodo p = this; //p inicia apuntando al inicio de la pila
            if (!this.Vacia()) //Solo se puede hacer un Peek si la pila tiene datos
            {
                while (p.siguiente != null) //p avanza hasta el último nodo
                    p = p.siguiente;
                resultado = p.elemento;
            }
            return resultado;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Nodo pila = new Nodo();
            bool r;
            int dato;
            pila.Ver();
            dato = pila.Peek();
            pila.Push(3);
            pila.Ver();
            dato = pila.Peek();
            pila.Push(4);
            pila.Push(8);
            pila.Ver();
            dato = pila.Peek();
            dato = pila.Pop();
            dato = pila.Pop();
            dato = pila.Pop();
            dato = pila.Pop();
            dato = pila.Pop();
            pila.Ver();
            dato = pila.Peek();
            dato = pila.Contar();
        }
    }
}
