using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace cadastro_remedios
{
    public partial class Pesquisa : Form
    {
        public Pesquisa()
        {
            InitializeComponent();
        }
        private void Pesquisar()
        {
            
            MySqlConnection con = new MySqlConnection(Connection.lConnection);
            con.Open();
            string op = (string)comboBox1.SelectedItem;
            switch (op)
            {

                case "Nome":
                    string pesquisa = "SELECT pro_codigo as Codigo,pro_nome_comercial as Nome,pro_preco_de_venda as Preco,pro_descricao_do_produto as Descricao,pro_fabricante_do_produto as Fabricante,pro_quantidade_no_estoque as Estoque FROM cadastro_remedios WHERE pro_nome_comercial LIKE @value";
                    MySqlDataAdapter ad = new MySqlDataAdapter(pesquisa, con);
                    ad.SelectCommand.Parameters.AddWithValue("value", txtSearch.Text + "%");
                    DataTable table = new DataTable();
                    ad.Fill(table);
                    dataGridView1.DataSource = table;
                    con.Close();
                    break;

                case "Fabricante":
                    string pesquisa1 = "SELECT pro_codigo as Codigo, pro_nome_comercial as Nome,pro_preco_de_venda as Preco,pro_descricao_do_produto as Descricao,pro_fabricante_do_produto as Fabricante,pro_quantidade_no_estoque as Estoque FROM cadastro_remedios FROM cadastro_remedios WHERE pro_fabricante_do_produto LIKE @value";
                    MySqlDataAdapter ad1 = new MySqlDataAdapter(pesquisa1, con);
                    ad1.SelectCommand.Parameters.AddWithValue("value", txtSearch.Text + "%");
                    DataTable table1 = new DataTable();
                    ad1.Fill(table1);
                    dataGridView1.DataSource = table1;
                    con.Close();
                    break;
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }
        //botão voltar
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Principal principal = new Principal();
            principal.Show();
        }

        private void Pesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {

                this.Close();
                Principal remedio = new Principal();
                remedio.Show();

            }
        }

        //pesquisa com enter
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            Pesquisar();
        }

        private void Pesquisa_Load(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }
    }
}
