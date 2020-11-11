using Dapper;
using JFinansysBackEnd.Domain.Adapters;
using JFinansysBackEnd.Domain.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Sql.Adapter
{
    public class DespesaSqlAdapter : IDespesaSqlAdapter
    {
        private readonly IConfiguration _configuration;

        public DespesaSqlAdapter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string GetConnectionString()
        {
            var connectionString = _configuration.GetSection("ConnectionStrings").
                GetSection("JFinansys").Value;


            return connectionString;
        }

        public void AdicionarDespesa(Despesa despesa)
        {

            using (var con = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    con.Open();

                    var query = @"INSERT INTO DESPESA
                                (  ID
                                  ,DESCRICAOGASTO
                                  ,VALORGASTO
                                  ,DATALANCAMENTO) 
                                VALUES
                                (  @Id
                                 , @DescricaoGasto
                                 , @ValorGasto
                                 , @DataLancamento)";

                    con.Execute(query, despesa);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public IEnumerable<Despesa> ListarDespesas()
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    connection.Open();

                    var consulta = @"SELECT
                                          ID
                                        , DESCRICAOGASTO
                                        , VALORGASTO
                                        , DATALANCAMENTO
                                    FROM DESPESA WITH(NOLOCK)";

                    var despesas = connection.Query<Despesa>(consulta);                  

                    return despesas;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public Despesa BuscarDespesaPorID(string ID)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    connection.Open();

                    var consulta = @"SELECT
                                          ID
                                        , DESCRICAOGASTO
                                        , VALORGASTO
                                        , DATALANCAMENTO
                                    FROM DESPESA WITH(NOLOCK)
                                    WHERE ID = @ID";

                    var despesa = connection
                        .QueryFirstOrDefault<Despesa>(consulta, new { ID });

                    return despesa;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void AtualizarDespesa(string ID, Despesa despesa)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    connection.Open();

                    despesa.ID = Guid.Parse(ID);

                    var consulta = @"UPDATE DESPESA SET                                        
                                          DESCRICAOGASTO = @DESCRICAOGASTO
                                        , VALORGASTO = @VALORGASTO
                                        , DATALANCAMENTO = @DATALANCAMENTO
                                    WHERE ID = @ID";

                    connection
                        .Execute(consulta, despesa);                    

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
