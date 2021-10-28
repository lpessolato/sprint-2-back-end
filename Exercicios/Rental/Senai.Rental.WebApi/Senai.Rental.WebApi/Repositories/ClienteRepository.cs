using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        public string stringConexao = @"Data Source=NOTE0113H2\SQLEXPRESS; initial catalog=LOCADORA; User id=sa; pwd=Senai@132;";

        public void AtualizarporURL(int idCliente, ClienteDomain clienteAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryURL = "update CLIENTES set nome = @nome, cpf = @cpf where idClientes = @idClientes";
                using (SqlCommand cmd = new SqlCommand(queryURL, con))
                {
                    cmd.Parameters.AddWithValue("@nome", clienteAtualizado.nome);
                    cmd.Parameters.AddWithValue("@cpf", clienteAtualizado.cpf);
                    cmd.Parameters.AddWithValue("@idClientes", idCliente);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public ClienteDomain BuscarporId(int idCliente)
        {
            List<ClienteDomain> ClienteId = new List<ClienteDomain>();
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryID = "select nome, cpf from CLIENTES where idClientes= @idClientes";
                con.Open();
                SqlDataReader reader;
                using (SqlCommand cmd = new SqlCommand(queryID, con))
                {
                    cmd.Parameters.AddWithValue("@idClientes", idCliente);
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        ClienteDomain clientebuscado = new ClienteDomain()
                        {
                            nome= Convert.ToString(reader[0]),
                            cpf= Convert.ToString(reader[1])

                        };
                        return clientebuscado;
                    }
                }
                return null;
            }
        }

        public void Cadastar(ClienteDomain novoCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryAdd = "insert into CLIENTES (nome, cpf) values (@nome, @cpf)";
                using (SqlCommand cmd = new SqlCommand(queryAdd, con))
                {
                    cmd.Parameters.AddWithValue("@nome", novoCliente.nome);
                    cmd.Parameters.AddWithValue("@cpf", novoCliente.cpf);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            
        }

        public void Deletar(int idCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "delete from CLIENTES where idClientes= @idClientes";
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idClientes", idCliente);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            
        }

        public List<ClienteDomain> ListarTodos()
        {
            List<ClienteDomain> listaCliente = new List<ClienteDomain>();
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryList = "select idClientes, nome , cpf from CLIENTES";
                con.Open();
                SqlDataReader reader;
                using (SqlCommand cmd = new SqlCommand(queryList, con))
                {
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ClienteDomain cliente = new ClienteDomain()
                        {
                           idClientes= Convert.ToInt32(reader[0]),
                           nome= Convert.ToString(reader[1]),
                           cpf= Convert.ToString(reader[2])

                        };
                        listaCliente.Add(cliente);
                    }
                }
            }

            return listaCliente;
        }
    }
    
}
