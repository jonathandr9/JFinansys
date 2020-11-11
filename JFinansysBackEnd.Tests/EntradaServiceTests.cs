using JFinansysBackEnd.Application;
using JFinansysBackEnd.Domain.Adapters;
using JFinansysBackEnd.Domain.IServices;
using JFinansysBackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace JFinansysBackEnd.Tests
{
    public class EntradaServiceTests
    {
        [Fact]
        [Trait("ListarDespesa", "Despesa")]
        public void ListarDespesas_DespesaService_Sucesso()
        {
            //Arrange
            IEnumerable<Entrada> entradasExpected = new List<Entrada>()
            {
                new Entrada{
                    ID = Guid.NewGuid(),
                    DescricaoEntrada = "Extra",
                    ValorEntrada = 50.80M,
                    DataLancamento = DateTime.Now
                },
                new Entrada{
                    ID = Guid.NewGuid(),
                    DescricaoEntrada = "Salario",
                    ValorEntrada = 1000M,
                    DataLancamento = DateTime.Now
                },
            };

            Moq.Mock<IEntradaSqlAdapter> sqlAdapter = new Moq.Mock<IEntradaSqlAdapter>();
            sqlAdapter.Setup(x => x.ListarEntradas()).Returns(entradasExpected);
            IEntradaService entradaService = new EntradaService(sqlAdapter.Object);

            //Act
            var entradasResult = entradaService.ListarEntradas();

            //Assert
            Assert.Equal(entradasExpected, entradasResult);
        }
    }
}
