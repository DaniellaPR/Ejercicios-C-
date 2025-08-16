using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozoPaula_InvertirCadena
{
    class Program
    {
        public static string Invertir(string s, int indice)
        {
            if (indice < 0)
                return "";
            else 
                return s[indice] + Invertir(s, indice - 1) ;
        }
        static void Main(string[] args)
        {
            string s = "comer";
            string inverso = Invertir(s, 4);
            Console.WriteLine(s);
            Console.WriteLine(inverso);
            Console.ReadKey();
        }
    }
}
