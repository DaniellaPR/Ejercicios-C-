using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
//Paula Pozo
namespace Arboles
{
    //Árbol creado en clase
    public class Nodo
    {
        public int contenido;
        public Nodo izq, der;

        //*******************Constructor**********************
        public Nodo(int contenido = 0)
        {
            this.contenido = contenido;
            this.izq = this.der = null;
        }

        //********************Métodos**********************
        public bool Vacio()                 //indica si el arbol esta vacio o no
        {
            bool vacio = false;             //definimos la variable vacio como false
            if (this.izq == null && this.contenido == 0 && this.der == null) //si el arbol no tiene hijos y su contenido es 0
                vacio = true;               //entonces el arbol esta vacio
            return vacio;                   //retornamos el valor de la variable vacio
        }

        //public Nodo Insertar(int valor)            //insertar un nuevo nodo con parámetro del nuevo valor
        //{
        //    if (this.contenido == 0)               //si el arbol esta vacio
        //    {
        //        this.contenido = valor;            //asignamos el valor al contenido
        //        return this;
        //    }
        //    if (valor < this.contenido)            //si el nuevo valor es menor al contenido
        //    {
        //        if (this.izq == null)
        //            this.izq = new Nodo(valor);    //creamos un nuevo nodo a la izquierda
        //        else
        //            this.izq.Insertar(valor);      //sino llamamos al método recursivamente
        //    }
        //    else if (valor > this.contenido)       //si el nuevo valor es mayor al contenido
        //    {
        //        if (this.der == null)
        //            this.der = new Nodo(valor);    //creamos un nuevo nodo a la derecha
        //        else
        //            this.der.Insertar(valor);      //sino llamamos al método recursivamente
        //    }
        //    return this;
        //}
        public Nodo Insertar(int valor)
        {
            if (valor<contenido)
            {
                izq = izq == null ? new Nodo(valor) : izq.Insertar(valor);
            }
            else if(valor>contenido)
            {
                der = der == null ? new Nodo(valor) : der.Insertar(valor);
            }
            return this;
        }
        public void Inorden()                             //indica si el arbol esta vacio o presenta por pantalla el recorrido en Inorden
        {
            if (Vacio())
                Console.WriteLine("Arbol vacio");
            else
                InordenRec();
            Console.WriteLine();
        }
        public void InordenRec() //indica si el arbol esta vacio o presenta por pantalla el recorrido en Inorden de forma recursiva
        {
            if (this.izq != null)
                this.izq.InordenRec();
            Console.Write(this.contenido + " ");
            if (this.der != null)
                this.der.InordenRec();

        }
        public bool Buscar(int valor)     //busca un valor en el árbol
        {
            bool encontrado = false;
            if (valor == this.contenido)                                //si el valor es igual al contenido
                encontrado = true;                                      //retornamos true
            else if (valor < this.contenido)                            //si el valor es menor al contenido
                return this.izq != null && this.izq.Buscar(valor);      //buscamos en el subárbol izquierdo

            else                                                        //si el valor es mayor al contenido
                return this.der != null && this.der.Buscar(valor);      //buscamos en el subárbol derecho
            return encontrado;
        }
        public int Minimo()       //busca el valor mínimo en el árbol
        {
            Nodo actual = this;
            while (actual.izq != null)
                actual = actual.izq;
            return actual.contenido;
        }

        public int Maximo()       //busca el valor máximo en el árbol
        {
            Nodo actual = this;
            while (actual.der != null)
                actual = actual.der;
            return actual.contenido;
        }
        public int Altura()      //calcula la altura del árbol
        {
            int altIzq = 0;
            int altDer = 0;

            if (this.izq != null)
                altIzq = this.izq.Altura();

            if (this.der != null)
                altDer = this.der.Altura();

            if (altIzq > altDer)
                return 1 + altIzq;
            else
                return 1 + altDer;
        }
        public void Ver1(string espacio = "") //indica si el arbol esta vacio o presenta por pantalla el recorrido en preorden de forma recursiva
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
        public void TomarDatos()  //toma por teclado los datos separados por espacios
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Ingrese los números sin repetir separados por espacios: ");
            string linea = Console.ReadLine();
            char sep = ' ';
            string[] num = linea.Split(sep);
            for (int i = 0; i < num.Length; i++)
                Insertar(Convert.ToInt32(num[i]));
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

    }
    class Program
    {

        static void Main(string[] args)
        {
            //Creamos un árbol binario
            Nodo arbol = new Nodo();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("*****************Árbol Binario*****************");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Árbol no balanceado");
            //Tomamos los datos por teclado
            arbol.TomarDatos();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Los datos han sido colocados...");                    //Mensaje de verificación
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Altura: ");                                              //Mensaje que indica que se presentarán los datos ordenados
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            //LLamamos al método Altura para presentar la altura del árbol
            Console.WriteLine(arbol.Altura());
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Máximo: ");                                               //Mnensaje para el maximo
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            //LLamamos al método Maximo para presentar el valor máximo del árbol
            Console.WriteLine(arbol.Maximo());
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Minimo: ");                                              //Mensaje para el mínimo
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            //LLamamos al método Minimo para presentar el valor mínimo del árbol
            Console.WriteLine(arbol.Minimo());
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Árbol visual: ");                                    //Mensaje que indica que se presentará el árbol por niveles
            //LLamamos al método Ver1 para presentar el árbol visualmente
            arbol.Ver1();
            Console.Write("¿Desea buscar un número? (s/n): ");                      //Preguntamos si se desea buscar un número
            string continuar = Console.ReadLine();
            while (continuar == "s")       //Bucle para buscar mientras desee
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("Número: ");
                int buscar = Convert.ToInt32(Console.ReadLine());               //Se lee número por teclado
                bool encontrado = arbol.Buscar(buscar);                         //Llamamos al método Buscar para buscar el número
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                if (encontrado == true)                                         //si el número fue o no encontrado
                    Console.WriteLine("El número fue encontrado");              //Imprimimos un mensaje de verificación
                else
                    Console.WriteLine("El número no fue encontrado");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("¿Desea buscar otro número? (s/n): ");            //Preguntamos si se desea buscar otro número
                continuar = Console.ReadLine();
            }

            Console.WriteLine();
            string continuar2 = "s";
            while (continuar2 == "s")
            {
                //Bucle para menu al usuario y elija el recorrido que desea
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("¿Qué recorrido desea realizar?");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("1: Preorden\n2: Inorden\n3: Postorden");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("Número: ");
                int recorrido = Convert.ToInt32(Console.ReadLine());
                if (recorrido == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("Recorrido en preorden: ");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    arbol.PreordenRec();
                }
                else if (recorrido == 2)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("Recorrido en inorden: ");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    arbol.Inorden();
                }
                else if (recorrido == 3)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("Recorrido en postorden: ");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    arbol.Postorden();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opción no válida");
                }

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("Desea realizar otro recorrido? (s/n): ");            //Preguntamos si se desea realizar otro recorrido
                continuar2 = Console.ReadLine();                                        //Leemos la respuesta por teclado
            }

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Gracias por usar el programa...");

            Console.ReadKey();
        }
    }
}
