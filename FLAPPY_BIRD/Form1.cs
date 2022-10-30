using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FLAPPY_BIRD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int gravidade = 5;
        int speed = 10;
        int placar = 0;
        int recorde = 0;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravidade = -5;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravidade = 5;
            }
        }

        private void jogo_Tick(object sender, EventArgs e)
        {
            bird.Top += gravidade;
            tuboInferior.Left -= speed;
            tuboSuperior.Left -= speed;
            if (tuboInferior.Left < 0 - tuboInferior.Width)
            {
                Random p = new Random();
                tuboInferior.Left = this.Width + tuboInferior.Width * p.Next(1,5);
                placar++;
            }
            if (tuboSuperior.Left < 0 - tuboSuperior.Width)
            {
                Random p = new Random();
                tuboSuperior.Left = this.Width + tuboSuperior.Width * p.Next(1, 5);
                placar++;
            }
            if (bird.Bounds.IntersectsWith(tuboInferior.Bounds) ||
                bird.Bounds.IntersectsWith(tuboSuperior.Bounds) ||
                bird.Bounds.IntersectsWith(ground.Bounds) ||
                bird.Top <= 0)
            {
                lbMensagem.Text = "VOCÊ PERDEU!";
                jogo.Stop();
            }
            lbPlacar.Text = String.Format("PLACAR: {0}", placar);
            Acelerar();
        }

        private void Acelerar()
        {
            if (placar > 10) speed = 12;
            if (placar > 20) speed = 15;
            if (placar > 30) speed = 18;
            if (placar > 40) speed = 21;
            if (placar > 50) speed = 24;
            if (placar > 60) speed = 27;
            if (placar > 70) speed = 30;
            if (placar > 80) speed = 33;
            if (placar > 90) speed = 36;
            if (placar > 100) speed = 39;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetterOrDigit(e.KeyChar))
            { 
                tuboInferior.Left = this.Width + tuboInferior.Width;
                tuboSuperior.Left = this.Width + tuboSuperior.Width;
                bird.Top = this.Height / 2;
                if (placar > recorde)
                {
                    recorde = placar;
                    lbRecorde.Text = String.Format("RECORDE = {0}", recorde);
                    Registro.Gravar("FLAPPY", "RECORDE", recorde.ToString());
                }
                lbMensagem.Text = "PRESSIONE ESC PARA SAIR...";
                placar = 0;
                speed = 10;
                jogo.Start();
            }
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                Environment.Exit(0);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            recorde = Int32.Parse(Registro.Ler("FLAPPY", "RECORDE"));
            lbRecorde.Text = String.Format("RECORDE = {0}", recorde);
        }
    }
}
