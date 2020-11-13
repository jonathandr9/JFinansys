using System;

namespace JFinansysBackEnd.WebApi.Dto
{
    public class EntradaPost
    {
        public string DescricaoEntrada { get; set; }
        public decimal ValorEntrada { get; set; }
        public DateTime DataLancamento { get; set; }
    }
}
