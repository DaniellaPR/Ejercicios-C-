using System;

namespace Ejercicio3
{
    public class Cliente //Empezamos creando una clase Cliente
    {
        //Ahora definir las variables con sus niveles de acceso
        private string nombre;
        private decimal saldo;
        private int depositos;
        private int retiros;

        //Constructor donde definirá nombre, saldo, depósito y retiros
        public Cliente(string nombre, decimal montoInicial)
        {
            this.nombre = nombre;
            saldo = montoInicial;
            depositos = 0;
            retiros = 0;
        }

        //Función de depósito
        public void Deposito(decimal monto)
        {
            saldo += monto;
            depositos++;
        }

        //Función de Retiro
        public void Retiro(decimal monto)
        {
            if (monto <= saldo)
            {
                saldo -= monto;
                retiros++;
            }
            else
                Console.WriteLine($"{nombre} no tiene suficiente saldo para retirar {monto}");
        }

        //Función para imprimir
        public void Impresion()
        {
            Console.WriteLine($"{nombre} realizó {depositos} depósitos y {retiros} retiros. Su saldo actual es: {saldo:C}");
        }
            
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //Crearemos mínimo 4 clientes con sus nombres y montos inciales que serán el saldo
            Cliente cliente4 = new Cliente("Ariel", 1000);
            Cliente cliente2 = new Cliente("Joel", 800);
            Cliente cliente3 = new Cliente("Martin", 900);
            Cliente cliente1 = new Cliente("Edwin", 700);

            //Realizaremos depósitos y retiros de cada uno de ellos
            cliente1.Deposito(300);
            cliente1.Retiro(200);

            cliente2.Deposito(300);
            cliente2.Deposito(822);
            cliente2.Retiro(100);

            cliente3.Deposito(5000);
            cliente3.Retiro(1300);
            cliente3.Retiro(200);
            cliente3.Retiro(4500);

            cliente4.Deposito(200);
            cliente4.Retiro(500);

            //Usar función de impresión
            cliente1.Impresion();
            cliente2.Impresion();
            cliente3.Impresion();
            cliente4.Impresion();

            Console.ReadKey(); //No olvidar
        }
    }
}
