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
using System.Runtime.InteropServices;

namespace JogoForca
{
    public partial class Form7 : Form 
    {
        public Form7()
        {
            InitializeComponent();
            StreamReader sr;
            string[] lerTexto = File.ReadAllLines(@"Rank.txt");
            sr = File.OpenText(@"Rank.txt");
            
            //le todas as linhas do ficheiro de ranks e re escreveas nas textbox
                try
                {
                    foreach (string s in lerTexto)
                    {
                        string[] linha = s.Split('\r');

                        foreach (string b in linha)
                        {
                            string[] divi = b.Split(';');
                            
                            textBox5.AppendText(divi[0] + "\n");
                            textBox6.AppendText(divi[1] + "\n");
                            textBox7.AppendText(divi[2] + "\n");
                            textBox8.AppendText(divi[3] + "\n");
                        }
                    }
                    
                }
                   
                catch { }
                               

        }

        private void Form7_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 rank = new Form6();
            this.Hide();
            rank.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 inicial = new Form1();
            this.Hide();
            inicial.Show();
        }
        

        


       
    }
}
