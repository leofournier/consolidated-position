using System;
using System.Collections.Generic;

namespace Consolidated.Position.Domain
{
    /// <summary>Classe de Fundos de Investimento</summary>
    public class FundosInvestimentos
    {
        /// <summary>Lista de Fundos de Investimentos</summary>
        public List<Fundo> Fundos { get; set; }
    }

    /// <summary>Classe Fundo</summary>
    public class Fundo
    {
        /// <summary>Valor de Capital Investido</summary>
        public decimal CapitalInvestido { get; set; }
       
        /// <summary>Valor Atual</summary>
        public decimal ValorAtual { get; set; }
        
        /// <summary>Data de Resgate</summary>
        public DateTime DataResgate { get; set; }
        
        /// <summary>Data da Compra</summary>
        public DateTime DataCompra { get; set; }
        
        /// <summary>Imposto sobre a operação</summary>
        public int Iof { get; set; }
        
        /// <summary>Nome do Fundo</summary>
        public string Nome { get; set; }
        
        /// <summary>Total de Taxas</summary>
        public decimal TotalTaxas { get; set; }
        
        /// <summary>Quantidade de Cotas</summary>
        public decimal Quantity { get; set; }
    }
}
