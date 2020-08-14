using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Consolidated.Position.Domain
{
    public class Investimento
    {
        public string Nome { get; set; }
        public decimal ValorInvestido { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime Vencimento { get; set; }
        public decimal Ir { get; set; }
        public decimal ValorResgate { get; set; }
    }

    public class Consolidado
    {
        public decimal ValorTotal { get; set; }
        public List<Investimento> Investimentos { get; set; }
    }

    public static class ConsolidadoExtensions
    {
        public static decimal CalculaValorResgate(this DateTime dataCompra, DateTime dataVenda)
        {
            var tempoCustodia = (DateTime.Today - dataCompra).TotalDays;
            var tempoVencer = (dataVenda - DateTime.Today).TotalDays;

            if (tempoVencer <= 90)
                return 0.06m;
            else if (tempoCustodia > tempoVencer)
                return 0.15m;
            else
                return 0.30m;
        }
        public static Consolidado MappingTesouroDiretoToConsolidado(this TesouroDireto tds)
        {
            var retorno = new Consolidado();
            var invest = new List<Investimento>();

            foreach (var item in tds.Papeis)
            {
                retorno.ValorTotal += item.ValorTotal;
                invest.Add(new Investimento
                {
                    Nome = item.Nome,
                    ValorInvestido = item.ValorInvestido,
                    ValorTotal = item.ValorTotal,
                    Vencimento = item.DataVencimento,
                    Ir = (item.ValorTotal - item.ValorInvestido) * 0.1m, //10%
                    ValorResgate = item.ValorTotal * CalculaValorResgate(item.DataDeCompra, item.DataVencimento)
                });
            }

            retorno.Investimentos = invest;

            return retorno;
        }
        public static Consolidado MappingPosicoesToConsolidado(this Fundos fdo, TesouroDireto tds, RendaFixa rdx)
        {
            var retorno = new Consolidado();
            var invest = new List<Investimento>();

            foreach (var item in fdo.FundoInvestimento)
            {
                retorno.ValorTotal += item.ValorAtual;
                invest.Add(new Investimento
                {
                    Nome = item.Nome,
                    ValorInvestido = item.CapitalInvestido,
                    ValorTotal = item.ValorAtual,
                    Vencimento = item.DataResgate,
                    Ir = (item.ValorAtual - item.CapitalInvestido) * 0.15m, //15%
                    ValorResgate = item.ValorAtual * CalculaValorResgate(item.DataCompra, item.DataResgate)
                });
            }

            foreach (var item in rdx.Ativos)
            {
                retorno.ValorTotal += item.CapitalAtual;
                invest.Add(new Investimento
                {
                    Nome = item.Nome,
                    ValorInvestido = item.CapitalInvestido,
                    ValorTotal = item.CapitalAtual,
                    Vencimento = item.DataVencimento,
                    Ir = (item.CapitalAtual - item.CapitalInvestido) * 0.05m, //5%
                    ValorResgate = item.CapitalAtual * CalculaValorResgate(item.DataOperacao, item.DataVencimento)
                });
            }

            foreach (var item in tds.Papeis)
            {
                retorno.ValorTotal += item.ValorTotal;
                invest.Add(new Investimento
                {
                    Nome = item.Nome,
                    ValorInvestido = item.ValorInvestido,
                    ValorTotal = item.ValorTotal,
                    Vencimento = item.DataVencimento,
                    Ir = (item.ValorTotal - item.ValorInvestido) * 0.1m, //10%
                    ValorResgate = item.ValorTotal * CalculaValorResgate(item.DataDeCompra, item.DataVencimento)
                });
            }

            retorno.Investimentos = invest;

            return retorno;
        }
        public static Consolidado MappingFundosToConsolidado(this Fundos fdo)
        {
            var retorno = new Consolidado();
            var invest = new List<Investimento>();

            foreach (var item in fdo.FundoInvestimento)
            {
                retorno.ValorTotal += item.ValorAtual;
                invest.Add(new Investimento
                {
                    Nome = item.Nome,
                    ValorInvestido = item.CapitalInvestido,
                    ValorTotal = item.ValorAtual,
                    Vencimento = item.DataResgate,
                    Ir = (item.ValorAtual - item.CapitalInvestido) * 0.15m, //15%
                    ValorResgate = item.ValorAtual * CalculaValorResgate(item.DataCompra, item.DataResgate)
                });
            }

            retorno.Investimentos = invest;

            return retorno;
        }
        public static Consolidado MappingRendaFixaToConsolidado(this RendaFixa rdx)
        {
            var retorno = new Consolidado();
            var invest = new List<Investimento>();

            foreach (var item in rdx.Ativos)
            {
                retorno.ValorTotal += item.CapitalAtual;
                invest.Add(new Investimento
                {
                    Nome = item.Nome,
                    ValorInvestido = item.CapitalInvestido,
                    ValorTotal = item.CapitalAtual,
                    Vencimento = item.DataVencimento,
                    Ir = (item.CapitalAtual - item.CapitalInvestido) * 0.05m, //5%
                    ValorResgate = item.CapitalAtual * CalculaValorResgate(item.DataOperacao, item.DataVencimento)
                });
            }

            retorno.Investimentos = invest;

            return retorno;
        }
    }
}
