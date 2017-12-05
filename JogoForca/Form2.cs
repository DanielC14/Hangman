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
using System.Text.RegularExpressions;

namespace JogoForca
{
    public partial class Form2 : Form
    {
        //iniciar o jogo com as configuraçoes anteriormente feitas
        public Form2(string tempoj,string ficheiro,int tentativa,string dificuldade,string Ttema,string Tdifi,string utilizador,int Pdifi)
        {
            InitializeComponent();
            //todas as variaveis usadas em outros forms
            this.tempojogada = tempoj;
            this.ficheirop = ficheiro;
            this.erradas = tentativa;
            this.nivel = dificuldade;
            this.Ttema = Ttema;
            this.Tdifi = Tdifi;
            this.utilizador = utilizador;
            this.Pdifi = Pdifi;
            Ltema.Text = Ttema;
            Ldific.Text = Tdifi;
            Luser.Text = utilizador;
            carregarpalavras();
            escolhaPalavra();
            label1.Text = tempojogada;
            timer1.Start();
        }

        

        private Bitmap[] forcaimagem = {JogoForca.Properties.Resources._1,JogoForca.Properties.Resources._2,
                                        JogoForca.Properties.Resources._3,JogoForca.Properties.Resources._4,
                                        JogoForca.Properties.Resources._5,JogoForca.Properties.Resources._6,
                                        JogoForca.Properties.Resources._7,JogoForca.Properties.Resources._8,
                                        JogoForca.Properties.Resources._9};
        int erradas = 0;
        string escolha = "";
        string copiaEscolha = "";
        string[] palavras;
        string[] linharank;
        string tempojogada = "20";
        string ficheirop = "";
        string nivel;
        string Ttema;
        string Tdifi;
        string utilizador;
        int pontuacao;
        int Pdifi;
        int index = 0;

        private void carregarpalavras() //void que le todas as palavras dependendo da categoria escolhida
        {
            string[] lerTexto = File.ReadAllLines(ficheirop);
            palavras = new string[lerTexto.Length];
            
            foreach (string s in lerTexto)
             {
                 
                 string[] linha = s.Split(',');
                 if (linha[0] == nivel)
                 {
                     palavras[index++] = linha[1];
                 }
             }
        }

        private void escolhaPalavra() //void que vai escolher uma palavra random da categoria e da dificuldade escolhidas
        {
            Random rnd = new Random();
            PBoxForca.Image = forcaimagem[erradas];
            int escIndex = rnd.Next(0,index);
            escolha = palavras[escIndex];

            copiaEscolha = "";
            for (int i = 0; i < escolha.Length; i++) //criaçao dos traços que aparecem na janela do jogo para indicar o numero de letras da palavra e que serao substituidos caso a letra escolhida esteja na palavra
            {
                if(escolha[i] == ' ')
                {
                    copiaEscolha += " ";
                }
                else
                {
                    copiaEscolha += "_";
                }
                
            }
            mostrarCopia();
        }

        private void mostrarCopia() // adiciona um espaço entre cada traço de modo a que nao fique ______ e sim _ _ _ _ _ 
        {
            Padivinha.Text = "";
            for (int i = 0; i < copiaEscolha.Length; i++)
            {
                Padivinha.Text += copiaEscolha.Substring(i, 1);
                Padivinha.Text += " ";
            }
        }

        private void tentativaClick(object sender, EventArgs e) //quando o jogador escolhe uma letra
        {
            try
            {
                label1.Text = tempojogada;
                Button escolhido = sender as Button; // o botao da respetiva letra é desativado
                escolhido.Enabled = false;
                if (escolha.Contains(escolhido.Text)) // e se a letra do botao escolhido esta contida na palavra, os _ sao substituidos por essa letra
                {
                    char[] temp = copiaEscolha.ToCharArray();
                    char[] busca = escolha.ToCharArray();
                    char adivinha = escolhido.Text.ElementAt(0);
                    for (int i = 0; i < busca.Length; i++)
                    {
                        if (busca[i] == adivinha)
                        {
                            temp[i] = adivinha;
                        }
                    }
                    copiaEscolha = new string(temp);
                    mostrarCopia();
                }
                else //se a letra nao estiver contida na palavra, o nº de erradas aumenta e a imagem muda
                {
                    erradas++;
                }

                if (erradas < 7)
                {
                    PBoxForca.Image = forcaimagem[erradas];
                }
                fimJogo();
            }
            catch
            {

            }
        }

        private void fimJogo() //jogador perde ficando sem tentativas ou ganha acertando na palavra
        {
            if (erradas == 7) // se o numero de erradas for 7 o temporizador pára, a imagem muda, é dito que o utilizador nao tem mais tentativas e é guardada a pontuaçao
            {
                timer1.Stop();
                Lresultado.Text = "Perdeste!!!";
                label1.Font = new Font(label1.Font.FontFamily, 26);
                PBoxForca.Image = forcaimagem[8];
                label1.Text = "Sem tentativas!!!";
                Padivinha.Text = escolha;
                DesativarBotao(BoxLetras);
                Bjnovamente.Visible = true;
                pontuacao = (-3) / Pdifi;
                calcPontos();
            }
            else if (label1.Text == "0") //caso o tempo acabe, é dito que o utilizador perdeu porque acabou o tempo
            {
                timer1.Stop();
                Lresultado.Text = "Perdeste!!!";
                label1.Font = new Font(label1.Font.FontFamily, 26);
                PBoxForca.Image = forcaimagem[8];
                label1.Text = "Acabou o tempo!!!";
                Padivinha.Text = escolha;
                DesativarBotao(BoxLetras);
                pontuacao = 0;
                Bjnovamente.Visible = true;
            }
            else if (copiaEscolha == escolha) // o jogador ganha depois de descobrir a palavra e é guardada a sua pontuação
            {
                timer1.Stop();
                Lresultado.Text = "Ganhaste!!!";
                PBoxForca.Image = forcaimagem[7];
                DesativarBotao(BoxLetras);
                Bjnovamente.Visible = true;
                pontuacao = 1 * Pdifi;
                calcPontos();
            }


            
        }

        private void calcPontos() //fazer o calculo de pontos e escrever num ficheiro o codigo do utilizador, nome, nº de jogos e pontuaçao
        {
            string[] lerTexto = File.ReadAllLines(@"Rank.txt");
            string todotexto = File.ReadAllText(@"Rank.txt");
            linharank = new string[lerTexto.Length];
            string linhab = "";
            StreamReader sr;
            StreamWriter sw;
            sr = File.OpenText(@"Rank.txt");
            bool userExiste = false;
            string lastline = "";
            string linhanovo = "";
            string snumuti = "";

            while((linhab = sr.ReadLine()) != null)
            {
                if (linhab.Contains(utilizador))
                {
                    userExiste = true;
                }
            }
            sr.Close();

            if(userExiste == true) //caso o jogador ja exista
            {
                foreach (string s in lerTexto)
                {
                    string[] linha = s.Split('\n');

                    foreach (string b in linha)
                    {
                        string[] divi = b.Split(';');
                        if(divi[1] == utilizador)
                        {
                            int njogos = Convert.ToInt32(divi[2]);
                            njogos = njogos + 1;
                            string njogos2 = Convert.ToString(njogos);
                            int pontos = Convert.ToInt32(divi[3]);
                            if (pontos < 0)
                            {
                                pontos = 0;
                            }
                            else
                            {
                                pontos = pontos + pontuacao;
                            }

                            string pontos2 = Convert.ToString(pontos);
                            string novotexto = b.Replace(divi[2] + ";" + divi[3], njogos2 + ";" + pontos2);
                            string textofinal = todotexto.Replace(s, novotexto);
                            File.Delete(@"Rank.txt");
                            sw = File.CreateText(@"Rank.txt");
                            sw.Write(textofinal);
                            sw.Close();
                        }
                        
                    }
                }
            }
            else //se o jogador nao existir
            {
                if ((lastline = File.ReadAllText(@"Rank.txt")) == "")
                {

                    linhanovo = "0001" + ";" + utilizador + ";1;" + pontuacao;
                    sw = File.AppendText(@"Rank.txt");
                    sw.Write(linhanovo);
                    sw.Close();
                }
                else
                {
                    lastline = File.ReadLines(@"Rank.txt").Last();
                    string[] last = lastline.Split(';');
                    int numuti = Convert.ToInt16(last[0]);
                    numuti = numuti + 1;
                    if (0 <= numuti && numuti <= 9)
                    {

                        snumuti = "000" + Convert.ToString(numuti);

                    }
                    else if (10 <= numuti && numuti <= 99)
                    {
                        snumuti = "00" + Convert.ToString(numuti);
                    }
                    else if (100 <= numuti && numuti <= 999)
                    {
                        snumuti = "0" + Convert.ToString(numuti);
                    }
                    else if (1000 <= numuti && numuti <= 9999)
                    {
                        snumuti = Convert.ToString(numuti);
                    }

                    if (pontuacao < 0)
                    {
                        pontuacao = 0;
                    }

                    linhanovo = snumuti + ";" + utilizador + ";1;" + pontuacao;
                    sw = File.AppendText(@"Rank.txt");
                    sw.Write("\r\n" + linhanovo);
                    sw.Close();
                }
            }
                    
                
            
        }

        private void DesativarBotao(Control con) //permite desativar um botao quando invocado
        {
            foreach (Control c in con.Controls)
            {
                DesativarBotao(c);
            }
            con.Enabled = false;
        }

        private void Bjnovamente_Click(object sender, EventArgs e) //botao de jogar novamente
        {
            timer1.Stop();
            erradas = 0;
            this.Controls.Clear();
            this.InitializeComponent();
            escolhaPalavra();
            label1.Text = tempojogada;
            Ltema.Text = Ttema;
            Ldific.Text = Tdifi;
            Luser.Text = utilizador;
            timer1.Start();
            fimJogo();
        }

        public void timer1_Tick(object sender, EventArgs e) //temporizador
        {
            try
            {
                int timer1 = Convert.ToInt32(label1.Text);
                timer1 = timer1 - 1;
                label1.Text = Convert.ToString(timer1);
                fimJogo();
            }
            catch { }
            
        }

        

        private void menuInicialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 menu = new Form1();
            this.Hide();
            menu.Show();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Tem a certeza que deseja sair?","Sair",MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Application.ExitThread();
            }
            else if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Tem a certeza que deseja sair?", "Sair", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Application.ExitThread();
            }
            else if (dialog == DialogResult.No)
            {
                
            }
        }

        private void alterarConfiguraçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 config = new Form4();
            this.Hide();
            config.Show();
        }

        private void Ltema_Click(object sender, EventArgs e)
        {

        }





      
    }
}
