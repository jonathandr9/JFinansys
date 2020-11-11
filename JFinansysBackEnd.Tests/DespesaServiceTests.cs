using JFinansysBackEnd.Application;
using JFinansysBackEnd.Domain.Adapters;
using JFinansysBackEnd.Domain.IServices;
using JFinansysBackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace JFinansysBackEnd.Tests
{
    public class DespesaServiceTests
    {
        [Fact]
        [Trait("ListarDespesa", "Despesa")]
        public void ListarDespesas_DespesaService_Sucesso()
        {
            //Arrange
            IEnumerable<Despesa> despesasExpected = new List<Despesa>()
            {
                new Despesa{
                    ID = Guid.NewGuid(),
                    DescricaoGasto = "Lanche",
                    ValorGasto = 36.60M,
                    DataLancamento = DateTime.Now
                },
                new Despesa{
                    ID = Guid.NewGuid(),
                    DescricaoGasto = "Gasolina",
                    ValorGasto = 50M,
                    DataLancamento = DateTime.Now
                },
            };

            Moq.Mock<IDespesaSqlAdapter> sqlAdapter = new Moq.Mock<IDespesaSqlAdapter>();
            sqlAdapter.Setup(x => x.ListarDespesas()).Returns(despesasExpected);
            IDespesaService despesaService = new DespesaService(sqlAdapter.Object);

            //Act
            var despesasResult = despesaService.ListarDepesas();

            //Assert
            Assert.Equal(despesasExpected, despesasResult);
        }

        [Fact]
        [Trait("InserirDespesa","Despesa")]
        public void InserirDespesa_DespesaService_Sucesso()
        {
            //Arrange

            //Act

            //Assert
        }
    }
}
