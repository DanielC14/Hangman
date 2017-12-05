using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoForca
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        string tempoj = "20";
        string ficheiro = "";
        int tentativa;
        string dificuldade;
        string Ttema;
        string Tdifi;
        int Pdifi;

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 menu = new Form1();
            this.Hide();
            menu.Show();
        }

        private void Bguardar_Click(object sender, EventArgs e)
        {
            //TEMPO DE JOGADA
            if(radioButton1.Checked)
            {
                tempoj = "5";
            }
            if (radioButton2.Checked)
            {
                tempoj = "10";
            }
            if (radioButton3.Checked)
            {
                tempoj = "15";
            }
            if (radioButton4.Checked)
            {
                tempoj = "20";
            }

            //TEMA
            if (radioButton11.Checked)
            {
               ficheiro = @"Animais.txt";
               Ttema = "Animais";
            }
            if (radioButton12.Checked)
            {
                ficheiro = @"Frutas.txt";
                Ttema = "Frutas";
            }
            if (radioButton13.Checked)
            {
                ficheiro = @"Países.txt";
                Ttema = "Países";
            }
            if (radioButton14.Checked)
            {
                ficheiro = @"Profissões.txt";
                Ttema = "Profissões";
            }

            //NUMERO DE TENTATIVAS
            if (radioButton8.Checked)
            {
                tentativa = 4;
            }
            if (radioButton9.Checked)
            {
                tentativa = 2;
            }
            if (radioButton10.Checked)
            {
                tentativa = 0;
            }

            //DIFICULDADE
            if (radioButton5.Checked)
            {
                dificuldade = "f";
                Tdifi = "Fácil";
                Pdifi = 1;
                
            }
            if (radioButton6.Checked)
            {
                dificuldade = "m";
                Tdifi = "Média";
                Pdifi = 2;
                
            }
            if (radioButton7.Checked)
            {
                dificuldade = "d";
                Tdifi = "Difícil";
                Pdifi = 3;
               
            }
            if (BoxUser.Text == "")
            {
                MessageBox.Show("Insira um nome de utilizador válido", "Erro", MessageBoxButtons.OK);
            }
            else
            {
                string utilizador = BoxUser.Text;
                Form2 jogo = new Form2(tempoj, ficheiro, tentativa, dificuldade, Ttema, Tdifi,utilizador,Pdifi); //variaveis a enviar para o form2
                this.Hide();
                jogo.Show();
            }

           
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }

        private void BoxUser_TextChanged(object sender, EventArgs e)
        {

        }

       



    }
}
