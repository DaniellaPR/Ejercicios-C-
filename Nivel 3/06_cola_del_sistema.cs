using System;
using System.Collections.Generic;

namespace ColaDelSistema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //En este ejemplo usaremos una cola para simular el orden de atención de clientes

            Queue<string> colaClientes = new Queue<string>();    //Creamos la cola para almacenar nombres de clientes

            colaClientes.Enqueue("Cliente 1"); //Agregamos el primer cliente a la cola
            colaClientes.Enqueue("Cliente 2"); //Agregamos el segundo cliente
            colaClientes.Enqueue("Cliente 3"); //Agregamos el tercer cliente

            Console.WriteLine("Clientes en espera:"); //Mostramos los clientes actuales
            foreach (var cliente in colaClientes)     //Recorremos la cola sin modificarla
                Console.WriteLine(cliente);

            Console.WriteLine("\nAtendiendo clientes..."); //Indicamos que empieza la atención

            while (colaClientes.Count > 0) //Mientras haya clientes en la cola
            {
                string clienteAtendido = colaClientes.Dequeue(); //Sacamos al primer cliente de la cola
                Console.WriteLine($"Atendiendo a: {clienteAtendido}"); //Mostramos quién está siendo atendido
            }

            Console.WriteLine("\nTodos los clientes han sido atendidos."); //Mensaje final
        }
    }
}
