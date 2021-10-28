using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class VeiculoRepository : IVeiculoRepository

    {
        public string stringConexao = @"Data Source=NOTE0113H2\SQLEXPRESS; initial catalog=LOCADORA; User id=sa; pwd=Senai@132;";


        public void AtualilzarporURL(int idVeiculo, VeiculoDomain veiculoAtualizado)
        {
            using(SqlConnection con= new SqlConnection(stringConexao))
            {
                string queryURL = "update VEICULOS set placa= @placa where idVeiculo = @idVeiculo";
                using(SqlCommand cmd= new SqlCommand(queryURL, con))
                {
                    cmd.Parameters.AddWithValue("@placa", veiculoAtualizado.placa);
                    cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            
        }

        public VeiculoDomain BuscarporID(int idVeiculo)
        {
            List<VeiculoDomain> ModeloId = new List<VeiculoDomain>();
            using(SqlConnection con= new SqlConnection(stringConexao))
            {
                string queryID = "select idVeiculo, idModelo, placa from VEICULOS where idVeiculo= @idVeiculo";
                con.Open();
                SqlDataReader reader;
                using(SqlCommand cmd= new SqlCommand(queryID, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        VeiculoDomain veiculoBuscado = new VeiculoDomain()
                        {
                            idVeiculo = Convert.ToInt32(reader[0]),
                            idModelo = Convert.ToInt32(reader[1]),
                            placa = Convert.ToString(reader[2])

                        };
                        return veiculoBuscado;
                    }
                }
                return null;
            }

            
        }

        public void Cadastrar(VeiculoDomain novoVeiculo)
        {
            using(SqlConnection con= new SqlConnection(stringConexao))
            {
                string queryAdd = "insert into VEICULOS (idModelo, placa) values (@idModelo, @placa)";
                using(SqlCommand cmd= new SqlCommand(queryAdd, con))
                {
                    cmd.Parameters.AddWithValue("@idModelo", novoVeiculo.idModelo);
                    cmd.Parameters.AddWithValue("@placa", novoVeiculo.placa);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idVeiculo)
        {
            using(SqlConnection con= new SqlConnection(stringConexao))
            {
                string queryDelete = "delete from VEICULOS where idVeiculo= @idVeiculo";
                using(SqlCommand cmd= new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            
        }

        public List<VeiculoDomain> ListarTodos()
        {
            List<VeiculoDomain> listaVeiculo = new List<VeiculoDomain>();
            using (SqlConnection con= new SqlConnection(stringConexao))
            {
                string queryList = "select idVeiculo, idModelo, placa from VEICULOS";
                con.Open();
                SqlDataReader reader;
                using(SqlCommand cmd= new SqlCommand(queryList, con))
                {
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        VeiculoDomain veiculo = new VeiculoDomain()
                        {
                            idVeiculo = Convert.ToInt32(reader[0]),
                            idModelo = Convert.ToInt32(reader[1]),
                            placa = Convert.ToString(reader[2])

                        };
                        listaVeiculo.Add(veiculo);
                    }
                }
            }

            return listaVeiculo;
        }
    }
}
