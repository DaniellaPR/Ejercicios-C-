using System;
//Pozo Daniela
namespace PaulaPozo
{
    class Nodo
    {
        private string elemento;
        private Nodo sig;

        public Nodo(string dato = null)
        {
            sig = null;
            elemento = dato;
        }
        public string Elemento
        {
            get { return elemento; }
            set { elemento = value; }
        }
        public Nodo Sig
        {
            get { return sig; }
            set { sig = value; }
        }
    }
    class ListaCircular
    {
        private Nodo ini;
        public ListaCircular()
        {
            ini = null;
        }
        public bool Vacia()
        {
            Nodo p;
            bool resp = false;
            if (ini == null)
            {
                resp = true;
            }
            return resp;
        }
        public void InsertarF(string dato)
        {
            Nodo p = ini;
            Nodo q = new Nodo(dato);
            if (Vacia())
            {
                ini = new Nodo();
                ini.Elemento = dato;
                ini.Sig = ini;
                Console.WriteLine();
            }
            else
            {
                while (p.Sig != ini)
                {
                    p = p.Sig;
                }
                if (p.Sig == ini)
                {
                    p.Sig = q;
                    q.Sig = ini;
                }

            }
        }
        public int Contar()
        {
            Nodo p = ini;
            int total = 0;
            while (p.Sig != ini)
            {
                p = p.Sig;
                total++;
            }
            return total + 2;
        }

        public string Eliminado(int distancia, bool depuracion = false)
        {
            Nodo p = ini;
            Nodo q = p.Sig;
            int cont = distancia;
            while (p.Sig != p)
            {
                while (cont > 2)
                {
                    p = p.Sig;
                    cont--;
                }
                if (distancia <= 1)
                {
                    while (p.Sig != ini)
                    {
                        p = p.Sig;
                    }
                    q = p.Sig;
                    ini = q.Sig;
                    p.Sig = ini;
                }
                else
                {
                    q = p.Sig;
                    if (q == ini)
                        ini = q.Sig;
                    p.Sig = q.Sig;
                    cont = distancia;
                    p = p.Sig;
                }
                if (depuracion)
                {
                    int soldados = Contar();
                    Console.WriteLine("Quedan " + soldados + " soldados. Muere el soldado #: " + q.Elemento);
                }
            }
            return p.Elemento;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("----------Selección del Martir------------");
            Console.WriteLine();
            bool depurar = false;
            string seguir = "s";
            while (seguir == "s" || seguir == "S")
            {
                ListaCircular l = new ListaCircular();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Ingrese el número de soldados: ");
                int soldado = Convert.ToInt32(Console.ReadLine());
                Console.Write("Ingrese la distancia: ");
                int dist = Convert.ToInt32(Console.ReadLine());
                if (dist <= 0)
                {
                    Console.WriteLine("Posición invalida, terminando el programa");
                    break;
                }

                for (int i = 1; i <= soldado; i++)
                    l.InsertarF(Convert.ToString(i));
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("Desea activar el MODO DEPURACIÓN? (s/n) ");
                Console.ForegroundColor = ConsoleColor.Gray;
                string DEPURAR = Console.ReadLine();
                Console.WriteLine();
                if (DEPURAR == "s")
                {
                    depurar = true;
                    string viv = l.Eliminado(dist, depurar);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Josefo se salvará en la posición: " + viv);
                }
                else
                {
                    string vivo = l.Eliminado(dist);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Josefo se salvará en la posición: " + vivo);
                }
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Desea repetir? (s/n): ");
                seguir = Console.ReadLine();
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
