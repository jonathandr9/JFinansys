using JFinansysBackEnd.Domain.Adapters;
using JFinansysBackEnd.Domain.IServices;
using JFinansysBackEnd.Domain.Models;
using System.Collections.Generic;

namespace JFinansysBackEnd.Application
{
    public class EntradaService : IEntradaService
    {
        public readonly IEntradaSqlAdapter _entradaSqlAdapter;

        public EntradaService(IEntradaSqlAdapter entradaSqlAdapter)
        {
            _entradaSqlAdapter = entradaSqlAdapter;
        }

        public void AtualizarEntrada(string ID, Entrada entrada)
        {
            _entradaSqlAdapter.AtualizarEntrada(ID, entrada);
        }

        public void IncluirEntrada(Entrada entrada)
        {
            _entradaSqlAdapter.AdicionarEntrada(entrada);
        }

        public Entrada ListaEntradaPorID(string ID)
        {
            return _entradaSqlAdapter.BuscarEntradaPorID(ID);
        }

        public IEnumerable<Entrada> ListarEntradas()
        {
            return _entradaSqlAdapter.ListarEntradas();
        }
    }
}
