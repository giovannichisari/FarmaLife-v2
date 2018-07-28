using System;
using MySql.Data.MySqlClient;

namespace cadastro_remedios
{
    class productQuery
    {
        public void Insert(Product lProduct)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Connection.lConnection);
                connection.Open();

                 string insert = "INSERT INTO cadastro_remedios(pro_codigo_de_barras,pro_descricao_do_produto,pro_nome_generico,pro_nome_comercial,pro_grupo,"
                    +"pro_fabricante_do_produto,pro_unidade,pro_local_de_armazenamento,pro_marca_fabricante,pro_quantidade_no_estoque,pro_data_de_cadastro," 
                    +"pro_preco_de_compra_por_caixa,pro_unid_caixa,pro_preco_de_compra_unitario,pro_margem,pro_preco_de_venda,pro_desconto_de_promocao,pro_margem_de_promocao," 
                    +"pro_preco_promocao,pro_inicio_da_promocao,pro_final_da_promocao,pro_obs,pro_status)" + "values ('"
                    + lProduct.prodCodigoBarras + "','" + lProduct.prodDescricao + "','" + lProduct.prodNomeGenerico + "','" + lProduct.prodNomeComercial + "','" + lProduct.prodGrupo + "','"
                    + lProduct.prodFabricante + "','" + lProduct.prodUnidade + "','" + lProduct.prodArmazenamento + "','" + lProduct.prodMarca + "','"
                    + lProduct.prodEstoque + "','" + lProduct.prodDataCadastro + "','" + lProduct.prodPrecoCaixa.Replace(",", ".") + "','" + lProduct.prodUnidadeCaixa + "','" + lProduct.prodCompraUnidade.Replace(",", ".") + "','"
                    + lProduct.prodMargem.Replace(",", ".") + "','" + lProduct.prodPrecoVenda.Replace(",", ".") + "','" + lProduct.prodDescontoPromocao.Replace(",", ".") + "','" + lProduct.prodMargemPromocao.Replace(",", ".") + "','"
                    + lProduct.prodPrecoPromocao.Replace(",", ".") + "','" + lProduct.prodInicioPromocao + "','" + lProduct.prodFinalPromocao + "','" + lProduct.prodObs + "','" + lProduct.prodStatus + "')";
                MySqlCommand command = new MySqlCommand(insert, connection);
                MySqlDataReader myreader;
                myreader = command.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }

        }

        internal void Update(Product lProduct)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Connection.lConnection);
                connection.Open();

                string update = "UPDATE cadastro_remedios set pro_codigo_de_barras= '" + lProduct.prodCodigoBarras + "',pro_descricao_do_produto= '" + lProduct.prodDescricao + "',pro_nome_generico= '" + lProduct.prodNomeGenerico + "',pro_nome_comercial= '" + lProduct.prodNomeComercial +
                     "',pro_grupo ='" + lProduct.prodGrupo + "',pro_fabricante_do_produto= '" + lProduct.prodFabricante + "',pro_unidade='"
                     + lProduct.prodUnidade + "',pro_local_de_armazenamento='" + lProduct.prodArmazenamento + "',pro_marca_fabricante='" + lProduct.prodMarca + "',pro_quantidade_no_estoque='" + lProduct.prodEstoque +
                     "',pro_data_de_cadastro='" + lProduct.prodDataCadastro + "',pro_preco_de_compra_por_caixa='" + lProduct.prodPrecoCaixa.Replace(",", ".") + "',pro_unid_caixa='" + lProduct.prodUnidadeCaixa + "',pro_preco_de_compra_unitario='" + lProduct.prodCompraUnidade.Replace(",", ".") +
                     "',pro_margem='" + lProduct.prodMargem.Replace(",", ".") + "',pro_preco_de_venda='" + lProduct.prodPrecoVenda.Replace(",", ".") + "',pro_desconto_de_promocao='" + lProduct.prodDescontoPromocao.Replace(",", ".") + "',pro_margem_de_promocao='" + lProduct.prodMargemPromocao.Replace(",", ".") +
                     "',pro_preco_promocao='" + lProduct.prodPrecoPromocao.Replace(",", ".") + "',pro_inicio_da_promocao='" + lProduct.prodInicioPromocao + "',pro_final_da_promocao='" + lProduct.prodFinalPromocao +
                     "',pro_obs='" + lProduct.prodObs + "',pro_status='" + lProduct.prodStatus + "' WHERE pro_codigo='" + lProduct.prodCodigo + "';";
                MySqlCommand command = new MySqlCommand(update, connection);
                MySqlDataReader myreader;
                myreader = command.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }



        public const string GetAllProducts = @"  SELECT 
                                                        pro_codigo as Codigo, 
                                                        pro_codigo_de_barras as 'Codigo De Barras',
                                                        pro_descricao_do_produto as 'Descricao Produto',
                                                        pro_nome_generico as 'Nome Generico',
                                                        pro_nome_comercial as 'Nome Comercial',
                                                        pro_grupo as Grupo ,pro_fabricante_do_produto as 'Fabricante',
                                                        pro_unidade as Unidade,
                                                        pro_local_de_armazenamento as 'Local Armazenamento',
                                                        pro_marca_fabricante as 'Marca Fabricante',
                                                        pro_quantidade_no_estoque as 'Qntd Estoque',
                                                        pro_data_de_cadastro as 'Data Cadastro',
                                                        pro_preco_de_compra_por_caixa as 'Preco Compra Caixa',
                                                        pro_unid_caixa as 'Unidade Caixa',
                                                        pro_preco_de_compra_unitario as 'Preco Compra Unitario',
                                                        pro_margem as Margem,
                                                        pro_preco_de_venda as 'Preco Venda',
                                                        pro_desconto_de_promocao as 'Desconto Promocao',
                                                        pro_margem_de_promocao as 'Margem Promocao',
                                                        pro_preco_promocao as 'Preco Promocao',
                                                        pro_inicio_da_promocao as 'Inicio Promocao',
                                                        pro_final_da_promocao as 'Final Promocao',
                                                        pro_obs as Observacoes, 
                                                        pro_status as Status
                                                   FROM cadastro_remedios";

        public const string GetAllActiveProducts = @"    SELECT 
                                                                pro_codigo as Codigo, 
                                                                pro_codigo_de_barras as 'Codigo De Barras',
                                                                pro_descricao_do_produto as 'Descricao Produto',
                                                                pro_nome_generico as 'Nome Generico',
                                                                pro_nome_comercial as 'Nome Comercial',
                                                                pro_grupo as Grupo ,pro_fabricante_do_produto as 'Fabricante',
                                                                pro_unidade as Unidade,
                                                                pro_local_de_armazenamento as 'Local Armazenamento',
                                                                pro_marca_fabricante as 'Marca Fabricante',
                                                                pro_quantidade_no_estoque as 'Qntd Estoque',
                                                                pro_data_de_cadastro as 'Data Cadastro',
                                                                pro_preco_de_compra_por_caixa as 'Preco Compra Caixa',
                                                                pro_unid_caixa as 'Unidade Caixa',
                                                                pro_preco_de_compra_unitario as 'Preco Compra Unitario',
                                                                pro_margem as Margem,
                                                                pro_preco_de_venda as 'Preco Venda',
                                                                pro_desconto_de_promocao as 'Desconto Promocao',
                                                                pro_margem_de_promocao as 'Margem Promocao',
                                                                pro_preco_promocao as 'Preco Promocao',
                                                                pro_inicio_da_promocao as 'Inicio Promocao',
                                                                pro_final_da_promocao as 'Final Promocao',
                                                                pro_obs as Observacoes, 
                                                                pro_status as Status
                                                           FROM cadastro_remedios
                                                          WHERE pro_status = 'A'";

        public const string GetAllInactiveProducts = @"  SELECT 
                                                        pro_codigo as Codigo, 
                                                        pro_codigo_de_barras as 'Codigo De Barras',
                                                        pro_descricao_do_produto as 'Descricao Produto',
                                                        pro_nome_generico as 'Nome Generico',
                                                        pro_nome_comercial as 'Nome Comercial',
                                                        pro_grupo as Grupo ,pro_fabricante_do_produto as 'Fabricante',
                                                        pro_unidade as Unidade,
                                                        pro_local_de_armazenamento as 'Local Armazenamento',
                                                        pro_marca_fabricante as 'Marca Fabricante',
                                                        pro_quantidade_no_estoque as 'Qntd Estoque',
                                                        pro_data_de_cadastro as 'Data Cadastro',
                                                        pro_preco_de_compra_por_caixa as 'Preco Compra Caixa',
                                                        pro_unid_caixa as 'Unidade Caixa',
                                                        pro_preco_de_compra_unitario as 'Preco Compra Unitario',
                                                        pro_margem as Margem,
                                                        pro_preco_de_venda as 'Preco Venda',
                                                        pro_desconto_de_promocao as 'Desconto Promocao',
                                                        pro_margem_de_promocao as 'Margem Promocao',
                                                        pro_preco_promocao as 'Preco Promocao',
                                                        pro_inicio_da_promocao as 'Inicio Promocao',
                                                        pro_final_da_promocao as 'Final Promocao',
                                                        pro_obs as Observacoes, 
                                                        pro_status as Status
                                                   FROM cadastro_remedios
                                                  WHERE pro_status = 'I'";

        public const string GetById = @"  SELECT 
                                                        pro_codigo as Codigo, 
                                                        pro_codigo_de_barras as 'Codigo De Barras',
                                                        pro_descricao_do_produto as 'Descricao Produto',
                                                        pro_nome_generico as 'Nome Generico',
                                                        pro_nome_comercial as 'Nome Comercial',
                                                        pro_grupo as Grupo ,pro_fabricante_do_produto as 'Fabricante',
                                                        pro_unidade as Unidade,
                                                        pro_local_de_armazenamento as 'Local Armazenamento',
                                                        pro_marca_fabricante as 'Marca Fabricante',
                                                        pro_quantidade_no_estoque as 'Qntd Estoque',
                                                        pro_data_de_cadastro as 'Data Cadastro',
                                                        pro_preco_de_compra_por_caixa as 'Preco Compra Caixa',
                                                        pro_unid_caixa as 'Unidade Caixa',
                                                        pro_preco_de_compra_unitario as 'Preco Compra Unitario',
                                                        pro_margem as Margem,
                                                        pro_preco_de_venda as 'Preco Venda',
                                                        pro_desconto_de_promocao as 'Desconto Promocao',
                                                        pro_margem_de_promocao as 'Margem Promocao',
                                                        pro_preco_promocao as 'Preco Promocao',
                                                        pro_inicio_da_promocao as 'Inicio Promocao',
                                                        pro_final_da_promocao as 'Final Promocao',
                                                        pro_obs as Observacoes, 
                                                        pro_status as Status
                                                   FROM cadastro_remedios
                                                  WHERE pro_status = 'A'
                                                    AND pro_codigo LIKE @value";

        public const string GetByCompany = @"  SELECT 
                                                        pro_codigo as Codigo, 
                                                        pro_codigo_de_barras as 'Codigo De Barras',
                                                        pro_descricao_do_produto as 'Descricao Produto',
                                                        pro_nome_generico as 'Nome Generico',
                                                        pro_nome_comercial as 'Nome Comercial',
                                                        pro_grupo as Grupo ,pro_fabricante_do_produto as 'Fabricante',
                                                        pro_unidade as Unidade,
                                                        pro_local_de_armazenamento as 'Local Armazenamento',
                                                        pro_marca_fabricante as 'Marca Fabricante',
                                                        pro_quantidade_no_estoque as 'Qntd Estoque',
                                                        pro_data_de_cadastro as 'Data Cadastro',
                                                        pro_preco_de_compra_por_caixa as 'Preco Compra Caixa',
                                                        pro_unid_caixa as 'Unidade Caixa',
                                                        pro_preco_de_compra_unitario as 'Preco Compra Unitario',
                                                        pro_margem as Margem,
                                                        pro_preco_de_venda as 'Preco Venda',
                                                        pro_desconto_de_promocao as 'Desconto Promocao',
                                                        pro_margem_de_promocao as 'Margem Promocao',
                                                        pro_preco_promocao as 'Preco Promocao',
                                                        pro_inicio_da_promocao as 'Inicio Promocao',
                                                        pro_final_da_promocao as 'Final Promocao',
                                                        pro_obs as Observacoes, 
                                                        pro_status as Status
                                                   FROM cadastro_remedios
                                                  WHERE pro_status = 'A'
                                                    AND pro_fabricante_do_produto LIKE @value";


        public const string GetByGenericName = @"  SELECT 
                                                        pro_codigo as Codigo, 
                                                        pro_codigo_de_barras as 'Codigo De Barras',
                                                        pro_descricao_do_produto as 'Descricao Produto',
                                                        pro_nome_generico as 'Nome Generico',
                                                        pro_nome_comercial as 'Nome Comercial',
                                                        pro_grupo as Grupo ,pro_fabricante_do_produto as 'Fabricante',
                                                        pro_unidade as Unidade,
                                                        pro_local_de_armazenamento as 'Local Armazenamento',
                                                        pro_marca_fabricante as 'Marca Fabricante',
                                                        pro_quantidade_no_estoque as 'Qntd Estoque',
                                                        pro_data_de_cadastro as 'Data Cadastro',
                                                        pro_preco_de_compra_por_caixa as 'Preco Compra Caixa',
                                                        pro_unid_caixa as 'Unidade Caixa',
                                                        pro_preco_de_compra_unitario as 'Preco Compra Unitario',
                                                        pro_margem as Margem,
                                                        pro_preco_de_venda as 'Preco Venda',
                                                        pro_desconto_de_promocao as 'Desconto Promocao',
                                                        pro_margem_de_promocao as 'Margem Promocao',
                                                        pro_preco_promocao as 'Preco Promocao',
                                                        pro_inicio_da_promocao as 'Inicio Promocao',
                                                        pro_final_da_promocao as 'Final Promocao',
                                                        pro_obs as Observacoes, 
                                                        pro_status as Status
                                                   FROM cadastro_remedios
                                                  WHERE pro_status = 'A'
                                                    AND pro_nome_generico LIKE @value";


        public const string GetProductForSales = @"SELECT   pro_codigo as Codigo, 
                                                            pro_nome_generico as Nome, 
                                                            pro_preco_de_venda as Preco ,
                                                            pro_desconto_de_promocao as Desconto, 
                                                            pro_inicio_da_promocao as 'Inicio Promocao',
                                                            pro_final_da_promocao as 'Final Promocao' 
                                                    FROM cadastro_remedios 
                                                   WHERE pro_nome_generico LIKE @value 
                                                     AND pro_status = 'A'";

    }
}
      
        
    

