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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Botao que abre o form onde se faz as configuraçoes do jogo
        private void Biniciar_Click(object sender, EventArgs e)
        {
            Form4 config = new Form4();
            this.Hide();
            config.Show();
        }


        //Botao para fechar o jogo
        private void Bterminar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Botao que abre o menu de upload de palavras
        private void Bpalavras_Click(object sender, EventArgs e)
        {
            Form5 upalavra = new Form5();
            this.Hide();
            upalavra.Show();
        }

        //Botao para abrir o menu de ranks
        private void Brank_Click(object sender, EventArgs e)
        {
            Form6 rank = new Form6();
            this.Hide();
            rank.Show();
        }

        //fechar a aplicaçao quando se fecha o form
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }

        
        

    }
}
