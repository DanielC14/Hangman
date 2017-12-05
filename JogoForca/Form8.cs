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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
            StreamReader sr;
            string[] lerTexto = File.ReadAllLines(@"Rank.txt");
            sr = File.OpenText(@"Rank.txt");
            int mpontos1 = 0;
            int mpontos2 = 0;
            int mpontos3 = 0;
            int mpontos4 = 0;
            int mpontos5 = 0;
            string cod = "";
            string uti = "";
            string njo = "";
            string pon = "";
            
            int points = 0;

            //le as pontuaçoes dos ranks e se forem menores do que as do rank anterior e maiores do que 0 ele guarda e escreve na textbox
            try
            {
                //PONTO 1
               
                    foreach (string s in lerTexto)
                {
                    string[] linha = s.Split('\n');

                    foreach (string b in linha)
                    {
                        string[] divi = b.Split(';');
                        points = Convert.ToInt16(divi[3]);
                        
                        if(points > mpontos1)
                        {
                            mpontos1 = points;
                            cod = divi[0];
                            uti = divi[1];
                            njo = divi[2];
                            pon = divi[3];
                        }
                    }
                        
                    }
                
                            textBox5.AppendText(cod + "\n");
                            textBox6.AppendText(uti + "\n");
                            textBox7.AppendText(njo + "\n");
                            textBox8.AppendText(pon + "\n");

                //PONTO 2
                           
                                foreach (string s in lerTexto)
                                {
                                    string[] linha = s.Split('\n');

                                    foreach (string b in linha)
                                    {
                                        string[] divi = b.Split(';');
                                        points = Convert.ToInt16(divi[3]);
                                        
                                        if (points < mpontos1 && points > mpontos2)
                                        {
                                            mpontos2 = points;
                                            cod = divi[0];
                                            uti = divi[1];
                                            njo = divi[2];
                                            pon = divi[3];
                                        }
                                    }

                                }
                            
                            textBox5.AppendText(cod + "\n");
                            textBox6.AppendText(uti + "\n");
                            textBox7.AppendText(njo + "\n");
                            textBox8.AppendText(pon + "\n");


                //PONTO 3
                            
                                foreach (string s in lerTexto)
                                {
                                    string[] linha = s.Split('\n');

                                    foreach (string b in linha)
                                    {
                                        string[] divi = b.Split(';');
                                        points = Convert.ToInt16(divi[3]);
                                        if (points < mpontos2 && points > mpontos3)
                                        {
                                            mpontos3 = points;
                                            cod = divi[0];
                                            uti = divi[1];
                                            njo = divi[2];
                                            pon = divi[3];
                                        }
                                    }

                                }
                            
                            textBox5.AppendText(cod + "\n");
                            textBox6.AppendText(uti + "\n");
                            textBox7.AppendText(njo + "\n");
                            textBox8.AppendText(pon + "\n");

                //PONTO 4
                            
                                foreach (string s in lerTexto)
                                {
                                    string[] linha = s.Split('\n');

                                    foreach (string b in linha)
                                    {
                                        string[] divi = b.Split(';');
                                        points = Convert.ToInt16(divi[3]);
                                        if (points < mpontos3 && points > mpontos4)
                                        {
                                            mpontos4 = points;
                                            cod = divi[0];
                                            uti = divi[1];
                                            njo = divi[2];
                                            pon = divi[3];
                                        }
                                    }

                                }
                            
                            textBox5.AppendText(cod + "\n");
                            textBox6.AppendText(uti + "\n");
                            textBox7.AppendText(njo + "\n");
                            textBox8.AppendText(pon + "\n");
                //PONTO 5
                            
                                foreach (string s in lerTexto)
                                {
                                    string[] linha = s.Split('\n');

                                    foreach (string b in linha)
                                    {
                                        string[] divi = b.Split(';');
                                        points = Convert.ToInt16(divi[3]);
                                        if (points < mpontos4 && points > mpontos5)
                                        {
                                            mpontos5 = points;
                                            cod = divi[0];
                                            uti = divi[1];
                                            njo = divi[2];
                                            pon = divi[3];
                                        }
                                    }

                                }
                            
                            textBox5.AppendText(cod + "\n");
                            textBox6.AppendText(uti + "\n");
                            textBox7.AppendText(njo + "\n");
                            textBox8.AppendText(pon + "\n");
                    }


                

            catch { }



        }

        private void Form8_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form6 rank = new Form6();
            this.Hide();
            rank.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 inicial = new Form1();
            this.Hide();
            inicial.Show();
        }
    }
}
