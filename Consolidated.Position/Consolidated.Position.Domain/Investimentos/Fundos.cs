using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Consolidated.Position.Domain
{
    /// <summary>Classe de Fundos de Investimento</summary>
    public class Fundos
    {
        /// <summary>Lista de Fundos de Investimentos</summary>
        [JsonProperty("fundos")]
        public List<Fundo> FundoInvestimento { get; set; }
    }

    /// <summary>Classe Fundo</summary>
    public class Fundo
    {
        /// <summary>Valor de Capital Investido</summary>
        [JsonProperty("capitalInvestido")]
        public decimal CapitalInvestido { get; set; }

        /// <summary>Valor Atual</summary>
        [JsonProperty("ValorAtual")]
        public decimal ValorAtual { get; set; }

        /// <summary>Data de Resgate</summary>
        [JsonProperty("dataResgate")]
        public DateTime DataResgate { get; set; }

        /// <summary>Data da Compra</summary>
        [JsonProperty("dataCompra")]
        public DateTime DataCompra { get; set; }

        /// <summary>Imposto sobre a operação</summary>
        [JsonProperty("iof")]
        public decimal Iof { get; set; }

        /// <summary>Nome do Fundo</summary>
        [JsonProperty("nome")]
        public string Nome { get; set; }

        /// <summary>Total de Taxas</summary>
        [JsonProperty("totalTaxas")]
        public decimal TotalTaxas { get; set; }

        /// <summary>Quantidade de Cotas</summary>
        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }
    }
}
