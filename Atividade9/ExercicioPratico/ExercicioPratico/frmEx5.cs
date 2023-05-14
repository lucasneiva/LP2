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
    public partial class frmEx5 : Form
    {
        public frmEx5()
        {
            InitializeComponent();
        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            int[,] notas = new int[20,3];
            double[] medias = new double[20];
            string stringona = "";
            for (int i = 0; i < 20; i++)
            {
                int acc = 0;
                for (int j = 0; j < 3; j++)
                {
                    
                    if (!int.TryParse(Interaction.InputBox("Aluno " + (i+1) + ", nota " + (j+1) + ": "), out notas[i,j]))
                    {
                        j--;
           
                        MessageBox.Show("Valor Inválido!");
                    }
                    else
                    {
                        acc += notas[i, j];
                        medias[i] = acc / (double)3;
                    }
                    
                }
            }

            for (int i = 0; i < 20; i++)
            {
                stringona += "Aluno " + (i+1) + ": Média: " + medias[i] + "\n";
            }
            MessageBox.Show(stringona);
        }
    }
}
