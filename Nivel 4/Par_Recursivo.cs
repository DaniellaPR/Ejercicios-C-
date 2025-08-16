using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pozo_Paula_Recursividad
{
    class Program
    {
        
       static bool Espar(int n)
        {
            bool resp = false;
            if (n == 0)
                resp = true;
            else if (n == 1)
                resp = false;
            else
                resp = Espar(n - 2);
            return resp;
        }
        static bool Impar(int n)
        {
            if (n == 0) return false;
            return SPar(n - 1);
        }
        static bool SPar(int n)
        {
            if (n == 0) return true;
            return Impar(n - 1);
        }

        
        static void Main(string[] args)
        {

            Console.WriteLine("Método restar 2: ");
            bool r;
            r = Espar(85);
            Console.WriteLine(r);

            Console.WriteLine("Método función par e impar: ");
            Console.WriteLine(Impar(10));
            Console.WriteLine(Impar(9));
            Console.WriteLine(Impar(18));

            Console.ReadKey();
        }
    }
}
