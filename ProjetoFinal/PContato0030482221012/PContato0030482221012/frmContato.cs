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
using System.Text.RegularExpressions;

namespace PContato0030482221012
{
    public partial class frmContato : Form
    {

        private BindingSource bncontato = new BindingSource();
        private bool bInclusao = false;
        private DataSet dscontato = new DataSet();
        private DataSet dsCidade = new DataSet();

        public frmContato()
        {
            InitializeComponent();

        }

        private void TxtTelefone_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void LblEmail_Click(object sender, EventArgs e)
        {

        }

        private void FrmContato_Load(object sender, EventArgs e)
        {
            try
            {
                Contato Con = new Contato();
                dscontato.Tables.Add(Con.Listar());
                bncontato.DataSource = dscontato.Tables["Contato"];
                dgvContato.DataSource = bncontato;

                bnvContato.BindingSource = bncontato;

                txtId.DataBindings.Add("TEXT", bncontato, "id_contato");
                txtNome.DataBindings.Add("TEXT", bncontato, "nome_contato");

                txtEnd.DataBindings.Add("TEXT", bncontato, "end_contato");
                txtTelefone.DataBindings.Add("TEXT", bncontato, "cel_contato");
                txtEmail.DataBindings.Add("TEXT", bncontato, "email_contato");
                dtpContato.DataBindings.Add("TEXT", bncontato, "dtcadastro_contato");

                Cidade Cid = new Cidade();
                dsCidade.Tables.Add(Cid.Listar());
                cbxCidade.DataSource = dsCidade.Tables["Cidade"];

                cbxCidade.DisplayMember = "nome_cidade";

                cbxCidade.ValueMember = "id_cidade";

                cbxCidade.DataBindings.Add("SelectedValue", bncontato, "cidade_id_cidade");
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao listar contatos!");
            }
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            if (tbContato.SelectedIndex == 0)
            {
                tbContato.SelectTab(1); // detalhes
            }

            bncontato.AddNew();
            dtpContato.Enabled = true;
            txtNome.Enabled = true;
            txtEnd.Enabled = true;
            txtTelefone.Enabled = true;
            txtEmail.Enabled = true;
            cbxCidade.Enabled = true;
            cbxCidade.SelectedIndex = 0;

            btnNovo.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = true;
            btnCancelar.Enabled = true;

            bInclusao = true;
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            

            if (txtNome.Text == "" || txtNome.Text.Length < 3 || txtNome.Text.Length > 50 || temNumero(txtNome.Text))
            {
                MessageBox.Show("Nome inválido!");
                
            }
            else
            {
                if(txtEnd.Text == "" || txtEnd.Text.Length > 100)
                {
                    MessageBox.Show("Endereço inválido!");
                }
                else
                {
                    int telefone;
                    if(txtTelefone.Text == "" || txtTelefone.Text.Length > 15 || !int.TryParse(txtTelefone.Text, out telefone))
                    {
                        MessageBox.Show("Celular inválido!");
                    }
                    else
                    {
                        if(txtEmail.Text == "" || txtEmail.Text.Length > 100)
                        {
                            MessageBox.Show("Email inválido!");
                        }
                        else
                        {
                            dtpContato.Enabled = false;
                            txtNome.Enabled = false;
                            txtEnd.Enabled = false;
                            txtTelefone.Enabled = false;
                            txtEmail.Enabled = false;
                            cbxCidade.Enabled = false;
                            Contato RegCon = new Contato();

                            RegCon.Idcontato = Convert.ToInt32(txtId.Text);
                            RegCon.Nomecontato = txtNome.Text.Trim();
                            RegCon.Emailcontato = txtEmail.Text.Trim();
                            RegCon.Endcontato = txtEnd.Text.Trim();
                            RegCon.Celcontato = txtTelefone.Text.Trim();
                            RegCon.Dtcadastrocontato = dtpContato.Value;
                            RegCon.Cidadeidcidade = Convert.ToInt32(cbxCidade.SelectedValue);


                            if (bInclusao)
                            {
                                if (RegCon.Salvar() > 0)
                                {
                                    MessageBox.Show("Contato adicionado com sucesso!", "SUCESSO");

                                    txtNome.Enabled = false;
                                    cbxCidade.Enabled = false;
                                    btnNovo.Enabled = true;
                                    btnAlterar.Enabled = true;
                                    btnExcluir.Enabled = true;
                                    btnSalvar.Enabled = false;
                                    btnCancelar.Enabled = false;

                                    bInclusao = false;

                                    //recarrega o grid
                                    dscontato.Tables.Clear();
                                    dscontato.Tables.Add(RegCon.Listar());
                                    bncontato.DataSource = dscontato.Tables["contato"];
                                }
                                else
                                {
                                    MessageBox.Show("Erro ao gravar contato!", "ERRO");
                                }
                            }
                            else
                            {
                                if (RegCon.Alterar() > 0)
                                {
                                    MessageBox.Show("Contato alterada com sucesso!");

                                    dscontato.Tables.Clear();
                                    dscontato.Tables.Add(RegCon.Listar());
                                    txtId.Enabled = false;
                                    txtNome.Enabled = false;
                                    cbxCidade.Enabled = false;
                                    btnSalvar.Enabled = false;
                                    btnAlterar.Enabled = true;
                                    btnNovo.Enabled = true;
                                    btnExcluir.Enabled = true;
                                    btnCancelar.Enabled = false;
                                    //recarrega o grid
                                    dscontato.Tables.Clear();
                                    dscontato.Tables.Add(RegCon.Listar());
                                    bncontato.DataSource = dscontato.Tables["contato"];

                                }
                                else
                                {
                                    MessageBox.Show("Erro ao alterar contato!");
                                }
                            }
                        }
                    }
                }
                

            }
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (tbContato.SelectedIndex == 0)
            {
                tbContato.SelectTab(1);
            }
            if (MessageBox.Show("Confirma exclusão?", "Yes or No",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            == DialogResult.Yes)
            {
                Contato RegCid = new Contato();
                RegCid.Idcontato = Convert.ToInt16(txtId.Text);
                
                if (RegCid.Excluir() > 0)
                {
                    MessageBox.Show("contato excluído com sucesso!");
                    Contato R = new Contato();
                    dscontato.Tables.Clear();
                    dscontato.Tables.Add(R.Listar());
                    bncontato.DataSource = dscontato.Tables["contato"];
                }
                else
                {
                    MessageBox.Show("Erro ao excluir contato!");
                }
            }
        }

        private void LblIdContato_Click(object sender, EventArgs e)
        {

        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            bncontato.CancelEdit();

            btnSalvar.Enabled = false;
            txtNome.Enabled = false;
            txtEmail.Enabled = false;
            txtEnd.Enabled = false;
            txtTelefone.Enabled = false;
            cbxCidade.Enabled = false;
            dtpContato.Enabled = false;


            btnAlterar.Enabled = true;
            btnCancelar.Enabled = false;

            btnNovo.Enabled = true;
            btnExcluir.Enabled = true;
        }

        private void BtnAlterar_Click(object sender, EventArgs e)
        {
            if (tbContato.SelectedIndex == 0)
            {
                tbContato.SelectTab(1);
            }
            txtNome.Enabled = true;
            txtEmail.Enabled = true;
            txtEnd.Enabled = true;
            txtTelefone.Enabled = true;
            cbxCidade.Enabled = true;
            dtpContato.Enabled = true;

            
            txtNome.Focus();
            btnSalvar.Enabled = true;
            btnAlterar.Enabled = false;
            btnNovo.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = true;
            bInclusao = false;
        }

        private void TxtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtNome_TextChanged(object sender, EventArgs e)
        {

        }

        public bool temNumero(string x)
        {
            foreach(char c in x)
            {
                if (char.IsNumber(c)) return true;
            }
            return false;
        }
    }
}
