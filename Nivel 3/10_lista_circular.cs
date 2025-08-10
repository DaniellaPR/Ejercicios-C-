using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaLigadaCircular
{
    internal class Program
    {
        class Nodo
        {
            internal string elemento;
            internal Nodo sig;  //se hace publico o interno para trbajar sin 4 variables en cada nodo, pero descriptor
            public Nodo(string dato = null)
            {
                elemento = dato;
                sig = null;
            }
            //Descriptor
            //public Nodo Sig
            //{
            //    get { return sig; }
            //    set { sig = value; }
            //}

            //public string Elemento
            //{
            //    get { return elemento; }
            //    set { elemento = value; }
            //}
        }
        class ListaCircular
        {
            Nodo ini; //Referencia al primer nodo de la lista
            public ListaCircular()
            { ini = null; }

            public bool Vacia()
            {
                bool respuesta = true;
                if (ini != null)
                    respuesta = false;
                return respuesta;
            }

            public void InsertarFinal(string dato)
            {
                Nodo p, nuevo; //p Avanzará hacia un nodo antes de ini
                if (Vacia()) //Nodo a insertarse
                {
                    ini = new Nodo(dato); //Se inserta en el primer nodo
                    ini.sig = ini;
                }
                else
                {
                    p = ini; //p aumenta al primer nodo;
                    while (p.sig != ini)
                    {
                        p = p.sig;
                    }
                    nuevo = new Nodo(dato);
                    nuevo.sig = p.sig;
                    p.sig = nuevo;
                }
            }
            public void InsertarInicio(string dato)
            {
                Nodo p;
                InsertarFinal(dato);
                p = ini;
                while (p.sig != ini)
                    p = p.sig;
                ini = p;
            }
            public void Ver()
            {
                Nodo p = ini;
                if (Vacia())
                {
                    Console.WriteLine("Esta lista esta vacia");
                }
                else
                {
                    do
                    {
                        Console.WriteLine("->" + p.elemento);
                        p = p.sig;
                    } while (p != ini);
                }
                Console.WriteLine();
            }

            public void Eliminar(string dato)
            {
                if (Vacia())
                    return;

                Nodo p = ini;
                Nodo q = ini.sig;

                //Caso especial: el nodo a eliminar es el inicial
                if (ini.elemento == dato)
                {
                    if (ini == ini.sig)
                    {
                        ini = null; //Un solo nodo
                    }
                    else
                    {
                        //Buscar el último nodo para cerrar el ciclo
                        Nodo ultimo = ini;
                        while (ultimo.sig != ini)
                            ultimo = ultimo.sig;

                        ini = ini.sig; //Mover inicio
                        ultimo.sig = ini; //Cerrar ciclo con el nuevo inicio
                    }
                    return;
                }

                //Caso general: el nodo no es el inicial
                while (q != ini)
                {
                    if (q.elemento == dato)
                    {
                        p.sig = q.sig; //Saltar el nodo
                        return; //Salir tras eliminar
                    }
                    p = q;
                    q = q.sig;
                }
            }            
        }

        static void Main(string[] args)
        {
            ListaCircular l = new ListaCircular();
            l.Vacia();
            l.InsertarFinal("A");
            l.InsertarFinal("B");
            l.InsertarInicio("1");
            l.InsertarFinal("A");
            l.InsertarFinal("B");
            l.InsertarInicio("1");
            l.Ver();
            l.Vacia();
            l.Eliminar("A");
            l.Eliminar("B");
            l.Eliminar("1");


        }
    }
}

