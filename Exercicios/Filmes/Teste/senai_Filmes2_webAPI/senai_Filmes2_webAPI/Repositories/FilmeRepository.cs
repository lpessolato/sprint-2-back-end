using senai_Filmes2_webAPI.Domains;
using senai_Filmes2_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Filmes2_webAPI.Repositories
{
    public class FilmeRepository : IFilmeRepository

    {
        private string stringConexao = @"Data Source=NOTE0113H3\SQLEXPRESS; initial catalog=CATALOGO; User Id=sa; pwd=Senai@132;";
        public void Cadastrar(FilmeDomain novoFilme)
        {
            throw new NotImplementedException();
        }

        public List<FilmeDomain> ListarFilmes()
        {
            List<FilmeDomain> listaFilme = new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string querySelectAll = "select idGenero, tituloFilme from FILMES";
                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd= new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain()
                        {
                            idGenero = Convert.ToInt32(rdr[0]),
                            tituloFilme = rdr[1].ToString()

                        };
                        listaFilme.Add(filme);
                    }


                }
            }



            return listaFilme;
        }
    }
}
