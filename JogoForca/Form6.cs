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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //abre o form de rank top 5
        {
            Form8 rankt = new Form8();
            this.Hide();
            rankt.Show();
        }

        private void button2_Click(object sender, EventArgs e) //abre o form de rank geral
        {
            Form7 rankg = new Form7();
            this.Hide();
            rankg.Show();
        }

        private void Form6_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }

        private void button3_Click(object sender, EventArgs e) //volta ao menu
        {
            Form1 iniciar = new Form1();
            this.Hide();
            iniciar.Show();
        }
    }
}
