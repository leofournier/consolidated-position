using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Consolidated.Position.Domain
{
    /// <summary>Classe de Renda Fixa</summary>
    public class RendaFixa
    {
        /// <summary>Lista dos ativos de Renda Fixa</summary>
        [JsonProperty("lcis")] 
        public List<Ativo> Ativos { get; set; }
    }

    /// <summary>Classe de Ativos de Renda Fixa</summary>
    public class Ativo
    {
        /// <summary>Valor de Capital Investido</summary>
        [JsonProperty("capitalInvestido")]
        public decimal CapitalInvestido { get; set; }

        /// <summary>Valor de Capital Atual</summary>
        [JsonProperty("capitalAtual")]
        public decimal CapitalAtual { get; set; }

        /// <summary>Quantidade do ativo</summary>
        [JsonProperty("quantidade")]
        public decimal Quantidade { get; set; }

        /// <summary>Data do Vencimento do Ativo</summary>
        [JsonProperty("vencimento")]
        public DateTime DataVencimento { get; set; }

        /// <summary>Imposto sobre o financeiro</summary>
        [JsonProperty("iof")]
        public decimal Iof { get; set; }

        /// <summary>Outras taxas referentes ao ativo</summary>
        [JsonProperty("outrasTaxas")]
        public decimal OutrasTaxas { get; set; }

        /// <summary>Taxa aplicada pelo ativo</summary>
        [JsonProperty("taxas")]
        public decimal Taxas { get; set; }

        /// <summary>Indice que regula o ativo</summary>
        [JsonProperty("indice")]
        public string Indice { get; set; }

        /// <summary>Tipo de Ativo</summary>
        [JsonProperty("tipo")]
        public string Tipo { get; set; }

        /// <summary>Nome do Ativo</summary>
        [JsonProperty("nome")]
        public string Nome { get; set; }

        /// <summary>Flag para saber se o ativo é garantido pelo FGC</summary>
        [JsonProperty("garantidoFGC")]
        public bool GarantidoFGC { get; set; }

        /// <summary>Data em que ocorreu a operação</summary>
        [JsonProperty("dataOperacao")]
        public DateTime DataOperacao { get; set; }

        /// <summary>Preço Unitário do Ativo</summary>
        [JsonProperty("precoUnitario")]
        public decimal PrecoUnitario { get; set; }

        /// <summary>Flag para saber se é primario</summary>
        [JsonProperty("primario")]
        public bool Primario { get; set; }
    }
}
