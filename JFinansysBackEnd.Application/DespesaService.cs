using JFinansysBackEnd.Domain.Adapters;
using JFinansysBackEnd.Domain.IServices;
using JFinansysBackEnd.Domain.Models;
using System.Collections.Generic;

namespace JFinansysBackEnd.Application
{
    public class DespesaService : IDespesaService
    {
        private readonly IDespesaSqlAdapter _sqlAdapter;
        public DespesaService(IDespesaSqlAdapter sqlAdapter)
        {
            _sqlAdapter = sqlAdapter;
        }

        public void AtualizarDespesa(string ID, Despesa despesa)
        {
            _sqlAdapter.AtualizarDespesa(ID, despesa);
        }

        public void IncluirDespesa(Despesa despesa)
        {
            _sqlAdapter.AdicionarDespesa(despesa);
        }

        public Despesa ListaDespesaPorID(string ID)
        {
            return _sqlAdapter.BuscarDespesaPorID(ID);
        }

        public IEnumerable<Despesa> ListarDepesas()
        {
            return _sqlAdapter.ListarDespesas();
        }
    }
}
