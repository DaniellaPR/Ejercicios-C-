using System;

namespace Clase5ClaseComplejos
{
    class Complejo
    {
        private double num1, num2;
        public Complejo()
        { this.num1 = this.num2 = 0; }
        public Complejo(double num1, double num2)
        {
            this.num1 = num1;
            this.num2 = num2;
        }
        public void Ver()
        {
            Console.WriteLine("(" + this.num1 + " + " + this.num2 + " i)");
        }
        public static Complejo Sumar1(Conplejo x; Complejo y)
        
        public static Complejo operator+(Complejo x, Complejo y)
        {
            Complejo r =new Complejo();
            r.num1 = x.num1+y.num1;
            r.num2 = x.num2+y.num2;
            return r

        }
        public override string ToString()//Sellado de funciones
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Complejo l1 = new Complejo();
            Complejo l2 = new Complejo();
            l1.Ver();
            l2.Ver();
            b.Real = Convert.ToDouble(Console.ReadLine());
            Console.ReadKey();
        }
    }
}
    
