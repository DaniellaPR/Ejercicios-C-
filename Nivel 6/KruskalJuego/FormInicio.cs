//Pantalla de Inicio

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RoboKruskal
{
    public partial class FormInicio : Form
    {
        private string carpetaMapas = "imagenes/mapas";
        private string carpetaObstaculos = "imagenes/obstaculos";

        private string mapaSeleccionado = "";
        private int dificultadSeleccionada = 0;

        public FormInicio()
        {
            InitializeComponent();
            this.ClientSize = new Size(900, 600);
            InicializarInterfaz();
        }

        private void InicializarInterfaz()
        {
            this.Text = "El gran robo - Pantalla de inicio";
            this.BackColor = Color.FromArgb(46, 46, 46);

            Label lblTitulo = new Label()
            {
                Text = "Trampas y Ladrones",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.Coral,
                AutoSize = true,
                Location = new Point(350, 20)
            };
            this.Controls.Add(lblTitulo);

            //Título dificultad
            Label lblDif = new Label()
            {
                Text = "Selecciona la dificultad:",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(50, 80),
                AutoSize = true
            };
            this.Controls.Add(lblDif);

            //Mostrar obstáculos
            int xDif = 50;
            for (int i = 1; i <= 10; i++)
            {
                Button btnDif = new Button()
                {
                    Name = $"btnDif{i}",
                    Tag = i,
                    Size = new Size(50, 50),
                    Location = new Point(xDif, 120),
                    BackColor = Color.Gray,
                    BackgroundImageLayout = ImageLayout.Stretch
                };

                string ruta = Path.Combine(carpetaObstaculos, $"{i}.png");
                if (File.Exists(ruta))
                    btnDif.BackgroundImage = Image.FromFile(ruta);

                btnDif.Click += BtnDificultad_Click;
                this.Controls.Add(btnDif);
                xDif += 60;
            }

            //Título mapas
            Label lblMapa = new Label()
            {
                Text = "Selecciona el mapa:",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(50, 200),
                AutoSize = true
            };
            this.Controls.Add(lblMapa);

            //Mapas
            string[] mapas = { "1_mansion.png", "2_barco.png", "3_museo.png" };
            int xMapa = 50;
            for (int i = 0; i < mapas.Length; i++)
            {
                Button btnMapa = new Button()
                {
                    Name = $"btnMapa{i + 1}",
                    Tag = mapas[i],
                    Size = new Size(250, 200),
                    Location = new Point(xMapa, 240),
                    BackgroundImageLayout = ImageLayout.Stretch
                };

                string ruta = Path.Combine(carpetaMapas, mapas[i]);
                if (File.Exists(ruta))
                    btnMapa.BackgroundImage = Image.FromFile(ruta);

                btnMapa.Click += BtnMapa_Click;
                this.Controls.Add(btnMapa);
                xMapa += 280;
            }

            //Botón comenzar
            Button btnJugar = new Button()
            {
                Text = "Trazar ruta",
                Name = "btnJugar",
                Size = new Size(200, 50),
                Location = new Point(350, 500),
                BackColor = Color.DarkGreen,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };
            btnJugar.Click += BtnJugar_Click;
            this.Controls.Add(btnJugar);
        }

        private void BtnDificultad_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            dificultadSeleccionada = (int)btn.Tag;
            new System.Media.SoundPlayer("imagenes/clic.wav").Play();
            MessageBox.Show($"Dificultad seleccionada: {dificultadSeleccionada}", "Info");
        }

        private void BtnMapa_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            mapaSeleccionado = btn.Tag.ToString();
            new System.Media.SoundPlayer("imagenes/clic.wav").Play();
            MessageBox.Show($"Mapa seleccionado: {mapaSeleccionado}", "Info");
        }

        private void BtnJugar_Click(object sender, EventArgs e)
        {
            if (dificultadSeleccionada == 0 || string.IsNullOrEmpty(mapaSeleccionado))
            {
                MessageBox.Show("Debes seleccionar un mapa y una dificultad.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                new System.Media.SoundPlayer("imagenes/clic.wav").Play();
                return;
            }

            //Llamar al form Juego
            FormJuego juego = new FormJuego(dificultadSeleccionada, Path.Combine(carpetaMapas, mapaSeleccionado));
            juego.Show();
            this.Hide();
        }
    }
}


