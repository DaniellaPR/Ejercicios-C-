using System;
using System.Collections.Generic;

namespace ArbolABO
{
    class Nodo
    {
        protected int elemento; //Contenido de un nodo
        protected Nodo izq, der;

        //Constructor
        public Nodo(int dato = -99999)
        {
            this.elemento = dato;
            this.izq = this.der = null;
        }

        //Devuelve true si el nodo de la llamada está vacío
        public bool Vacio()
        {
            if (this.elemento == -99999 && this.izq == null && this.der == null)
                return true;
            return false;
        }

        //Realiza el recorrido en Inorden del árbol y lo presenta por pantalla
        public void InordenRec()
        {

            if (this.izq != null)
                this.izq.InordenRec(); //Se recorre en inorden por la izquierda
            Console.Write(this.elemento + " "); //Se imprime la raíz
            if (this.der != null)
                this.der.InordenRec(); //Se recorre en inorden por la derecha
        }

        //Imprime por pantalla el recorrido Inorden o vacío si no tiene datos
        public void Inorden()
        {
            if (Vacio())
                Console.Write("Árbol sin datos");
            else
            {
                Console.Write("Recorrido en Inorden: ");
                InordenRec();
            }
            Console.WriteLine();
        }

        //Genera el Arbol ABO
        public void GenerarABO(int[] arreglo)
        {
            Nodo ap = this;
            bool salir;
            int i;
            if (Vacio())
                this.elemento = arreglo[0]; //El primer elemento del arreglo es la raiz
            for (i = 1; i < arreglo.Length; i++) //For para insertar cada elemento del arreglo
            {
                ap = this;
                salir = false; //Para finalizar el proceso
                while (!salir)
                {
                    if (arreglo[i] <= ap.elemento) //Si elemento es menor o igual que el nodo analizado pregunto;
                    {
                        if (ap.izq == null) //Si no hay nada por la izquierda
                        {
                            ap.izq = new Nodo(arreglo[i]); //Se ingresa el nuevo nodo
                            salir = true; //Se termina el proceso
                            break; //Sale del bucle
                        }
                        else //Sí, si hay
                            ap = ap.izq; //Avanza por la izquierda del nodo analizado
                    }
                    else
                    {
                        if (arreglo[i] > ap.elemento) //Si elemento es mayor o igual que el nodo analizado pregunto;
                        {
                            if (ap.der == null) //Si no hay nada por la derecha
                            {
                                ap.der = new Nodo(arreglo[i]); //Se ingresa el nuevo nodo 
                                salir = true; //Se termina el proceso
                                break; //Sale del bucle
                            }
                            else //Sí, si hay
                                ap = ap.der; //Avanza por la derecha del nodo analizado
                        }
                    }
                }
            }
        }
        public void Ver() //Presenta el árbol de modo visual por consola
        {
            if (Vacio())
                Console.WriteLine("Arbol vacío");
            else
            {
                VerRecursivo2("", true);
                Console.WriteLine();
            }
        }
        protected void VerRecursivo2(string espacio, bool nodoDer) //Parte recursiva del anterior, segunda versión, con marcos visuales
        {
            string borde = nodoDer ? "└──" : "├──"; //Ascii: └192, ├195, ─196, │179
            if (espacio == "" && nodoDer == true) //Nodo raiz
                Console.Write("   " + elemento);
            else //Cualquier otro nodo
                Console.Write(espacio + borde + elemento);
            espacio += nodoDer ? "   " : "│  ";
            Console.WriteLine();
            if (this.izq != null)
                this.izq.VerRecursivo2(espacio, false);
            if (this.der != null)
                this.der.VerRecursivo2(espacio, true);
        }
    }
}
