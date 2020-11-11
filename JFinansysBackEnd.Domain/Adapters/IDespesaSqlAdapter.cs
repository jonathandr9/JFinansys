using JFinansysBackEnd.Domain.Models;
using System.Collections.Generic;

namespace JFinansysBackEnd.Domain.Adapters
{
    public interface IDespesaSqlAdapter
    {
        void AdicionarDespesa(Despesa despesa);

        IEnumerable<Despesa> ListarDespesas();

        Despesa BuscarDespesaPorID(string ID);

        void AtualizarDespesa(string ID, Despesa despesa);
    }
}
