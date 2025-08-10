using System;
namespace ListaEnlazada
{
    class Nodo
    {
        private string elemento;
        private Nodo sig;
        public Nodo()
        {
            this.elemento = null;
            this.sig = null;
        }
        //Segundo constructor, sobrecarga para inserciones de datos
        public Nodo(string dato)
        {
            this.elemento = dato;
            this.sig = null;
        }
        //Vacia, si la lista está vacía ------------------------------------------------------------------
        public bool Vacia()
        {
            bool resultado = false;
            if (elemento == null && sig == null)
                resultado = true;
            return resultado;
        }
        //Insertar, inserta al final un dato ----------------------------------------------------------------
        public void InsertarFinal(string dato)
        {
            Nodo nuevo;
            Nodo p = this;
            if (Vacia()) //Si está vacía
                elemento = dato;
            else //cuando no está vacía
            {
                while (p.sig != null)
                    p = p.sig;
                nuevo = new Nodo(dato); //Se copia el primer nodo en uno nuevo
                p.sig = nuevo;

            }
        }
        //Insertar, inserta al inicio un dato --------------------------------------------------------------
        public void InsertarInicio(string dato)
        {
            Nodo nuevo, p;
            if (Vacia()) //Si está vacía
                elemento = dato;
            else //cuando no está vacía
            {
                p = this.sig;
                nuevo = new Nodo(dato); //Se copia el primer nodo en uno nuevo
                this.sig = nuevo;
                this.elemento = dato;
                nuevo.sig = p;
            }
        }
      //Eliminar del inicio ------------------------------------------------------
        public string EliminarInicio()
        {
            Nodo p = this.sig;
            string resultado = null;
            if (!Vacia())
            {
                if (this.sig == null)
                {
                    resultado = this.elemento;
                    this.elemento = null;
                }
                else
                {
                    resultado += this.elemento;
                    this.elemento = p.elemento;
                    this.sig = p.sig;
                }
            }
            return resultado;
        }

        //Tomar, elemina el último nodo y edvuelve su contenido ------------------------------------------
        public string Tomar()
        {
            string resultado = null;
            Nodo p = this, q = this;
            if (!this.Vacia()) //Solo se hace pop si pila tiene datos
            {
                if (this.sig == null) //es ultimo nodo que se quiere eliminar
                {
                    resultado = this.elemento;
                    this.elemento = null;
                }
                else
                {
                    while (p != null) //p aavanza hasta el ultimo nodo
                        p = p.sig;
                    while (p.sig != p) //p avanza hasta un nodo antes de p
                        q = q.sig;
                    q.sig = null; //Se desconecta el ultimo nodo de la pila
                    resultado = p.elemento;
                }
            }
            return resultado;
        }
        //Copia el nodo anterior -----------------------------------------------------------
        public Nodo Copiar()
        {
            Nodo copia = new Nodo();
            Nodo p = this;
            if (!this.Vacia())
            {
                while (p != null)
                {
                    copia.InsertarFinal(p.elemento);
                    p = p.sig;
                }
            }
            return copia;
        }

        //Otro invertir ----------------------------------------------------------------------
        public void Invertir(Nodo nodo)
        {
            Nodo p = new Nodo();
            nodo = new Nodo();
            if (Vacia()) //Si está vacía
                elemento = nodo.Tomar();
            else //cuando no está vacía
            {
                p = this;
                p = new Nodo(nodo.Tomar()); //Se copia el primer nodo en uno nuevo
                this.sig = p;
                this.elemento = nodo.Tomar();
                p.sig = p;
            }
        }
        //Vaciar ------------------------------------------------------------------------------
        public void Vaciar()
        {
            this.sig = null;
            this.elemento = null;
        }
      //Invertir 2 ----------------------------------------------------------------------------
        public void InvertirLista()
        {
            Nodo copia, p;
            copia =this.Copiar();
            this.Vaciar();
            if (!copia.Vacia())
            {
                p = copia;
                while(p != null)
                {
                    this.InsertarInicio(p.elemento);
                    p = p.sig;
                }
            }
        }
        //Invertir ----------------------------------------------------------------------------
        public void InvertirI()
        {
            Nodo copia = this.Copiar();
            Nodo invertido = new Nodo();
            string elemento = null;
            if (!Vacia())
            {
                while (copia !=null)
                {
                    elemento = copia.Tomar();
                    invertido.InsertarFinal(elemento);
                }
            }
            this.elemento = invertido.elemento;
            this.sig = invertido.sig;
        }

        internal class Program
        {
            static void Main(string[] args)
            {
                Nodo lista = new Nodo();
                string p;
                lista.InsertarFinal("A");
                lista.InsertarFinal("B");
                lista.InsertarFinal("C");
                p = lista.Tomar();
                p = lista.Tomar();
                lista.InsertarInicio("D");
                lista.InsertarInicio("E");
                lista.InsertarInicio("F");
                p = lista.Tomar();
                Nodo L2;
                L2 = lista.Copiar();
            }
        }
    }
}
