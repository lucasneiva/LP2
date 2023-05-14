using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExercicioPratico
{
    public partial class frmEx3 : Form
    {
        public frmEx3()
        {
            InitializeComponent();
        }

        private void btnContar_Click(object sender, EventArgs e)
        {
            string[] Alunos = { "Viviane", "André", "Hélio", "Denise", "Junior", "Leonardo", "Jose", "Nelma", "Tobby" }; 
            Int32 I, Total = 0; 
            Int32 N = Alunos.Length; 
            for (I = 0; I < N-1; I++) 
            { 
                Total += Alunos[I].Length;
            }
            MessageBox.Show(Total.ToString());
        }
    }
}
