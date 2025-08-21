using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Grafo
{
    class Program
    {
        static void Imprimir(int[,] mat, int inf, string nombre)
        {
            int i, j;
            Console.WriteLine($"Matriz: {nombre}:");
            for (i = 0; i < mat.GetLength(0); i++)
            {
                Console.Write("|");
                for(j=0;j<mat.GetLength(1); j++)
                {
                    if (mat[i, j] < 10 || mat[i, j] == inf)
                        Console.Write(" ");
                    if (mat[i, j] == inf)
                        Console.Write("∞ ");
                    else
                        Console.Write(mat[i, j] + " ");
                }
                Console.WriteLine("|");
            }
        }
        static int[,] FWarsjall( ref int[,] ady,bool todo=false,bool caminos=false)
        {
            int[,] cam = Crearmn(ady.GetLength(0),ady.GetLength(1));            
            int[,] min = new int[ady.GetLength(0), ady.GetLength(1)];
            int i, j, k;
            if (caminos) Imprimir(cam, 99999999, $"Caminos original");Console.WriteLine("--------------------------------------------------------------");
           
            for (i = 0; i < ady.GetLength(0); i++)
            {
                for (j = 0; j < ady.GetLength(0); j++)
                {
                    for (k = 0; k < ady.GetLength(1); k++)
                    {
                        if (ady[i, k] + ady[j, i] < ady[j, k])
                        {
                            ady[j, k] = ady[i, k] + ady[j, i];
                            cam[j, k] = i + 1;
                        }
                    }
                }
                if (todo && caminos && i != ady.GetLength(0) - 1) { 
                    Imprimir(ady, 99999999, $"Iteracion {i + 1}"); Imprimir(cam, 99999999, $"Iteracion caminos {i + 1}");                               
                }
                else if(todo && !caminos)
                {
                    Imprimir(ady, 99999999, $"Iteracion {i + 1}");
                }
                if (todo) Console.WriteLine("--------------------------------------------------------------");
            }
            min = (int[,])(ady.Clone());
            ady = cam;
            return min;
        }
        static void Interpretacion(int[,]matriz, int[,] caminos)
        {
            for(int i = 0;i < caminos.GetLength(0); i++)
            {
                for(int j= 0;j < caminos.GetLength(0); j++)
                {
                    if(i==j) continue;
                    else Console.WriteLine($"Entre el vertice {i+1} y el vertice {j+1} el peso minimo es {matriz[i, j]} y pasa por {caminos[i, j]}");
                }
            }
        }
        static int[,] Crearmn(int x, int y)
        {
            int[,] matriz= new int[x,y];
            int i, j;
            for(i=0;i<x;i++)
                for (j = 0; j < y; j++)
                {
                    if (i == j)
                        matriz[i, j] = 0;
                    else
                        matriz[i, j] = j+1;
                }
            return matriz;
        }

        static int[,] RellenarMatriz(int[,] matriz,int inf)
        {
            int i = 0, j = 0,peso;
            string existe;
            for(i=0; i < matriz.GetLength(0); i++)
            {
                for (j = 0;j < matriz.GetLength(1); j++)
                {
                    if (i == j)
                        continue;
                    else
                    {
                        Console.WriteLine($"Existe el arco {i + 1}/{j + 1} (s/n)");
                        existe=Console.ReadLine().ToLower();
                        if(existe == "s")
                        {
                            Console.WriteLine($"Peso del arco: ");
                            peso =Convert.ToInt32(Console.ReadLine());
                            matriz[i,j]=peso;
                        }
                        else
                        {
                            peso = inf;
                            matriz[i, j] = peso;
                        }


                    }
                }
            }
            return matriz;
        }
        
        static void Main(string[] args)
        {
            const int inf = 99999999;
            string opcion = null;
            bool todo=false, caminos=false;
           // Console.WriteLine("Cuantos vertices? :");
           // int vertices = Convert.ToInt32(Console.ReadLine());
            int[,] mcm;
            //int[,] matriz = new int[vertices,vertices];
            int[,] matriz = new int[,]
          {
                { 0,3,5,1,inf,inf},
                { 3,0,inf,inf,9,inf},
                { 5,inf,0,7,7,1},
                { 1,inf,7,0,inf,4},
                { inf,9,7,inf,0,inf},
                { inf,inf,1,4,inf,0}
          };
            Console.WriteLine("Quiere ver iteraciones? (s/n):");
            opcion = Console.ReadLine().ToLower();
            if(opcion=="s") todo = true;
            Console.WriteLine("Quiere ver la matriz de caminos? (s/n):");
            opcion = Console.ReadLine().ToLower();
            if (opcion == "s") caminos = true;
            //matriz = RellenarMatriz(matriz,inf);
            Imprimir(matriz, inf, "original");
            mcm=FWarsjall( ref matriz,todo,caminos);
            Console.WriteLine();
            Imprimir(mcm, inf, "final");
            Console.WriteLine();
            if(caminos)Imprimir(matriz, inf, "caminos");
            Interpretacion(mcm, matriz);
        }
        
    }
}
