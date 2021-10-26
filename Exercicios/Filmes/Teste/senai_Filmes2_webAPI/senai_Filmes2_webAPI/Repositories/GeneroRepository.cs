using senai_Filmes2_webAPI.Domains;
using senai_Filmes2_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Filmes2_webAPI.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        private string stringConexao = @"Data Source=NOTE0113H4\SQLEXPRESS; initial catalog=CATALOGO ;User Id=sa; pwd=Senai@132;";

        public void AtualizarIdCorpo(GeneroDomain generoAtualizado)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int idGenero, GeneroDomain generoAtualizado)
        {
           using(SqlConnection con= new SqlConnection(stringConexao))
            {
                string queryUpdate = "update GENERO set nomeGenero = @nomeGenero where idGenero = @idGenero";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("nomeGenero", generoAtualizado.nomeGenero);
                    cmd.Parameters.AddWithValue("idGenero", idGenero);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            
        }

        public GeneroDomain BuscarPorId(int idGenero)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectbyId = "select nomeGenero, idGenero from GENERO where idGenero = @idGenero";
                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectbyId, con))
                {
                    cmd.Parameters.AddWithValue("@idGenero", idGenero);
                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        GeneroDomain generobuscado = new GeneroDomain
                        {
                            idGenero = Convert.ToInt32(reader[1]),
                            nomeGenero = Convert.ToString(reader[0])

                        };
                        return generobuscado;
                    }
                    return null;
                }

            }

          
        }

        public void Cadastrar(GeneroDomain novoGenero)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "Insert into GENERO (nomeGenero) values (@nomeGenero)";

                con.Open();

                using (SqlCommand cmd= new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nomeGenero", novoGenero.nomeGenero);

                    cmd.ExecuteNonQuery();


                }
            }


        }

        public void Deletar(int idGenero)
        {
            using (SqlConnection con= new SqlConnection(stringConexao))
            {
                string queryDelete = "delete from GENERO where idGenero = @idgenero";
                

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idgenero", idGenero);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }

            }


        }

        public List<GeneroDomain> ListarTodos()
        {
            List<GeneroDomain> listaGeneros = new List<GeneroDomain>();

            using (SqlConnection con= new SqlConnection(stringConexao))
            {
                string querySelectAll = "select idGenero, nomeGenero from GENERO";
                con.Open();

                SqlDataReader rdr;

                using(SqlCommand cmd= new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain()
                        {
                            idGenero = Convert.ToInt32(rdr[0]),
                            nomeGenero = rdr[1].ToString()
                        };
                        listaGeneros.Add(genero);
                    }
                }
            }

            return listaGeneros;
        }
    }
}
