using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace PContato0030482221012
{
    public partial class Form1 : Form
    {
        public static SqlConnection conexao;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection("");
                conexao.Open();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Erro de banco de dados =/");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Outros Erros =/" + ex.Message);
            }
            
        }

        private void CidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if(Application.OpenForms.OfType<frmCidade>().Count()>0)
            {
                MessageBox.Show("Formulário já existe!");
                Application.OpenForms["frmcidade"].BringToFront();
            }
            else
            {
                frmCidade objC = new frmCidade();
                objC.MdiParent = this;
                objC.WindowState = FormWindowState.Maximized;
                objC.Show();
            }
        }

        private void ContatoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<frmContato>().Count() > 0)
            {
                MessageBox.Show("Formulário já existe!");
                Application.OpenForms["frmcontato"].BringToFront();
            }
            else
            {
                frmContato objC = new frmContato();
                objC.MdiParent = this;
                objC.WindowState = FormWindowState.Maximized;
                objC.Show();
            }
        }

        private void SobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<frmSobre>().Count() > 0)
            {
                MessageBox.Show("Formulário já existe!");
                Application.OpenForms["frmsobre"].BringToFront();
            }
            else
            {
                frmSobre objC = new frmSobre();
                objC.MdiParent = this;
                objC.WindowState = FormWindowState.Maximized;
                objC.Show();
            }
        }

        private void SairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
