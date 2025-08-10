using System;
namespace Zapatito_Cochinito
{
    public class ListaCircular
    {
        int valor; //Contenido de cada nodo (posiciones de la 0 a la n-1)
        bool izq; //Todos los jugadores inician con el zapato derecho, este iniciará como falso y pasará a verdadero cuando "cambie de zapato"
        ListaCircular sig; //Apuntador al siguiente nodo
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
            if (this.sig == this && this.valor == -1)
                return true;
            else
                return false;
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
            int i;
            for (i = 0; i < n; i++)
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
        //Elimina el nodo, se asume que ap es parte de la lista, caso contrario se queda en un bucle infinito.
        //Se hace sin verificar que nodo sea parte de la lista, tampoco se verifica que no esté vacía por cuestión de tiempo; pero se sabe que para el
        //algoritmo a solucionar, al menos deben existir dos nodos en la llamada a este método
        public void EliminarPos(ListaCircular nodo)
        {
            ListaCircular ap = this;
            if (nodo == this) //No se puede eliminar el this
            {
                this.valor = this.sig.valor;
                this.sig = this.sig.sig;
            }
            else
            {
                while (ap.sig != nodo)
                    ap = ap.sig;
                ap.sig = nodo.sig;
            }
        }
        public int ResolverZapatitoCochinito(int numJugadores, int distancia)
        {
            ListaCircular x = this; //Nodo que se va a eliminar
            ListaCircular y; //Nodo cuya posición estará después del que se va a eliminar, para saber quien es el siguiente jugador
            int solucion = 0;
            int i;
            this.GenerarListaInicial(numJugadores); //Se genera la lista con los nodos iniciales
            while (Contar() > 1)
            {
                for (i = 0; i < distancia; i++) //Con este for se logrará avanzar hasta el nodo que se va a cambiar de zapato o eliminar
                    x = x.sig;
                if (x.izq) //Es lo mismo que a x.izq==true, lo que significa que ya ha cambiado de "piecito", por lo que hay que sacarlo del juego
                {
                    y = x.sig; //Se guarda la posición del siguiente nodo
                    EliminarPos(x);
                    x = y; //Se indica que el siguiente jugador es la posición guardada
                    while (x.sig.valor != y.valor) //x se ubica en la posición anterior, como es circular se puede recorrer hasta antes de ser el mismo
                        x = x.sig;
                }
                else //Debe cambiar de "piecito"
                    x.izq = true; //Cambia de "piecito"
                solucion = x.valor;
            }
            return solucion;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int jugadores; //Número de jugadores
            int distancia; //Distancia para el juego del zapatito cochinito
            int solucion; //Solución de donde debe ubicarse el jugador a ganar
            ListaCircular lc = new ListaCircular();
            Console.Write("¿Cuántos jugadores hay?... ");
            jugadores = Convert.ToInt32(Console.ReadLine());
            Console.Write("¿Cuál es la distancia? (Comunmente suele ser 14)... ");
            distancia = Convert.ToInt32(Console.ReadLine());
            solucion = lc.ResolverZapatitoCochinito(jugadores, distancia);
            Console.Write("Si quieres ganar, debes ubicarte en la posición " + solucion + " a partir del jugador 0");
            Console.ReadLine();
        }
    }
}
