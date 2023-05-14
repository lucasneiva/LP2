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
    public partial class frmEx1 : Form
    {
        public frmEx1()
        {
            InitializeComponent();
        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            int[] vetor = new int[10];
            string resultado = "";
            for (int i = 0; i < 10; i++)
            {
                if (!int.TryParse(Interaction.InputBox("Digite um numero: "), out vetor[i]))
                {
                    i--;
                    MessageBox.Show("Valor Inválido!");
                }
            }

            //Array.Reverse(vetor);

            for (int i = 9; i >= 0; i--)
            {
                resultado += vetor[i] + " ";
            }
            
            
            MessageBox.Show(resultado);
        }
    }
}
