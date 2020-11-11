using System;

namespace JFinansysBackEnd.Domain.Models
{
    public class Despesa
    {
        public Guid ID { get; set;} = Guid.NewGuid();
        public string DescricaoGasto { get; set; }
        public decimal ValorGasto { get; set; }
        public DateTime DataLancamento { get; set; } = DateTime.Now;
    }
}
