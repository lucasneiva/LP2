using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace ExercicioPratico
{
    public partial class frmEx2 : Form
    {
        public frmEx2()
        {
            InitializeComponent();
        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            int[] qtdes = new int[10];
            int[] precos = new int[10];
            double fat = 0;
            for(int i = 0; i < 10; i++)
            {
                if (!int.TryParse(Interaction.InputBox("Digite qtde do Produto " + i + ": "), out qtdes[i]))
                {
                    i--;
                    MessageBox.Show("Valor Inválido!");
                }
                if (!int.TryParse(Interaction.InputBox("Digite preco do Produto " + i + ": "), out precos[i]))
                {
                    i--;
                    MessageBox.Show("Valor Inválido!");
                }
            }

            for(int i = 0; i < 10; i++)
            {
                fat += qtdes[i]*precos[i];

            }
            MessageBox.Show("Faturamento: " + fat);
        }
    }
}
