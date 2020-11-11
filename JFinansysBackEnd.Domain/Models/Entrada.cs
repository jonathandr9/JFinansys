using System;

namespace JFinansysBackEnd.Domain.Models
{
    public class Entrada
    {
        public Guid ID { get; set; }
        public string DescricaoEntrada { get; set; }
        public decimal ValorEntrada { get; set; }
        public DateTime DataLancamento { get; set; }
    }
}
