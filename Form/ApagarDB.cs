using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace cadastro_remedios
{
    public partial class ApagarDB : Form
    {
        public ApagarDB()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(Connection.lConnection);
            con.Open();
            string pesquisa = "SELECT * FROM cadastro_cliente";
            MySqlDataAdapter ad = new MySqlDataAdapter(pesquisa, con);
            DataTable table = new DataTable();
            ad.Fill(table);
            dataGridView1.DataSource = table;
            con.Close();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente zerar o banco de dados?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (MessageBox.Show("DESEJA REALMENTE ZERAR O BANCO DE DADOS?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        MySqlConnection con = new MySqlConnection(Connection.lConnection);
                        con.Open();
                        string deletar = "DELETE FROM cadastro_cliente";
                        MySqlCommand cmd = new MySqlCommand(deletar, con);
                        MySqlDataReader myreader;
                        myreader = cmd.ExecuteReader();
                        MessageBox.Show("Banco zerado com sucesso");
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro de comandos" + ex.Message);
                    }
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Principal principal = new Principal();
            principal.Show();
            
        }

        private void ApagarDB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                Principal remedio = new Principal();
                remedio.Show();
            }
        }
    }
}
