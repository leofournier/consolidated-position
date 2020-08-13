using System;
using System.Collections.Generic;

namespace Consolidated.Position.Domain
{
    /// <summary>Classe de Tesouro Direto</summary>
    public class TesouroDireto
    {
        /// <summary>Lista de Papeis do Tesouro Direto</summary>
        public List<Papel> Papeis { get; set; }
    }

    /// <summary>Papel do Tesouro Direto</summary>
    public class Papel
    {
        /// <summary>Valor Investido no Papel</summary>
        public decimal ValorInvestido { get; set; }
       
        /// <summary>Valor Total Financeiro</summary>
        public decimal ValorTotal { get; set; }
       
        /// <summary>Data de Vencimento do Papel</summary>
        public DateTime DataVencimento { get; set; }
      
        /// <summary>Data de Compra do Papel</summary>
        public DateTime DataDeCompra { get; set; }
      
        /// <summary>Imposto sobre a operação</summary>
        public decimal Iof { get; set; }
       
        /// <summary>Indice do papel</summary>
        public string Indice { get; set; }
      
        /// <summary>Tipo do Papel</summary>
        public string Tipo { get; set; }
      
        /// <summary>Nome do Papel</summary>
        public string Nome { get; set; }
    }
}
