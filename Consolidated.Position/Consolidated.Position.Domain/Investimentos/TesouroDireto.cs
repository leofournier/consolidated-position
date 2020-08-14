using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Consolidated.Position.Domain
{
    /// <summary>Classe de Tesouro Direto</summary>
    public class TesouroDireto
    {
        /// <summary>Lista de Papeis do Tesouro Direto</summary>
        [JsonProperty("tds")]
        public List<Papel> Papeis { get; set; }
    }

    /// <summary>Papel do Tesouro Direto</summary>
    public class Papel
    {
        /// <summary>Valor Investido no Papel</summary>
        [JsonProperty("valorInvestido")]
        public decimal ValorInvestido { get; set; }

        /// <summary>Valor Total Financeiro</summary>
        [JsonProperty("valorTotal")]
        public decimal ValorTotal { get; set; }

        /// <summary>Data de Vencimento do Papel</summary>
        [JsonProperty("vencimento")]
        public DateTime DataVencimento { get; set; }

        /// <summary>Data de Compra do Papel</summary>
        [JsonProperty("dataDeCompra")]
        public DateTime DataDeCompra { get; set; }

        /// <summary>Imposto sobre a operação</summary>
        [JsonProperty("iof")]
        public decimal Iof { get; set; }

        /// <summary>Indice do papel</summary>
        [JsonProperty("indice")]
        public string Indice { get; set; }

        /// <summary>Tipo do Papel</summary>
        [JsonProperty("tipo")]
        public string Tipo { get; set; }

        /// <summary>Nome do Papel</summary>
        [JsonProperty("nome")]
        public string Nome { get; set; }
    }
}
