using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace cadastro_remedios
{
    public partial class PesquisaVenda : Form
    {
        public PesquisaVenda()
        {
            InitializeComponent();
        }

        private void PesquisaVenda_Load(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }

        //teclas de atalho
        private void PesquisaVenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {

                this.Close();
                Principal principal = new Principal();
                principal.Show();

            }

            if (e.KeyCode == Keys.F7)
            {

                this.Close();
                Venda venda = new Venda();
                venda.Show();

            }
        }

        //voltar a tela principal
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Principal principal = new Principal();
            principal.Show();
        }
        private void Pesquisar()
        {
            
            MySqlConnection con = new MySqlConnection(Connection.lConnection);
            con.Open();
            string op = (string)comboBox1.SelectedItem;
            switch (op)
            {
                case "Código da Venda":
                    string pesquisa = "SELECT ven_cod as Codigo,ven_data as Data,ven_total_liq as Liquido,ven_total_bruto as Bruto,ven_status as Status,cli_cod as Cliente, Func_cod as Funcionario, desc_venda as Desconto,cod_prod as Produto,ven_horario as 'Hora da Venda' FROM venda WHERE ven_cod LIKE @value";
                    MySqlDataAdapter ad = new MySqlDataAdapter(pesquisa, con);
                    ad.SelectCommand.Parameters.AddWithValue("value", txtSearch.Text + "%");
                    DataTable table = new DataTable();
                    ad.Fill(table);
                    dataGridViewSearch.DataSource = table;
                    con.Close();
                    break;

                case "Data da Venda":
                    string pesquisa1 = "SELECT ven_cod as Codigo,ven_data as Data,ven_total_liq as Liquido,ven_total_bruto as Bruto,ven_status as Status,cli_cod as Cliente, Func_cod as Funcionario, desc_venda as Desconto,cod_prod as Produto,ven_horario as 'Hora da Venda' FROM venda WHERE ven_data LIKE @value";
                    MySqlDataAdapter ad1 = new MySqlDataAdapter(pesquisa1, con);
                    ad1.SelectCommand.Parameters.AddWithValue("value", txtSearch.Text + "%");
                    DataTable table1 = new DataTable();
                    ad1.Fill(table1);
                    dataGridViewSearch.DataSource = table1;
                    con.Close();
                    break;

                case "Código do Funcionário":
                    string pesquisa2 = "SELECT ven_cod as Codigo,ven_data as Data,ven_total_liq as Liquido,ven_total_bruto as Burto,ven_status as Status,cli_cod as Cliente, Func_cod as Funcionario, desc_venda as Desconto,cod_prod as Produto,ven_horario as 'Hora da Venda' FROM venda WHERE Func_cod LIKE @value";
                    MySqlDataAdapter ad2 = new MySqlDataAdapter(pesquisa2, con);
                    ad2.SelectCommand.Parameters.AddWithValue("value", txtSearch.Text + "%");
                    DataTable table2 = new DataTable();
                    ad2.Fill(table2);
                    dataGridViewSearch.DataSource = table2;
                    con.Close();
                    break;
            }

        }

        //pesquisar venda
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }
        //pesquisa com enter
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            Pesquisar();

        }
    }
}
