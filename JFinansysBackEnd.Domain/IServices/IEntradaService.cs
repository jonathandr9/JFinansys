using JFinansysBackEnd.Domain.Models;
using System.Collections.Generic;

namespace JFinansysBackEnd.Domain.IServices
{
    public interface IEntradaService
    {
        void IncluirEntrada(Entrada entrada);
        IEnumerable<Entrada> ListarEntradas();
        Entrada ListaEntradaPorID(string ID);
        void AtualizarEntrada(string ID, Entrada entrada);
    }
}
