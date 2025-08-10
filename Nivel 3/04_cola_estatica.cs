using System;

namespace ColaEstatica
{
    class Cola
    {
        int ini, fin; //Posiciones de inicio y fin + 1 de los elementos
        char[] elementos; //Arreglo que maneja la estructura estática cola

        public Cola(int tamanio)
        //Constructor: recibe el tamaño de la cola
        {
            elementos = new char[tamanio];
            ini = fin = 0;
        }
        public bool Vacia()
        //Informa si la cola está vacía
        {
            bool resultado = false;
            if (ini == fin) //Si el inicio y el fin están en el mismo lugar, entonces está vacía
                resultado = true;
            return resultado;
        }
        public bool Llena()
        //Informa si la cola está llena
        {
            bool resultado = false;
            if (ini == 0 && fin == elementos.Length)
                resultado = true;
            return resultado;
        }
        public bool Colocar(char dato)
        //Agrega a dato al final de la cola, devuelve true si la operación fue exitosa
        {
            bool resultado = false;
            if (!Llena()) //Sí se puede insertar un dato
            {
                if (fin == elementos.Length) //Todo está pegado al final, pero hay posiciones libres al inicio
                    Reorganizar(); //Se moverán todos los datos al inicio del arreglo
                elementos[fin++] = dato;
                resultado = true;
            }
            return resultado;
        }
        public void Reorganizar()
        //Mueve los datos del arreglo para que queden pegados al inicio del arreglo
        {
            int i, j;
            for (i = ini, j = 0; i < fin ; i++, j++)
            {
                elementos[j] = elementos[i];
                elementos[i] = '\0';
            }
            ini = 0;
            fin = j;
        }
        public char Tomar()
        //Toma y devuelve el siguiente elemento en salir de la cola según sistema FIFO
        //Si la cola está vacía, devuelve '\0'
        {
            char resultado = '\0';
            if (!Vacia()) //Solo se puede tomar si no está vacía
            {
                resultado = elementos[ini];
                elementos[ini++] = '\0';
            }
            return resultado;
        }

        public void Ver()
        //Permite ver por consola los elementos de la cola o saber si está vacía
        //Además, si está llena indica que así es
        {
            int i;
            if (Vacia())
                Console.Write("Cola vacía");
            else
            {
                Console.Write("Cola");
                if (Llena())
                    Console.Write("(llena)");
                Console.Write(": ");
                for (i=ini; i<fin; i++)
                    Console.Write(elementos[i] + " ");
            }
            Console.WriteLine();
        }
        public int Contar()
        {
            int resultado = 0;
            if (!Vacia())
                resultado = fin - ini;
            return resultado;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Cola cola = new Cola(8);
            int total;
            bool b;
            char r;
            cola.Ver();
            total = cola.Contar();
            b = cola.Colocar('a');
            total = cola.Contar();
            cola.Ver();
            b = cola.Colocar('b');
            b = cola.Colocar('c');
            total = cola.Contar();
            cola.Ver();
            r = cola.Tomar();
            r = cola.Tomar();
            total = cola.Contar();
            b = cola.Colocar('d');
            b = cola.Colocar('e');
            total = cola.Contar();
            cola.Ver();
            b = cola.Colocar('f');
            b = cola.Colocar('g');
            r = cola.Tomar();
            r = cola.Tomar();
            r = cola.Tomar();
            r = cola.Tomar();
            r = cola.Tomar();
            r = cola.Tomar();
            b = cola.Colocar('h');
            b = cola.Colocar('i');
            b = cola.Colocar('j');
            b = cola.Colocar('l');
            b = cola.Colocar('m');
            b = cola.Colocar('n');
            b = cola.Colocar('o');
            b = cola.Colocar('p');
            b = cola.Colocar('q');
            b = cola.Colocar('r');
            total = cola.Contar();
            cola.Ver();
        }
    }
}
