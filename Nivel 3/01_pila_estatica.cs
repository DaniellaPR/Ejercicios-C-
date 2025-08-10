using System;

namespace PilaEstatica
{
    class Pila
    {
        private int[] elementos;     //Datos de la pila
        private int tope;            //Límite de la pila
        public Pila(int tamanio)
        {
            int i;
            this.elementos = new int[tamanio];
            for (i = 0; i < tamanio; i++)
                this.elementos[i] = -1;
        }
        public bool Vacia()
        //Devuelve true si la pila está vacía
        {
            bool resultado = false;
            if (this.tope == 0)
                resultado = true;
            return resultado;
        }

        public bool Llena()
        //Devuelve true si la pila está llena
        { 
            bool resultado = false;
            if (this.tope >= this.elementos.Length)
                resultado = true;
            return resultado;
        }
        public bool Push(int dato)
        //Inserta a dato en la pila. Devuelve true si la operación es exitosa
        { 
            bool resultado = false; 
            if (!this.Llena()) //Solo se puede hacer push si no está llena
            {
                this.elementos[this.tope++] = dato;
                resultado = true;
            }
            return resultado;
        }
        public int Pop()
        //Retira y devuelve un dato de la pila, si la pila está vacía
        //devuelve -1
        { 
            int resultado = -1;
            if (!this.Vacia()) //Solo se puede hacer pop si no está vacía
            {
                resultado = this.elementos[--tope];
                elementos[tope] = -1;
            }
            return resultado;
        }
        public void Ver()
        //Presenta por consola la pila
        {
            int i;
            if (this.Vacia())
                Console.Write("Pila vacía");
            else
            {
                Console.Write("Pila: ");
                for (i=0;i<this.tope;i++)
                    Console.Write(this.elementos[i] + " ");
            }
            Console.WriteLine();
        }

        public int Contar()
        //Devuelve el número de elementos de la pila
        { return this.tope; }

        public int Peek()
        //Devuelve el próximo elemento que saldrá de la pila, pero no lo saca
        //Si la pila está vacía, devuelve -1
        {
            int resultado = -1;
            if (!this.Vacia()) //Solo se puede hacer pop si no está vacía
                resultado = this.elementos[tope-1];
            return resultado;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Pila p = new Pila(6);
            Pila q = new Pila(3);
            bool resp;
            int r;
            r = p.Peek();
            p.Ver();
            r = p.Contar();
            resp = p.Push(4);
            resp = p.Push(9);
            r = p.Contar();
            r = p.Peek();
            p.Ver();
            r = p.Pop();
            r = p.Pop();
            r = p.Pop();
            resp = q.Push(2);
            resp = q.Push(5);
            resp = p.Push(3);
            resp = p.Push(0);
            resp = p.Push(1);
            resp = q.Push(4);
            resp = q.Push(1);

            r = p.Contar();
            r = p.Peek();
            p.Ver();
            resp = p.Push(499);
            resp = p.Push(5);
            r = p.Contar();
            r = p.Peek();
            p.Ver();
            r = p.Pop();
            r = p.Pop();
            r = p.Pop();
            r = p.Pop();
            r = p.Pop();
            r = p.Pop();
            p.Ver();
        }
    }
}
