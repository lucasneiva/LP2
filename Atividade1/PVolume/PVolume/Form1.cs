using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PVolume
{
    public partial class Form1 : Form
    {
        double raio;
        public Form1()
        {
            InitializeComponent();
        }

        private void TextBox2_Validated(object sender, EventArgs e)
        {
            //double raio;
            if (!double.TryParse(textBox2.Text, out raio))
                MessageBox.Show("raio inválido");
            else if (raio <= 0)
            {
                MessageBox.Show("raio deve ser maior que zero");
                textBox2.Focus();
            }
        }

        private void TextBox4_Validated(object sender, EventArgs e)
        {
            double altura;
            if (!double.TryParse(textBox4.Text, out altura))
            {
                MessageBox.Show("altura inválida");
                textBox4.Focus();
            }
            else if (altura <= 0)
            {
                MessageBox.Show("altura deve ser maior que zero");
                textBox4.Focus();
            }

            double volume;
            volume = Math.PI * Math.Pow(raio, 2) * altura;
            textBox5.Text = volume.ToString("N2");
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
