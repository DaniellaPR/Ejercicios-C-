using System;
using System.Collections.Generic;
//Visual mal hecho :c
//Pero se entiende :D
//No funciona con 3, 6, 8, 9...
namespace Zapatito_Cochinito
{
    public class ListaCircular
    {
        int valor;
        bool izq;
        ListaCircular sig;

        public ListaCircular()
        {
            valor = -1;
            izq = false;
            sig = this;
        }
        public ListaCircular(int dato)
        {
            valor = dato;
            izq = false;
            sig = this;
        }
        public bool Vacia()
        {
            return this.sig == this && this.valor == -1;
        }
        public void InsertarFinal(int dato)
        {
            ListaCircular ap = this, nuevo;
            if (Vacia())
                this.valor = dato;
            else
            {
                while (ap.sig != this)
                    ap = ap.sig;
                nuevo = new ListaCircular(dato);
                ap.sig = nuevo;
                nuevo.sig = this;
            }
        }
        public void GenerarListaInicial(int n)
        {
            for (int i = 0; i < n; i++)
                InsertarFinal(i);
        }
        public int Contar()
        {
            ListaCircular ap = this;
            int total = 0;
            if (!Vacia())
            {
                total = 1;
                while (ap.sig != this)
                {
                    ap = ap.sig;
                    total++;
                }
            }
            return total;
        }
        public void EliminarPos(ListaCircular nodo)
        {
            ListaCircular ap = this;
            if (nodo == this)
            {
                this.valor = this.sig.valor;
                this.izq = this.sig.izq;
                this.sig = this.sig.sig;
            }
            else
            {
                while (ap.sig != nodo)
                    ap = ap.sig;
                ap.sig = nodo.sig;
            }
        }

        public void MostrarEstado(ListaCircular nodo, int posicionSilaba, string[] silabas, int distancia, ListaCircular jugadorFinal)
        {
            //1. Obtener lista de jugadores
            List<(int jugador, bool izq)> jugadores = new List<(int, bool)>();
            ListaCircular temp = nodo;
            do
            {
                jugadores.Add((temp.valor+1, temp.izq));
                temp = temp.sig;
            } while (temp != nodo);

            int numJugadores = jugadores.Count;

            //2. Imprimir fila de jugadores
            for (int i = 0; i < numJugadores; i++)
            {
                if (jugadores[i].jugador == jugadorFinal.valor)
                    Console.ForegroundColor = ConsoleColor.Red;
                else if (jugadores[i].izq)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                else
                    Console.ForegroundColor = ConsoleColor.Green;

                Console.Write($"{(jugadores[i].jugador),6}");
                Console.ResetColor();
            }
            Console.WriteLine();

            //3. Imprimir sílabas, alineadas con jugadores
            int Silaba = 0;
            int silabasRestantes = distancia;

            while (silabasRestantes > 0)
            {
                for (int i = 0; i < numJugadores && silabasRestantes > 0; i++)
                {
                    if (silabasRestantes == 1) // Última sílaba
                        Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write($"{silabas[Silaba % silabas.Length],6}");
                    Console.ResetColor();

                    Silaba++;
                    silabasRestantes--;
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            //4. Lista de jugadores con colores
            Console.Write("Jugadores: [");
            for (int i = 0; i < numJugadores; i++)
            {
                if (jugadores[i].jugador == jugadorFinal.valor)
                    Console.ForegroundColor = ConsoleColor.Red;
                else if (jugadores[i].izq)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                else
                    Console.ForegroundColor = ConsoleColor.Green;

                Console.Write(jugadores[i].jugador);
                Console.ResetColor();

                if (i < numJugadores - 1)
                    Console.Write(", ");
            }
            Console.WriteLine("]");
            Console.WriteLine();
        }



        public int ResolverZapatitoCochinito(int numJugadores, int distancia)
        {
            string[] silabas = { "zapa", "tito", "cochi", "nito", "cam", "bia", "de", "pie", "ci", "to" };
            ListaCircular x = this;
            ListaCircular y;
            int solucion = 0;
            int posicionSilaba = 0;

            this.GenerarListaInicial(numJugadores);

            while (Contar() > 1)
            {
                ListaCircular inicioRonda = x;
                ListaCircular tempCalc = x;
                int sibTemp = posicionSilaba;
                for (int i = 0; i < distancia; i++)
                {
                    tempCalc = tempCalc.sig;
                    sibTemp = (sibTemp + 1) % silabas.Length;
                }
                ListaCircular jugadorFinal = tempCalc;
                

                MostrarEstado(inicioRonda, posicionSilaba, silabas, distancia, jugadorFinal);

                for (int i = 0; i < distancia - 1; i++)
                {
                    x = x.sig;
                    posicionSilaba = (posicionSilaba + 1) % silabas.Length;
                }

                if (x.izq)
                {
                    Console.WriteLine($"> Acabó en el jugador {x.valor + 1}: sale");
                    y = x.sig;
                    EliminarPos(x);
                    x = y;
                }
                else
                {
                    Console.WriteLine($"> Acabó en el jugador {x.valor + 1}: cambia de pie");
                    x.izq = true;
                }
                Console.WriteLine();
            }

            solucion = x.valor;
            return solucion;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int jugadores, distancia, solucion;
            ListaCircular lc = new ListaCircular();

            Console.Write("¿Cuántos jugadores hay?... ");
            jugadores = Convert.ToInt32(Console.ReadLine());
            Console.Write("¿Cuál es la distancia? (Tiene que ser 10)... ");
            distancia = Convert.ToInt32(Console.ReadLine());

            solucion = lc.ResolverZapatitoCochinito(jugadores, distancia);
            Console.WriteLine($"El ganador es el jugador {solucion + 1}");
            Console.ReadLine();
        }
    }
}
