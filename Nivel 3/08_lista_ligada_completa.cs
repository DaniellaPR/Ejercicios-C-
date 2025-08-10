using System;
//Lista ligada o enlazada simple
namespace ListaLigada
{
    class Nodo
    {
        private string elemento;
        private Nodo sig;
        public Nodo()
        {
            this.elemento = null;
            this.sig = null;
        }
        public Nodo(string dato)
        {
            this.elemento = dato;
            this.sig = null;
        }
        public bool Vacia() ----------------------------------------------------------------------------------
        //Devuelve true si la lista está vacía
        {
            bool resultado = false;
            if (elemento == null && sig == null)
                resultado = true;
            return resultado;
        }
        public void InsertarFinal(string dato) --------------------------------------------------------------
        //Inserta a dato como nuevo nodo al final de la lista
        {
            Nodo p = this;                  //Avanzará hasta el último nodo
            Nodo nuevo;                     //Nuevo nodo que se va a anexar a la lista
            if (Vacia())                    //Se inserta el primer nodo
                elemento = dato;
            else                            //El segundo nodo o superior
            {
                while (p.sig != null)       //p llega a apuntar al último nodo
                    p = p.sig;
                nuevo = new Nodo(dato);
                p.sig = nuevo;
            }
        }
        public void InsertarInicio(string dato) --------------------------------------------------------------
        {
            /*
             * Se duplica el primer nodo y se inserta como segundo nodo
             * a ese duplicado. Luego se sustuye el contenido de el nodo
             * apuntado por this por dato en el primer nodo
             */
            Nodo nuevo, p;
            if (Vacia())                         //Se va a insertar el primer nodo
                this.elemento = dato;
            else                                 //Se va a ingresar el segundo nodo o superior
            {
                p = this.sig;
                nuevo = new Nodo(this.elemento); //Se copia el primer nodo en nuevo
                this.elemento = dato;
                this.sig = nuevo;
                nuevo.sig = p;
            }
        }
        public string EliminarInicio() ---------------------------------------------------------------------
        //Elimina el primer nodo y devuelve su contenido
        //Devuelve null si la lista está vacía
        {
            Nodo p = this.sig;           //p apunta al segundo nodo
            string resultado = null;
            if (!Vacia())
            {
                if (this.sig == null)    //Se va a eliminar el primer nodo
                {
                    resultado = this.elemento;
                    this.elemento = null;
                    this.sig = null;     // Asegurarse de que el siguiente también sea null
                }
                else                     //Se va a eliminar el segundo nodo o superior
                {
                    resultado = this.elemento;    //Se almacena el valor a devolverse
                    this.elemento = p.elemento;   //Se copia el contenido de p en this
                    this.sig = p.sig;             //Se hace que el primer nodo apunte al tercero
                }
            }
            return resultado;
        }

        public string EliminarElemento(string dato) ----------------------------------------------------------
        //Elimina un elemento específico de la lista
        {
            Nodo p = this;           //apunta al primer nodo
            Nodo prev = null;        //apunta al nodo anterior
            string resultado = null; //variable para almacenar el resultado de la eliminación
            while (p != null && p.elemento != dato)
            {
                prev = p;            //mover a siguiente nodo
                p = p.sig;
            }
            if (p != null) //Si se encuentra el nodo
            {
                if (prev == null)   //si es el primer nodo
                {
                    resultado = this.elemento;
                    this.elemento = this.sig != null ? this.sig.elemento : null;
                    this.sig = this.sig != null ? this.sig.sig : null;
                }
                else
                {
                    resultado = p.elemento;
                    prev.sig = p.sig; //elimina el nodo de la lista
                }
            }
            return resultado;
        }

        public Nodo Copiar() -----------------------------------------------------------------------------------------------------
        //Genera una copia de la lista implícita y la devuelve
        {
            Nodo copia = new Nodo();                   //Crwamos copia para almacenar datos de la principal
            Nodo p = this;
            if (!Vacia())
            {
                while (p != null)
                {
                    copia.InsertarFinal(p.elemento);   //Copiamos usando el metodo insertarFinal
                    p = p.sig;                         //Mientras haya siguiente
                }
            }
            return copia;
        }
        public void Vaciar() ------------------------------------------------------------------------------------------------------
        //Deja vacía la lista
        {
            this.sig = null;       //Ponemos null al indicador sig
            this.elemento = null;  //Ponemos como null a todo elemento
        }
        public void Invertir() --------------------------------------------------------------------------------------------------
        //Invierte la lista (no la devuelve)
        {
            Nodo copia;   //importante crear copia
            Nodo p;
            copia = this.Copiar();
            this.Vaciar();
            if (!copia.Vacia())
            {
                p = copia; //p apunta al primer nodo de copia
                while (p != null)
                {
                    this.InsertarInicio(p.elemento);   //usamos el metodo insertar inicio para nvertir
                    p = p.sig;
                }
            }
        }
        public Nodo Buscar(string buscado, Nodo inicio = null) ------------------------------------------------------------------
        //Devuelve una referencia a la primera ocurrencia del elemento buscado o 
        //null si no se encuentra. La búsqueda inicia en la posición inicio o en el primer
        //nodo si no se especifica esa posición
        {
            Nodo p = inicio;
            if (inicio == null)
                p = this;
            while (p != null && p.elemento != buscado)
                p = p.sig;
            return p;
        }

        public int InsertarDespuesDe(string buscado, string dato, bool todos = false) --------------------------------------------
        //Inserta dato como nuevo nodo después del nodo cuyo contenido sea buscado.
        //En forma predeterminada solo lo hace sobre la primera ocurrencia, pero si
        //el booleano todos es verdadero, lo hará después de todas las ocurrencias
        //de buscado. Devuelve el número de inserciones realizadas.
        {
            int total = 0;
            Nodo p;                          //Para recorrer la lista
            Nodo nuevo;                      //Nuevo nodo a insertarse
            if (!Vacia())
            {
                p = this.Buscar(buscado);    //Se busca la primera ocurrencia de buscado en la lista
                if (p != null)               //Se encontró el primer buscado
                {
                    nuevo = new Nodo(dato);  //Se crea el nuevo nodo
                    nuevo.sig = p.sig;
                    p.sig = nuevo;
                    total++;
                    if (todos)               //Se intenta hacer lo mismo para el resto de incersiones
                    {
                        p = this.Buscar(buscado, p.sig);     //Se busca la siguiente ocurrencia de buscado en la lista
                        while (p != null)
                        {
                            nuevo = new Nodo(dato);          //Se crea el nuevo nodo
                            nuevo.sig = p.sig;
                            p.sig = nuevo;
                            total++;
                            p = this.Buscar(buscado, p.sig); //Se busca la siguiente ocurrencia de buscado en la lista
                        }
                    }
                }
            }
            return total;
        }

        public int Contar() //Devuelve el número de elementos existente en la lista -----------------------
        {
            Nodo p = this;            //Tras crear nuevo nodo
            int total = 0;            //Declarar una variable para guardar el total
            if (!Vacia())
                while (p != null)     //Verificamos que no este vacia y q p no sea nulo
                {
                    total++;         //para contar de 1 en 1
                    p = p.sig;       //mientras haya siguiente
                }
            return total;            //Devolvemos
        }
        public string[] ListaAArreglo() ------------------------------------------------------------------
        {
            string[] r = null;    //Resultado (arreglo)
            Nodo p = this;        //Para recorrer la lista
            int i = 0;            //Para recorrer el arreglo
            if (!Vacia())
            {
                r = new string[Contar()];  //usamos el metodo contar y lo guardamos en r
                while (p != null)          //si p no esta vacio
                {
                    r[i++] = p.elemento;   //se guardará el elemento en r y tambien i aumentarpa
                    p = p.sig;             //p pasa ala siguiente
                }
            }
            return r;
        }

        //Para imprimir la lista ----------------------------------------------------------------
        public void MostrarLista()
        {
            Nodo p = this;  //creamos nodo
            while (p != null) //si p no es nulo
            {
                Console.Write(p.elemento + " -> "); //cada elemento seguirá colocandose
                p = p.sig;
            }
            Console.WriteLine("null");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Nodo lista = new Nodo();  //Empezamos creando nuevo nodo
            bool salir = false;       //Un booleano para salir
            Console.WriteLine("   Bienvenido al programa   ");
            while (!salir)            //bucle para salir del programa
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n-----  Opciones  -----");             //Indicamos las opciones que tiene
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("1. Agregar un elemento al final");          //Agregar elemento
                Console.WriteLine("2. Buscar un elemento");                    //Buscar
                Console.WriteLine("3. Eliminar un elemento específico");       //Eliminar
                Console.WriteLine("4. Mostrar todos los elementos");           //Imprimir
                Console.WriteLine("5. Salir");                                 //Salir
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nSeleccione un número: ");                //Pedimos un número de las opciones, sino lo intentará de nuevo
                Console.ForegroundColor = ConsoleColor.Yellow;
                string opcion = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Gray;

                if (opcion == "1")                                                     // 1. AGREGAR ELEMENTO
                {
                    Console.Write("Ingrese el elemento q quiera agregar: ");           //Solicitamos q ingrese elemento
                    string elemento = Console.ReadLine();
                    lista.InsertarFinal(elemento);                                     //Usamos método colocar al final
                    Console.WriteLine($"El elemento '{elemento}' fue agregado.");      //Mensaje de aprobación
                }
                else if (opcion == "2")                                                // 2. BUSCAR ELEMENTO
                {
                    Console.Write("Ingrese el elemento q desee buscar: ");             //Solicitamos que ingrese elemento a buscar
                    string buscar = Console.ReadLine();
                    Nodo encontrado = lista.Buscar(buscar);                            //Usamos método
                    if (encontrado != null)                                            //Mensajes por si fue o no encontrado
                        Console.WriteLine($"Elemento '{buscar}' fue encontrado");
                    else
                        Console.WriteLine($"Elemento '{buscar}' no se ncuentra en la lista");
                }
                else if (opcion == "3")                                                // 3. ELIMINAR
                {
                    Console.Write("Ingrese el elemento que desee eliminar: ");         //Solicitamos elemento para eliminar
                    string eliminar = Console.ReadLine();
                    string resultado = lista.EliminarElemento(eliminar);
                    if (resultado != null)                                             //Si hay elementos, se eliminará
                        Console.WriteLine($"El elemento '{resultado}' ha sido eliminado.");
                    else
                        Console.WriteLine($"No se encontró el elemento: '{eliminar}'");
                }
                else if (opcion == "4")                                                // 4. IMPRIMIR
                {
                    Console.WriteLine("Elementos de la lista:");                       //Nombre indicativo
                    lista.MostrarLista();                                              //Usamos función
                }
                else if (opcion == "5")                                                // 5. SALIR
                {
                    salir = true;                                                      //Usamos bandera que colocamos al inicio
                    break;                                                             //Salimos del programa
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Intente de nuevo");                            //Mnesaje por si colocó cualquier otra cosa
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            Console.WriteLine("Gracias por usar este programa...");                   //Mensaje de finalización
            Console.ReadKey();
        }
    }
}
