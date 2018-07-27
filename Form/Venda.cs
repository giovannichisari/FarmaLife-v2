using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Net.Mail;
using System.Diagnostics;
using System.Data;
using cadastro_remedios.Models;

namespace cadastro_remedios
{
    public partial class Venda : Form
    {
        private MailMessage Email;
        Stopwatch Stop = new Stopwatch();
        public Venda()
        {
            InitializeComponent();
        }
        int actualStock = 0;
        int counter = 0;
        //mostrar data/hora
        private void Venda_Load(object sender, EventArgs e)
        {
            txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtHour.Text = DateTime.Now.ToString("hh:mm:ss");
            txtEmployee.Focus();
        }
        //configurar funcionário
        private void txtEmployee_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection cn = new MySqlConnection(Connection.lConnection);
            cn.Open();

            MySqlCommand cmd2 = new MySqlCommand("SELECT empId,empName FROM registeremployee WHERE empId= '" + txtEmployee.Text + "' and empStatus= 'A'", cn);
            MySqlDataReader reader = null;
            reader = cmd2.ExecuteReader();

            if (reader.Read())
            {
                txtNameEmployee.Text = reader.GetString(1);
            }
        }
        // configurar produto
        private void txtProduct_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection cn = new MySqlConnection(Connection.lConnection);
            cn.Open();

            MySqlCommand cmd2 = new MySqlCommand("SELECT pro_codigo,pro_nome_comercial,pro_preco_de_venda,pro_fabricante_do_produto,pro_quantidade_no_estoque,pro_desconto_de_promocao FROM cadastro_remedios WHERE pro_codigo = '" + txtProduct.Text + "' and pro_status = 'A'", cn);
            MySqlDataReader reader = null;
            reader = cmd2.ExecuteReader();

            if (reader.Read())
            {
                txtProdName.Text = reader.GetString(1);
                txtProdValor.Text = reader.GetString(2);
                txtProdMarca.Text = reader.GetString(3);
                txtProdEstoque.Text = reader.GetString(4);
                txtProdDesc.Text = reader.GetString(5);
            }
        }
        // quantidade manda pra datagrid
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Product lProduct = new Product();

            MySqlConnection cn5 = new MySqlConnection(Connection.lConnection);
            MySqlCommand cmd5 = new MySqlCommand("SELECT pro_quantidade_no_estoque FROM cadastro_remedios WHERE pro_codigo='" + txtProduct.Text + "'", cn5);
            cn5.Open();
            MySqlDataReader reader = cmd5.ExecuteReader();

            if (reader.Read())
            {
                int sotockQuantity = reader.GetInt32(0);
                if (e.KeyChar == 13)
                {
                    btnClose.Enabled = true;
                    btnGet.Enabled = false;
                    pictureBox7.Visible = false;
                    pictureBox1.Visible = true;
                    dataGridView2.Visible = false;
                    comboBox2.Visible = false;
                    panel1.Visible = false;
                    textBox1.Visible = false;
                    btnPequisar.Visible = false;
                    btnClean.Visible = false;
                    button1.Enabled = false;

                    dataGridView2.Enabled = false;
                    dataGridView2.Columns.Clear();
                    dataGridView2.Refresh();
                    comboBox2.Enabled = false;
                    panel1.Enabled = false;
                    textBox1.Enabled = false;
                    btnPequisar.Enabled = false;
                    btnClean.Enabled = false;

                    dataGridView1.Visible = true;
                    txtSearch.Visible = false;
                    comboBox1.Visible = false;
                    dataGridViewSearch.Columns.Clear();
                    dataGridViewSearch.Refresh();
                    dataGridViewSearch.Visible = false;
                    btnSearch.Visible = false;

                    if (txtProdQnt.Text == "0" || this.txtProdQnt.Text == string.Empty)
                    {
                        txtProdQnt.Text = "1";
                        MessageBox.Show("A quantidade '0' foi substituída por '1'");
                    }
                    double qqty = 0, value, total, discount, finaldiscount;
                    qqty = Convert.ToDouble(txtProdQnt.Text);

                    if (sotockQuantity >= qqty)
                    {
                        counter++;
                        value = Convert.ToDouble(txtProdValor.Text);
                        discount = Convert.ToDouble(txtProdDesc.Text);
                        finaldiscount = discount * qqty;
                        total = (qqty * value) - finaldiscount;
                        dataGridView1.Rows.Add(txtProduct.Text, txtProdName.Text, txtProdQnt.Text, txtProdValor.Text, finaldiscount, total);
                    }
                    else
                    {
                        MessageBox.Show("O estoque não possui está quantidade", "Alerta");

                        if (sotockQuantity == 0)
                        {
                            Email = new MailMessage();
                            Email.To.Add(new MailAddress(Credentials.lGerenciaAdress));
                            Email.From = (new MailAddress(Credentials.lAdress));
                            Email.Subject = "Atenção";
                            Email.IsBodyHtml = true;
                            Email.Body = "FarmaLife Enterprises 2018 ®</br>Foi verificado que ao tentar realizar uma compra do produto com o código: " + txtProduct.Text + " e o nome: " + txtProdName.Text + " no dia " + DateTime.Now + "</b>, o mesmo não se encontrava em estoque, favor tomar medidas cabíveis. </br> <i> Não responder esse e-mail</i></br>";

                            SmtpClient sell = new SmtpClient(Credentials.lSmtpLive, Credentials.lSmtpLivePort);

                            using (sell)
                            {
                                sell.Credentials = new System.Net.NetworkCredential(Credentials.lAdress, Credentials.lPassword);
                                sell.EnableSsl = true;
                                sell.Send(Email);
                            }
                        }
                        else
                            MessageBox.Show("O estoque não possui está quantidade", "Alerta");
                    }
                }
            }
        }
        // configurar cliente
        private void txtClient_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection cn = new MySqlConnection(Connection.lConnection);
            cn.Open();

            MySqlCommand cmd3 = new MySqlCommand("SELECT for_cod,for_nome FROM cadastro_cliente WHERE for_cod = '" + txtClient.Text + "' and for_status = 'A'", cn);
            MySqlDataReader reader = null;
            reader = cmd3.ExecuteReader();

            if (reader.Read())
                txtNameCliente.Text = reader.GetString(1);
        }
        // fechar cesta
        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseMethod();
        }
        // finalizar venda
        private void btnFinish_Click(object sender, EventArgs e)
        {
            FinishMethod();
        }
        // foco ao clicar em enter
        private void text_id_func_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtClient.Focus();
        }

        private void text_id_cliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtProduct.Focus();
        }

        private void text_id_prod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (this.txtProduct.Text == string.Empty | this.txtEmployee.Text == string.Empty | this.txtClient.Text == string.Empty)
                { txtProdQnt.Enabled = false; }

                else
                {
                    txtProdQnt.Enabled = true;
                    txtProdQnt.Focus();
                }
            }
        }
        //pesquisa de vendas
        private void btnGet_Click(object sender, EventArgs e)
        {
            pictureBox7.Visible = false;
            dataGridView1.Visible = false;
            txtSearch.Visible = true;
            comboBox1.Visible = true;
            dataGridViewSearch.Visible = true;
            btnSearch.Visible = true;
            pictureBox1.Visible = true;
        }
        // cancelar venda
        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelMethod();
        }
        //botão voltar
        private void btnBack_Click(object sender, EventArgs e)
        {
            BackMethod();
        }
        //teclas de atalho
        private void Venda_KeyDown_1(object sender, KeyEventArgs e)
        {
            //atalho para voltar a tela principal
            if (e.KeyCode == Keys.Escape)
            {
                BackMethod();
            }
            //atalho para finalizar venda
            if (e.KeyCode == Keys.F5)
            {
                FinishMethod();
            }
            //atalho fechar cesta
            if (e.KeyCode == Keys.F6)
            {
                CloseMethod();
            }
            //atalho cancelar venda
            if (e.KeyCode == Keys.F7)
            {
                CancelMethod();
            }
            //atalho para pesquisa
            if (e.KeyCode == Keys.F8)
            {
                btnGet.Focus();
            }
            if (e.KeyCode == Keys.F4)
            {
                Calculadora Calculadora = new Calculadora();
                Calculadora.Show();
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;

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

        private void btnCalculator_Click(object sender, EventArgs e)
        {
            Calculadora Calculadora = new Calculadora();
            Calculadora.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView2.Visible = true;
            comboBox2.Visible = true;
            panel1.Visible = true;
            textBox1.Visible = true;
            btnPequisar.Visible = true;
            btnClean.Visible = true;

            dataGridView2.Enabled = true;
            comboBox2.Enabled = true;
            panel1.Enabled = true;
            textBox1.Enabled = true;
            btnPequisar.Enabled = true;
            btnClean.Enabled = true;
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            dataGridView2.Visible = false;
            comboBox2.Visible = false;
            panel1.Visible = false;
            textBox1.Visible = false;
            btnPequisar.Visible = false;
            btnClean.Visible = false;

            dataGridView2.Enabled = false;
            dataGridView2.Columns.Clear();
            dataGridView2.Refresh();
            comboBox2.Enabled = false;
            panel1.Enabled = false;
            textBox1.Enabled = false;
            btnPequisar.Enabled = false;
            btnClean.Enabled = false;
        }

        private void btnPequisar_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(Connection.lConnection);
            con.Open();
            string op = (string)comboBox2.SelectedItem;
            switch (op)
            {
                case "Funcionario":
                    string pesquisa = "SELECT empId as Codigo, empName as Nome,empEmail as Email,empCellphone as Celular,empCity as Cidade,empRegionState as Estado FROM registeremployee WHERE empName LIKE @value AND empStatus= 'A'";
                    MySqlDataAdapter ad = new MySqlDataAdapter(pesquisa, con);
                    ad.SelectCommand.Parameters.AddWithValue("value", textBox1.Text + "%");
                    DataTable table = new DataTable();
                    ad.Fill(table);
                    dataGridView2.DataSource = table;
                    con.Close();
                    break;

                case "Cliente":
                    string pesquisa2 = "SELECT for_cod as Codigo, for_nome as Nome,for_email as Email,for_fone as Celular,for_cidade as Cidade, for_uf as Estado FROM cadastro_cliente WHERE for_nome LIKE @value AND for_status = 'A'";
                    MySqlDataAdapter ad2 = new MySqlDataAdapter(pesquisa2, con);
                    ad2.SelectCommand.Parameters.AddWithValue("value", textBox1.Text + "%");
                    DataTable table2 = new DataTable();
                    ad2.Fill(table2);
                    dataGridView2.DataSource = table2;
                    con.Close();
                    break;

                case "Remedio":
                    string pesquisa3 = "SELECT pro_codigo as Codigo, pro_nome_generico as Nome, pro_preco_de_venda as Preco ,pro_desconto_de_promocao as Desconto, pro_inicio_da_promocao as 'Inicio Promocao',pro_final_da_promocao as 'Final Promocao'  FROM cadastro_remedios WHERE pro_nome_generico LIKE @value AND pro_status = 'A'";
                    MySqlDataAdapter ad3 = new MySqlDataAdapter(pesquisa3, con);
                    ad3.SelectCommand.Parameters.AddWithValue("value", textBox1.Text + "%");
                    DataTable table3 = new DataTable();
                    ad3.Fill(table3);
                    dataGridView2.DataSource = table3;
                    con.Close();
                    break;
            }
        }

        private void CloseMethod()
        {
            double total = 0, total1 = 0;
            double totalValue = 0;

            foreach (DataGridViewRow dgv in dataGridView1.Rows)
            {
                double value1 = Convert.ToDouble(dgv.Cells[2].Value);
                double value2 = Convert.ToDouble(dgv.Cells[3].Value);
                double value3 = Convert.ToDouble(dgv.Cells[4].Value);
                double subtotal = value1 * value2;
                total = total + subtotal;
                txtGrossAmount.Text = total.ToString();
                double totalliq = value1 * value2 - value3;
                total1 = total1 + totalliq;
                txtNetAmount.Text = total1.ToString();
            }
            foreach (DataGridViewRow col in dataGridView1.Rows)
            {
                totalValue = totalValue + Convert.ToDouble(col.Cells[4].Value);
            }
            txtDiscount.Text = totalValue.ToString();
            btnFinish.Enabled = true;
        }
        private void FinishMethod()
        {
            if (this.txtProduct.Text == string.Empty | this.txtEmployee.Text == string.Empty | this.txtClient.Text == string.Empty | this.txtGrossAmount.Text == string.Empty | this.txtDiscount.Text == string.Empty | this.txtNetAmount.Text == string.Empty)
            {
                MessageBox.Show("Algumas informações importantes para a venda ficaram de fora, ou foram preenchidos errados, revise.", "Atenção!");
                txtEmployee.Focus();
            }

            else if (MessageBox.Show("Deseja finalizar venda?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Product lProduct = new Product();
                Employee lEmployee = new Employee();
                Client lClient = new Client();
                Sell lSell = new Sell();
                ItemSell lItemSell = new ItemSell();
                sellQuery lsellQuery = new sellQuery();
                {
                    lEmployee.employeeId = Convert.ToInt16(txtEmployee.Text);
                    lClient.clientId = Convert.ToInt16(txtClient.Text);
                    lProduct.prodCodigo = Convert.ToInt16(txtProduct.Text);
                    lSell.sellGrossAmount = txtGrossAmount.Text;
                    lSell.sellDiscount = txtDiscount.Text;
                    lSell.sellNetAmount = txtNetAmount.Text;
                    lSell.sellStatus = txtStatus.Text;
                    lSell.sellDate = txtDate.Text;
                    lSell.sellHour = txtHour.Text;
                    lsellQuery.SellMethod(lProduct, lEmployee, lClient, lSell);
                }

                //exibir código da venda
                string result;
                MySqlConnection cn2 = new MySqlConnection(Connection.lConnection);
                MySqlCommand cmd = new MySqlCommand("SELECT  max(ven_cod) FROM venda", cn2);
                cn2.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    result = reader.GetString(0);
                    txtId.Visible = true;
                    label8.Visible = true;
                    txtId.Text = result;
                }
                cn2.Close();
                //configurar datagrid
                string[,] item = new string[counter, 5];
                for (int l = 0; l < counter; l++)
                {
                    for (int c = 0; c < 5; c++)
                    {
                        DataGridViewCell cell = null;
                        foreach (DataGridViewCell selectedCell in dataGridView1.SelectedCells)
                        {
                            cell = selectedCell;
                            break;
                        }
                        if (cell != null)
                        {
                            if (c == 0)
                            {
                                item[l, c] = dataGridView1.Rows[l].Cells[c].Value.ToString();
                                lProduct.prodCodigo = Convert.ToInt32(item[l, c]);
                            }
                            else if (c == 1)
                            {
                                item[l, c] = dataGridView1.Rows[l].Cells[2].Value.ToString();
                                lItemSell.itemQuantity = Convert.ToInt32(item[l, c]);
                            }
                            else if (c == 2)
                            {
                                item[l, c] = dataGridView1.Rows[l].Cells[3].Value.ToString();
                                lProduct.prodPrecoVenda = (item[l, c]);
                            }
                            else if (c == 3)
                            {
                                item[l, c] = dataGridView1.Rows[l].Cells[5].Value.ToString();
                                lItemSell.itemTotal = (item[l, c]);
                            }
                            else if (c == 4)
                            {
                                lSell.sellId = Convert.ToInt32(txtId.Text);
                            }
                        }
                    }
                    lsellQuery.ItemSellMethod(lProduct, lSell, lItemSell);
                    //Atualiza estoque
                    MySqlConnection cn3 = new MySqlConnection(Connection.lConnection);
                    MySqlCommand cmd3 = new MySqlCommand("SELECT pro_quantidade_no_estoque FROM cadastro_remedios WHERE pro_codigo = '" + lProduct.prodCodigo + "'", cn3);
                    cn3.Open();
                    MySqlDataReader reader3 = cmd3.ExecuteReader();

                    if (reader3.Read())
                    {
                        int sotockQuantity = reader3.GetInt32(0);
                        actualStock = sotockQuantity - lItemSell.itemQuantity;
                    }

                    try
                    {
                        MySqlConnection connection = new MySqlConnection(Connection.lConnection);
                        connection.Open();

                        string update = "UPDATE cadastro_remedios SET pro_quantidade_no_estoque =  '" + actualStock + "' WHERE pro_codigo = '" + lProduct.prodCodigo + "';";

                        MySqlCommand command = new MySqlCommand(update, connection);
                        MySqlDataReader myreader;
                        myreader = command.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(" Erro de comandos " + ex.Message);
                    }
                }
                MessageBox.Show("Venda Finalizada com Sucesso", "Sucesso!");
                //limpar a tela após finalizar venda

                if (Convert.ToDouble(txtNetAmount.Text) > 850.00)
                {
                    try
                    {
                        Email = new MailMessage();
                        Email.To.Add(new MailAddress(Credentials.lGerenciaAdress));
                        Email.From = (new MailAddress(Credentials.lAdress));
                        Email.Subject = "Atenção";
                        Email.IsBodyHtml = true;
                        Email.Body = "FarmaLife Enterprises 2018 ®</br>A compra com o código: " + txtId.Text + " teve o valor de  " + txtNetAmount.Text.Replace(",", ".") + ", que foi realizada por " + txtNameEmployee.Text + " para o cliente " + txtNameCliente.Text + ", no dia " + DateTime.Now + " o valor em questão foi acima do padrão, favor verificar. </br> <i> Não responder esse e-mail</i></br>";

                        SmtpClient sell2 = new SmtpClient(Credentials.lSmtpLive, Credentials.lSmtpLivePort);

                        using (sell2)
                        {
                            sell2.Credentials = new System.Net.NetworkCredential(Credentials.lAdress, Credentials.lPassword);
                            sell2.EnableSsl = true;
                            sell2.Send(Email);
                        }
                        this.Close();
                        Venda sell = new Venda();
                        sell.Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    this.Close();
                    Venda sell = new Venda();
                    sell.Show();
                }
            }
        }
        private void BackMethod()
        {
            if (MessageBox.Show("Deseja voltar a tela principal?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                Principal principal = new Principal();
                principal.Show();
            }
        }
        private void CancelMethod()
        {
            if (MessageBox.Show("Deseja realmente cancelar a venda?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                Venda venda = new Venda();
                venda.Show();
            }
        }
    }
}











