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
    public partial class frmEx6 : Form
    {
        public frmEx6()
        {
            InitializeComponent();
        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < 2; i++)
            {
                string nome = Interaction.InputBox("Digite seu nome: ").Trim();
                
                string mensagem = "O nome " + nome + " tem " + nome.Replace(" ", "").Length + " letras.";
                listBoxNomes.Items.Add(mensagem);

            }
        }
    }
}
