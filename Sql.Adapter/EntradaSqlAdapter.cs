using Dapper;
using JFinansysBackEnd.Domain.Adapters;
using JFinansysBackEnd.Domain.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Sql.Adapter
{
    public class EntradaSqlAdapter : IEntradaSqlAdapter
    {
        private readonly IConfiguration _configuration;

        public EntradaSqlAdapter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string GetConnectionString()
        {
            var connectionString = _configuration.GetSection("ConnectionStrings").
                GetSection("JFinansys").Value;


            return connectionString;
        }

        public void AdicionarEntrada(Entrada entrada)
        {

            using (var con = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    con.Open();

                    var query = @"INSERT INTO ENTRADA
                                (  ID
                                  ,DESCRICAOENTRADA
                                  ,VALORENTRADA
                                  ,DATALANCAMENTO) 
                                VALUES
                                (  @Id
                                 , @DescricaoEntrada
                                 , @ValorEntrada
                                 , @DataLancamento)";

                    con.Execute(query, entrada);
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

        public IEnumerable<Entrada> ListarEntradas()
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    connection.Open();

                    var consulta = @"SELECT
                                          ID
                                        , DESCRICAOENTRADA
                                        , VALORENTRADA
                                        , DATALANCAMENTO
                                    FROM ENTRADA WITH(NOLOCK)";

                    var entradas = connection.Query<Entrada>(consulta);

                    return entradas;

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

        public Entrada BuscarEntradaPorID(string ID)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    connection.Open();

                    var consulta = @"SELECT
                                          ID
                                        , DESCRICAOENTRADA
                                        , VALORENTRADA
                                        , DATALANCAMENTO
                                    FROM ENTRADA WITH(NOLOCK)
                                    WHERE ID = @ID";

                    var entrada = connection
                        .QueryFirstOrDefault<Entrada>(consulta, new { ID });

                    return entrada;

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

        public void AtualizarEntrada(string ID, Entrada entrada)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    connection.Open();

                    entrada.ID = Guid.Parse(ID);

                    var consulta = @"UPDATE ENTRADA SET                                        
                                          DESCRICAOENTRADA = @DESCRICAOENTRADA
                                        , VALORENTRADA = @VALORENTRADA
                                        , DATALANCAMENTO = @DATALANCAMENTO
                                    WHERE ID = @ID";

                    connection
                        .Execute(consulta, entrada);

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
