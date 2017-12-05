using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace JogoForca
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        string ficheiro = "";
        string dificuldade = "";
        private void Binserir_Click(object sender, EventArgs e)
        {
            
            //verifica qual a categoria a que estamos a fazer upload
            if (radioButton1.Checked)
            {
                ficheiro = @"Animais.txt";
            }
            else if (radioButton2.Checked)
            {
                ficheiro = @"Frutas.txt";
            }
            else if (radioButton3.Checked)
            {
                ficheiro = @"Países.txt";
            }
            else if (radioButton4.Checked)
            {
                ficheiro = @"Profissões.txt";
            }
            else
            {
                MessageBox.Show("Escolha a categoria onde pretende inserir", "Erro", MessageBoxButtons.OK);
                
            }

            if (radioButton5.Checked)
            {
                dificuldade = "f";
            }
            else if (radioButton6.Checked)
            {
                dificuldade = "m";
            }
            else if (radioButton7.Checked)
            {
                dificuldade = "d";
            }
            else
            {
                MessageBox.Show("Escolha uma dificuldade", "Erro", MessageBoxButtons.OK);
            }

            palavra();
        }

        private void palavra()
        {
            //abre o ficheiro da categoria e adiciona a palavra
            string palavra = BoxPalavra.Text;
            StreamWriter sw;
            sw = File.AppendText(ficheiro);
            string linha ="\r\n" + dificuldade + "," + palavra;
            sw.Write(linha);
            sw.Close();
            label3.Visible = true;
        }

        private void Bvoltar_Click(object sender, EventArgs e)
        {
            Form1 menu = new Form1();
            this.Hide();
            menu.Show();
            
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }

       
    }
}
