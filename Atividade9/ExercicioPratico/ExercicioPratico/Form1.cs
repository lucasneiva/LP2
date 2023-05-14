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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEx1_Click(object sender, EventArgs e)
        {
            if (!(Application.OpenForms.OfType<frmEx1>().Count() > 0))
            {
                frmEx1 ex1 = new frmEx1();
                //ex1.MdiParent = this;
                ex1.WindowState = FormWindowState.Maximized;
                ex1.Show();
            }
            else
                Application.OpenForms["frmEx1"].BringToFront();
        }

        private void btnEx2_Click(object sender, EventArgs e)
        {
            if (!(Application.OpenForms.OfType<frmEx2>().Count() > 0))
            {
                frmEx2 ex2 = new frmEx2();
                //ex1.MdiParent = this;
                ex2.WindowState = FormWindowState.Maximized;
                ex2.Show();
            }
            else
                Application.OpenForms["frmEx2"].BringToFront();
        }

        private void btnEx3_Click(object sender, EventArgs e)
        {
            if (!(Application.OpenForms.OfType<frmEx3>().Count() > 0))
            {
                frmEx3 ex3 = new frmEx3();
                //ex1.MdiParent = this;
                ex3.WindowState = FormWindowState.Maximized;
                ex3.Show();
            }
            else
                Application.OpenForms["frmEx3"].BringToFront();
        }

        private void btnEx4_Click(object sender, EventArgs e)
        {
            if (!(Application.OpenForms.OfType<frmEx4>().Count() > 0))
            {
                frmEx4 ex4 = new frmEx4();
                //ex1.MdiParent = this;
                ex4.WindowState = FormWindowState.Maximized;
                ex4.Show();
            }
            else
                Application.OpenForms["frmEx4"].BringToFront();
        }

        private void btnEx5_Click(object sender, EventArgs e)
        {
            if (!(Application.OpenForms.OfType<frmEx5>().Count() > 0))
            {
                frmEx5 ex5 = new frmEx5();
                //ex1.MdiParent = this;
                ex5.WindowState = FormWindowState.Maximized;
                ex5.Show();
            }
            else
                Application.OpenForms["frmEx5"].BringToFront();
        }

        private void btnEx6_Click(object sender, EventArgs e)
        {
            if (!(Application.OpenForms.OfType<frmEx6>().Count() > 0))
            {
                frmEx6 ex6 = new frmEx6();
                //ex1.MdiParent = this;
                ex6.WindowState = FormWindowState.Maximized;
                ex6.Show();
            }
            else
                Application.OpenForms["frmEx6"].BringToFront();
        }
    }
}
