using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolesBi
{
    //Árbol Binario en clase PozoP
    public class Nodo
    {
        public string contenido;
        public Nodo izq, der;

        public Nodo(string contenido = null)
        {
            this.contenido = contenido;
            this.izq = this.der = null;
        }

        public void Eliminar()
        {
            contenido = null;
            izq = der = null;
        }

        public bool Vacio()
        {
            bool vacio = false;
            if (this.izq == null && this.contenido == null && this.der == null)
            {
                vacio = true;
            }
            return vacio;
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

        public void Ver1(string espacio="") //indica si el arbol esta vacio o presenta por pantalla el recorrido en preorden de forma recursiva
        {
            Console.WriteLine(espacio + contenido);
            espacio += "   ";
            if (this.izq != null)
            {
                this.izq.Ver1(espacio);
            }
            if (this.der != null)
            {
                this.der.Ver1(espacio);
            }

        }
        public void Ver2(string espacio="", bool nodoDer=true)
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
        public Nodo BuscarPreorden(string caracter)
        {
            Nodo resultado=new Nodo();
            bool encontrado=false;
            if (this.contenido != caracter)
            {
                if (this.izq != null)
                {
                    resultado = this.izq.BuscarPreorden(caracter);
                    if (resultado != null)
                        encontrado=true;
                }
                if (this.der != null && encontrado==false)
                {
                    resultado = this.der.BuscarPreorden(caracter);
                    if (resultado != null)
                        encontrado = true;
                }
            }
            else if (this.contenido == caracter)
            {
                resultado = this;
            }
            else
                resultado = null;
            return resultado;

        }
        public void Inorden()
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
        public void GenerarRaiz()
        {
            string raiz;
            this.Eliminar();
            Console.Write("Ingrese el contenido de la raiz");
            this.contenido = Console.ReadLine();
            GenerarRec();

        }

        public void Anchura()
        {
            Queue<Nodo> cola = new Queue<Nodo>();
            Nodo p = this;//Referencia a la raiz
            cola.Enqueue(p);
            while (cola.Count >= 1)
            {
                p = cola.Dequeue();
                if (p.izq == null)
                    cola.Enqueue(p.izq);
                if (p.der == null)
                    cola.Enqueue(p.der);
                Console.Write(p.contenido + " ");
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
                this.izq = new Nodo(dato);
                this.izq.GenerarRec();
            }
            //Inserta por la derecha
            Console.Write($"Nodo {this.contenido}. Tiene hijo por la izquieda (s/n)");
            op = Console.ReadLine().ToLower();
            if (op == "s")
            {
                Console.Write("¿Contenido?...");
                dato = Console.ReadLine();
                this.der = new Nodo(dato);
                this.der.GenerarRec();
            }
        }

        public bool InsertarDespuesDePre(string dato, string buscado, bool ins_izq, bool resto_izq)
        {
            bool encontrado = false;
            Nodo p;
            Nodo busca=new Nodo();
            Nodo nuevo=new Nodo(dato);
            busca=BuscarPreorden(buscado);

            /*Inserta un nuevo nodo cuyo contenido será dato despues de encontrar la primera 
            ocurrencia de buscado en el arbol mediante recorrido preorden
            si ins_izq es verdades, inserta a la izquierda del nodo buscado,sino a la derecha. 
            Si resto_izq e verdadero, el resto del arbol que existia previo a la insersión va a parar a la izquierda del nuevo nodo
            isertado, sino a la derecha
            Devuelve true si se logra hacer la inserición*/
            if (BuscarPreorden(buscado) != null)
            {
                if (ins_izq)
                {
                    p = busca.izq;
                    busca.izq = nuevo;
                    if (resto_izq)
                        nuevo.izq = p;
                    else
                        nuevo.der = p;
                   
                    
                }
                else
                {
                    p=busca.der;
                    busca.der = nuevo;
                    if (resto_izq)
                        nuevo.izq = p;
                    else
                        nuevo.der = p;
                }
            }
            return encontrado;
        }
        //Busca el padre de un nodo
        public Nodo BuscarPadre(Nodo buscado)
        {
            Nodo respuesta = null;
            if (!Vacio())
                BuscarPadreRec(buscado, ref respuesta);
            return respuesta;
        }
        //Parte recursiva del método anterior
        protected void BuscarPadreRec(Nodo buscado, ref Nodo resultado)
        {
            if(izq!=null)
                izq.BuscarPadreRec(buscado, ref resultado);
            if ((this.izq != null && this.izq == buscado) || (this.der != null && this.der == buscado));
            {
                resultado = this;
                return;
            }
            if (der !=null)
                der.BuscarPadreRec(buscado, ref resultado);
        }
        //Elimina
        public Nodo Eliminar(string buscado)
        {
            Nodo resultado;
            Nodo elim = new Nodo(), papa;
            this.BuscarPreorden(buscado);
            papa = this.BuscarPadre(elim);
            resultado = elim;
            if (papa.izq == elim)
                papa.izq = null;
            else if (papa.der == elim)
                papa.der = null;
            return resultado;
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Nodo arbol = new Nodo();
            bool prueba=false;
            arbol.PreordenRec();
            arbol.DatosPrueba();
            /*Nodo arbol = new Nodo();      
            arbol.PreordenRec();
            arbol.InordenRec();
            arbol.PostordenRec();
            arbol.Eliminar();
            arbol.PreordenRec();
            arbol.InordenRec();
            arbol.PostordenRec();*/
            Console.WriteLine("arbol antes");
            arbol.Ver2();
            arbol.InsertarDespuesDePre("X","B",false,false);
            Console.WriteLine("arbol despues");
            arbol.Ver2();
            Console.WriteLine("Eliminar");
            arbol.Eliminar("D");
            arbol.Ver2();
            Console.ReadKey();
        }
    }
}
