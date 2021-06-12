﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Juego_de_la_Plaga
{
    public partial class TABJuegoCvH : Form
    {
        Button[,] btn = new Button[50, 50];
        int turno = 0;

        public TABJuegoCvH()
        {
            InitializeComponent();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMP_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuPrincipal menu = new MenuPrincipal();
            menu.Show();

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
            Nivel1 nivel = new Nivel1();
            nivel.Show();

        }

        private void btnReiniciar_Click_1(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btnGO_Click(object sender, EventArgs e)
        {
            Iniciar();
        }

        string jugador1 = " ";
        string jugador2 = " ";

        private void Iniciar()
        {
            if (txtJug.Text == "" && txtIA.Text == "")
            {
                MessageBox.Show("El nombre de los Jugadores no debe estar vacío", "Nombre no válido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (txtJug.Text == "")
                {
                    MessageBox.Show("El nombre del jugador 1 no debe estar vacío", "Nombre no válido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (txtIA.Text == "")
                {
                    MessageBox.Show("El nombre del jugador 2 no debe estar vacío", "Nombre no válido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            if (txtJug.Text != "" && txtIA.Text != "")
            {
                if (rbtnJR.Checked && rbtnIAA.Checked)
                {
                    jugador1 = txtJug.Text;
                    jugador2 = txtIA.Text;
                    rbtnJA.Enabled = false;
                    rbtnIAR.Enabled = false;
                    PlayGame();

                }
                if (rbtnJA.Checked && rbtnIAR.Checked)
                {
                    jugador1 = txtIA.Text;
                    jugador2 = txtJug.Text;
                    rbtnJR.Enabled = false;
                    rbtnIAA.Enabled = false;
                    PlayGame();
                }
                if (rbtnJR.Checked && rbtnIAR.Checked)
                {
                    MessageBox.Show("Ambos jugadores no pueden escoger la misma opción", "Vuelva a escoger", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                if (rbtnJA.Checked && rbtnIAA.Checked)
                {
                    MessageBox.Show("Ambos jugadores no pueden escoger la misma opción", "Vuelva a escoger", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                if (rbtnJR.Checked == false && rbtnJA.Checked == false || rbtnIAR.Checked == false && rbtnIAA.Checked == false)
                {
                    MessageBox.Show("Cada jugador puede escoger solamente una opción", "Vuelva a escoger", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void PlayGame()
        {
            lblJug.Text = txtJug.Text;
            lblIA.Text = txtIA.Text;
            groupBox1.Text = "Marcador";
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int Xtxt = int.Parse(txtX.Text);
            int Ytxt = int.Parse(txtY.Text);

            for (int i = 1; i <= Xtxt; i++)
            {
                for (int j = 1; j <= Ytxt; j++)
                {
                    btn[i, j] = new Button()
                    {
                        Name = i + " " + j
                    };
                    btn[i, j].Size = new Size(35, 35);
                    btn[i, j].BackColor = Color.DarkGray;
                    btn[i, j].Location = new Point(35 * i, 35 * j);
                    btn[i, j].Click += new EventHandler(button_Click);

                    Controls.Add(btn[i, j]);
                    //btn[x,y].Click += (sender1, ex) => this.button_Click(index + 1);
                }
            }
            btnAgregar.Enabled = false;

            // PINTO MIS BOTONES DE INICIALIZAR (ROJO Y AZUL)
            btn[1, 1].BackColor = Color.Red;
            btn[Xtxt, Ytxt].BackColor = Color.Blue;

        }

        void Valores(object sender, ref int x, ref int y) // Agarra los valores del click
        {
            Button b = sender as Button;

            string[] split = b.Name.Split(new Char[] { ' ' });

            x = Convert.ToInt32(split[0]);
            y = Convert.ToInt32(split[1]);
        }

        void button_Click(object sender, EventArgs e)
        {
            int x = 0;
            int y = 0;
            bool movimiento = false;
            Valores(sender, ref x, ref y);

            //PINTAR ADYACENTE
            if (turno == 0)
            {
                // JUGADOR 1

                // BOTON DERECHO
                if (btn[x + 1, y] == null)
                {
                }
                else if (btn[x + 1, y].BackColor == Color.Red)
                {
                    movimiento = true;
                }

                // BOTON IZQUIERDO

                if (btn[x - 1, y] == btn[0, y])
                {
                }
                else if (btn[x - 1, y].BackColor == Color.Red)
                {
                    movimiento = true;
                }


                // BOTON ARRIBA
                if (btn[x, y - 1] == btn[x, 0])
                {
                }
                else if (btn[x, y - 1].BackColor == Color.Red)
                {
                    movimiento = true;
                }

                // BOTON ABAJO
                if (btn[x, y + 1] == null)
                {
                }
                else if (btn[x, y + 1].BackColor == Color.Red)
                {
                    movimiento = true;
                }

                // BOTON SUPERIOR IZQUIERDO
                if (btn[x - 1, y - 1] == btn[0, 0])
                {
                }
                else if (btn[x - 1, y - 1].BackColor == Color.Red)
                {
                    movimiento = true;
                }
                // BOTON SUPERIOR DERECHO
                if (btn[x + 1, y - 1] == btn[x, 0])
                {
                }
                else if (btn[x + 1, y - 1].BackColor == Color.Red)
                {
                    movimiento = true;
                }

                // BOTON INFERIOR IZQUIERDO
                if (btn[x - 1, y + 1] == btn[0, y])
                {
                }
                else if (btn[x - 1, y + 1].BackColor == Color.Red)
                {
                    movimiento = true;
                }

                // BOTON INFERIOR DERECHO
                if (btn[x + 1, y + 1] == null)
                {
                }
                else if (btn[x + 1, y + 1].BackColor == Color.Red)
                {
                    movimiento = true;
                }
            }
            // JUGADOR 2
            else
            {
                // BOTON DERECHO
                if (btn[x + 1, y] == null)
                {
                }
                else if (btn[x + 1, y].BackColor == Color.Blue)
                {
                    movimiento = true;
                }
                // BOTON IZQUIERDO
                if (btn[x - 1, y] == btn[0, y])
                {
                }
                else if (btn[x - 1, y].BackColor == Color.Blue)
                {
                    movimiento = true;
                }

                // BOTON ARRIBA
                if (btn[x, y - 1] == btn[x, 0])
                {
                }
                else if (btn[x, y - 1].BackColor == Color.Blue)
                {
                    movimiento = true;
                }

                // BOTON ABAJO
                if (btn[x, y + 1] == null)
                {
                }
                else if (btn[x, y + 1].BackColor == Color.Blue)
                {
                    movimiento = true;
                }

                // BOTON SUPERIOR IZQUIERDO
                if (btn[x - 1, y - 1] == btn[0, 0])
                {
                }
                else if (btn[x - 1, y - 1].BackColor == Color.Blue)
                {
                    movimiento = true;
                }

                // BOTON SUPERIOR DERECHO
                if (btn[x + 1, y - 1] == btn[x, 0])
                {
                }
                else if (btn[x + 1, y - 1].BackColor == Color.Blue)
                {
                    movimiento = true;
                }

                // BOTON INFERIOR IZQUIERDO
                if (btn[x - 1, y + 1] == btn[0, y])
                {
                }
                else if (btn[x - 1, y + 1].BackColor == Color.Blue)
                {
                    movimiento = true;
                }

                // BOTON INFERIOR DERECHO
                if (btn[x + 1, y + 1] == null)
                {
                }
                else if (btn[x + 1, y + 1].BackColor == Color.Blue)
                {
                    movimiento = true;
                }
            }

            if (movimiento == true)
            {
                Jugadas(x, y, ref turno);
            }

        }

        void PintarAdyacente(int x, int y, int turno)
        {

            if (turno == 0)
            {
                // JUGADOR 1

                // PINTA BOTON DERECHO
                if (btn[x + 1, y] == null)
                {
                }
                else if (btn[x + 1, y].BackColor == Color.Blue)
                {
                    btn[x + 1, y].BackColor = Color.Red;
                }

                // PINTA BOTON IZQUIERDO

                if (btn[x - 1, y] == btn[0, y])
                {
                }
                else if (btn[x - 1, y].BackColor == Color.Blue)
                {
                    btn[x - 1, y].BackColor = Color.Red;
                }


                // PINTA BOTON ARRIBA
                if (btn[x, y - 1] == btn[x, 0])
                {
                }
                else if (btn[x, y - 1].BackColor == Color.Blue)
                {
                    btn[x, y - 1].BackColor = Color.Red;
                }

                // PINTA BOTON ABAJO
                if (btn[x, y + 1] == null)
                {
                }
                else if (btn[x, y + 1].BackColor == Color.Blue)
                {
                    btn[x, y + 1].BackColor = Color.Red;
                }

                // PINTA BOTON SUPERIOR IZQUIERDO
                if (btn[x - 1, y - 1] == btn[0, 0])
                {
                }
                else if (btn[x - 1, y - 1].BackColor == Color.Blue)
                {
                    btn[x - 1, y - 1].BackColor = Color.Red;
                }
                // PINTA BOTON SUPERIOR DERECHO
                if (btn[x + 1, y - 1] == btn[x, 0])
                {
                }
                else if (btn[x + 1, y - 1].BackColor == Color.Blue)
                {
                    btn[x + 1, y - 1].BackColor = Color.Red;
                }

                // PINTA BOTON INFERIOR IZQUIERDO
                if (btn[x - 1, y + 1] == btn[0, y])
                {
                }
                else if (btn[x - 1, y + 1].BackColor == Color.Blue)
                {
                    btn[x - 1, y + 1].BackColor = Color.Red;
                }

                // PINTA BOTON INFERIOR DERECHO
                if (btn[x + 1, y + 1] == null)
                {
                }
                else if (btn[x + 1, y + 1].BackColor == Color.Blue)
                {
                    btn[x + 1, y + 1].BackColor = Color.Red;
                }
            }

            else
            {
                // JUGADOR 2

                // PINTA BOTON DERECHO
                if (btn[x + 1, y] == null)
                {
                }
                else if (btn[x + 1, y].BackColor == Color.Red)
                {
                    btn[x + 1, y].BackColor = Color.Blue;
                }
                // PINTA BOTON IZQUIERDO
                if (btn[x - 1, y] == btn[0, y])
                {
                }
                else if (btn[x - 1, y].BackColor == Color.Red)
                {
                    btn[x - 1, y].BackColor = Color.Blue;
                }

                // PINTA BOTON ARRIBA
                if (btn[x, y - 1] == btn[x, 0])
                {
                }
                else if (btn[x, y - 1].BackColor == Color.Red)
                {
                    btn[x, y - 1].BackColor = Color.Blue;
                }

                // PINTA BOTON ABAJO
                if (btn[x, y + 1] == null)
                {
                }
                else if (btn[x, y + 1].BackColor == Color.Red)
                {
                    btn[x, y + 1].BackColor = Color.Blue;
                }

                // PINTA BOTON SUPERIOR IZQUIERDO
                if (btn[x - 1, y - 1] == btn[0, 0])
                {
                }
                else if (btn[x - 1, y - 1].BackColor == Color.Red)
                {
                    btn[x - 1, y - 1].BackColor = Color.Blue;
                }

                // PINTA BOTON SUPERIOR DERECHO
                if (btn[x + 1, y - 1] == btn[x, 0])
                {
                }
                else if (btn[x + 1, y - 1].BackColor == Color.Red)
                {
                    btn[x + 1, y - 1].BackColor = Color.Blue;
                }

                // PINTA BOTON INFERIOR IZQUIERDO
                if (btn[x - 1, y + 1] == btn[0, y])
                {
                }
                else if (btn[x - 1, y + 1].BackColor == Color.Red)
                {
                    btn[x - 1, y + 1].BackColor = Color.Blue;
                }

                // PINTA BOTON INFERIOR DERECHO
                if (btn[x + 1, y + 1] == null)
                {
                }
                else if (btn[x + 1, y + 1].BackColor == Color.Red)
                {
                    btn[x + 1, y + 1].BackColor = Color.Blue;
                }
            }
        }

        void Jugadas(int x, int y, ref int turno)
        {
            if (turno == 0)
            {
                btn[x, y].BackColor = Color.Red;
                PintarAdyacente(x, y, turno);
                turno = 1;
            }
            else
            {
                btn[x, y].BackColor = Color.Blue;
                PintarAdyacente(x, y, turno);
                turno = 0;
            }
        }

    }
}
