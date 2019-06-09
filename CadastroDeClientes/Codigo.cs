using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroDeClientes
{
    public partial class frmCadastroCliente : Form
    {

        public frmCadastroCliente()
        {
            InitializeComponent();
        }

        private void frmCadastroCliente_Load(object sender, EventArgs e)
        {
            tsbNovo.Enabled = true;
            tsbSalvar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbExcluir.Enabled = false;
            txtId.Enabled = false;
            tsbBuscar.Enabled = true;
            txtNome.Enabled = false;
            txtEndereco.Enabled = false;
            mskCep.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            txtUf.Enabled = false;
            mskTelefone.Enabled = false;
            tstId.Enabled = true;
            tstId.Clear();
        }

        SqlConnection sqlCon = null;
        private string strCon = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=cadastro;Data Source=ADM-PC\SQLEXPRESS01";
        private string strSql = string.Empty;

        private void tsbNovo_Click(object sender, EventArgs e)
        {
            tsbNovo.Enabled = false;
            tsbSalvar.Enabled = true;
            tsbCancelar.Enabled = true;
            tsbExcluir.Enabled = false;
            tstId.Enabled = false;
            tsbBuscar.Enabled = false;
            txtNome.Enabled = true;
            txtEndereco.Enabled = true;
            mskCep.Enabled = true;
            txtBairro.Enabled = true;
            txtCidade.Enabled = true;
            txtUf.Enabled = true;
            txtId.Enabled = true;
            mskTelefone.Enabled = true;
            txtNome.Focus();

        }

        private void tsbSalvar_Click(object sender, EventArgs e)
        {
            strSql = "insert into tbl_cliente1 (ID, NOME, ENDERECO, CEP, BAIRRO, CIDADE, UF, TELEFONE) VALUES (@ID, @NOME, @ENDERECO, @CEP, @BAIRRO, @CIDADE, @UF, @TELEFONE)";

            sqlCon = new SqlConnection(strCon);
            SqlCommand cmd = new SqlCommand(strSql, sqlCon);


            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = txtId.Text;
            cmd.Parameters.Add("@NOME", SqlDbType.VarChar).Value = txtNome.Text;
            cmd.Parameters.Add("@ENDERECO", SqlDbType.VarChar).Value = txtEndereco.Text;
            cmd.Parameters.Add("@CEP", SqlDbType.VarChar).Value = mskCep.Text;
            cmd.Parameters.Add("@BAIRRO", SqlDbType.VarChar).Value = txtBairro.Text;
            cmd.Parameters.Add("@CIDADE", SqlDbType.VarChar).Value = txtCidade.Text;
            cmd.Parameters.Add("@UF", SqlDbType.VarChar).Value = txtUf.Text;
            cmd.Parameters.Add("@TELEFONE", SqlDbType.VarChar).Value = mskTelefone.Text;

            sqlCon.Open();
            try
            {
                cmd.ExecuteNonQuery();

                MessageBox.Show("Cadastro realizado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }

            txtNome.Clear();
            txtEndereco.Clear();
            mskCep.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            txtUf.Clear();
            mskTelefone.Clear();



        }
    }
}
        

        //private void tstId_Click(object sender, EventArgs e)
        //{

          //  strSql = "select * from tbl_cliente1 where Nome@pesquisa";

          //  sqlCon = new SqlConnection(strCon);
          //  SqlCommand cmd = new SqlCommand(strSql, sqlCon);

         //   comando.Parameters.Add("@pesquisa", SqlDbType.VarChar).Value = tstId.Text;

        //    try
         //   {
           //     if (tstId == String.Empty)
           //         MessageBox.Show("Você não inseriu nenhum nome");
           // }
            
     //   }
 //   }
    

