using System;

namespace ColaDinamica
{
    class Cola
    {
        private string elemento;
        private Cola sig;

        public Cola(string dato = null)
        {
            this.elemento = dato;
            this.sig = null;
        }
        public bool Vacia() //Devuleve true si la cola no tiene datos
        {
            bool respuesta = false;
            if (this.elemento == null && this.sig == null)
                respuesta = true;
            return respuesta;
        }
        public void Colocar(string dato) //siemore se puede insertar void
        {
            Cola nuevo, p;
            if (Vacia())   //Inserta prrimer nodo
                this.elemento = dato;
            else //inserta segundo nodo o superior
            {
                //Una parte para todo desde segundo                                                 ESTE
                p = this.sig;
                nuevo = new Cola(this.elemento); //Se copia el primer nodo en uno nuevo
                this.sig = nuevo;
                this.elemento = dato;
                nuevo.sig = p;

                //Dos partes                                                                        O ESTE
                if (this.sig == null) //Segundo nodo
                {
                    nuevo = new Cola(this.elemento); //Se copia el primer nodo en uno nuevo
                    this.sig = nuevo;
                    this.elemento = dato;
                }
                else //todos a partir del tercero
                {
                    p = this.sig;
                    nuevo = new Cola(this.elemento); //Se copia el primer nodo en uno nuevo
                    this.sig = nuevo;
                    this.elemento = dato;
                    nuevo.sig = p;
                }
            }
        }
        public string Tomar() //Elmina último nodo y devuelve su contenido
        {
            string resultado = null;
            Cola p = this, q = this;
            if (!this.Vacia()) //Solo se hace pop si pila tiene datos
            {
                if (this.sig == null) //es ultimo nodo quye se uieres eliminar
                {
                    resultado = this.elemento;
                    this.elemento = null;
                }
                else
                {
                    while (p != null) //p aavanza hasta el ultimo noo
                        p = p.sig;
                    while (p.sig != p) //p avanza hasta un nodo antes de p
                        q = q.sig;
                    q.sig = null; //Se desconecta el ultimo nodo de la pila
                    resultado = p.elemento;

                }
            }
            return resultado;
        }
        public void Ver()
        {
            Cola p = this;
            if (!this.Vacia())
                Console.WriteLine("La piala esta vacia");

            while (p.siguiente != null)
            {
                p = p.siguiente;
                Console.Write(p.elemento);
            }
        }
        public int Contar()
        {
            int total = 0;
            Cola p = this;
            if (!this.Vacia())
            {
                while (p.sig != null)
                    p = p.sig;
                total += 1;
            }
            return total;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Cola c = new Cola();
            c.Colocar("m");
            c.Colocar("o");
            c.Colocar("p");
            c.Tomar();
        }
    }
}

