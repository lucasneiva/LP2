using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;



namespace ExercicioPratico
{
    public partial class frmEx4 : Form
    {
        public frmEx4()
        {
            InitializeComponent();
        }

        private void btnContar_Click(object sender, EventArgs e)
        {
            string[] lista = { "Ana", "André", "Débora", "Fátima", "João", "Janete", "Otávio", "Marcelo", "Pedro", "Thais" };
            ArrayList arrayList = new ArrayList(lista);
            string res = "";
            arrayList.Remove("Otávio");
            for(int i = 0; i < arrayList.Count; i++)
            {
                res += (string)arrayList[i] + " ";
            }
            MessageBox.Show(res);
        }
    }
}
