using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursividad
{
    class Program
    {
        public static int Multi(int n, int m)
        {
            int respuesta=0;
            if (m == 1)
                respuesta =n;
            else
                respuesta = n + Multi(n, m -1);
            return respuesta;
        }
        static void Main(string[] args)
        {
            int x;
            x = Multi(4, 5);
        }
    }
}
