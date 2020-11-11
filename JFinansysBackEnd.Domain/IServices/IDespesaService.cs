using JFinansysBackEnd.Domain.Models;
using System.Collections.Generic;

namespace JFinansysBackEnd.Domain.IServices
{
    public interface IDespesaService
    {
        void IncluirDespesa(Despesa despesa);
        IEnumerable<Despesa> ListarDepesas();
        Despesa ListaDespesaPorID(string ID);
        void AtualizarDespesa(string ID, Despesa despesa);
    }
}
