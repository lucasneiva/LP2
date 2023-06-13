using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace PContato0030482221012
{
    class Contato
    {
        private int idcontato, cidadeidcidade;
        private string nomecontato, endcontato, celcontato, emailcontato;
        private DateTime dtcadastrocontato;

        public int Idcontato { get => idcontato; set => idcontato = value; }
        public int Cidadeidcidade { get => cidadeidcidade; set => cidadeidcidade = value; }
        public string Nomecontato { get => nomecontato; set => nomecontato = value; }
        public string Endcontato { get => endcontato; set => endcontato = value; }
        public string Celcontato { get => celcontato; set => celcontato = value; }
        public string Emailcontato { get => emailcontato; set => emailcontato = value; }
        public DateTime Dtcadastrocontato { get => dtcadastrocontato; set => dtcadastrocontato = value; }

        public DataTable Listar()
        {
            SqlDataAdapter daContato;
            DataTable dtContato = new DataTable();

            try
            {
                daContato = new SqlDataAdapter("SELECT * FROM CONTATO", Form1.conexao);
                daContato.Fill(dtContato);
                daContato.FillSchema(dtContato, SchemaType.Source);

            }
            catch (Exception)
            {
                throw;
            }

            return dtContato;

        }

        public int Salvar()
        {
            int retorno = 0;

            try
            {
                SqlCommand mycommand;

                mycommand = new SqlCommand("INSERT INTO CONTATO VALUES (@nomecontato, @endcontato, @cidadeidcidade, @celcontato, @emailcontato, @dtcadastrocontato)", Form1.conexao);

                mycommand.Parameters.Add(new SqlParameter("@nomecontato", SqlDbType.VarChar));
                mycommand.Parameters.Add(new SqlParameter("@endcontato", SqlDbType.VarChar));
                mycommand.Parameters.Add(new SqlParameter("@cidadeidcidade", SqlDbType.Int));
                mycommand.Parameters.Add(new SqlParameter("@celcontato", SqlDbType.VarChar));
                mycommand.Parameters.Add(new SqlParameter("@emailcontato", SqlDbType.VarChar));
                mycommand.Parameters.Add(new SqlParameter("@dtcadastrocontato", SqlDbType.DateTime));

                mycommand.Parameters["@nomecontato"].Value = Nomecontato;
                mycommand.Parameters["@endcontato"].Value = Endcontato;
                mycommand.Parameters["@cidadeidcidade"].Value = Cidadeidcidade;
                mycommand.Parameters["@celcontato"].Value = Celcontato;
                mycommand.Parameters["@emailcontato"].Value = Emailcontato;
                mycommand.Parameters["@dtcadastrocontato"].Value = Dtcadastrocontato;

                retorno = mycommand.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            return retorno;
        }

        public int Excluir()
        {
            int nReg = 0;

            try
            {
                SqlCommand mycommand;
                mycommand = new SqlCommand("DELETE FROM CONTATO" + " WHERE ID_CONTATO = @id_contato", Form1.conexao);

                mycommand.Parameters.Add(new SqlParameter("@id_contato", SqlDbType.Int));


                mycommand.Parameters["@id_contato"].Value = Idcontato;


                nReg = mycommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return nReg;
        }

        public int Alterar()
        {
            int retorno = 0;
            try
            {
                SqlCommand mycommand;
                mycommand = new SqlCommand("UPDATE CONTATO SET " + 
                    " NOME_CONTATO=@nomecontato, END_CONTATO=@endcontato, " +
                    "  CEL_CONTATO=@celcontato, " +
                    " EMAIL_CONTATO=@emailcontato, " +
                    " DTCADASTRO_CONTATO=@dtcadastrocontato " +
                    " WHERE ID_CONTATO = @idcontato", Form1.conexao);

                mycommand.Parameters.Add(new SqlParameter("@idcontato", SqlDbType.Int));
                mycommand.Parameters.Add(new SqlParameter("@nomecontato", SqlDbType.VarChar));
                mycommand.Parameters.Add(new SqlParameter("@endcontato", SqlDbType.VarChar));
                mycommand.Parameters.Add(new SqlParameter("@celcontato", SqlDbType.VarChar));
                mycommand.Parameters.Add(new SqlParameter("@emailcontato", SqlDbType.VarChar));
                mycommand.Parameters.Add(new SqlParameter("@dtcadastrocontato", SqlDbType.Date));

                mycommand.Parameters["@idcontato"].Value = Idcontato;
                mycommand.Parameters["@nomecontato"].Value = Nomecontato;
                mycommand.Parameters["@endcontato"].Value = Endcontato;
                mycommand.Parameters["@celcontato"].Value = Celcontato;
                mycommand.Parameters["@emailcontato"].Value = Emailcontato;
                mycommand.Parameters["@dtcadastrocontato"].Value = dtcadastrocontato;


                retorno = mycommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            return retorno;
        }
    }
}

