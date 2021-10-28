using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class AlugelRepository : IAluguelRepository

    {
        public string stringConexao = @"Data Source=NOTE0113H2\SQLEXPRESS; initial catalog=LOCADORA; User id=sa; pwd=Senai@132;";



        public void AtualizarporURL(int idAluguel, AluguelDomain aluguelAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryURL = "update ALUGUEIS set data_inicio = @data_inicio, data_fim = @data_fim where idAluguel = @idAluguel";
                using (SqlCommand cmd = new SqlCommand(queryURL, con))
                {
                    cmd.Parameters.AddWithValue("data_inicio",aluguelAtualizado.data_inicio);
                    cmd.Parameters.AddWithValue("@data_fim",aluguelAtualizado.data_fim);
                    cmd.Parameters.AddWithValue("@idAluguel",idAluguel);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public AluguelDomain BuscarporID(int idAluguel)
        {
            List<AluguelDomain> AlugelId = new List<AluguelDomain>();
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryID = "select idAluguel, idVeiculo, idClientes, data_inicio, data_fim from ALUGUEIS where idAluguel= @idAluguel";
                con.Open();
                SqlDataReader reader;
                using (SqlCommand cmd = new SqlCommand(queryID, con))
                {
                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        AluguelDomain aluguelbuscado = new AluguelDomain()
                        {
                            idAluguel=Convert.ToInt32(reader[0]),
                            idVeiculo=Convert.ToInt32(reader[1]),
                            idClientes=Convert.ToInt32(reader[2]),
                            data_inicio=Convert.ToDateTime(reader[3]),
                            data_fim=Convert.ToDateTime(reader[4])
                           

                        };
                        return aluguelbuscado;
                    }
                }
                return null;
            }
        }

        public void Cadastrar(AluguelDomain novoAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryAdd = "insert into ALUGUEIS (idVeiculo, idClientes, data_inicio, data_fim) values (@idVeiculo, @idCliente, @data_inicio, @data_fim)";
                using (SqlCommand cmd = new SqlCommand(queryAdd, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", novoAluguel.idVeiculo);
                    cmd.Parameters.AddWithValue("@idCliente", novoAluguel.idClientes);
                    cmd.Parameters.AddWithValue("@data_inicio", novoAluguel.data_inicio);
                    cmd.Parameters.AddWithValue("@data_fim", novoAluguel.data_fim);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "delete from ALUGUEIS where idAluguel= @idAluguel";
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<AluguelDomain> ListarTodos()
        {
            List<AluguelDomain> listaAluguel = new List<AluguelDomain>();
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryList = "select idVeiculo, idClientes, data_inicio, data_fim from ALUGUEIS";
                con.Open();
                SqlDataReader reader;
                using (SqlCommand cmd = new SqlCommand(queryList, con))
                {
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        AluguelDomain aluguel = new AluguelDomain()
                        {
                            idVeiculo=Convert.ToInt32(reader[0]),
                            idClientes=Convert.ToInt32(reader[1]),
                            data_inicio=Convert.ToDateTime(reader[2]),
                            data_fim=Convert.ToDateTime(reader[3])

                        };
                        listaAluguel.Add(aluguel);
                    }
                }
            }

            return listaAluguel;
        }
    }
}
