using System;
using System.Collections.Generic;

namespace Consolidated.Position.Domain
{
    /// <summary>Classe de Tesouro Direto</summary>
    public class TesouroDireto
    {
        /// <summary>Valor de Capital Investido</summary>
        public List<Papel> Papeis { get; set; }
    }

    /// <summary>Valor de Capital Investido</summary>
    public class Papel
    {
        /// <summary>Valor de Capital Investido</summary>
        public decimal ValorInvestido { get; set; }
       
        /// <summary>Valor de Capital Investido</summary>
        public decimal ValorTotal { get; set; }
       
        /// <summary>Valor de Capital Investido</summary>
        public DateTime DataVencimento { get; set; }
      
        /// <summary>Valor de Capital Investido</summary>
        public DateTime DataDeCompra { get; set; }
      
        /// <summary>Valor de Capital Investido</summary>
        public decimal Iof { get; set; }
       
        /// <summary>Valor de Capital Investido</summary>
        public string Indice { get; set; }
      
        /// <summary>Valor de Capital Investido</summary>
        public string Tipo { get; set; }
      
        /// <summary>Valor de Capital Investido</summary>
        public string Nome { get; set; }
    }
}
