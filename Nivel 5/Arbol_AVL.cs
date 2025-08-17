using System;

namespace ArbolAVL
{
    class Nodo
    {
        public int contenido;
        public Nodo izquierda;
        public Nodo derecha;
        public int altura;

        public Nodo(int valor=0)
        {
            this.contenido = valor;
            this.izquierda=this.derecha =null;
            this.altura = 1;
        }
        public bool Vacio()
        {
            if (this.contenido == 0 && this.izquierda == null && this.derecha == null)
                return true;
            return false;
        }
        public Nodo Insertar(int nuevoValor)
        {
            if (nuevoValor < contenido)
            {
                izquierda = izquierda == null ? new Nodo(nuevoValor) : izquierda.Insertar(nuevoValor);
            }
            else if (nuevoValor > contenido)
            {
                derecha = derecha == null ? new Nodo(nuevoValor) : derecha.Insertar(nuevoValor);
            }
            else
            {
                return this;
            }

            ActualizarAltura();

            return Balancear();
        }
        public bool Buscar(int valorBuscado)
        {
            if (valorBuscado == contenido)
                return true;

            if (valorBuscado < contenido)
                return izquierda != null && izquierda.Buscar(valorBuscado);

            return derecha != null && derecha.Buscar(valorBuscado);
        }

        private void ActualizarAltura()
        {
            int alturaIzq = izquierda != null ? izquierda.altura : 0;
            int alturaDer = derecha != null ? derecha.altura : 0;
            altura = 1 + Math.Max(alturaIzq, alturaDer);
        }

        private int FactorBalance()
        {
            int alturaIzq = izquierda != null ? izquierda.altura : 0;
            int alturaDer = derecha != null ? derecha.altura : 0;
            return alturaIzq - alturaDer;
        }

        private Nodo Balancear()
        {
            int balance = FactorBalance();

            if (balance > 1 && izquierda.FactorBalance() >= 0)
                return RotacionDerecha();

            if (balance > 1 && izquierda.FactorBalance() < 0)
            {
                izquierda = izquierda.RotacionIzquierda();
                return RotacionDerecha();
            }

            if (balance < -1 && derecha.FactorBalance() <= 0)
                return RotacionIzquierda();

            if (balance < -1 && derecha.FactorBalance() > 0)
            {
                derecha = derecha.RotacionDerecha();
                return RotacionIzquierda();
            }

            return this;
        }

        private Nodo RotacionDerecha()
        {
            Nodo nuevaRaiz = izquierda;
            izquierda = nuevaRaiz.derecha;
            nuevaRaiz.derecha = this;

            ActualizarAltura();
            nuevaRaiz.ActualizarAltura();

            return nuevaRaiz;
        }

        private Nodo RotacionIzquierda()
        {
            Nodo nuevaRaiz = derecha;
            derecha = nuevaRaiz.izquierda;
            nuevaRaiz.izquierda = this;

            ActualizarAltura();
            nuevaRaiz.ActualizarAltura();

            return nuevaRaiz;
        }

        public void Preorden()
        {
            Console.Write(contenido + " ");
            izquierda?.Preorden();
            derecha?.Preorden();
        }

        public void Inorden()
        {
            izquierda?.Inorden();
            Console.Write(contenido + " ");
            derecha?.Inorden();
        }

        public void Postorden()
        {
            izquierda?.Postorden();
            derecha?.Postorden();
            Console.Write(contenido + " ");
        }

        public void Mostrar(string espacio = "", bool esDerecho = true)
        {
            string borde = esDerecho ? "└──" : "├──";
            if (espacio == "" && esDerecho == true)
                Console.WriteLine("   " + contenido);
            else
                Console.WriteLine(espacio + borde + contenido);

            espacio += esDerecho ? "   " : "│  ";
            if (izquierda != null || derecha != null)
            {
                izquierda?.Mostrar(espacio, false);
                derecha?.Mostrar(espacio, true);
            }
        }
        public void Hojas(ref int contador)
        {
            if (this.izquierda == null && this.derecha == null)
            {
                contador++;
                return;
            }
            if (izquierda != null)
            {
                izquierda.Hojas(ref contador);
            }
            if (derecha != null)
            {
                derecha.Hojas(ref contador);
            }
        }
        public int ContarHojas()
        {
            int contador = 0;
            if (!Vacio())
                Hojas(ref contador);
            return contador;
        }

        //Se puede conocer la profundidad llamando recursivamente por la izq y contabilizando el número de llamadas. Luego haciendo lo mismo por la derecha y devolviendo la mayor
        //de las dos contabilizaciones. Escriba un método que no reciba argumento y que devuelva la profundidad del árbol implícito.

        public int Profundidad()
        {
            int profundo = 0, cont = 0, conta = 0;
            if (izquierda != null)
                cont = izquierda.Profundidad();
            if (derecha != null)
                conta = derecha.Profundidad();
            if (cont > conta)
                profundo = cont + 1;
            else
                profundo = conta + 1;
            return profundo;
        }
        public int Profu()
        {
            int prof = 0;
            if (!Vacio())
                prof = Profundidad();
            return prof;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Nodo arbol = null;
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("════════════ MENÚ ÁRBOL AVL ════════════");
                Console.WriteLine("1. Insertar valor");
                Console.WriteLine("2. Buscar valor");
                Console.WriteLine("3. Mostrar árbol");
                Console.WriteLine("4. Recorrido Preorden");
                Console.WriteLine("5. Recorrido Inorden");
                Console.WriteLine("6. Recorrido Postorden");
                Console.WriteLine("0. Salir");
                Console.WriteLine("═════════════════════════════════════════");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("¡Opción no válida!");
                    Console.ReadKey();
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese el valor a insertar: ");
                        if (int.TryParse(Console.ReadLine(), out int valorInsertar))
                        {
                            if (arbol == null)
                                arbol = new Nodo(valorInsertar);
                            else
                                arbol = arbol.Insertar(valorInsertar);
                            Console.WriteLine("Valor insertado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("¡Valor no válido!");
                        }
                        break;

                    case 2:
                        int contar =arbol.ContarHojas();
                        int total = arbol.Profu();
                        Console.WriteLine("Hojas: "+contar+"\nProfundidad: "+total);
                        Console.Write("Ingrese el valor a buscar: ");
                        if (int.TryParse(Console.ReadLine(), out int valorBuscar))
                        {
                            bool encontrado = arbol != null && arbol.Buscar(valorBuscar);
                            Console.WriteLine(encontrado ? "¡Valor encontrado!" : "Valor no encontrado.");
                        }
                        else
                        {
                            Console.WriteLine("¡Valor no válido!");
                        }
                        break;

                    case 3:
                        Console.WriteLine("\nESTRUCTURA DEL ÁRBOL AVL:");
                        if (arbol != null)
                            arbol.Mostrar();
                        else
                            Console.WriteLine("Árbol vacío");
                        break;

                    case 4:
                        Console.Write("Recorrido Preorden: ");
                        if (arbol != null)
                            arbol.Preorden();
                        Console.WriteLine();
                        break;

                    case 5:
                        Console.Write("Recorrido Inorden: ");
                        if (arbol != null)
                            arbol.Inorden();
                        Console.WriteLine();
                        break;

                    case 6:
                        Console.Write("Recorrido Postorden: ");
                        if (arbol != null)
                            arbol.Postorden();
                        Console.WriteLine();
                        break;

                    case 0:
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default:
                        Console.WriteLine("¡Opción no válida!");
                        break;
                }

                if (opcion != 0)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 0);
        }
    }
}
