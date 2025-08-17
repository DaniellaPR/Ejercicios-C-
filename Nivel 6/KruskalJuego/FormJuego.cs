using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RoboKruskal
{
    public partial class FormJuego : Form
    {
        private int dificultad;
        private string rutaMapa;
        private Panel panelMapa;
        private Panel panelDificultades;
        private List<Nodo> nodos = new List<Nodo>();
        private List<Arista> aristas = new List<Arista>();
        private List<Arista> aristasJugador = new List<Arista>();
        private List<Arista> mstKruskal = new List<Arista>();
        private Random random = new Random();
        private Nodo nodoSeleccionado = null;
        private bool mostrarSolucion = false;
        private bool modoSeleccionActivo = false;

        private readonly Color[] coloresDificultad = new Color[]
        {
            Color.Yellow, Color.Salmon, Color.Orange, Color.Pink, Color.Red,
            Color.MediumPurple, Color.Cyan, Color.Blue, Color.Turquoise, Color.Green
        };

        public FormJuego(int dificultad, string rutaMapa)
        {
            InitializeComponent();
            this.dificultad = dificultad;
            this.rutaMapa = rutaMapa;
            this.DoubleBuffered = true;
            this.ClientSize = new Size(1100, 700);
            this.BackColor = Color.FromArgb(66, 66, 66);
            this.BackgroundImageLayout = ImageLayout.Stretch;

            panelMapa = new Panel()
            {
                Name = "panelMapa",
                Size = new Size(700, 550),
                Location = new Point(30, 45),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.Transparent
            };
            panelMapa.MouseClick += PanelMapa_MouseClick;
            panelMapa.Paint += (s, e) => DibujarGrafoInicial(e.Graphics);
            this.Controls.Add(panelMapa);

            if (File.Exists(rutaMapa))
            {
                panelMapa.BackgroundImage = Image.FromFile(rutaMapa);
                panelMapa.BackgroundImageLayout = ImageLayout.Stretch;
            }

            panelDificultades = new Panel()
            {
                Name = "panelDificultades",
                Size = new Size(200, 618),
                Location = new Point(this.ClientSize.Width - 300, 45),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(96, 96, 96)
            };
            this.Controls.Add(panelDificultades);

            DibujarLeyendaDificultad();

            AgregarBoton("Tesoros", new Point(40, 615), () => { new System.Media.SoundPlayer("imagenes/moneda.wav").Play(); GenerarTesoro(); });
            AgregarBoton("Conectar", new Point(150, 615), () => { new System.Media.SoundPlayer("imagenes/clic2.wav").Play(); GenerarConexionesIndividuales(); });
            AgregarBoton("Iniciar", new Point(260, 615), () =>
            {
                foreach (var arista in aristas)
                    arista.SeleccionadaPorJugador = false;

                aristasJugador.Clear();
                nodoSeleccionado = null;
                modoSeleccionActivo = true;
                new System.Media.SoundPlayer("imagenes/clic.wav").Play();
                panelMapa.Invalidate();
            });
            AgregarBoton("Rendirse", new Point(370, 615), () => { mostrarSolucion = true; panelMapa.Invalidate(); });
            AgregarBoton("Terminar", new Point(480, 615), () => { new System.Media.SoundPlayer("imagenes/caja.wav").Play(); MostrarResultado(); });
        }

        private void AgregarBoton(string texto, Point loc, Action accion)
        {
            Button btn = new Button()
            {
                Text = texto,
                Size = new Size(100, 45),
                Location = loc,
                BackColor = Color.DarkGoldenrod,
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            btn.Click += (s, e) => accion();
            this.Controls.Add(btn);
        }

        private void DibujarLeyendaDificultad()
        {
            panelDificultades.Controls.Clear();
            int startY = 20;
            for (int i = 1; i <= dificultad; i++)
            {
                string rutaImg = $"imagenes/obstaculos/{i}.png";
                var obstaculo = new Button()
                {
                    Size = new Size(50, 50),
                    Location = new Point(20, startY),
                    BackgroundImage = File.Exists(rutaImg) ? Image.FromFile(rutaImg) : null,
                    BackgroundImageLayout = ImageLayout.Stretch,
                    FlatStyle = FlatStyle.Flat,
                    FlatAppearance = { BorderSize = 0 },
                    BackColor = Color.Transparent
                };

                var lbl = new Label()
                {
                    Text = $"Peso: {i}",
                    ForeColor = coloresDificultad[i - 1],
                    BackColor = Color.Transparent,
                    Location = new Point(80, startY + 15),
                    Font = new Font("Segoe UI", 12, FontStyle.Italic),
                    AutoSize = true
                };
                panelDificultades.Controls.Add(obstaculo);
                panelDificultades.Controls.Add(lbl);
                startY += 60;
            }
        }

        private void GenerarTesoro()
        {
            string[] opciones = { "monedas.png", "monedas.png", "tesoro.png", "cerveza.png", "corona.png" };
            string imagen = opciones[random.Next(opciones.Length)];
            int x, y;
            do
            {
                x = random.Next(20, panelMapa.Width - 60);
                y = random.Next(20, panelMapa.Height - 60);
            }
            while (nodos.Any(n => Math.Sqrt(Math.Pow(n.Posicion.X - x, 2) + Math.Pow(n.Posicion.Y - y, 2)) < 60));

            var pic = new PictureBox()
            {
                Size = new Size(35, 35),
                Location = new Point(x, y),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = Image.FromFile("imagenes/tesoros/" + imagen),
                BackColor = Color.Transparent,
                Tag = imagen
            };
            pic.Click += NodoPictureBox_Click;
            panelMapa.Controls.Add(pic);
            nodos.Add(new Nodo { Imagen = pic, Posicion = new Point(x + 18, y + 18), Tesoro = imagen });
        }

        private void GenerarConexionesIndividuales()
        {
            if (nodos.Count < 2) return;

            int intentos = 0;
            while (intentos < 100)
            {
                Nodo a = nodos[random.Next(nodos.Count)];
                Nodo b = nodos[random.Next(nodos.Count)];

                if (a != b && !aristas.Any(x => (x.NodoA == a && x.NodoB == b) || (x.NodoA == b && x.NodoB == a)))
                {
                    int peso = random.Next(1, dificultad + 1);
                    aristas.Add(new Arista { NodoA = a, NodoB = b, Peso = peso });
                    panelMapa.Invalidate();
                    return;
                }
                intentos++;
            }
            MessageBox.Show("No se pueden generar más conexiones únicas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PanelMapa_MouseClick(object sender, MouseEventArgs e)
        {
            if (!modoSeleccionActivo) return;

            var nodoCercano = nodos.FirstOrDefault(n => Math.Sqrt(Math.Pow(n.Posicion.X - e.X, 2) + Math.Pow(n.Posicion.Y - e.Y, 2)) < 30);
            if (nodoCercano != null)
            {
                if (nodoSeleccionado == null)
                {
                    nodoSeleccionado = nodoCercano;
                    nodoCercano.Imagen.BackColor = Color.FromArgb(150, Color.Yellow);
                }
                else if (nodoSeleccionado != nodoCercano)
                {
                    var arista = aristas.FirstOrDefault(a =>
                        (a.NodoA == nodoSeleccionado && a.NodoB == nodoCercano) ||
                        (a.NodoB == nodoSeleccionado && a.NodoA == nodoCercano));

                    if (arista != null && !aristasJugador.Contains(arista) && !FormaCiclo(arista))
                    {
                        arista.SeleccionadaPorJugador = true;
                        aristasJugador.Add(arista);
                        new System.Media.SoundPlayer("imagenes/minecraft.wav").Play();
                        panelMapa.Invalidate();
                    }
                    nodoSeleccionado.Imagen.BackColor = Color.Transparent;
                    nodoSeleccionado = null;
                }
            }
        }

        private bool FormaCiclo(Arista nueva)
        {
            var padres = nodos.ToDictionary(n => n, n => n);
            Nodo Buscar(Nodo n) => padres[n] == n ? n : padres[n] = Buscar(padres[n]);
            void Unir(Nodo a, Nodo b) => padres[Buscar(a)] = Buscar(b);

            foreach (var a in aristasJugador)
                Unir(a.NodoA, a.NodoB);

            return Buscar(nueva.NodoA) == Buscar(nueva.NodoB);
        }

        private void DibujarGrafoInicial(Graphics g)
        {
            foreach (var a in aristas)
            {
                using (Pen pen = new Pen(Color.Black, 3))
                    g.DrawLine(pen, a.NodoA.Posicion, a.NodoB.Posicion);
                DibujarObstaculo(g, a);
            }

            foreach (var a in aristas.Where(x => x.SeleccionadaPorJugador))
            {
                using (Pen pen = new Pen(Color.LimeGreen, 5))
                    g.DrawLine(pen, a.NodoA.Posicion, a.NodoB.Posicion);
            }

            if (mostrarSolucion)
            {
                foreach (var a in ObtenerMST())
                {
                    using (Pen pen = new Pen(Color.DeepSkyBlue, 3) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash })
                        g.DrawLine(pen, a.NodoA.Posicion, a.NodoB.Posicion);
                }
            }
        }

        private void DibujarObstaculo(Graphics g, Arista arista)
        {
            string ruta = $"imagenes/obstaculos/{arista.Peso}.png";
            if (!File.Exists(ruta)) return;
            Image img = Image.FromFile(ruta);
            Point centro = new Point((arista.NodoA.Posicion.X + arista.NodoB.Posicion.X) / 2,
                                     (arista.NodoA.Posicion.Y + arista.NodoB.Posicion.Y) / 2);
            Size size = new Size(30, 30);
            g.DrawImage(img, new Rectangle(centro - new Size(size.Width / 2, size.Height / 2), size));
        }

        private void MostrarResultado()
        {
            int coronas = nodos.Count(n => n.Tesoro == "corona.png");
            int monedas = nodos.Count(n => n.Tesoro == "monedas.png");
            int cervezas = nodos.Count(n => n.Tesoro == "cerveza.png");
            int cofre = nodos.Count(n => n.Tesoro == "tesoro.png");

            mstKruskal = ObtenerMST();
            int pesoJugador = aristasJugador.Sum(a => a.Peso);
            int pesoMST = mstKruskal.Sum(a => a.Peso);

            string texto;
            if (aristasJugador.Count == mstKruskal.Count && pesoJugador == pesoMST)
                texto = "Deberías llamarte Kruskal... ¡Felicidades!\n";
            else if (pesoJugador <= pesoMST + 3)
                texto = "No fue el mejor de los robos....\n";
            else
                texto = "Tomaste un camino más largo. Y así te haces llamar ladrón....\n";

            texto += $"\nCoronas: {coronas}\nMonedas: {monedas}\nCervezas: {cervezas}\nCofre: {cofre}";

            var form = new Form() { Size = new Size(420, 260), BackColor = Color.Black, ForeColor = Color.White, Text = "Resultado final" };
            form.Controls.Add(new Label()
            {
                Text = texto,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 14),
                Height = 160
            });

            var btnSalir = new Button() { Text = "Salir", Location = new Point(30, 180), Size = new Size(100, 40) };
            var btnReiniciar = new Button() { Text = "Jugar de nuevo", Location = new Point(150, 180), Size = new Size(120, 40) };
            var btnMostrarKruskal = new Button() { Text = "Ver Kruskal", Location = new Point(290, 180), Size = new Size(100, 40) };

            btnSalir.Click += (s, e) => Application.Exit();
            btnReiniciar.Click += (s, e) => { form.Close(); Application.Restart(); };
            btnMostrarKruskal.Click += (s, e) => { form.Close(); mostrarSolucion = true; panelMapa.Invalidate(); };

            form.Controls.Add(btnSalir);
            form.Controls.Add(btnReiniciar);
            form.Controls.Add(btnMostrarKruskal);
            form.ShowDialog();
        }

        private List<Arista> ObtenerMST()
        {
            var mst = new List<Arista>();
            var padres = nodos.ToDictionary(n => n, n => n);

            Nodo Buscar(Nodo n) => padres[n] == n ? n : padres[n] = Buscar(padres[n]);
            void Unir(Nodo a, Nodo b) => padres[Buscar(a)] = Buscar(b);

            foreach (var a in aristas.OrderBy(a => a.Peso))
            {
                if (Buscar(a.NodoA) != Buscar(a.NodoB))
                {
                    Unir(a.NodoA, a.NodoB);
                    mst.Add(a);
                }
            }
            return mst;
        }
        private void NodoPictureBox_Click(object sender, EventArgs e)
        {
            if (!modoSeleccionActivo) return;

            PictureBox pic = sender as PictureBox;
            Nodo nodoCercano = nodos.FirstOrDefault(n => n.Imagen == pic);

            if (nodoCercano != null)
            {
                if (nodoSeleccionado == null)
                {
                    nodoSeleccionado = nodoCercano;
                    nodoCercano.Imagen.BackColor = Color.FromArgb(150, Color.Yellow);
                }
                else if (nodoSeleccionado != nodoCercano)
                {
                    var aristaExistente = aristas.FirstOrDefault(a =>
                        (a.NodoA == nodoSeleccionado && a.NodoB == nodoCercano) ||
                        (a.NodoB == nodoSeleccionado && a.NodoA == nodoCercano));

                    if (aristaExistente == null)
                    {
                        
                        var nuevaArista = new Arista()
                        {
                            NodoA = nodoSeleccionado,
                            NodoB = nodoCercano,
                            Peso = 1,
                            SeleccionadaPorJugador = true
                        };
                        aristas.Add(nuevaArista);
                        aristasJugador.Add(nuevaArista);
                    }
                    else if (!aristaExistente.SeleccionadaPorJugador && !FormaCiclo(aristaExistente))
                    {
                        aristaExistente.SeleccionadaPorJugador = true;
                        aristasJugador.Add(aristaExistente);
                    }

                    new System.Media.SoundPlayer("imagenes/mouse.wav").Play();
                    nodoSeleccionado.Imagen.BackColor = Color.Transparent;
                    nodoSeleccionado = null;
                    panelMapa.Invalidate();
                }
            }
        }
    }

    public class Nodo
    {
        public PictureBox Imagen;
        public Point Posicion;
        public string Tesoro;
    }

    public class Arista
    {
        public Nodo NodoA, NodoB;
        public int Peso;
        public bool SeleccionadaPorJugador = false;
    }
}
