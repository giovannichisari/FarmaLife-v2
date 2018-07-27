using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace cadastro_remedios
{
    public partial class Cadastro_Remedio : Form
    {
        public Cadastro_Remedio()
        {
            InitializeComponent();
        }
        //botão cadastrar 
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                Product lProduct= new Product();
                productQuery da = new productQuery();
                lProduct.prodCodigoBarras = txtIdBarras.Text;
                lProduct.prodDescricao = txtDescricao.Text;
                lProduct.prodNomeGenerico = txtNameGenerico.Text;
                lProduct.prodNomeComercial = txtNameComercial.Text;
                lProduct.prodGrupo = txtGrupo.Text;
                lProduct.prodFabricante = txtFabricante.Text;
                lProduct.prodUnidade = txtUnidade.Text;
                lProduct.prodArmazenamento = txtArmazenamento.Text;
                lProduct.prodMarca = txtMarca.Text;
                lProduct.prodEstoque = txtQuantidade.Text;
                lProduct.prodDataCadastro = txtDateCadastro.Text;
                lProduct.prodPrecoCaixa = txtPrecoCaixa.Text;
                lProduct.prodUnidadeCaixa = txtUnidadeCaixa.Text;
                lProduct.prodCompraUnidade = txtPrecoCompraUnidade.Text;
                lProduct.prodMargem = txtMargem.Text;
                lProduct.prodPrecoVenda = txtPrecoVenda.Text;
                lProduct.prodDescontoPromocao = txtDiscountPromocao.Text;
                lProduct.prodMargemPromocao = txtMargemPromocao.Text;
                lProduct.prodPrecoPromocao = txtPrecoPromocao.Text;
                lProduct.prodInicioPromocao = txtInicioPromocao.Text;
                lProduct.prodFinalPromocao = txtFinalPromocao.Text;
                lProduct.prodObs = txtObs.Text;

                da.Insert(lProduct);
                MessageBox.Show(" Produtos Registrados com sucesso ");
                this.txtId.Text = string.Empty;
                this.txtIdBarras.Text = string.Empty;
                this.txtDescricao.Text = string.Empty;
                this.txtNameGenerico.Text = string.Empty;
                this.txtNameComercial.Text = string.Empty;
                this.txtGrupo.Text = string.Empty;
                this.txtFabricante.Text = string.Empty;
                this.txtUnidade.Text = string.Empty;
                this.txtArmazenamento.Text = string.Empty;
                this.txtMarca.Text = string.Empty;
                this.txtQuantidade.Text = string.Empty;
                this.txtDateCadastro.Text = string.Empty;
                this.txtPrecoCaixa.Text = string.Empty;
                this.txtUnidadeCaixa.Text = string.Empty;
                this.txtPrecoCompraUnidade.Text = string.Empty;
                this.txtMargem.Text = string.Empty;
                this.txtPrecoVenda.Text = string.Empty;
                this.txtDiscountPromocao.Text = string.Empty;
                this.txtMargemPromocao.Text = string.Empty;
                this.txtPrecoPromocao.Text = string.Empty;
                this.txtInicioPromocao.Text = string.Empty;
                this.txtFinalPromocao.Text = string.Empty;
                this.txtObs.Text = string.Empty;
            }
            else
            {
                Product lProduct= new Product();
                productQuery da = new productQuery();
                lProduct.prodCodigo = Convert.ToInt16(txtId.Text);
                lProduct.prodCodigoBarras = txtIdBarras.Text;
                lProduct.prodDescricao = txtDescricao.Text;
                lProduct.prodNomeGenerico = txtNameGenerico.Text;
                lProduct.prodNomeComercial = txtNameComercial.Text;
                lProduct.prodGrupo = txtGrupo.Text;
                lProduct.prodFabricante = txtFabricante.Text;
                lProduct.prodUnidade = txtUnidade.Text;
                lProduct.prodArmazenamento = txtArmazenamento.Text;
                lProduct.prodMarca = txtMarca.Text;
                lProduct.prodEstoque = txtQuantidade.Text;
                lProduct.prodDataCadastro = txtDateCadastro.Text;
                lProduct.prodPrecoCaixa = txtPrecoCaixa.Text;
                lProduct.prodUnidadeCaixa = txtUnidadeCaixa.Text;
                lProduct.prodCompraUnidade = txtPrecoCompraUnidade.Text;
                lProduct.prodMargem = txtMargem.Text;
                lProduct.prodPrecoVenda = txtPrecoVenda.Text;
                lProduct.prodDescontoPromocao = txtDiscountPromocao.Text;
                lProduct.prodMargemPromocao = txtMargemPromocao.Text;
                lProduct.prodPrecoPromocao = txtPrecoPromocao.Text;
                lProduct.prodInicioPromocao = txtInicioPromocao.Text;
                lProduct.prodFinalPromocao = txtFinalPromocao.Text;
                lProduct.prodObs = txtObs.Text;

                da.Update(lProduct);
                MessageBox.Show(" Produto alterado com sucesso ");
                this.txtId.Text = string.Empty;
                this.txtIdBarras.Text = string.Empty;
                this.txtDescricao.Text = string.Empty;
                this.txtNameGenerico.Text = string.Empty;
                this.txtNameComercial.Text = string.Empty;
                this.txtGrupo.Text = string.Empty;
                this.txtFabricante.Text = string.Empty;
                this.txtUnidade.Text = string.Empty;
                this.txtArmazenamento.Text = string.Empty;
                this.txtMarca.Text = string.Empty;
                this.txtQuantidade.Text = string.Empty;
                this.txtDateCadastro.Text = string.Empty;
                this.txtPrecoCaixa.Text = string.Empty;
                this.txtUnidadeCaixa.Text = string.Empty;
                this.txtPrecoCompraUnidade.Text = string.Empty;
                this.txtMargem.Text = string.Empty;
                this.txtPrecoVenda.Text = string.Empty;
                this.txtDiscountPromocao.Text = string.Empty;
                this.txtMargemPromocao.Text = string.Empty;
                this.txtPrecoPromocao.Text = string.Empty;
                this.txtInicioPromocao.Text = string.Empty;
                this.txtFinalPromocao.Text = string.Empty;
                this.txtObs.Text = string.Empty;
            }
        }
        //botão limpar
        private void btnClean_Click(object sender, EventArgs e)
        {
            this.txtId.Text = string.Empty;
            this.txtIdBarras.Text = string.Empty;
            this.txtDescricao.Text = string.Empty;
            this.txtNameGenerico.Text = string.Empty;
            this.txtNameComercial.Text = string.Empty;
            this.txtGrupo.Text = string.Empty;
            this.txtFabricante.Text = string.Empty;
            this.txtUnidade.Text = string.Empty;
            this.txtArmazenamento.Text = string.Empty;
            this.txtMarca.Text = string.Empty;
            this.txtQuantidade.Text = string.Empty;
            this.txtDateCadastro.Text = string.Empty;
            this.txtPrecoCaixa.Text = string.Empty;
            this.txtUnidadeCaixa.Text = string.Empty;
            this.txtPrecoCompraUnidade.Text = string.Empty;
            this.txtMargem.Text = string.Empty;
            this.txtPrecoVenda.Text = string.Empty;
            this.txtDiscountPromocao.Text = string.Empty;
            this.txtMargemPromocao.Text = string.Empty;
            this.txtPrecoPromocao.Text = string.Empty;
            this.txtInicioPromocao.Text = string.Empty;
            this.txtFinalPromocao.Text = string.Empty;
            this.txtObs.Text = string.Empty;
        }

        private void Search()
        { 
            MySqlConnection con = new MySqlConnection(Connection.lConnection);
            con.Open();
            string op = (string)comboBox1.SelectedItem;
            switch (op)
            {

                case "Código":
                    string pesquisa = "SELECT pro_codigo as Codigo, pro_codigo_de_barras as 'Codigo De Barras',pro_descricao_do_produto as 'Descricao Produto'," +
                        "pro_nome_generico as 'Nome Generico',pro_nome_comercial as 'Nome Comercial',pro_grupo as Grupo ,pro_fabricante_do_produto as 'Fabricante'," +
                        "pro_unidade as Unidade,pro_local_de_armazenamento as 'Local Armazenamento',pro_marca_fabricante as 'Marca Fabricante',pro_quantidade_no_estoque as 'Qntd Estoque'," +
                        "pro_data_de_cadastro as 'Data Cadastro',pro_preco_de_compra_por_caixa as 'Preco Compra Caixa',pro_unid_caixa as 'Unidade Caixa',pro_preco_de_compra_unitario as 'Preco Compra Unitario'," +
                        "pro_margem as Margem,pro_preco_de_venda as 'Preco Venda',pro_desconto_de_promocao as 'Desconto Promocao',pro_margem_de_promocao as 'Margem Promocao',pro_preco_promocao as 'Preco Promocao'," +
                        "pro_inicio_da_promocao as 'Inicio Promocao',pro_final_da_promocao as 'Final Promocao',pro_obs as Observacoes " +
                        "FROM cadastro_remedios WHERE pro_codigo LIKE @value";
                    MySqlDataAdapter ad = new MySqlDataAdapter(pesquisa, con);
                    ad.SelectCommand.Parameters.AddWithValue("value", txtSearch.Text + "%");
                    DataTable table = new DataTable();
                    ad.Fill(table);
                    dataGridView.DataSource = table;
                    con.Close();
                    break;
                case "Fabricante":
                    string pesquisa2 = "SELECT pro_codigo as Codigo, pro_codigo_de_barras as 'Codigo De Barras',pro_descricao_do_produto as 'Descricao Produto'," +
                        "pro_nome_generico as 'Nome Generico',pro_nome_comercial as 'Nome Comercial',pro_grupo as Grupo ,pro_fabricante_do_produto as 'Fabricante'," +
                        "pro_unidade as Unidade,pro_local_de_armazenamento as 'Local Armazenamento',pro_marca_fabricante as 'Marca Fabricante',pro_quantidade_no_estoque as 'Qntd Estoque'," +
                        "pro_data_de_cadastro as 'Data Cadastro',pro_preco_de_compra_por_caixa as 'Preco Compra Caixa',pro_unid_caixa as 'Unidade Caixa',pro_preco_de_compra_unitario as 'Preco Compra Unitario'," +
                        "pro_margem as Margem,pro_preco_de_venda as 'Preco Venda',pro_desconto_de_promocao as 'Desconto Promocao',pro_margem_de_promocao as 'Margem Promocao',pro_preco_promocao as 'Preco Promocao'," +
                        "pro_inicio_da_promocao as 'Inicio Promocao',pro_final_da_promocao as 'Final Promocao',pro_obs as Observacoes " +
                        "FROM cadastro_remedios WHERE pro_fabricante_do_produto LIKE @value";
                    MySqlDataAdapter ad1 = new MySqlDataAdapter(pesquisa2, con);
                    ad1.SelectCommand.Parameters.AddWithValue("value", txtSearch.Text + "%");
                    DataTable table1 = new DataTable();
                    ad1.Fill(table1);
                    dataGridView.DataSource = table1;
                    con.Close();
                    break;
                case "Nome Genérico":
                    string pesquisa3 = "SELECT pro_codigo as Codigo, pro_codigo_de_barras as 'Codigo De Barras',pro_descricao_do_produto as 'Descricao Produto'," +
                        "pro_nome_generico as 'Nome Generico',pro_nome_comercial as 'Nome Comercial',pro_grupo as Grupo ,pro_fabricante_do_produto as 'Fabricante'," +
                        "pro_unidade as Unidade,pro_local_de_armazenamento as 'Local Armazenamento',pro_marca_fabricante as 'Marca Fabricante',pro_quantidade_no_estoque as 'Qntd Estoque'," +
                        "pro_data_de_cadastro as 'Data Cadastro',pro_preco_de_compra_por_caixa as 'Preco Compra Caixa',pro_unid_caixa as 'Unidade Caixa',pro_preco_de_compra_unitario as 'Preco Compra Unitario'," +
                        "pro_margem as Margem,pro_preco_de_venda as 'Preco Venda',pro_desconto_de_promocao as 'Desconto Promocao',pro_margem_de_promocao as 'Margem Promocao',pro_preco_promocao as 'Preco Promocao'," +
                        "pro_inicio_da_promocao as 'Inicio Promocao',pro_final_da_promocao as 'Final Promocao',pro_obs as Observacoes " +
                        "FROM cadastro_remedios WHERE pro_nome_generico LIKE @value";
                    MySqlDataAdapter ad2 = new MySqlDataAdapter(pesquisa3, con);
                    ad2.SelectCommand.Parameters.AddWithValue("value", txtSearch.Text + "%");
                    DataTable table2 = new DataTable();
                    ad2.Fill(table2);
                    dataGridView.DataSource = table2;
                    con.Close();
                    break;
            }
        }
        //botão pesquisar
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
        //botão voltar
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Principal remedio = new Principal();
            remedio.Show();
        }
        //clicar na celula do datagrid
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string codigo;
            codigo = Convert.ToString(dataGridView.CurrentRow.Cells[0].Value);

            MySqlConnection cn = new MySqlConnection(Connection.lConnection);
            cn.Open();

            MySqlCommand cmd2 = new MySqlCommand("SELECT pro_codigo, pro_codigo_de_barras,pro_descricao_do_produto,pro_nome_generico,pro_nome_comercial,pro_grupo ,pro_fabricante_do_produto,pro_unidade," +
            "pro_local_de_armazenamento,pro_marca_fabricante,pro_quantidade_no_estoque,pro_data_de_cadastro,pro_preco_de_compra_por_caixa,pro_unid_caixa,pro_preco_de_compra_unitario," +
            "pro_margem,pro_preco_de_venda,pro_desconto_de_promocao,pro_margem_de_promocao,pro_preco_promocao,pro_inicio_da_promocao,pro_final_da_promocao,pro_obs FROM cadastro_remedios WHERE pro_codigo = '" + codigo + "'", cn);
            MySqlDataReader reader = null;
            reader = cmd2.ExecuteReader();

            if (reader.Read())
            {
                txtId.Text = reader.GetString(0);
                txtIdBarras.Text = reader.GetString(1);
                txtDescricao.Text = reader.GetString(2);
                txtNameGenerico.Text = reader.GetString(3);
                txtNameComercial.Text = reader.GetString(4);
                txtGrupo.Text = reader.GetString(5);
                txtFabricante.Text = reader.GetString(6);
                txtUnidade.Text = reader.GetString(7);
                txtArmazenamento.Text = reader.GetString(8);
                txtMarca.Text = reader.GetString(9);
                txtQuantidade.Text = reader.GetString(10);
                txtDateCadastro.Text = reader.GetString(11);
                txtPrecoCaixa.Text = reader.GetString(12);
                txtUnidadeCaixa.Text = reader.GetString(13);
                txtPrecoCompraUnidade.Text = reader.GetString(14);
                txtMargem.Text = reader.GetString(15);
                txtPrecoVenda.Text = reader.GetString(16);
                txtDiscountPromocao.Text = reader.GetString(17);
                txtMargemPromocao.Text = reader.GetString(18);
                txtPrecoPromocao.Text = reader.GetString(19);
                txtInicioPromocao.Text = reader.GetString(20);
                txtFinalPromocao.Text = reader.GetString(21);
                txtObs.Text = reader.GetString(22);
            }
            cn.Close();
            tabControl1.SelectedTab = tabPage1;
        }
        // voltar ao principal através da tecla esc
        private void Cadastro_Remedio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                Principal remedio = new Principal();
                remedio.Show();
            }
        }
        // pesquisar ao digitar 
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            Search();
        }

        private void Cadastro_Remedio_Load(object sender, EventArgs e)
        {
            txtIdBarras.Focus();
            txtDateCadastro.Text = DateTime.Now.ToString();
        }
    }
}