using System;

namespace JFinansysBackEnd.WebApi.Dto
{
    public class DespesaPost
    {
        public string DescricaoDespesa { get; set; }
        public decimal ValorGasto { get; set; }
        public DateTime DataLancamento { get; set; }
    }
}
