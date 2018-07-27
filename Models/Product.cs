using System;

namespace cadastro_remedios
{
    public class Product
    {        //cadastro de produto

        public int prodCodigo { get; set; }
        public string prodCodigoBarras { get; set; }
        public string prodDescricao { get; set; }
        public string prodNomeGenerico { get; set; }
        public string prodNomeComercial { get; set; }
        public string prodGrupo { get; set; }
        public string prodFabricante { get; set; }
        public string prodUnidade { get; set; }
        public string prodArmazenamento { get; set; }
        public string prodMarca { get; set; }
        public string prodEstoque { get; set; }
        public string prodDataCadastro { get; set; }
        public string prodPrecoCaixa { get; set; }
        public string prodUnidadeCaixa { get; set; }
        public string prodCompraUnidade { get; set; }
        public string prodMargem { get; set; }
        public string prodPrecoVenda { get; set; }
        public string prodDescontoPromocao { get; set; }
        public string prodMargemPromocao { get; set; }
        public string prodPrecoPromocao { get; set; }
        public string prodInicioPromocao { get; set; }
        public string prodFinalPromocao { get; set; }
        public string prodObs { get; set; }

    }
}