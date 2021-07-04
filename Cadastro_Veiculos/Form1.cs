using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Cadastro_Veiculos
{
    public partial class Form1 : Form
    {
        SqlConnection conexao;
        SqlCommand comando;
        SqlDataAdapter da;
        SqlDataReader dr;
        string strSQL;
        string connectrionstring = @"Server = DESKTOP-KMCB6GH\SQLEXPRESS; Database = veiculo; User Id = sa; Password = xxxxx";

        //string connectrionstring = @"Data Source=DESKTOP-KMCB6GH\SQLEXPRESS;
        //                        Initial Catalog=paulo;Integrated Security=True";


        public Form1()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {

                conexao = new SqlConnection(connectrionstring);

                strSQL = "insert into cad_veiculo(placa, marca, modelo," +
                    " ano_fabricacao, ano_modelo, cliente_nome, documento," +
                    " numero_documento)" +

                    "values (@placa, @marca, @modelo, @ano_fabricacao, @ano_modelo," +
                    "@cliente_nome, @documento, @numero_documento)";

                comando = new SqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@placa", txtPlaca.Text);
                comando.Parameters.AddWithValue("@marca", txtMarca.Text);
                comando.Parameters.AddWithValue("@modelo", txtModelo.Text);
                comando.Parameters.AddWithValue("@ano_fabricacao", txtAF.Text);
                comando.Parameters.AddWithValue("@ano_modelo", txtAM.Text);
                comando.Parameters.AddWithValue("@cliente_nome", txtNomeCliente.Text);
                comando.Parameters.AddWithValue("@documento", txtTipoDoc.Text);
                comando.Parameters.AddWithValue("@numero_documento", txtNumeroDoc.Text);

                conexao.Open();
                comando.ExecuteNonQuery();
                
                MessageBox.Show("Veiculo cadastrado com sucesso!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: "+ ex);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
            }
        }
        private void btnListar_Click(object sender, EventArgs e)
        {
            try
            {

                conexao = new SqlConnection(connectrionstring);

                strSQL = "select * from cad_veiculo";

                DataSet ds = new DataSet();

                da = new SqlDataAdapter(strSQL, conexao);

                conexao.Open();

                da.Fill(ds);

                dgvDados.DataSource = ds.Tables[0];

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
            }
        }
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {

                conexao = new SqlConnection(connectrionstring);

                strSQL = "select * from cad_veiculo where id = @id";

                comando = new SqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@id", txtId.Text);


                conexao.Open();
                dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    txtPlaca.Text = (string)dr["placa"];
                    txtMarca.Text = (string)dr["marca"];
                    txtModelo.Text = (string)dr["Modelo"];
                    txtAF.Text = Convert.ToString(dr["ano_fabricacao"]);
                    txtAM.Text = Convert.ToString(dr["ano_modelo"]);
                    txtNomeCliente.Text = (string)dr["cliente_nome"];
                    txtTipoDoc.Text = Convert.ToString(dr["documento"]);
                    txtNumeroDoc.Text = Convert.ToString(dr["numero_documento"]);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
            }

        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {

                conexao = new SqlConnection(connectrionstring);

                strSQL ="update cad_veiculo set placa = @placa, marca = @marca," +
                    "modelo = @modelo, ano_fabricacao = @ano_fabricacao," +
                    "ano_modelo = @ano_modelo, cliente_nome = @cliente_nome," +
                    "documento = @documento, numero_documento = @numero_documento where id = @id";

                comando = new SqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@id", txtId.Text);
                comando.Parameters.AddWithValue("@placa", txtPlaca.Text);
                comando.Parameters.AddWithValue("@marca", txtMarca.Text);
                comando.Parameters.AddWithValue("@modelo", txtModelo.Text);
                comando.Parameters.AddWithValue("@ano_fabricacao", txtAF.Text);
                comando.Parameters.AddWithValue("@ano_modelo", txtAM.Text);
                comando.Parameters.AddWithValue("@cliente_nome", txtNomeCliente.Text);
                comando.Parameters.AddWithValue("@documento", txtTipoDoc.Text);
                comando.Parameters.AddWithValue("@numero_documento", txtNumeroDoc.Text);

                conexao.Open();
                comando.ExecuteNonQuery();

                MessageBox.Show("Veiculo Atualizado com sucesso!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {

                conexao = new SqlConnection(connectrionstring);

                strSQL = "delete cad_veiculo where id = @id";

                comando = new SqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@id", txtId.Text);
              
                conexao.Open();
                comando.ExecuteNonQuery();

                MessageBox.Show("Veiculo deletado com sucesso!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
            {

            }

    }
}
