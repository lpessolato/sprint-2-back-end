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

        public void Cadastrar(GeneroDomain novoGenero)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "Insert into GENERO (nomeGenero) values ('" + novoGenero.nomeGenero + "')";

                con.Open();

                using (SqlCommand cmd= new SqlCommand(queryInsert, con))
                {
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
