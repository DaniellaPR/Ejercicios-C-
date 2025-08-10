using System;
using System.Diagnostics.Eventing.Reader;

namespace clase
{
    class ListaSimple
    {
        private string elemento;
        private ListaSimple sig;
        public ListaSimple()
        {
            this.elemento = null;
            this.sig = null;
        }
        public ListaSimple(string dato)
        {
            this.elemento = dato;
            this.sig = null;
        }
        public bool Vacia()
        //Devuelve true si la lista está vacía
        {
            bool resultado = false;
            if (elemento == null && sig == null)
                resultado = true;
            return resultado;
        }
        public void InsertarFinal(string dato)
        //Inserta a dato como nuevo nodo al final de la lista
        {
            ListaSimple p = this; //Avanzará hasta el último nodo
            ListaSimple nuevo; //Nuevo nodo que se va a anexar a la lista
            if (Vacia()) //Se inserta el primer nodo
                elemento = dato;
            else //El segundo nodo o superior
            {
                while (p.sig != null) //p llega a apuntar al último nodo
                    p = p.sig;
                nuevo = new ListaSimple(dato);
                p.sig = nuevo;
            }
        }

        public void InsertarInicio(string dato)
        {
            /*
             * Se duplica el primer nodo y se inserta como segundo nodo
             * a ese duplicado. Luego se sustuye el contenido de el nodo
             * apuntado por this por dato en el primer nodo
             */
            ListaSimple nuevo, p;
            if (Vacia()) //Se va a insertar el primer nodo
                this.elemento = dato;
            else //Se va a ingresar el segundo nodo o superior
            {
                p = this.sig;
                nuevo = new ListaSimple(this.elemento); //Se copia el primer nodo en nuevo
                this.elemento = dato;
                this.sig = nuevo;
                nuevo.sig = p;
            }
        }

    }
    class Nodo
    {
        internal string elemento;
        internal Nodo ant, sig;

        public Nodo(string dato = null)
        {
            elemento = dato;
            ant = sig = null;
        }
    }
    class ListaDoble
    {
        private Nodo ini, fin;
        public ListaDoble()
        {
            ini = new Nodo();
            fin = new Nodo();
            ini.sig = fin;
            fin.ant = ini;
        }

        public bool Vacia()
        {
            bool resultado = false;
            if (ini.sig == fin && fin.ant == ini && ini.elemento == null && fin.elemento == null)
                resultado = true;
            return resultado;
        }

        public void InsertarFinal(string dato) //Inserta un nuevo nodo cuyo contenido sera dato al final de la lista junto al nodo fin
        {
            Nodo p = fin.ant;
            Nodo nuevo = new Nodo(dato);
            Conectar(p, nuevo, fin);
        }

        public void InsertarInicio(string dato)
        {
            Nodo p = ini.sig;
            Nodo nuevo = new Nodo(dato);
            Conectar(ini, nuevo, p);
        }
        public void Conectar(Nodo a, Nodo b, Nodo c)
        {
            a.sig = b;
            b.sig = c;
            c.ant = b;
            b.ant = a;
        }

        public void Ver(bool recorrer = true)
        {
            Nodo p = ini.sig;
            if (recorrer)
            {
                while (p.sig != fin)
                {
                    Console.Write(p.elemento + "<=>");
                    p = p.sig;
                }
                Console.Write(p.elemento);
            }
            else
            {
                p = fin.ant;
                while (p.ant != ini)
                {
                    Console.Write(p.elemento + "<=>");
                    p = p.ant;
                }
                Console.Write(p.elemento);
            }
            Console.WriteLine();
        }

        public int EliminarDespuesDe(string buscado, bool todos = false)
        {
            //Elimina la primera ocurrencia del nodo que este siguiente a buscado
            //devuelve el numero de nodos eliminados
            //devuelve  0 si la lista esta vacia
            //devuelve -1 si no existe el elemento buscado
            //devuelve -2 si se intenta elminar el fin
            Nodo p = ini.sig;
            Nodo q = new Nodo();
            Nodo r = new Nodo();
            int contador = 0;
            bool encontrado = false;
            if (!Vacia())
            {
                while (p != fin && encontrado == false)
                {

                    if (p.elemento == buscado)
                    {
                        if (p.sig == fin)
                        {
                            if (contador == 0)
                                contador = -2;
                            encontrado = true;
                            todos = false;
                        }
                        else
                        {
                            q = p.sig;
                            q = q.sig;
                            p.sig = q;
                            q.ant = p;
                            if (todos == false)
                                encontrado = true;
                            contador++;
                        }
                    }
                    p = p.sig;

                }
                if (contador == 0)
                    contador = -1;
            }
            return contador;
        }
        public ListaDoble Cortar(int pos)
        {
            ListaDoble segunda = new ListaDoble();

            Nodo p = ini.sig;
            int desde = pos;
            int contador = 0;

            while (p != fin)
            {

                if (contador < desde)
                    EliminarEnPosicion(contador);
                else
                    segunda.InsertarFinal(p.elemento);

                p = p.sig;
                contador++;
            }

            return segunda;
        }

        public bool EliminarEnPosicion(int posicion)
        {
            Nodo p = ini.sig;
            int posi = 0;
            while (p != fin && posi < posicion)
            {
                p = p.sig;
                posi++;
            }
            if (p != fin && posi == posicion)
            {
                p.ant.sig = p.sig;
                p.sig.ant = p.ant;
                return true;
            }
            return false;
        }

        public ListaSimple AlistaSimple(bool finIni = false)
        {
            ListaSimple r = new ListaSimple();
            Nodo p = ini;
            if (Vacia())
            {
                return r;
            }
            else
            {
                if (finIni == false)
                {
                    while (p != fin)
                    {
                        r.InsertarFinal(p.elemento);
                        p = p.sig;
                    }

                }
                else
                {
                    while (p != fin)
                    {
                        r.InsertarInicio(p.elemento);
                        p = p.sig;
                    }
                }

            }
            return r;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            ListaDoble ld = new ListaDoble();
            int valor = 0;
            ld.InsertarFinal("A");
            ld.InsertarFinal("A");
            ld.Ver();
            valor = ld.EliminarDespuesDe("A");
            ld.Ver();
            Console.WriteLine();
            ld.InsertarFinal("A");
            ld.InsertarFinal("B");
            ld.InsertarFinal("C");
            ld.InsertarFinal("D");
            ld.InsertarFinal("E");
            ld.Ver();
            Console.WriteLine();
            ListaDoble nueva = new ListaDoble();
            nueva = ld.Cortar(2);
            ld.Ver();
            nueva.Ver();
            Console.ReadKey();
        }

    }
}
