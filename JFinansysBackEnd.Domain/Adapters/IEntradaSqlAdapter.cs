using JFinansysBackEnd.Domain.Models;
using System.Collections.Generic;

namespace JFinansysBackEnd.Domain.Adapters
{
    public interface IEntradaSqlAdapter
    {
        void AdicionarEntrada(Entrada entrada);

        IEnumerable<Entrada> ListarEntradas();

        Entrada BuscarEntradaPorID(string ID);

        void AtualizarEntrada(string ID, Entrada entrada);
    }
}
