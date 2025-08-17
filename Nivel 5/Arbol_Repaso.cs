using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolRepasoSi
{
    class Nodo
    {
        public int contenido;
        public Nodo izq, der;

        public Nodo(int contenido = -9999)
        {
            this.izq = this.der = null;
            this.contenido = contenido;
        }

        public void Eliminar()
        {
            contenido = 0;
            izq = der = null;
        }

        public bool Vacio()
        {
            bool vacio = false;
            if (this.contenido == 0 && this.izq == null && this.der == null)
                vacio = true;
            return vacio;
        }

        public void DatosPrueba()
        {
            Nodo p;
            this.Eliminar();
            this.contenido = 1;
            this.izq = new Nodo(2);
            this.der = new Nodo(5);
            p = this.izq;
            p.izq = new Nodo(3);
            p.der = new Nodo(4);
            p = this.der;
            p.izq = new Nodo(6);
            p = p.der;
            p.izq = new Nodo(7);
            p.der = new Nodo(8);
        }

        public void Ver(string espacio = "    ")
        {
            Console.WriteLine(espacio + contenido);
            espacio += "    ";
            if (this.izq != null)
                this.izq.Ver(espacio);
            if (this.der != null)
                this.der.Ver(espacio);
        }

        public void Ver2(string espacio = "", bool esder = true)
        {
            string marco = esder ? "└──" : "├──"; //Alt + 192, Alt + 195, dos: Alt + 196
            if (espacio == "" && esder == true)
                Console.WriteLine("    " + contenido);
            else
                Console.WriteLine(espacio + marco + contenido);

            espacio += esder ? "    " : "│   ";
            Console.WriteLine();
            if (this.izq != null)
                this.izq.Ver2(espacio, false);
            if (this.der != null)
                this.der.Ver2(espacio, true);
        }

        public void GenerarABO(int[] arreglo)
        {
            Nodo ap = this;
            if (Vacio())
            {
                this.contenido = arreglo[0]; //El primer elemento del arreglo es la raiz
            }
            for (int i = 1; i < arreglo.Length; i++) //For para insertar los elementos
            {
                ap = this;
                while (true)
                {
                    if (arreglo[i] <= ap.contenido) //Si elemento es menor o igual que el nodo analizado pregunto;
                    {
                        if (ap.izq == null) //Si no hay nada por la izquierda
                        {

                            ap.izq = new Nodo(arreglo[i]); //Ingreso el nuevo nodo 
                            break; //Detengo el while
                        }
                        else //Si si hay
                            ap = ap.izq; //Me muevo por la izq del nodo analizado
                    }
                    else
                    {
                        if (arreglo[i] > ap.contenido) //Si elemento es mayor o igual que el nodo analizado pregunto;
                        {
                            if (ap.der == null) //Si no hay nada por la derecha
                            {

                                ap.der = new Nodo(arreglo[i]); //Ingreso el nuevo nodo 
                                break; //Detengo el while
                            }
                            else //Si si hay
                                ap = ap.der; //Me muevo por la izq del nodo analizado
                        }
                    }
                }
            }
        }

        public void PreordenRec()
        {
            Console.Write(this.contenido + " "); //Se imprime la raíz
            if (this.izq != null)
                this.izq.PreordenRec(); //Se recorre en preorden por la izquierda
            if (this.der != null)
                this.der.PreordenRec(); //Se recorre en preorden por la derecha
        }

        //Imprime por pantalla el recorrido preorden o vacío si no tiene datos
        public void Preorden()
        {
            if (Vacio())
                Console.WriteLine("Árbol sin datos");
            else
            {
                Console.WriteLine("Recorrido en preorden: ");
                PreordenRec();
                Console.WriteLine();
            }
        }

        //Realiza el recorrido en Postorden del árbol y lo presenta por pantalla
        public void PostordenRec()
        {
            if (this.izq != null)
                this.izq.PostordenRec();//Se recorre en post por la izquierda
            if (this.der != null)
                this.der.PostordenRec(); //Se recorre en post por la derecha
            Console.Write(this.contenido + " "); //Se imprime el elemento
        }

        //Imprime por pantalla el recorrido Postorden o vacío si no tiene datos
        public void PostOrden()
        {
            if (Vacio())
                Console.WriteLine("Árbol sin datos");
            else
            {
                Console.WriteLine("Recorrido en Postorden: ");
                PostordenRec();
                Console.WriteLine();
            }
        }

        //Realiza el recorrido en Inorden del árbol y lo presenta por pantalla
        public void InordenRec()
        {

            if (this.izq != null)
                this.izq.InordenRec(); //Se recorre en inorden por la izquierda
            Console.Write(this.contenido + " "); //Se imprime la raíz
            if (this.der != null)
                this.der.InordenRec(); //Se recorre en inorden por la derecha
        }

        //Imprime por pantalla el recorrido Inorden o vacío si no tiene datos
        public void Inorden()
        {
            if (Vacio())
                Console.WriteLine("Árbol sin datos");
            else
            {
                Console.WriteLine("Recorrido en Inorden: ");
                InordenRec();
                Console.WriteLine();
            }
        }

        public bool InsertarDespuesDePre(int dato, int buscado, bool ins_izq, bool resto_izq)
        {
            bool encontrado = false;
            Nodo p;
            Nodo busca = new Nodo();
            Nodo nuevo = new Nodo(dato);
            busca = BuscarPreorden(buscado);

            /*Inserta un nuevo nodo cuyo contenido será dato despues de encontrar la primera 
            ocurrencia de buscado en el arbol mediante recorrido preorden
            si ins_izq es verdades, inserta a la izquierda del nodo buscado,sino a la derecha. 
            Si resto_izq e verdadero, el resto del arbol que existia previo a la insersión va a parar a la izquierda del nuevo nodo
            isertado, sino a la derecha
            Devuelve true si se logra hacer la inserición*/
            if (BuscarPreorden(buscado) != null)
            {
                if (ins_izq)
                {
                    p = busca.izq;
                    busca.izq = nuevo;
                    if (resto_izq)
                        nuevo.izq = p;
                    else
                        nuevo.der = p;

                }
                else
                {
                    p = busca.der;
                    busca.der = nuevo;
                    if (resto_izq)
                        nuevo.izq = p;
                    else
                        nuevo.der = p;
                }
            }
            return encontrado;
        }

        public Nodo Eliminar(int dato)
        {
            Nodo eliminado = new Nodo();
            if (BuscarPreorden(dato) != null)
                eliminado = EliminarRecursivo(dato);
            else eliminado = null;
            return eliminado;
        }

        public Nodo EliminarRecursivo(int caracter)
        {
            Nodo resultado = new Nodo();
            resultado = null;
            Nodo p = new Nodo();
            Nodo apoyo = new Nodo();

            bool encontrado = false;

            if (this.izq != null)
            {
                p = this.izq;
                if (p.contenido == caracter)
                {
                    encontrado = true;
                    this.izq = null;
                    resultado = p;
                }
                else
                    if (this.izq != null)
                    resultado = this.izq.EliminarRecursivo(caracter);
            }
            if (this.der != null && encontrado == false)
            {
                p = this.der;
                if (p.contenido == caracter)
                {
                    encontrado = true;
                    this.der = null;
                    resultado = p;
                }
                else
                    if (this.der != null)
                    resultado = this.der.EliminarRecursivo(caracter);
            }
            if (!encontrado)
                resultado = null;

            return resultado;
        }

        public Nodo BuscarPreorden(int caracter)
        {
            Nodo resultado = new Nodo();
            bool encontrado = false;
            if (this.contenido != caracter)
            {
                if (this.izq != null)
                {
                    resultado = this.izq.BuscarPreorden(caracter);
                    if (resultado != null)
                        encontrado = true;
                }
                if (this.der != null && encontrado == false)
                {
                    resultado = this.der.BuscarPreorden(caracter);
                    if (resultado != null)
                        encontrado = true;
                }
            }
            else if (this.contenido == caracter)
                resultado = this;
            else
                resultado = null;
            return resultado;

        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Nodo arbol = new Nodo();
            int opcion;
            bool salir = false;

            do
            {
                Console.Clear();
                Console.WriteLine("════════════ MENÚ ÁRBOL BINARIO ════════════");
                Console.WriteLine("1. Generar árbol de prueba");
                Console.WriteLine("2. Insertar datos manualmente (ABO)");
                Console.WriteLine("3. Mostrar árbol (formato simple)");
                Console.WriteLine("4. Mostrar árbol (formato gráfico)");
                Console.WriteLine("5. Recorrido Preorden");
                Console.WriteLine("6. Recorrido Inorden");
                Console.WriteLine("7. Recorrido Postorden");
                Console.WriteLine("8. Insertar nodo después de otro");
                Console.WriteLine("9. Eliminar nodo");
                Console.WriteLine("10. Buscar nodo");
                Console.WriteLine("0. Salir");
                Console.WriteLine("═════════════════════════════════════════════");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("¡Opción no válida!");
                    Console.ReadKey();
                    continue;
                }

                switch (opcion)
                {
                    case 1: // Generar árbol de prueba
                        arbol.DatosPrueba();
                        Console.WriteLine("Árbol de prueba generado con éxito.");
                        break;

                    case 2: // Insertar datos manualmente (ABO)
                        Console.Write("Ingrese números separados por espacios: ");
                        string input = Console.ReadLine();
                        string[] numerosStr = input.Split(' ');
                        int[] numeros = new int[numerosStr.Length];

                        for (int i = 0; i < numerosStr.Length; i++)
                        {
                            if (!int.TryParse(numerosStr[i], out numeros[i]))
                            {
                                Console.WriteLine($"¡'{numerosStr[i]}' no es un número válido! Se omitirá.");
                                numeros[i] = 0; // Valor por defecto
                            }
                        }

                        arbol.GenerarABO(numeros);
                        Console.WriteLine("Árbol generado con éxito.");
                        break;

                    case 3: // Mostrar árbol (formato simple)
                        Console.WriteLine("\nESTRUCTURA DEL ÁRBOL (Simple):");
                        arbol.Ver();
                        break;

                    case 4: // Mostrar árbol (formato gráfico)
                        Console.WriteLine("\nESTRUCTURA DEL ÁRBOL (Gráfico):");
                        arbol.Ver2();
                        break;

                    case 5: // Recorrido Preorden
                        Console.WriteLine("\nRECORRIDO PREORDEN:");
                        arbol.Preorden();
                        break;

                    case 6: // Recorrido Inorden
                        Console.WriteLine("\nRECORRIDO INORDEN:");
                        arbol.Inorden();
                        break;

                    case 7: // Recorrido Postorden
                        Console.WriteLine("\nRECORRIDO POSTORDEN:");
                        arbol.PostOrden();
                        break;

                    case 8: // Insertar nodo después de otro
                        Console.Write("Ingrese el valor del nuevo nodo: ");
                        int nuevoValor = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese el valor del nodo de referencia: ");
                        int referencia = int.Parse(Console.ReadLine());
                        Console.Write("¿Insertar a la izquierda? (s/n): ");
                        bool izquierda = Console.ReadLine().ToLower() == "s";
                        Console.Write("¿Mover subárbol a la izquierda? (s/n): ");
                        bool restoIzquierda = Console.ReadLine().ToLower() == "s";

                        bool exito = arbol.InsertarDespuesDePre(nuevoValor, referencia, izquierda, restoIzquierda);
                        Console.WriteLine(exito ? "¡Nodo insertado con éxito!" : "¡No se encontró el nodo de referencia!");
                        break;

                    case 9: // Eliminar nodo
                        Console.Write("Ingrese el valor del nodo a eliminar: ");
                        int valorEliminar = int.Parse(Console.ReadLine());
                        Nodo eliminado = arbol.Eliminar(valorEliminar);

                        if (eliminado != null)
                        {
                            Console.WriteLine("Nodo eliminado:");
                            eliminado.Ver();
                        }
                        else
                            Console.WriteLine("¡Nodo no encontrado!");
                        break;

                    case 10: // Buscar nodo
                        Console.Write("Ingrese el valor a buscar: ");
                        int valorBuscar = int.Parse(Console.ReadLine());
                        Nodo encontrado = arbol.BuscarPreorden(valorBuscar);

                        if (encontrado != null)
                        {
                            Console.WriteLine("Nodo encontrado:");
                            encontrado.Ver();
                        }
                        else
                            Console.WriteLine("¡Nodo no encontrado!");
                        break;

                    case 0: // Salir
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("¡Opción no válida!");
                        break;
                }

                if (!salir)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (!salir);

            Console.WriteLine("¡Programa finalizado!");
        }
    }
}
