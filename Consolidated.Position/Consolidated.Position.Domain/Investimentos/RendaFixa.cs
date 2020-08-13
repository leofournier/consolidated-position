using System;
using System.Collections.Generic;

namespace Consolidated.Position.Domain
{
    /// <summary>Classe de Renda Fixa</summary>
    public class RendaFixa
    {
        /// <summary>Lista dos ativos de Renda Fixa</summary>
        public List<Ativo> Ativos { get; set; }
    }

    /// <summary>Classe de Ativos de Renda Fixa</summary>
    public class Ativo
    {
        /// <summary>Valor de Capital Investido</summary>
        public decimal CapitalInvestido { get; set; }

        /// <summary>Valor de Capital Atual</summary>
        public decimal CapitalAtual { get; set; }

        /// <summary>Quantidade do ativo</summary>
        public decimal Quantidade { get; set; }

        /// <summary>Data do Vencimento do Ativo</summary>
        public DateTime DataVencimento { get; set; }

        /// <summary>Imposto sobre o financeiro</summary>
        public decimal Iof { get; set; }

        /// <summary>Outras taxas referentes ao ativo</summary>
        public decimal OutrasTaxas { get; set; }

        /// <summary>Taxa aplicada pelo ativo</summary>
        public decimal Taxas { get; set; }

        /// <summary>Indice que regula o ativo</summary>
        public string Indice { get; set; }

        /// <summary>Tipo de Ativo</summary>
        public string Tipo { get; set; }

        /// <summary>Nome do Ativo</summary>
        public string Nome { get; set; }

        /// <summary>Flag para saber se o ativo é garantido pelo FGC</summary>
        public bool GarantidoFGC { get; set; }

        /// <summary>Data em que ocorreu a operação</summary>
        public DateTime DataOperacao { get; set; }

        /// <summary>Preço Unitário do Ativo</summary>
        public decimal PrecoUnitario { get; set; }

        /// <summary>Flag para saber se é primario</summary>
        public bool Primario { get; set; }
    }
}
