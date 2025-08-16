using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursividad_BusquedaBinaria
{
    class Program
    {
        public static bool BusquedaBin(int[] arr, int dato)
        {
            bool hay = false;
            int[] nuevo = new int[arr.Length];
            List<int> list = new List<int>();
            int i, medio;

            if (arr.Length ==1 && arr[0] ==dato)
                hay = true;
            else if (arr.Length ==0)
                hay = false;
            else
            {
                medio = arr.Length / 2;
                if (arr[medio] == dato)
                    return hay = true;
                else if (dato < arr[medio])
                {
                    for (i = 0; i < medio; i++)
                        list.Add(arr[i]);
                    nuevo = list.ToArray();
                }
                return BusquedaBin(nuevo, dato);
            }
            return hay;
        }
        static void Main(string[] args)
        {
            int dato = 5;
            int[] arreglo = { 1, 2, 3, 4, 5, 6, };
            bool resp = BusquedaBin(arreglo, dato);

        }
    }
}
